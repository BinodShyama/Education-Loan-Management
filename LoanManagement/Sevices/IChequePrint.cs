using LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutById;
using LoanManagement.Helpers.Extensions;
using LoanManagement.ViewModel.Cheque;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Sevices
{

    public interface IChequePrint
    {
        Task<ResponseModel<string>> Print(string layoutId, ChequeDataDto data);
        ResponseModel<string> Print(ChequeLayoutDto layout, ChequeDataDto data);
    }
    public class ChequePrint : IChequePrint
    {
        private readonly IMediator _mediator;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ChequePrint(IMediator mediator, IHostingEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<ResponseModel<string>> Print(string layoutId, ChequeDataDto data)
        {
            try
            {
                var layout = await _mediator.Send(new GetChequeLayoutByIdQuery { id = layoutId });
                return Print(layout, data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<string>() { Status=false, Messages= new List<string>() { "Fail to generate cheque."},Data ="" };
            }

        }

        public ResponseModel<string> Print(ChequeLayoutDto layout, ChequeDataDto data)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                //page.Size = PdfSharpCore.PageSize.Undefined;
                page.Height = XUnit.FromCentimeter(layout.Height);
                page.Width = XUnit.FromCentimeter(layout.Width);
                XFont font = new XFont("Arial", 12);
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Get the size (in point) of the text
                XSize size = gfx.MeasureString("**One Lakh fifty thousand**", font);

                XTextFormatter tf = new XTextFormatter(gfx);
                var x1 = layout.XDate * 0.393701;
                var x2 = x1 + .25;
                var x3 = x2 + .25;
                var x4 = x3 + .25;
                var x5 = x4 + .25;
                var x6 = x5 + .25;
                var x7 = x6 + .25;
                var x8 = x7 + .25;

                XRect rectDate1 = new XRect(XUnit.FromInch(x1), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate2 = new XRect(XUnit.FromInch(x2), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate3 = new XRect(XUnit.FromInch(x3), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate4 = new XRect(XUnit.FromInch(x4), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate5 = new XRect(XUnit.FromInch(x5), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate6 = new XRect(XUnit.FromInch(x6), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate7 = new XRect(XUnit.FromInch(x7), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));
                XRect rectDate8 = new XRect(XUnit.FromInch(x8), XUnit.FromCentimeter(layout.YDate), XUnit.FromInch(.25), XUnit.FromInch(.375));

                tf.Alignment = XParagraphAlignment.Center;
                var date = data.Date.Split("-");
                var year = date[0];
                var month = date[1];
                var day = date[2];
                tf.DrawString(day.ToList()[0].ToString(), font, XBrushes.Black, rectDate1, XStringFormats.TopLeft);
                tf.DrawString(day.ToList()[1].ToString(), font, XBrushes.Black, rectDate2, XStringFormats.TopLeft);
                tf.DrawString(month.ToList()[0].ToString(), font, XBrushes.Black, rectDate3, XStringFormats.TopLeft);
                tf.DrawString(month.ToList()[1].ToString(), font, XBrushes.Black, rectDate4, XStringFormats.TopLeft);
                tf.DrawString(year.ToList()[0].ToString(), font, XBrushes.Black, rectDate5, XStringFormats.TopLeft);
                tf.DrawString(year.ToList()[1].ToString(), font, XBrushes.Black, rectDate6, XStringFormats.TopLeft);
                tf.DrawString(year.ToList()[2].ToString(), font, XBrushes.Black, rectDate7, XStringFormats.TopLeft);
                tf.DrawString(year.ToList()[3].ToString(), font, XBrushes.Black, rectDate8, XStringFormats.TopLeft);

                // gfx.DrawString("2 2 0 4 2 0 7 9", font, XBrushes.Black, new XPoint(XUnit.FromCentimeter(layout.XDate), XUnit.FromCentimeter(layout.YDate)));

                gfx.DrawString($"**{data.Payee}**", font, XBrushes.Black, new XPoint(XUnit.FromCentimeter(layout.XPayee), XUnit.FromCentimeter(layout.YPayee)));

                gfx.DrawString($"**{data.Amount}**", font, XBrushes.Black, new XPoint(XUnit.FromCentimeter(layout.XAmount), XUnit.FromCentimeter(layout.YAmount)));

                XRect rect = new XRect(XUnit.FromCentimeter(layout.XAmountInWordLine1), XUnit.FromCentimeter(layout.YAmountInWordLine1), XUnit.FromCentimeter(10), XUnit.FromCentimeter(1.3));

                tf.Alignment = XParagraphAlignment.Center;
                tf.DrawString($"**{data.AmountInWord}**", font, XBrushes.Black, rect, XStringFormats.TopLeft);

                string filename = Guid.NewGuid() + "." + "pdf";
                string folderpath = _hostingEnvironment.ContentRootPath;
                System.IO.Directory.CreateDirectory($"{folderpath}\\wwwroot\\cheques");
                string filepath = $"{folderpath}\\wwwroot\\cheques\\{filename}";
                document.Save(filepath);
                return new ResponseModel<string>() { Status = true, Messages = new List<string>() { "Successcully generated pdf." }, Data = $"{filename}" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<string>() { Status = false, Messages = new List<string>() { "Fail to generate cheque." }, Data = "" };
            }
        }
    }
}
