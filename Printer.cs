using System;

namespace UnderscoreParser
{
    public class Printer
    {
        public void PrintResult(int cantidadArchivos)
        {
            string resultado = "";
            
            if(cantidadArchivos == 1)
            {
                resultado = "Se quitaron guiones bajos de {0} archivo.";
            }
            else if(cantidadArchivos > 1)
            {
                resultado = "Se quitaron guiones bajos de {0} archivos.";
            }
            else 
            {
                resultado = "No se quitaron guiones bajos.";
            }

            Console.WriteLine("");
            Console.WriteLine(String.Format(resultado, cantidadArchivos));
            Logger logger = Logger.GetInstance();
            logger.AccumulateTextToLog("");
            logger.AccumulateTextToLog(String.Format(resultado, cantidadArchivos));
        }

        public void Print(string text) {
            Console.Write(text);
        }

        public void PrintLine(string text) {
            Console.WriteLine(text);
        }

        public string ReadLine() {
            return Console.ReadLine();
        }
    }
}