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
            byte[] xStationNewFirmwareTest = [ 
                51, 55, 51, 51, 51, 54, 51,
                56, 51, 57, 51, 57, 51, 48, 
                51, 56, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0 ];

             byte[] xStationNewScanDataTest = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x55, 0x51, 0x54, 0x56,
                0x57, 0x57, 0x48, 0x56 ];

            byte[] hexByteList = [ 
                0x33, 0x37, 0x33, 0x33, 0x33, 0x36, 0x33,
                0x38, 0x33, 0x39, 0x33, 0x39, 0x33, 0x30, 
                0x33, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            byte[] hexScanByteList = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x37, 0x33, 0x36, 0x38,
                0x39, 0x39, 0x30, 0x38 ];

            byte[] xStationNewFirmwareTest2 = [ 
                0x52, 0x52, 0x52, 0x50, 0x51, 0x54, 0x51,
                0x55, 0x52, 0x52, 0x52, 0x54, 0x51, 0x54, 
                0x52, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            byte[] hexByteList2 = [ 
                0x34, 0x34, 0x34, 0x32, 0x33, 0x36, 0x33,
                0x37, 0x34, 0x34, 0x34, 0x36, 0x33, 0x36, 
                0x34, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            var hexStringtest = Convert.ToBase64String(xStationNewFirmwareTest);

            _logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", hexStringtest));

            var test = Convert.FromBase64String(_cardConverter.CardConverter("SH.GOV.64.BS2V2", "0000000073689908"));

            byte[] xStationNewFirmware = [ 
                0x51, 0x55, 0x51, 0x51, 0x51, 0x54, 0x51,
                0x56, 0x51, 0x57, 0x51, 0x57, 0x51, 0x48, 
                0x51, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            byte[] xStationOldFirmware = [
                0x51, 0x52, 0x53, 0x55, 0x53, 0x56, 0x55,
                0x52, 0x55, 0x50, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00];

            byte[] xPassStandardFirmware = [
                0x51, 0x52, 0x53, 0x55, 0x53, 0x56, 0x55,
                0x52, 0x55, 0x50, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            byte[] xPassOldFirmware = [
                0x51, 0x55, 0x51, 0x51, 0x51, 0x54, 0x51,
                0x56, 0x51, 0x57, 0x51, 0x57, 0x51, 0x48, 
                0x51, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00 ];

            byte[] xStationNewScanData = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x55, 0x51, 0x54, 0x56,
                0x57, 0x57, 0x48, 0x56 ];

            string xStationNewScanDataHex = "00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-37-33-36-38-39-39-30-38";

            byte[] xStationOldScanData = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0xCE, 0x16, 0x99, 0x10 ];

            string xStationOldScanDataHex = "00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-CE-16-99-10";
            

            byte[] xPassStandardScanData = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0xCE, 0x16, 0x99, 0x10 ];

            byte[] xPassOldScanData = [
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x55, 0x51, 0x54, 0x56,
                0x57, 0x57, 0x48, 0x56 ];

            string xPassOldScanDataHex = "00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-37-33-36-38-39-39-30-38";

            #region Test
            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", Convert.ToBase64String(xStationNewFirmware)));

            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xStationNewBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xStationOldBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xPassBase64));

            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xStationOldScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xPassScanBase64));

            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xStationNewBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xStationOldBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xPassBase64));

            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xStationOldScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xPassScanBase64));


            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", Convert.ToBase64String(expected)));

            //_logger.LogInformation(Convert.ToBase64String(expected));

            //_logger.LogInformation(_cardConverter.CardConverter("SHBTYPE34MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SH.HID.STD.26MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE32MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SH.CTD.68MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SH.HID.CTD.37MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("ICLASS26MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SHTYPE35MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SHTYPE80MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE34MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE32BS2MSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHPARITYMSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-STANDARD-WITHOUTPARITYMSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHPARITYMSG", xStationNewScanBase64));
            //_logger.LogInformation(_cardConverter.CardConverter("MIFARE-REVERSE-WITHOUTPARITYMSG", xStationNewScanBase64));

            //byte[] expected = {
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //    0x35, 0x38, 0x41, 0x38, 0x39, 0x45, 0x46, 0x41 };

            //var cardNo = "0000000058A89EFA";
            

            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2", cardNo));

            //_logger.LogInformation(Convert.ToBase64String(expected));

            //byte[] cardBytes = {
            //    0x33, 0x35, 0x33, 0x38, 0x34, 0x31, 0x33, 0x38,
            //    0x33, 0x39, 0x34, 0x35, 0x34, 0x36, 0x34, 0x31,
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            //_logger.LogInformation(_cardConverter.CardConverter("SH.GOV.64.BS2V2MSG", Convert.ToBase64String(cardBytes)));

            //_logger.LogInformation(Convert.ToBase64String(cardBytes));


            //var convertCardNo = CSHGov64BS2V2(cardNo);
            //_logger.LogInformation("{CSHGov64BS2V2}", convertCardNo);

            //var bytes = Convert.FromBase64String("MzEzNzM0MzAzMTMwMzgzMDM3MzcAAAAAAAAAAAAAAAA=");
            //_logger.LogInformation("{CSHGov64BS2V2MSG}", CSHGov64BS2V2MSG(Convert.ToBase64String(bytes)));

            #endregion
        }


        public byte[] ByteArrayToHexByteArray(byte[] bytes)
        {
            bytes.Where(b => b.Equals(0x00)).ToList().ForEach(b => b = Convert.ToByte(Convert.ToString(b, 16)));

            return bytes;
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

        public string BSToMifare(string cardByte)
        {
            byte[] asciiCardBytes = Convert.FromBase64String(cardByte);

            var cardInt =
                Convert.ToUInt32(Encoding.ASCII.GetString(asciiCardBytes).Replace("\0", string.Empty));

            byte[] bytes = BitConverter.GetBytes(cardInt);

            Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0).ToString().PadLeft(10, '0');
        }

        public string MifareToBS(string cardNo)
        {
            byte[] arr = BitConverter.GetBytes(Convert.ToUInt32(cardNo));

            var newArray = new byte[32]
            {
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, arr[0], arr[1], arr[2], arr[3],
            };
            return Convert.ToBase64String(newArray, 0, 32);
        }

        public string BSToGovernment(string cardByte)
        {
            byte[] asciiBytes = Convert.FromBase64String(cardByte);
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

        public string GovernmentToBS(string cardNo)
        {
            var trimData = cardNo.TrimStart(new Char[] { '0' });
            List<byte> byteList = new List<byte>();
            foreach (var c in trimData)
            {
                byteList.Add(Convert.ToByte(c));
            }

            byte[] cardDataToApply = new byte[32];

            Array.Copy(byteList.ToArray(), 0, cardDataToApply, 32 - byteList.Count, byteList.Count);

            return Convert.ToBase64String(cardDataToApply, 0, 32);
        }
    }
}
