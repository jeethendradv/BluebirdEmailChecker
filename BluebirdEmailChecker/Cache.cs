using System.IO;
using System.Reflection;

namespace BluebirdEmailChecker
{
    public static class Cache
    {
        private const string CACHE_FILENAME = "RegisteredEmailCache.txt"; 

        public static void Add(string email)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + CACHE_FILENAME;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(email);
            }
        }

        public static bool Exists(string email)
        {
            bool exists = false;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + CACHE_FILENAME;
            using (StreamReader sw = new StreamReader(path))
            {
                string cachedEmail;
                while ((cachedEmail = sw.ReadLine()) != null)
                {
                    if (cachedEmail.ToLower() == email.ToLower())
                    {
                        exists = true;
                        break;
                    }
                }
            }
            return exists;
        }
    }
}
