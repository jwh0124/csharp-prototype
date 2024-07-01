// See https://aka.ms/new-console-template for more information
using A2FC_Compete;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

const string APPLICATION_NAME = "A2FC";
string[] Scopes = [SheetsService.Scope.Spreadsheets];

GoogleCredential credential;
using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
{
    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
}

SheetsService sheetService = new(new BaseClientService.Initializer()
{
    HttpClientInitializer = credential,
    ApplicationName = APPLICATION_NAME
});

Console.Write("Match Date : ");
string? matchDate = Console.ReadLine();
Console.Write("Game attendees :");
string? gameAttendees = Console.ReadLine();
string[] gameAttendeesList = gameAttendees!.Split(',');
const string SPREADSHEET_ID = "1Jph1ZFo4PldgaBD1VtATVx188QFRkO135HYbvGA6B3U";
const string MATCH_SHEET_NAME = "경기이력";
const string MATCH_HISTORY_SHEET_NAME = "참석이력";

if (matchDate != null && gameAttendeesList.Length > 0) {
    SpreadsheetsResource.ValuesResource _googleSheetValues = sheetService.Spreadsheets.Values;

    var matchrange = $"{MATCH_SHEET_NAME}!B:B";
    var appendMatchRequest = _googleSheetValues.Append(new ValueRange { Values = MapToMatchRangeData(matchDate) }, SPREADSHEET_ID, matchrange);
    appendMatchRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
    var matchInsertResult = appendMatchRequest.Execute();
    if (matchInsertResult.Updates.UpdatedRows > 0)
    {
        Console.WriteLine($"경기 진행 일자 추가 완료 : {matchDate}", matchDate);
    }

    foreach (var user in gameAttendeesList)
    {
        var matchdHisory = new CompeteHistory { Date = matchDate, Name = user.Trim() };
        var matchHistoryrange = $"{MATCH_HISTORY_SHEET_NAME}!B:C";

        var appendRequest = _googleSheetValues.Append(new ValueRange { Values = MapToMatchHistoryRangeData(matchdHisory) }, SPREADSHEET_ID, matchHistoryrange);
        appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
        var result = appendRequest.Execute();
        if(result.Updates.UpdatedRows > 0)
        {
            Console.WriteLine($"참석자 추가 완료 : {user}", user);
        }
    }
}

static IList<IList<object>> MapToMatchRangeData(string match)
{
    var objectList = new List<object>() { match };
    var rangeData = new List<IList<object>> { objectList };
    return rangeData;
}

static IList<IList<object>> MapToMatchHistoryRangeData(CompeteHistory competeHistory)
{
    var objectList = new List<object>() { competeHistory.Date, competeHistory.Name };
    var rangeData = new List<IList<object>> { objectList };
    return rangeData;
}