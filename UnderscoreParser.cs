using System;

namespace UnderscoreParser
{
    class UnderscoreParser
    {
        static Logger logger;

        static void Main(string[] args)
        {
            Printer printer = new Printer();
            
            try
            {
                Parser parser = new Parser();
                logger = Logger.GetInstance();
                int cantidadArchivos = 0;
                bool modificado = false;
                bool preguntarPorLog = true;
                string guardarLog = string.Empty;
                printer.Log("Uderscore Parser\n© Todos los derechos reservados");
                logger.AccumulateTextToLog("Uderscore Parser\n© Todos los derechos reservados");
                
                if(args.Length > 0) {
                    printer.Log("");
                    logger.AccumulateTextToLog("");
                    printer.Log(string.Format("Lista de Archivos recibidos: \n{0}", string.Join("\n", args)));
                    logger.AccumulateTextToLog(string.Format("Lista de Archivos recibidos: \n{0}", string.Join("\n", args)));

                    foreach(string filepath in args) 
                    {
                        modificado = false;
                        parser.ParseFileName(filepath, out modificado);
                        if(modificado)
                        {
                            cantidadArchivos++;
                        }
                    }
                }

                printer.Log("");
                printer.PrintResultado(cantidadArchivos);
                
                do
                {
                    printer.Log("");
                    printer.Log(" ------------------------------");
                    printer.Log("| ¿Desea guardar el Log? (S/N) |");
                    printer.Log("| (Default is N)               |");
                    printer.Log(" ------------------------------");
                    guardarLog = Console.ReadLine().ToUpper();

                    switch(guardarLog)
                    {
                        case "S":
                            logger.LogAccumulated();
                            preguntarPorLog = false;
                            break;
                        case "":
                        case "N":
                            preguntarPorLog = false;
                            break;
                        default:
                            break;
                    }

                } while(preguntarPorLog);

                printer.Log("");
                printer.Log("Presione una telca para continuar...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                printer.Log("Ocurrió un error inesperado");
                printer.Log(string.Format("Message: {0}", e.Message));
                printer.Log(string.Format("StackTrace: {0}", e.StackTrace));
                printer.Log("");
                printer.Log("Presione una telca para continuar...");
                Console.ReadKey();
            }
        }
    }
}