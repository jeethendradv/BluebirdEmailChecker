using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BluebirdEmailChecker
{
    public class EmailAddressReader
    {
        private const string EMAIL_LIST_FILENAME = "EmailList.txt";

        public List<string> GetEmailAddresses()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), EMAIL_LIST_FILENAME);
            return readFile(path);
        }

        public List<string> GetEmailAddresses(string path)
        {
            return readFile(path);
        }

        private List<string> readFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines.Select(l => l.Trim()).Distinct().ToList();
        }
    }
}
