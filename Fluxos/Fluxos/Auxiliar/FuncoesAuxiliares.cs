using PdfToImage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxos.Auxiliar
{
    class FuncoesAuxiliares
    {


        public static bool ConvertSingleImage(string filename, string pPastaAtualApresentacao)
        {
            bool Converted = false;
            //Setup the converter
            //if (numericThreads.Value > 0)
            //    converter.RenderingThreads = (int)numericThreads.Value;

            //if (((int)numericTextSampling.Value > 0) && ((int)numericTextSampling.Value != 3))
            //    converter.TextAlphaBit = (int)numericTextSampling.Value;

            //if (((int)numericGraphSampling.Value > 0) && ((int)numericGraphSampling.Value != 3))
            //    converter.TextAlphaBit = (int)numericGraphSampling.Value;

            PDFConvert converter = new PDFConvert();

            converter.OutputToMultipleFile = true;
            converter.FirstPageToConvert = 0;
            converter.LastPageToConvert = 100;
            converter.FitPage = true;
            converter.JPEGQuality = 100;
            converter.OutputFormat = "png16m";
            System.IO.FileInfo input = new FileInfo(filename);


            //string output = string.Format("{0}\\{1}{2}", input.Directory, input.Name, ".png");
            string output = string.Format("{0}\\{1}{2}", pPastaAtualApresentacao, input.Name, ".png");

            //If the output file exist alrady be sure to add a random name at the end until is unique!
            while (File.Exists(output))
            {
                output = output.Replace(".png", string.Format("{1}{0}", ".png", DateTime.Now.Ticks));
            }
            //Just avoid this code, isn't working yet
            //if (checkRedirect.Checked)
            //{
            //    Image newImage = converter.Convert(input.FullName);
            //    Converted = (newImage != null);
            //    if (Converted)
            //        pictureOutput.Image = newImage;
            //}
            //else 
            Converted = converter.Convert(input.FullName, output);
            //txtArguments.Text = converter.ParametersUsed;

            return Converted;

            //if (Converted)
            //{
            //    renomeiaArquivos(pPastaAtualApresentacao);
                //lblInfo.Text = string.Format("{0}:File converted!", DateTime.Now.ToShortTimeString());
                //txtArguments.ForeColor = Color.Black;
            //}
            //else
            //{
                //lblInfo.Text = string.Format("{0}:File NOT converted! Check Args!", DateTime.Now.ToShortTimeString());
                //txtArguments.ForeColor = Color.Red;
            //}
        }
    }
}
