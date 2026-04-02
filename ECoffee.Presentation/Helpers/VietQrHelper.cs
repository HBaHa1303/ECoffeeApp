using QRCoder;
using System.Drawing;

namespace ECoffee.Presentation.Helpers
{
    public static class VietQrHelper
    {
        public static Bitmap GenerateQrBitmap(string bankName, string accountNo, string accountName, decimal amount, string content)
        {
            var payload = $"BANK={bankName};ACC={accountNo};NAME={accountName};AMOUNT={amount:0};CONTENT={content}";
            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            using var qr = new QRCode(data);
            return qr.GetGraphic(20);
        }
    }
}
