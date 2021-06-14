using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using StampWatermarkEntity;
using StampWatermarkEntity.Models;
using DrawingImage = System.Drawing.Image;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace StampWatermakService.Business
{
    public class StampWatermarkText
    {

        #region ManipulatePdf
        public Task<byte[]> ManipulatePdf(
            StampSimple fileSource)
        {

            using MemoryStream pdfDest = new();
            using MemoryStream pdfStream = new(fileSource.ImageSource);
            var pdfDoc = new PdfDocument(new PdfReader(pdfStream), new PdfWriter(pdfDest));
            var doc = new Document(pdfDoc);

            foreach (TextProperties text in fileSource.Texts)
            {
                var font = PdfFontFactory.CreateFont(FontProgramFactory.CreateFont(text.FontName));

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

                var paragraph = new Paragraph(text.Text).SetFont(font).SetFontSize(text.FontSize).SetFontColor(fontColor);

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

            return  Task.FromResult(pdfDest.ToArray());
        }
        #endregion

        #region DrawTextToImage
        /// <summary>
        /// Converting text to image (png).
        /// </summary>
        /// <param name="text">text to convert</param>
        /// <param name="font">Font to use</param>
        /// <param name="textColor">text color</param>
        /// <param name="maxWidth">max width of the image</param>
        /// <param name="path">path to save the image</param>
        public void DrawText(String text, Font font, System.Drawing.Color textColor, int maxWidth, String path)
        {
            //first, create a dummy bitmap just to get a graphics object
            DrawingImage img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font, maxWidth);

            //set the stringformat flags to rtl
            StringFormat sf = new StringFormat();
            //uncomment the next line for right to left languages
            //sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            sf.Trimming = StringTrimming.Word;
            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);
            //Adjust for high quality
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            //paint the background
            drawing.Clear(System.Drawing.Color.Transparent);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();
            img.Save(path, ImageFormat.Png);
            img.Dispose();

        }
        #endregion

    }
}
