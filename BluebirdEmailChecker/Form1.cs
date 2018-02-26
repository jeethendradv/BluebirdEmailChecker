using BluebirdEmailChecker.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace BluebirdEmailChecker
{
    public partial class Form1 : Form
    {
        BluebirdEmailValidator validator;
        
        int emailsProcessed = 0;
        int emailsRegistered = 0;
        int emailsNonRegistered = 0;
        delegate void StringArgReturningVoidDelegate(string text);
        delegate void EnableButtonDelegate(bool enabled);

        private void setEnabledFileSelection(bool enabled)
        {
            if (this.btnSelectFile.InvokeRequired)
            {
                EnableButtonDelegate d = new EnableButtonDelegate(setEnabledFileSelection);
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.btnSelectFile.Enabled = enabled;
            }
        }
        private void setEnabledForValidateButton(bool enabled)
        {
            if (this.btnValidate.InvokeRequired)
            {
                EnableButtonDelegate d = new EnableButtonDelegate(setEnabledForValidateButton);
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.btnValidate.Enabled = enabled;
            }
        }
        private void setEmailsToProcessText(string text)
        {
            if (this.lblEmailsToProcess.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setEmailsToProcessText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblEmailsToProcess.Text = text;
            }
        }
        private void setEmailsProcessedText(string text)
        {
            if (this.lblEmailsProcessed.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setEmailsProcessedText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblEmailsProcessed.Text = text;
            }
        }
        private void setEmailsRegisteredText(string text)
        {
            if (this.lblEmailsRegistered.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setEmailsRegisteredText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblEmailsRegistered.Text = text;
            }
        }
        private void setEmailsNonRegisteredText(string text)
        {
            if (this.lblEmailsNotRegistered.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setEmailsNonRegisteredText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblEmailsNotRegistered.Text = text;
            }
        }

        private void setEmailText(string text)
        {
            if (this.lblEmail.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setEmailText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblEmail.Text = text;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFilePath.Text = openTextFileDialog.FileName;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            this.btnValidate.Enabled = false;
            this.btnSelectFile.Enabled = false;
            var th = new Thread(() =>
            {
                validate();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void validate()
        {
            if (string.IsNullOrEmpty(openTextFileDialog.FileName))
            {
                displayErrorMessage("Please select the file");
            }
            
            try
            {
                this.setEnabledFileSelection(false);
                this.setEnabledForValidateButton(false);
                OutputWriter output = new OutputWriter();
                EmailAddressReader reader = new EmailAddressReader();
                List<string> emailAddresses = reader.GetEmailAddresses(openTextFileDialog.FileName);
                setEmailsToProcessText(emailAddresses.Count.ToString());
                validator = new BluebirdEmailValidator();
                foreach (var email in emailAddresses)
                {
                    setEmailText(email);
                    if (!Cache.Exists(email))
                    {
                        bool isValid = validator.IsValid(email);
                        if (isValid)
                        {
                            output.WriteRegisteredEmail(email);
                            emailsRegistered = emailsRegistered + 1;
                            setEmailsRegisteredText(emailsRegistered.ToString());
                            Cache.Add(email);
                        }
                        else
                        {
                            output.WriteNonRegisteredEmail(email);
                            emailsNonRegistered = emailsNonRegistered + 1;
                            setEmailsNonRegisteredText(emailsNonRegistered.ToString());
                        }
                    }
                    else
                    {
                        output.WriteRegisteredEmail(email);
                        emailsRegistered = emailsRegistered + 1;
                        setEmailsRegisteredText(emailsRegistered.ToString());
                    }
                    emailsProcessed = emailsProcessed + 1;
                    setEmailsProcessedText(emailsProcessed.ToString());
                }

                if (emailsProcessed == emailAddresses.Count)
                {
                    MessageBox.Show("Email Addresses processed successfully");
                }
            }
            catch (OpenAccountNavigationException ex)
            {
                displayErrorMessage(ex.Message);
            }
            catch (AccountFormFieldException ex)
            {
                displayErrorMessage(ex.Message);
            }
            catch (OutputPathException ex)
            {
                displayErrorMessage(ex.Message);
            }
            catch(ValidationLimitExceededException ex)
            {
                displayErrorMessage(ex.Message);
            }
            catch (Exception ex)
            {
                displayErrorMessage(ex.Message);
                LogWriter.Write(ex.Message);
                LogWriter.Write(ex.StackTrace);
            }
            finally
            {
                validator.Close();
                this.setEnabledFileSelection(true);
                this.setEnabledForValidateButton(true);
            }
        }

        private void displayErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validator != null)
            {
                validator.Close();
            }
        }
    }
}
