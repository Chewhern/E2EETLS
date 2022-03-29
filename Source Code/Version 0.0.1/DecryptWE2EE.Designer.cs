
namespace E2EETLS
{
    partial class DecryptWE2EE
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
            this.FileSizeTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.E2EESessionFolderCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OriginalFileNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RachetCountTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DecryptionProgressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SymmetricEncryptionAlgorithmGB = new System.Windows.Forms.GroupBox();
            this.AES256GCMRB = new System.Windows.Forms.RadioButton();
            this.XChaCha20Poly1305RB = new System.Windows.Forms.RadioButton();
            this.DefaultRB = new System.Windows.Forms.RadioButton();
            this.DecryptBTN = new System.Windows.Forms.Button();
            this.ChooseFileBTN = new System.Windows.Forms.Button();
            this.EncryptedFileChooserDialog = new System.Windows.Forms.OpenFileDialog();
            this.DecryptedFilesFolderChooserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SymmetricEncryptionAlgorithmGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSizeTB
            // 
            this.FileSizeTB.Location = new System.Drawing.Point(17, 182);
            this.FileSizeTB.Multiline = true;
            this.FileSizeTB.Name = "FileSizeTB";
            this.FileSizeTB.ReadOnly = true;
            this.FileSizeTB.Size = new System.Drawing.Size(224, 28);
            this.FileSizeTB.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 48;
            this.label8.Text = "File Size";
            // 
            // E2EESessionFolderCB
            // 
            this.E2EESessionFolderCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.E2EESessionFolderCB.FormattingEnabled = true;
            this.E2EESessionFolderCB.Location = new System.Drawing.Point(17, 46);
            this.E2EESessionFolderCB.Name = "E2EESessionFolderCB";
            this.E2EESessionFolderCB.Size = new System.Drawing.Size(295, 33);
            this.E2EESessionFolderCB.TabIndex = 47;
            this.E2EESessionFolderCB.SelectedIndexChanged += new System.EventHandler(this.E2EESessionFolderCB_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "Choose an established E2EE session";
            // 
            // OriginalFileNameTB
            // 
            this.OriginalFileNameTB.Location = new System.Drawing.Point(441, 210);
            this.OriginalFileNameTB.Multiline = true;
            this.OriginalFileNameTB.Name = "OriginalFileNameTB";
            this.OriginalFileNameTB.Size = new System.Drawing.Size(249, 103);
            this.OriginalFileNameTB.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 25);
            this.label6.TabIndex = 44;
            this.label6.Text = "Original File Name + Ext";
            // 
            // RachetCountTB
            // 
            this.RachetCountTB.Location = new System.Drawing.Point(441, 135);
            this.RachetCountTB.Name = "RachetCountTB";
            this.RachetCountTB.ReadOnly = true;
            this.RachetCountTB.Size = new System.Drawing.Size(249, 31);
            this.RachetCountTB.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Rachet Count";
            // 
            // DecryptionProgressBar
            // 
            this.DecryptionProgressBar.Location = new System.Drawing.Point(441, 47);
            this.DecryptionProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DecryptionProgressBar.Name = "DecryptionProgressBar";
            this.DecryptionProgressBar.Size = new System.Drawing.Size(249, 44);
            this.DecryptionProgressBar.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "Decryption Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Choose A Symmetric Encryption Algorithm";
            // 
            // SymmetricEncryptionAlgorithmGB
            // 
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.AES256GCMRB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.XChaCha20Poly1305RB);
            this.SymmetricEncryptionAlgorithmGB.Controls.Add(this.DefaultRB);
            this.SymmetricEncryptionAlgorithmGB.Location = new System.Drawing.Point(17, 245);
            this.SymmetricEncryptionAlgorithmGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Name = "SymmetricEncryptionAlgorithmGB";
            this.SymmetricEncryptionAlgorithmGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SymmetricEncryptionAlgorithmGB.Size = new System.Drawing.Size(367, 176);
            this.SymmetricEncryptionAlgorithmGB.TabIndex = 38;
            this.SymmetricEncryptionAlgorithmGB.TabStop = false;
            // 
            // AES256GCMRB
            // 
            this.AES256GCMRB.AutoSize = true;
            this.AES256GCMRB.Location = new System.Drawing.Point(5, 103);
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
            this.XChaCha20Poly1305RB.Location = new System.Drawing.Point(6, 64);
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
            this.DefaultRB.Location = new System.Drawing.Point(5, 25);
            this.DefaultRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DefaultRB.Name = "DefaultRB";
            this.DefaultRB.Size = new System.Drawing.Size(255, 29);
            this.DefaultRB.TabIndex = 0;
            this.DefaultRB.TabStop = true;
            this.DefaultRB.Text = "Default - XSalsa20Poly1305";
            this.DefaultRB.UseVisualStyleBackColor = true;
            // 
            // DecryptBTN
            // 
            this.DecryptBTN.Location = new System.Drawing.Point(16, 441);
            this.DecryptBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DecryptBTN.Name = "DecryptBTN";
            this.DecryptBTN.Size = new System.Drawing.Size(367, 68);
            this.DecryptBTN.TabIndex = 37;
            this.DecryptBTN.Text = "Decrypt";
            this.DecryptBTN.UseVisualStyleBackColor = true;
            this.DecryptBTN.Click += new System.EventHandler(this.DecryptBTN_Click);
            // 
            // ChooseFileBTN
            // 
            this.ChooseFileBTN.Location = new System.Drawing.Point(16, 90);
            this.ChooseFileBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChooseFileBTN.Name = "ChooseFileBTN";
            this.ChooseFileBTN.Size = new System.Drawing.Size(225, 59);
            this.ChooseFileBTN.TabIndex = 34;
            this.ChooseFileBTN.Text = "Choose File";
            this.ChooseFileBTN.UseVisualStyleBackColor = true;
            this.ChooseFileBTN.Click += new System.EventHandler(this.ChooseFileBTN_Click);
            // 
            // EncryptedFileChooserDialog
            // 
            this.EncryptedFileChooserDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.EncryptedFileChooserDialog_FileOk);
            // 
            // DecryptWE2EE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.FileSizeTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.E2EESessionFolderCB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.OriginalFileNameTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RachetCountTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DecryptionProgressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SymmetricEncryptionAlgorithmGB);
            this.Controls.Add(this.DecryptBTN);
            this.Controls.Add(this.ChooseFileBTN);
            this.Name = "DecryptWE2EE";
            this.Text = "DecryptWE2EE";
            this.Load += new System.EventHandler(this.DecryptWE2EE_Load);
            this.SymmetricEncryptionAlgorithmGB.ResumeLayout(false);
            this.SymmetricEncryptionAlgorithmGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileSizeTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox E2EESessionFolderCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox OriginalFileNameTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RachetCountTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar DecryptionProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox SymmetricEncryptionAlgorithmGB;
        private System.Windows.Forms.RadioButton AES256GCMRB;
        private System.Windows.Forms.RadioButton XChaCha20Poly1305RB;
        private System.Windows.Forms.RadioButton DefaultRB;
        private System.Windows.Forms.Button DecryptBTN;
        private System.Windows.Forms.Button ChooseFileBTN;
        private System.Windows.Forms.OpenFileDialog EncryptedFileChooserDialog;
        private System.Windows.Forms.FolderBrowserDialog DecryptedFilesFolderChooserDialog;
    }
}