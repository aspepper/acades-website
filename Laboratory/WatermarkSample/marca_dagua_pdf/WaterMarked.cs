using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Newtonsoft.Json.Linq;
using DrawingImage = System.Drawing.Image;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace marca_dagua_pdf
{
    public class WaterMarked
    {
        public void ManipulatePdf(
            string pdfSrc, 
            string pdfDest, 
            string text, 
            string imageName,
            float fontSize,
            string fontName)
        {
            MemoryStream pdfStream = new(File.ReadAllBytes(pdfSrc));
            PdfDocument pdfDoc = new(new PdfReader(pdfStream), new PdfWriter(pdfDest));
            Document doc = new(pdfDoc);
            PdfFont font = PdfFontFactory.CreateFont(FontProgramFactory.CreateFont(fontName));
            Paragraph paragraph = new Paragraph(text).SetFont(font).SetFontSize(fontSize).SetFontColor(iText.Kernel.Colors.ColorConstants.CYAN);

            //DrawText(text, new Font(StandardFonts.HELVETICA, 14.0f), System.Drawing.Color.Aqua, 500, IMG + imageName);
            //ImageData img = ImageDataFactory.Create(IMG + imageName);

            //float w = img.GetWidth();
            //float h = img.GetHeight();
            float radio = 20.2f;

            PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.3f);

            // Implement transformation matrix usage in order to scale image
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                PdfPage pdfPage = pdfDoc.GetPage(i);
                Rectangle pageSize = pdfPage.GetPageSize();
                float x = (pageSize.GetLeft() + pageSize.GetRight()) / 2;
                float y = (pageSize.GetTop() + pageSize.GetBottom()) / 2;
                PdfCanvas over = new PdfCanvas(pdfPage);
                over.SaveState();
                over.SetExtGState(gs1);

                //if (i % 2 == 1)
                //{
                //    doc.ShowTextAligned(paragraph, x, y-200, i, TextAlignment.CENTER, VerticalAlignment.TOP, 10);
                //    doc.ShowTextAligned(paragraph, x, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 10);
                // }
                // else
                //{
                    
                doc.ShowTextAligned(paragraph, x - 200, y + 160, i, TextAlignment.CENTER, VerticalAlignment.TOP, radio);
                doc.ShowTextAligned(paragraph, x - 100, y + 80, i, TextAlignment.CENTER, VerticalAlignment.TOP, radio);
                doc.ShowTextAligned(paragraph, x, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, radio);
                doc.ShowTextAligned(paragraph, x + 100, y - 80, i, TextAlignment.CENTER, VerticalAlignment.TOP, radio);
                doc.ShowTextAligned(paragraph, x + 200, y - 160, i, TextAlignment.CENTER, VerticalAlignment.TOP, radio);

                //over.AddImageWithTransformationMatrix(img, w, 0, 0, h, x - (w / 2), y - (h / 80), true);
                //over.AddImageWithTransformationMatrix(img, w, 0, 0, h, x - (w / 2), y - (h / 60), true);
                //over.AddImageWithTransformationMatrix(img, w, 0, 0, h, x - (w / 2), y - (h / 40), true);
                //over.AddImageWithTransformationMatrix(img, w, 0, 0, h, x - (w / 2), y - (h / 2), true);
                //}

                over.RestoreState();
            }

            doc.Close();
        }

        #region DrawTextToImage
        /// <summary>
        /// Converting text to image (png).
        /// </summary>
        /// <param name="text">text to convert</param>
        /// <param name="font">Font to use</param>
        /// <param name="textColor">text color</param>
        /// <param name="maxWidth">max width of the image</param>
        /// <param name="path">path to save the image</param>
        public static void DrawText(String text, Font font, System.Drawing.Color textColor, int maxWidth, String path)
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


