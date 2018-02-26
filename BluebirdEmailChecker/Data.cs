using BluebirdEmailChecker.Exceptions;
using System.IO;
using System.Reflection;
using System.Xml;

namespace BluebirdEmailChecker
{
    public class Data
    {
        private const string DATA_FILENAME = "Data.xml";
        public Data()
        {
            if (!File.Exists(getDataFilePath()))
            {
                throw new DataConfigFileNotFoundException();
            }
            readConfig();
        }

        public string URL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public string Line1 { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string Pin { get; set; }
        public string SecurityChallengeId { get; set; }
        public string SecurityChallengeAnswer { get; set; }
        public bool BrowserVisible { get; set; }
        public int Delay { get; set; }

        private string getDataFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DATA_FILENAME); ;
        }

        private void readConfig()
        {
            XmlDocument document = new XmlDocument();
            document.Load(getDataFilePath());
            this.URL = document.SelectSingleNode("/Config/BlueBird/Data[@name='url']").InnerText;
            this.FirstName = document.SelectSingleNode("/Config/BlueBird/Data[@name='FirstName']").InnerText;
            this.LastName = document.SelectSingleNode("/Config/BlueBird/Data[@name='LastName']").InnerText;
            this.PostCode = document.SelectSingleNode("/Config/BlueBird/Data[@name='PostCode']").InnerText;
            this.Line1 = document.SelectSingleNode("/Config/BlueBird/Data[@name='AddressLine1']").InnerText;
            this.PhoneType = document.SelectSingleNode("/Config/BlueBird/Data[@name='PhoneType']").InnerText;
            this.PhoneNumber = document.SelectSingleNode("/Config/BlueBird/Data[@name='PhoneNumber']").InnerText;
            this.UserName = document.SelectSingleNode("/Config/BlueBird/Data[@name='UserName']").InnerText;
            this.Password = document.SelectSingleNode("/Config/BlueBird/Data[@name='Password']").InnerText;
            this.DateOfBirth = document.SelectSingleNode("/Config/BlueBird/Data[@name='DateOfBirth']").InnerText;
            this.Pin = document.SelectSingleNode("/Config/BlueBird/Data[@name='Pin']").InnerText;
            this.SSN = document.SelectSingleNode("/Config/BlueBird/Data[@name='Ssn']").InnerText;
            this.SecurityChallengeId = document.SelectSingleNode("/Config/BlueBird/Data[@name='SecurityChallengeId']").InnerText;
            this.SecurityChallengeAnswer = document.SelectSingleNode("/Config/BlueBird/Data[@name='SecurityChallengeAnswer']").InnerText;
            this.BrowserVisible = bool.Parse(document.SelectSingleNode("/Config/BlueBird/Data[@name='BrowserVisible']").InnerText);
            this.Delay = int.Parse(document.SelectSingleNode("/Config/BlueBird/Data[@name='Delay']").InnerText);
        }
    }
}