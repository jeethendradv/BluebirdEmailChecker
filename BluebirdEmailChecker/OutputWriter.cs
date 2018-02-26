using BluebirdEmailChecker.Exceptions;
using System.IO;
using System.Reflection;

namespace BluebirdEmailChecker
{
    public class OutputWriter
    {
        private string basePath;

        private const string REGISTERED_EMAIL_FILENAME = "RegisteredEmails.txt";
        private const string NONREGISTERED_EMAIL_FILENAME = "NonRegisteredEmails.txt";
        private const string OUTPUT_FOLDER_NAME = @"Output\";

        public OutputWriter()
        {
            initialize();
        }

        public void WriteRegisteredEmail(string email)
        {
            string path = basePath + REGISTERED_EMAIL_FILENAME;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(email);
            }
        }

        public void WriteNonRegisteredEmail(string email)
        {
            string path = basePath + NONREGISTERED_EMAIL_FILENAME;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(email);
            }
        }

        private void initialize()
        {
            basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), OUTPUT_FOLDER_NAME);
            if (!Directory.Exists(basePath))
            {
                throw new OutputPathException();
            }

            //File.CreateText(basePath + REGISTERED_EMAIL_FILENAME).Close();
            File.CreateText(basePath + NONREGISTERED_EMAIL_FILENAME).Close();
        }
    }
}
