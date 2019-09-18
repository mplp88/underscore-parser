using System;
using System.IO;
using System.Text;

namespace UnderscoreParser
{
    public class Logger
    {
        private static Logger _logger;
        public string AccumulatedTextToLog { get; set; }
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FullPath { get; private set; }
        private bool Created = false;
        private StringBuilder _sb { get; set;}

        protected Logger()
        {
            AccumulatedTextToLog = string.Empty;
            FileName = "UnderscoreParser.log";
            FilePath = AppContext.BaseDirectory + @"Logs\";
            FullPath = FilePath + FileName;
            _sb = new StringBuilder();
        }

        public static Logger GetInstance()
        {
            if(_logger == null)
                _logger = new Logger();
            
            return _logger;
        }
        
        public void Log(string textToLog)
        {
            if(!Created) {
                CreateLogFile();
            }

            _sb.Append(textToLog);
            File.AppendAllText(FullPath, _sb.ToString());
            _sb.Clear();
        }

        public void CreateLogFile() 
        {
            Console.WriteLine("");
            Console.WriteLine(String.Format("Se guardará el log en la ruta: {0}{1}", FilePath, FileName));
            Directory.CreateDirectory(FilePath);
            using(FileStream fs = File.Create(FullPath))
            {
                byte[] data = new UTF8Encoding(true).GetBytes(string.Format("Log creado {0} \n\n", DateTime.Now));
                fs.Write(data, 0, data.Length);
            }
            Created = true;
        }

        public void AccumulateTextToLog(string text)
        {
            AccumulatedTextToLog += text + "\n";
        }

        public void LogAccumulated()
        {
            Log(AccumulatedTextToLog);
        }

        public void ClearTextToLog()
        {
            AccumulatedTextToLog = string.Empty;
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
            FullPath = FilePath + FileName;
        }
    }
}