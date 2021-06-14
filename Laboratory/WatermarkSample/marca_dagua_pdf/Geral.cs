using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StampWatermarkEntity;
using StampWatermarkEntity.Models;

namespace marca_dagua_pdf
{

    public class Geral
    {

        //public readonly String DEST = @"D:\Projetos\marca_dagua\marca_dagua_pdf\resultados\";
        public readonly string DEST = "/Users/alexsandro.pimenta/Projects/acades/acades/Laboratory/marca_dagua_pdf/resultados/";
        private readonly HttpClient client = new();


        public async Task ProcessRepositories()
        {
            FileInfo file = new(DEST);
            file.Directory.Create();

            client.BaseAddress = new Uri("https://localhost:27469/");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //string pdfSrc = @"D:\Projetos\marca_dagua\marca_dagua_pdf\documentos\7-Encarte_modalidade-Mecanico_Dedicado.pdf";
            string pdfSrc = "/Users/alexsandro.pimenta/Projects/acades/acades/Laboratory/marca_dagua_pdf/documentos/2017-Scrum-Guide-Portuguese-Brazilian.pdf";

            var filler = pdfSrc.Split("/");

            var imageDataBytes = await File.ReadAllBytesAsync(pdfSrc);

            var dataToSend = new StampSimple()
            {
                ImageSource = imageDataBytes,
                FileName = filler[filler.Length-1],
                Texts = new TextProperties[] {
                    new TextProperties() {
                        Text = "Este documento é livre e pode\nser baixado por qualquer pessoa",
                        Color = ConstantColors.Gray,
                        FontName = ConstantFonts.Heltica,
                        FontSize = 25.0f,
                        Opacity = 0.5f,
                        Radio = 5.30f,
                        PosX = 450.0f,
                        PosY = 680.0f
                    },
                    new TextProperties()
                    {
                        Text = "Este documento é livre e pode\nser baixado por qualquer pessoa",
                        Color = ConstantColors.Green,
                        FontName = ConstantFonts.Heltica,
                        FontSize = 25.0f,
                        Opacity = 0.5f,
                        Radio = 5.30f,
                        PosX = 290.0f,
                        PosY = 480.0f
                    },
                    new TextProperties()
                    {
                        Text = "Este documento é livre e pode\nser baixado por qualquer pessoa",
                        Color = ConstantColors.DarkGray,
                        FontName = ConstantFonts.Heltica,
                        FontSize = 25.0f,
                        Opacity = 0.5f,
                        Radio = 5.30f,
                        PosX = 150.0f,
                        PosY = 220.0f
                    }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(dataToSend);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            

            var result = await client.PostAsync("api/StampWatermark/StampTextsToPDF", httpContent);
            if (result.IsSuccessStatusCode)
            {
                var imageArrayByte = await result.Content.ReadAsByteArrayAsync();
                await File.WriteAllBytesAsync(DEST + filler[filler.Length - 1], imageArrayByte);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
                throw new Exception(result.ReasonPhrase);
            }

        }


    }

}
