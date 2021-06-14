using System;
using iText.IO.Font.Constants;

namespace marca_dagua_pdf
{
    class Program
    {

        public static void Main(String[] args)
        {

            new Geral().ProcessRepositories().Wait();

        }

    }
        
}
