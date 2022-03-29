
namespace E2EETLS
{
    partial class EncryptWE2EE
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
            this.PlainTextFileChooserDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFileBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SymmetricEncryptionAlgorithmGB = new System.Windows.Forms.GroupBox();
            this.AES256GCMRB = new System.Windows.Forms.RadioButton();
            this.XChaCha20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.DefaultRB = new System.Windows.Forms.RadioButton();
            this.EncryptBTN = new System.Windows.Forms.Button();
            this.EncryptionProgressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RachetCountTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E2EESessionFolderCB = new System.Windows.Forms.ComboBox();
            this.FileSizeTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EncryptedFilesFolderChooserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SymmetricEncryptionAlgorithmGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlainTextFileChooserDialog
            // 
            this.PlainTextFileChooserDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.PlainTextFileChooserDialog_FileOk);
            // 
            // ChooseFileBTN
            // 
            this.ChooseFileBTN.Location = new System.Drawing.Point(9, 86);
            this.ChooseFileBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChooseFileBTN.Name = "ChooseFileBTN";
            this.ChooseFileBTN.Size = new System.Drawing.Size(225, 59);
            this.ChooseFileBTN.TabIndex = 3;
            this.ChooseFileBTN.Text = "Choose File";
            this.ChooseFileBTN.UseVisualStyleBackColor = true;
            this.ChooseFileBTN.Click += new System.EventHandler(this.ChooseFileBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Name With Extension";
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(10, 238);
            this.FileNameTB.Multiline = true;
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.ReadOnly = true;
            this.FileNameTB.Size = new System.Drawing.Size(224, 28);
            this.FileNameTB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Choose A Symmetric Encryption Algorithm";
            // 
            // SymmetricEncryptionAlgorithmGB
            // 
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.AES256GCMRB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XChaCha20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.DefaultRB);
            this.SymmetricEncryptionAlgorithmGB.Location = new System.Drawing.Point(10, 308);
            this.SymmetricEncryptionAlgorithmGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Name = "SymmetricEncryptionAlgorithmGB";
            this.SymmetricEncryptionAlgorithmGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Size = new System.Drawing.Size(367, 176);
            this.SymmetricEncryptionAlgorithmGB.TabIndex = 20;
            this.SymmetricEncryptionAlgorithmGB.TabStop = false;
            // 
            // AES256GCMRB
            // 
            this.AES256GCMRB.AutoSize = true;
            this.AES256GCMRB.Location = new System.Drawing.Point(5, 102);
            this.AES256GCMRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AES256GCMRB.Name = "AES256GCMRB";
            this.AES256GCMRB.Size = new System.Drawing.Size(314, 54);
            this.AES256GCMRB.TabIndex = 2;
            this.AES256GCMRB.Text = "Hardware Accelerated AES256GCM\r\n(Few device supports it)";
            this.AES256GCMRB.UseVisualStyleBackColor = true;
            // 
            // XChaCha20Poly1305RB
            // 
            this.XChaCha20Poly1305RB.AutoSize = true;
            this.XChaCha20Poly1305RB.Location = new System.Drawing.Point(6, 63);
            this.XChaCha20Poly1305RB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.XChaCha20Poly1305RB.Name = "XChaCha20Poly1305RB";
            this.XChaCha20Poly1305RB.Size = new System.Drawing.Size(201, 29);
            this.XChaCha20Poly1305RB.TabIndex = 1;
            this.XChaCha20Poly1305RB.Text = "XChaCha20Poly1305";
            this.XChaCha20Poly1305RB.UseVisualStyleBackColor = true;
            // 
            // DefaultRB
            // 
            this.DefaultRB.AutoSize = true;
            this.DefaultRB.Checked = true;
            this.DefaultRB.Location = new System.Drawing.Point(5, 24);
            this.DefaultRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DefaultRB.Name = "DefaultRB";
            this.DefaultRB.Size = new System.Drawing.Size(255, 29);
            this.DefaultRB.TabIndex = 0;
            this.DefaultRB.TabStop = true;
            this.DefaultRB.Text = "Default - XSalsa20Poly1305";
            this.DefaultRB.UseVisualStyleBackColor = true;
            // 
            // EncryptBTN
            // 
            this.EncryptBTN.Location = new System.Drawing.Point(9, 504);
            this.EncryptBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EncryptBTN.Name = "EncryptBTN";
            this.EncryptBTN.Size = new System.Drawing.Size(367, 68);
            this.EncryptBTN.TabIndex = 19;
            this.EncryptBTN.Text = "Encrypt";
            this.EncryptBTN.UseVisualStyleBackColor = true;
            this.EncryptBTN.Click += new System.EventHandler(this.EncryptBTN_Click);
            // 
            // EncryptionProgressBar
            // 
            this.EncryptionProgressBar.Location = new System.Drawing.Point(434, 43);
            this.EncryptionProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EncryptionProgressBar.Name = "EncryptionProgressBar";
            this.EncryptionProgressBar.Size = new System.Drawing.Size(249, 44);
            this.EncryptionProgressBar.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Encryption Progress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Rachet Count";
            // 
            // RachetCountTB
            // 
            this.RachetCountTB.Location = new System.Drawing.Point(434, 131);
            this.RachetCountTB.Name = "RachetCountTB";
            this.RachetCountTB.ReadOnly = true;
            this.RachetCountTB.Size = new System.Drawing.Size(249, 31);
            this.RachetCountTB.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Choose an established E2EE session";
            // 
            // E2EESessionFolderCB
            // 
            this.E2EESessionFolderCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.E2EESessionFolderCB.FormattingEnabled = true;
            this.E2EESessionFolderCB.Location = new System.Drawing.Point(10, 42);
            this.E2EESessionFolderCB.Name = "E2EESessionFolderCB";
            this.E2EESessionFolderCB.Size = new System.Drawing.Size(295, 33);
            this.E2EESessionFolderCB.TabIndex = 31;
            this.E2EESessionFolderCB.SelectedIndexChanged += new System.EventHandler(this.E2EESessionFolderCB_SelectedIndexChanged);
            // 
            // FileSizeTB
            // 
            this.FileSizeTB.Location = new System.Drawing.Point(10, 178);
            this.FileSizeTB.Multiline = true;
            this.FileSizeTB.Name = "FileSizeTB";
            this.FileSizeTB.ReadOnly = true;
            this.FileSizeTB.Size = new System.Drawing.Size(224, 28);
            this.FileSizeTB.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "File Size";
            // 
            // EncryptWE2EE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 649);
            this.Controls.Add(this.FileSizeTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.E2EESessionFolderCB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RachetCountTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EncryptionProgressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SymmetricEncryptionAlgorithmGB);
            this.Controls.Add(this.EncryptBTN);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseFileBTN);
            this.Name = "EncryptWE2EE";
            this.Text = "EncryptWE2EE";
            this.Load += new System.EventHandler(this.EncryptWE2EE_Load);
            this.SymmetricEncryptionAlgorithmGB.ResumeLayout(false);
            this.SymmetricEncryptionAlgorithmGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog PlainTextFileChooserDialog;
        private System.Windows.Forms.Button ChooseFileBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox SymmetricEncryptionAlgorithmGB;
        private System.Windows.Forms.RadioButton AES256GCMRB;
        private System.Windows.Forms.RadioButton XChaCha20Poly1305RB;
        private System.Windows.Forms.RadioButton DefaultRB;
        private System.Windows.Forms.Button EncryptBTN;
        private System.Windows.Forms.ProgressBar EncryptionProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RachetCountTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox E2EESessionFolderCB;
        private System.Windows.Forms.TextBox FileSizeTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog EncryptedFilesFolderChooserDialog;
    }
}