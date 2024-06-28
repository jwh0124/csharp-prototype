﻿// See https://aka.ms/new-console-template for more information
using A2FC_Compete;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Requests.BatchRequest;
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
const string SHEET_NAME = "참석이력";

if (matchDate != null && gameAttendeesList.Length > 0) {
    SpreadsheetsResource.ValuesResource _googleSheetValues = sheetService.Spreadsheets.Values;

    foreach (var user in gameAttendeesList)
    {
        var attendHisory = new CompeteHistory { Date = matchDate, Name = user.Trim() };
        var range = $"{SHEET_NAME}!B:C";

        var appendRequest = _googleSheetValues.Append(new ValueRange { Values = MapToRangeData(attendHisory) }, SPREADSHEET_ID, range);
        appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
        var result = appendRequest.Execute();
        if(result.Updates.UpdatedRows > 0)
        {
            Console.WriteLine($"Google Sheet Data Insert Success : {user}", user);
        }
    }
}

static IList<IList<object>> MapToRangeData(CompeteHistory competeHistory)
{
    var objectList = new List<object>() { competeHistory.Date, competeHistory.Name };
    var rangeData = new List<IList<object>> { objectList };
    return rangeData;
}