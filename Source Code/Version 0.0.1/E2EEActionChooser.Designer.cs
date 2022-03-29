
namespace E2EETLS
{
    partial class E2EEActionChooser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DecryptBTN = new System.Windows.Forms.Button();
            this.EncryptBTN = new System.Windows.Forms.Button();
            this.DeleteSessionBTN = new System.Windows.Forms.Button();
            this.CheckSecurityNumberBTN = new System.Windows.Forms.Button();
            this.CreateE2EESessionBTN = new System.Windows.Forms.Button();
            this.CreateRecipientKeysBTN = new System.Windows.Forms.Button();
            this.CreateSenderKeysBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DecryptBTN
            // 
            this.DecryptBTN.Location = new System.Drawing.Point(206, 398);
            this.DecryptBTN.Name = "DecryptBTN";
            this.DecryptBTN.Size = new System.Drawing.Size(389, 61);
            this.DecryptBTN.TabIndex = 15;
            this.DecryptBTN.Text = "3. Decrypt Information/Key From E2EE file";
            this.DecryptBTN.UseVisualStyleBackColor = true;
            this.DecryptBTN.Click += new System.EventHandler(this.DecryptBTN_Click);
            // 
            // EncryptBTN
            // 
            this.EncryptBTN.Location = new System.Drawing.Point(206, 316);
            this.EncryptBTN.Name = "EncryptBTN";
            this.EncryptBTN.Size = new System.Drawing.Size(389, 61);
            this.EncryptBTN.TabIndex = 14;
            this.EncryptBTN.Text = "3. Encrypt Information/Key In Zip";
            this.EncryptBTN.UseVisualStyleBackColor = true;
            this.EncryptBTN.Click += new System.EventHandler(this.EncryptBTN_Click);
            // 
            // DeleteSessionBTN
            // 
            this.DeleteSessionBTN.Location = new System.Drawing.Point(206, 571);
            this.DeleteSessionBTN.Name = "DeleteSessionBTN";
            this.DeleteSessionBTN.Size = new System.Drawing.Size(389, 61);
            this.DeleteSessionBTN.TabIndex = 13;
            this.DeleteSessionBTN.Text = "3. Delete E2EE Session";
            this.DeleteSessionBTN.UseVisualStyleBackColor = true;
            this.DeleteSessionBTN.Click += new System.EventHandler(this.DeleteSessionBTN_Click);
            // 
            // CheckSecurityNumberBTN
            // 
            this.CheckSecurityNumberBTN.Location = new System.Drawing.Point(206, 484);
            this.CheckSecurityNumberBTN.Name = "CheckSecurityNumberBTN";
            this.CheckSecurityNumberBTN.Size = new System.Drawing.Size(389, 61);
            this.CheckSecurityNumberBTN.TabIndex = 12;
            this.CheckSecurityNumberBTN.Text = "3. Check Mutual Thumbprints";
            this.CheckSecurityNumberBTN.UseVisualStyleBackColor = true;
            this.CheckSecurityNumberBTN.Click += new System.EventHandler(this.CheckSecurityNumberBTN_Click);
            // 
            // CreateE2EESessionBTN
            // 
            this.CreateE2EESessionBTN.Location = new System.Drawing.Point(206, 231);
            this.CreateE2EESessionBTN.Name = "CreateE2EESessionBTN";
            this.CreateE2EESessionBTN.Size = new System.Drawing.Size(389, 61);
            this.CreateE2EESessionBTN.TabIndex = 11;
            this.CreateE2EESessionBTN.Text = "2. Create End To End Encryption Session";
            this.CreateE2EESessionBTN.UseVisualStyleBackColor = true;
            this.CreateE2EESessionBTN.Click += new System.EventHandler(this.CreateE2EESessionBTN_Click);
            // 
            // CreateRecipientKeysBTN
            // 
            this.CreateRecipientKeysBTN.Location = new System.Drawing.Point(206, 145);
            this.CreateRecipientKeysBTN.Name = "CreateRecipientKeysBTN";
            this.CreateRecipientKeysBTN.Size = new System.Drawing.Size(389, 61);
            this.CreateRecipientKeysBTN.TabIndex = 10;
            this.CreateRecipientKeysBTN.Text = "1. Create Recipient Keys";
            this.CreateRecipientKeysBTN.UseVisualStyleBackColor = true;
            this.CreateRecipientKeysBTN.Click += new System.EventHandler(this.CreateRecipientKeysBTN_Click);
            // 
            // CreateSenderKeysBTN
            // 
            this.CreateSenderKeysBTN.Location = new System.Drawing.Point(206, 70);
            this.CreateSenderKeysBTN.Name = "CreateSenderKeysBTN";
            this.CreateSenderKeysBTN.Size = new System.Drawing.Size(389, 57);
            this.CreateSenderKeysBTN.TabIndex = 9;
            this.CreateSenderKeysBTN.Text = "1. Create Sender Keys";
            this.CreateSenderKeysBTN.UseVisualStyleBackColor = true;
            this.CreateSenderKeysBTN.Click += new System.EventHandler(this.CreateSenderKeysBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(206, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose a button (E2EE Action)";
            // 
            // E2EEActionChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 654);
            this.Controls.Add(this.DecryptBTN);
            this.Controls.Add(this.EncryptBTN);
            this.Controls.Add(this.DeleteSessionBTN);
            this.Controls.Add(this.CheckSecurityNumberBTN);
            this.Controls.Add(this.CreateE2EESessionBTN);
            this.Controls.Add(this.CreateRecipientKeysBTN);
            this.Controls.Add(this.CreateSenderKeysBTN);
            this.Controls.Add(this.label1);
            this.Name = "E2EEActionChooser";
            this.Text = "E2EE Main Menu";
            this.Load += new System.EventHandler(this.E2EEActionChooser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DecryptBTN;
        private System.Windows.Forms.Button EncryptBTN;
        private System.Windows.Forms.Button DeleteSessionBTN;
        private System.Windows.Forms.Button CheckSecurityNumberBTN;
        private System.Windows.Forms.Button CreateE2EESessionBTN;
        private System.Windows.Forms.Button CreateRecipientKeysBTN;
        private System.Windows.Forms.Button CreateSenderKeysBTN;
        private System.Windows.Forms.Label label1;
    }
}

