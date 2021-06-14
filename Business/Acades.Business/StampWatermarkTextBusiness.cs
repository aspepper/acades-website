using System.IO;
using System.Net;
using System.Threading.Tasks;
using Acades.Dto;
using Acades.Entities;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Extensions.Configuration;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace Acades.Business
{
    public class StampWatermarkTextBusiness : BaseBusiness
    {
        private readonly IConfiguration _conf;

        public StampWatermarkTextBusiness(RepositoryContext context, IConfiguration con)
            : base(context)
        {
            this._conf = con;
        }

        public StampWatermarkTextBusiness(RepositoryContext context) : base(context) { }

        private static void ConvertToStream(string fileUrl, Stream stream)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                Stream response_stream = response.GetResponseStream();

                response_stream.CopyTo(stream, 4096);
            }
            finally
            {
                response.Close();
            }
        }

        #region ManipulatePdfFromURL
        public Task<byte[]> ManipulatePdfFromURL(
            StampSimpleDto fileSource)
        {
            using MemoryStream mem = new MemoryStream();
            ConvertToStream(fileSource.URL, mem);
            mem.Seek(0, SeekOrigin.Begin);
            fileSource.ImageSource = mem.ToArray();
            return ManipulatePdf(fileSource);
        }
        #endregion

        #region ManipulatePdf
        public Task<byte[]> ManipulatePdf(
            StampSimpleDto fileSource)
        {

            using MemoryStream pdfDest = new MemoryStream();
            using MemoryStream pdfStream = new MemoryStream(fileSource.ImageSource);
            var pdfDoc = new PdfDocument(new PdfReader(pdfStream), new PdfWriter(pdfDest));
            var doc = new Document(pdfDoc);

            foreach (TextPropertiesDto text in fileSource.Texts)
            {
                //var font = PdfFontFactory.CreateFont(FontProgramFactory.CreateFont(text.FontName));

                iText.Kernel.Colors.Color fontColor = iText.Kernel.Colors.ColorConstants.CYAN;
                switch (text.Color)
                {
                    case "WHITE": fontColor = iText.Kernel.Colors.ColorConstants.WHITE; break;
                    case "BLACK": fontColor = iText.Kernel.Colors.ColorConstants.BLACK; break;
                    case "BLUE": fontColor = iText.Kernel.Colors.ColorConstants.BLUE; break;
                    case "DARKGRAY": fontColor = iText.Kernel.Colors.ColorConstants.DARK_GRAY; break;
                    case "GRAY": fontColor = iText.Kernel.Colors.ColorConstants.GRAY; break;
                    case "GREEN": fontColor = iText.Kernel.Colors.ColorConstants.GREEN; break;
                    case "MAGENTA": fontColor = iText.Kernel.Colors.ColorConstants.MAGENTA; break;
                    case "ORANGE": fontColor = iText.Kernel.Colors.ColorConstants.ORANGE; break;
                    case "PINK": fontColor = iText.Kernel.Colors.ColorConstants.PINK; break;
                    case "RED": fontColor = iText.Kernel.Colors.ColorConstants.RED; break;
                    case "YELLOW": fontColor = iText.Kernel.Colors.ColorConstants.YELLOW; break;
                }

                PdfFont fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                try
                {
                    fonte = PdfFontFactory.CreateFont(text.FontName);
                }
                catch
                {
                    fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                }
                var paragraph = new Paragraph(text.Text).SetFont(fonte).SetFontSize(text.FontSize).SetFontColor(fontColor);

                var gs1 = new PdfExtGState().SetFillOpacity(text.Opacity);

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    PdfPage pdfPage = pdfDoc.GetPage(i);
                    Rectangle pageSize = pdfPage.GetPageSize();
                    float x = (pageSize.GetLeft() + pageSize.GetRight()) / 2;
                    float y = (pageSize.GetTop() + pageSize.GetBottom()) / 2;
                    var over = new PdfCanvas(pdfPage);
                    over.SaveState();
                    over.SetExtGState(gs1);

                    doc.ShowTextAligned(paragraph, text.PosX, text.PosY, i, TextAlignment.CENTER, VerticalAlignment.TOP, text.Radio);
                    over.RestoreState();
                }
            }

            doc.Close();

            return Task.FromResult(pdfDest.ToArray());
        }
        #endregion

    }
}
