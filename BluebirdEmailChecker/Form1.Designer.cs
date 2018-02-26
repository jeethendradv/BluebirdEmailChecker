namespace BluebirdEmailChecker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openTextFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmailsNotRegistered = new System.Windows.Forms.Label();
            this.lblEmailsRegistered = new System.Windows.Forms.Label();
            this.lblEmailsProcessed = new System.Windows.Forms.Label();
            this.lblEmailsToProcess = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openTextFileDialog
            // 
            this.openTextFileDialog.Filter = "Text|*.txt";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(160, 62);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(120, 45);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 62);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(131, 45);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 13);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(88, 13);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "No File Selected.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEmailsNotRegistered);
            this.groupBox1.Controls.Add(this.lblEmailsRegistered);
            this.groupBox1.Controls.Add(this.lblEmailsProcessed);
            this.groupBox1.Controls.Add(this.lblEmailsToProcess);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // lblEmailsNotRegistered
            // 
            this.lblEmailsNotRegistered.AutoSize = true;
            this.lblEmailsNotRegistered.Location = new System.Drawing.Point(200, 91);
            this.lblEmailsNotRegistered.Name = "lblEmailsNotRegistered";
            this.lblEmailsNotRegistered.Size = new System.Drawing.Size(13, 13);
            this.lblEmailsNotRegistered.TabIndex = 7;
            this.lblEmailsNotRegistered.Text = "0";
            // 
            // lblEmailsRegistered
            // 
            this.lblEmailsRegistered.AutoSize = true;
            this.lblEmailsRegistered.Location = new System.Drawing.Point(200, 67);
            this.lblEmailsRegistered.Name = "lblEmailsRegistered";
            this.lblEmailsRegistered.Size = new System.Drawing.Size(13, 13);
            this.lblEmailsRegistered.TabIndex = 6;
            this.lblEmailsRegistered.Text = "0";
            // 
            // lblEmailsProcessed
            // 
            this.lblEmailsProcessed.AutoSize = true;
            this.lblEmailsProcessed.Location = new System.Drawing.Point(200, 43);
            this.lblEmailsProcessed.Name = "lblEmailsProcessed";
            this.lblEmailsProcessed.Size = new System.Drawing.Size(13, 13);
            this.lblEmailsProcessed.TabIndex = 5;
            this.lblEmailsProcessed.Text = "0";
            // 
            // lblEmailsToProcess
            // 
            this.lblEmailsToProcess.AutoSize = true;
            this.lblEmailsToProcess.Location = new System.Drawing.Point(200, 20);
            this.lblEmailsToProcess.Name = "lblEmailsToProcess";
            this.lblEmailsToProcess.Size = new System.Drawing.Size(13, 13);
            this.lblEmailsToProcess.TabIndex = 4;
            this.lblEmailsToProcess.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of email\'s not registered:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of email\'s registered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of email\'s processed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of email\'s to process:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 253);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 13);
            this.lblEmail.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 277);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnValidate);
            this.Name = "Form1";
            this.Text = "Bluebird Email Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openTextFileDialog;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmailsNotRegistered;
        private System.Windows.Forms.Label lblEmailsRegistered;
        private System.Windows.Forms.Label lblEmailsProcessed;
        private System.Windows.Forms.Label lblEmailsToProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmail;
    }
}

