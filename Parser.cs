using System;
using System.IO;
using System.Linq;

namespace UnderscoreParser
{
    public class Parser
    {
        Logger logger { get; set; }

        public Parser()
        {
            logger = Logger.GetInstance();
        }

        public void ParseFileName(string filepath, out bool parseado)
        {
            Capitalizer capitalizer = new Capitalizer();
            bool capitalizado = false;
            string[] aux = new string[0];
            aux = filepath.Split('\\');
            string filename = aux[aux.Length - 1];
            aux = aux.Take(aux.Count() - 1).ToArray();
            string path = string.Join("\\", aux);
            
            aux = filename.Split('_');

            if(aux.Length > 1)
            {
                filename = string.Join(" ", aux);
                parseado = true;
            }
            else
            {   
                parseado = false;
            }
            
            filename = capitalizer.CapitalizeWords(filename, out capitalizado);
            
            if(parseado || capitalizado){
                Console.WriteLine("");
                logger.AccumulateTextToLog("");
                Console.WriteLine(string.Format("RENOMBRAR\n{0} a\n{1}\\{2}", filepath, path, filename));
                logger.AccumulateTextToLog(string.Format("RENOMBRAR\n{0} a\n{1}\\{2}", filepath, path, filename));
                File.Move(filepath, path + "\\" + filename);

            }
        }
    }
}