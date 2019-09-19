using System;
using System.IO;
using System.Text;

namespace UnderscoreParser
{
    public class Logger
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FullPath { get; private set; }

        private static Logger _logger;
        private StringBuilder _sb;
        private string AccumulatedTextToLog { get; set; }
        private Printer printer { get; set; }
        private bool FileCreated { get; set; }

        protected Logger()
        {
            AccumulatedTextToLog = string.Empty;
            FileCreated = false;
            FileName = "UnderscoreParser";
            FilePath = AppContext.BaseDirectory + @"Logs\";
            FullPath = FilePath + FileName;
            printer = new Printer();
            _sb = new StringBuilder();
        }

        // Singleton para que todos mantengan el mismo AccumulatedTextToLog.
        public static Logger GetInstance()
        {
            if(_logger == null)
                _logger = new Logger();
            
            return _logger;
        }
        
        public void Log(string textToLog)
        {
            if(!FileCreated) {
                CreateLogFile();
            }

            _sb.Append(textToLog);
            File.AppendAllText(FullPath, _sb.ToString());
            _sb.Clear();
        }

        public void CreateLogFile() 
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("Se guardará el log en la ruta: {0}", FullPath));
            Directory.CreateDirectory(FilePath);
            using(FileStream fs = File.Create(FullPath))
            {
                byte[] data = new UTF8Encoding().GetBytes(string.Format("Log creado {0} \n\n", DateTime.Now));
                fs.Write(data, 0, data.Length);
            }
            FileCreated = true;
        }

        public void AccumulateTextToLog(string text)
        {
            AccumulatedTextToLog += text + "\n";
        }

        public void ClearAccumulatedTextToLog()
        {
            AccumulatedTextToLog = string.Empty;
        }

        public void LogAccumulated()
        {
            Log(AccumulatedTextToLog);
        }

        public void AskChangeFileName()
        {
            string fileName = string.Empty;
            printer.Print("Nombre del archivo (Puede dejarse vacío): ");
            fileName = Console.ReadLine();
            if(!string.IsNullOrEmpty(fileName))
            {
                SetFileName(fileName);
            }
        }

        public void SetFileName(string fileName)
        {
            FileName = fileName;
            UpdateFullPath();
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
            UpdateFullPath();
        }

        public void UpdateFullPath()
        {
            FullPath = FilePath + FileName + ".log";
        }
    }
}