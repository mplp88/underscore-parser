using System;

namespace UnderscoreParser
{
    public class Printer
    {
        Logger logger { get; set; }

        public Printer()
        {
            logger = Logger.GetInstance();
        }

        public void PrintResultado(int cantidadArchivos)
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
            logger.AccumulateTextToLog("");
            logger.AccumulateTextToLog(String.Format(resultado, cantidadArchivos));
        }

        public void Log(string text) {
            Console.WriteLine(text);
        }
    }
}