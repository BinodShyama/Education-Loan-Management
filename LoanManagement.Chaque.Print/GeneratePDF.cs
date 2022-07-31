

using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace LoanManagement.Chaque.Print
{
    public class PDF
    {
        public void GeneratePDF()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
           
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.Undefined;
            page.Height = XUnit.FromInch(7.5);
            page.Width = XUnit.FromInch(3.5);
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 20);
            gfx.DrawString("One Lakh fifty thousand", font, XBrushes.Black,new XPoint(100, 200));
            document.Save("");
        }
      
    }
}
