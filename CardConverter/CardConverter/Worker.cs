using SHSystem.BS2.CardConverter;
using System.Text;

namespace CardConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly CCardConverter _cardConverter = new();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            byte[] expected = {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x35, 0x38, 0x41, 0x38, 0x39, 0x45, 0x46, 0x41 };

            var cardNo = "0000000058A89EFA";

            _logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2", cardNo));
            
            _logger.LogInformation(Convert.ToBase64String(expected));

            byte[] cardBytes = {
                0x33, 0x35, 0x33, 0x38, 0x34, 0x31, 0x33, 0x38,
                0x33, 0x39, 0x34, 0x35, 0x34, 0x36, 0x34, 0x31,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            _logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", Convert.ToBase64String(cardBytes)));

            _logger.LogInformation(Convert.ToBase64String(cardBytes));


            //var convertCardNo = CSHGov64BS2V2(cardNo);
            //_logger.LogInformation("{CSHGov64BS2V2}", convertCardNo);
                       
            //var bytes = Convert.FromBase64String("MzEzNzM0MzAzMTMwMzgzMDM3MzcAAAAAAAAAAAAAAAA=");
            //_logger.LogInformation("{CSHGov64BS2V2MSG}", CSHGov64BS2V2MSG(Convert.ToBase64String(bytes)));
        }

        public string CSHGov64BS2V2(string Data)
        {
            try
            {
                var trimData = Data.TrimStart(new Char[] { '0' });
                List<byte> byteList = new List<byte>();
                foreach (var c in trimData)
                {
                    byteList.Add(Convert.ToByte(c));
                }

                byte[] cardDataToApply = new byte[32];

                Array.Copy(byteList.ToArray(), 0, cardDataToApply, 32 - byteList.Count, byteList.Count);

                return Convert.ToBase64String(cardDataToApply, 0, 32);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Card Number Converting is failed " + ex.ToString());
                return "Failed";
            }
        }

        public string CSHGov64BS2V2MSG(string Data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Data))
                {
                    Console.WriteLine("CardNumber should not be empty.");
                    return "Failed";
                }

                // 아스키 변환 두번 
                // 1) 0x33, 0x30, 0x33, 0x37 
                // 2) 3037 (아스키 string 으로 변환)
                // 3) => 0x30, 0x37 ( 두자리씩 byte 로 변환)
                // 4) => 07 (아스키 string 으로 한번 더 변환)

                byte[] asciiBytes = Convert.FromBase64String(Data);
                asciiBytes.ToList().RemoveAll(c => c == 0x00);

                var asciiConvertedString = Encoding.ASCII.GetString(asciiBytes);
                List<byte> asciiAsciiBytes = new List<byte>();
                for (int i = 0; i < asciiConvertedString.Count(); i += 2)
                {
                    var sliced = Slice(asciiConvertedString, i, i + 2);
                    if (sliced == "\0\0")
                        break;

                    asciiAsciiBytes.Add(Convert.ToByte(sliced, 16));
                }

                var asciiDoubleConvertedString =
                    Encoding.ASCII.GetString(asciiAsciiBytes.ToArray()).PadLeft(16, '0');

                return asciiDoubleConvertedString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Card Number Converting is failed " + ex.ToString());
                return "Failed";
            }
        }

        public string Slice(string source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;
            return source.Substring(start, len);
        }
    }
}
