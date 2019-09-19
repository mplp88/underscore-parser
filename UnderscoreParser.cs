using System;

namespace UnderscoreParser
{
    class UnderscoreParser
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            
            try
            {
                Parser parser = new Parser();
                Logger logger = Logger.GetInstance();
                int cantidadArchivos = 0;
                bool modificado = false;
                bool preguntarPorLog = true;
                string guardarLog = string.Empty;
                printer.PrintLine("Uderscore Parser\n© Todos los derechos reservados");
                logger.AccumulateTextToLog("Uderscore Parser\n© Todos los derechos reservados");
                
                if(args.Length > 0) {
                    printer.PrintLine("");
                    logger.AccumulateTextToLog("");
                    printer.PrintLine(string.Format("Lista de Archivos recibidos: \n{0}", string.Join("\n", args)));
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

                printer.PrintLine("");
                printer.PrintResult(cantidadArchivos);
                
                do
                {
                    // Preguntar si se desea guardar el log de finalización exitosa.
                    printer.PrintLine("");
                    printer.PrintLine(" ------------------------------");
                    printer.PrintLine("| ¿Desea guardar el Log? (S/N) |");
                    printer.PrintLine("| (Por defecto N)              |");
                    printer.PrintLine(" ------------------------------");
                    guardarLog = Console.ReadLine().ToUpper();

                    switch(guardarLog)
                    {
                        case "S":
                            logger.AskChangeFileName();
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

                // Mensaje por defecto para finalizar la aplicación.
                printer.PrintLine("");
                printer.PrintLine("Presione una telca para continuar...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                // Avisar que hubo un error.
                printer.PrintLine("Ocurrió un error inesperado. Revise el log para más información");
                
                // Guardar el log del error
                Logger logger = Logger.GetInstance();
                logger.ClearAccumulatedTextToLog();
                logger.SetFileName(string.Format("{0}_error", logger.FileName));
                logger.Log("Ocurrió un error inesperado");
                logger.Log(string.Format("Message: {0}", e.Message));
                logger.Log(string.Format("StackTrace: {0}", e.StackTrace));
                
                // Mensaje por defecto para finalizar la aplicación.
                printer.PrintLine("");
                printer.PrintLine("Presione una telca para continuar...");
                Console.ReadKey();
            }
        }
    }
}