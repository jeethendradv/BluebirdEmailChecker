using System.IO;
using System.Reflection;

namespace BluebirdEmailChecker
{
    public static class LogWriter
    {
        private const string LOG_FILENAME = "Log.txt";
        private const string OUTPUT_FOLDER_NAME = @"Output\";
        static LogWriter()
        {
            initialize();
        }

        public static void Write(string message)
        {
            string basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), OUTPUT_FOLDER_NAME);
            string path = basePath + LOG_FILENAME;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }

        private static void initialize()
        {
            string baseDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), OUTPUT_FOLDER_NAME);
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            File.CreateText(baseDirectory + LOG_FILENAME).Close();
        }
    }
}
