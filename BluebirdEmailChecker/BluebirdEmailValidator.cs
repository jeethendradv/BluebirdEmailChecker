using BluebirdEmailChecker.Exceptions;
using BluebirdEmailChecker.WatinExtension;
using System;
using System.Text;
using System.Threading;
using WatiN.Core;

namespace BluebirdEmailChecker
{
    public class BluebirdEmailValidator
    {
        private IE ie;
        private string accountRegistrationUrl;
        private Data data;
        public BluebirdEmailValidator()
        {
            initialize();   
        }

        public bool IsValid(string email)
        {
            wait();
            if (!isInRegistrationPage())
            {
                navigateToRegistrationPage();
                fillAccountForm();
            }
            fillEmailAddress(email);
            fillPasswordFields();
            fillATMPinFields();
            fillUsernameField(email);
            submitForm();            
            return isRegisteredEmail();
        }

        public void Close()
        {
            ie.Close();
        }

        private void wait()
        {
            ie.WaitForComplete();
        }

        private void initialize()
        {
            data = new Data();
            ie = new IE();
            ie.ClearCookies();
            ie.ClearCache();
            ie.WaitForComplete();
            ie.Visible = data.BrowserVisible;
            accountRegistrationUrl = getOpenAccountUrl();
            navigateToRegistrationPage();
            fillAccountForm();
        }

        private bool isRegisteredEmail()
        {
            bool isRegistered = false;
            if (isInRegistrationPage())
            {
                ie = IE.AttachTo<IE>(Find.ByUrl(accountRegistrationUrl));
            }
            if (ie.ContainsText(Constants.BlueBirdConstants.ACCOUNT_EXCEEDED_MESSAGE))
            {
                throw new ValidationLimitExceededException();
            }

            List ul = ie.List(Find.BySelector(Constants.BlueBirdConstants.ERROR_ELEMENT_SELECTOR));
            if (isInRegistrationPage() && !ul.Exists)
            {                
                if (ie.ContainsText(Constants.BlueBirdConstants.EMAIL_ERROR_MESSAGE))
                {
                    isRegistered = true;
                }
            }
            else if (ul != null)
            {
                foreach (var li in ul.ListItems)
                {
                    if (li.InnerHtml.ToLower() == Constants.BlueBirdConstants.EMAIL_ERROR_MESSAGE.ToLower())
                    {
                        isRegistered = true;
                        break;
                    }
                }
            }
            
            return isRegistered;
        }

        private bool isUserNameError(string errorMessage)
        {
            return errorMessage.ToLower().Contains(Constants.BlueBirdConstants.USERNAME_ERROR_MESSAGE.ToLower());
        }

        private void fillAccountForm()
        {
            fillNameFields();
            fillAddressFields();
            fillPhoneFields();            
            fillDOBAndSSNFields();
            fillATMPinFields();
            fillSecurityQuestionFields();
            fillLineAddress();
            clickConsolidatedConsent();
        }

        private void fillNameFields()
        {
            ie.TextField(Constants.BlueBirdConstants.FIRSTNAME_ELEMENT_ID).Value = data.FirstName;
            ie.TextField(Constants.BlueBirdConstants.LASTNAME_ELEMENT_ID).Value = data.LastName;
        }

        private void fillEmailAddress(string email)
        {
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.EMAILADDRESS_ELEMENT_ID).Value = email;
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.EMAILADDRESSCONFIRM_ELEMENT_ID).Value = email;
        }

        private void fillAddressFields()
        {
            TextFieldExtended postCode = ie.ElementOfType<TextFieldExtended>(Find.ByClass(Constants.BlueBirdConstants.POSTALCODE_CLASSNAME));            
            postCode.TypeText(data.PostCode);            
            ie.RunScript(Constants.BlueBirdConstants.POSTALCODE_TRIGGER_INPUT_SCRIPT);
            Thread.Sleep(1000);
        }

        private void fillLineAddress()
        {
            IElementContainer predictiveAddress = (IElementContainer)ie.Element(Find.By(Constants.BlueBirdConstants.PREDICTIVE_ADDRESS_ATTRIBUTE, Constants.BlueBirdConstants.PREDICTIVE_ADDRESS_ATTRIBUTE_VALUE));
            predictiveAddress.TextField(Constants.BlueBirdConstants.PREDICTIVE_ADDRESS_LINE1_ELEMENT_ID).TypeText(data.Line1);
        }

        private void fillPhoneFields()
        {
            ie.SelectList(Constants.BlueBirdConstants.PHONETYPE_ELEMENT_ID).SelectByValue(data.PhoneType);
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.PHONENUMBER_ELEMENT_ID).Value = data.PhoneNumber;
        }

        private void fillUsernameField(string email)
        {
            string userName = generateUserName(email);
            ie.TextField(Constants.BlueBirdConstants.USERNAME_ELEMENT_ID).Value = removeSpecialCharacters(userName);
        }

        private void fillPasswordFields()
        {            
            ie.TextField(Constants.BlueBirdConstants.PASSWORD_ELEMENT_ID).Value = data.Password;
            ie.TextField(Constants.BlueBirdConstants.CONFIRM_PASSWORD_ELEMENT_ID).Value = data.Password;
        }

        private void fillDOBAndSSNFields()
        {
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.DATEOFBIRTH_ELEMENT_ID).Value = data.DateOfBirth;
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.SSN_ELEMENT_ID).Value = data.SSN;
        }

        private void fillATMPinFields()
        {
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.PIN_ELEMENT_ID).Value = data.Pin;
            ie.ElementOfType<TextFieldExtended>(Constants.BlueBirdConstants.CONFIRM_PIN_ELEMENT_ID).Value = data.Pin;
        }

        private void fillSecurityQuestionFields()
        {
            ie.SelectList(Constants.BlueBirdConstants.SECURITY_CHALLENGE_ELEMENT_ID).SelectByValue(data.SecurityChallengeId);
            ie.TextField(Constants.BlueBirdConstants.SECURITY_CHALLENGE_ANSWER_ELEMENT_ID).Value = data.SecurityChallengeAnswer;
        }

        private void clickConsolidatedConsent()
        {
            ie.CheckBox(Constants.BlueBirdConstants.CONSOLIDATEDCONSENT_ELEMENT_ID).Click();
        }

        private void submitForm()
        {
            ie.Button(Constants.BlueBirdConstants.SUBMITBUTTON_ELEMENT_ID).Click();            
            Thread.Sleep(data.Delay);
            ie.WaitForComplete();
        }

        private string getOpenAccountUrl()
        {
            return data.URL;
        }

        private void navigateToUrl(string url)
        {
            while (true)
            {
                ie.ClearCache();
                ie.ClearCookies();
                ie.GoTo(url);
                Thread.Sleep(6000);
                ie.WaitForComplete();             
                if (ie.Url == url)
                    break;
            }
        }

        private bool isInRegistrationPage()
        {
            return ie.Url == accountRegistrationUrl;
        }

        private void navigateToRegistrationPage()
        {
            if (!string.IsNullOrEmpty(accountRegistrationUrl))
            {
                navigateToUrl(accountRegistrationUrl);
                return;
            }
            throw new OpenAccountNavigationException();
        }

        private string removeSpecialCharacters(string str)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString() + r.Next(0, 9);
        }

        private string generateUserName(string email)
        {
            Random r = new Random();
            string str = removeSpecialCharacters(email);
            str = str.Substring(0, str.Length >= 18 ? 17 : str.Length - 1);
            return str + r.Next(0, 20);
        }
    }
}