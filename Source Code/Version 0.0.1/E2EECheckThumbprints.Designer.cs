
namespace E2EETLS
{
    partial class E2EECheckThumbprints
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
            this.E2EESessionFolderCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CheckNumbersBTN = new System.Windows.Forms.Button();
            this.SecurityNumberLabel = new System.Windows.Forms.Label();
            this.FirstDHKXNumberLabel = new System.Windows.Forms.Label();
            this.SecondDHKXNumberLabel = new System.Windows.Forms.Label();
            this.ThirdDHKXNumberLabel = new System.Windows.Forms.Label();
            this.FourthDHKXNumberLabel = new System.Windows.Forms.Label();
            this.SecurityNumberTB = new System.Windows.Forms.TextBox();
            this.FirstDHKXNumberTB = new System.Windows.Forms.TextBox();
            this.SecondDHKXNumberTB = new System.Windows.Forms.TextBox();
            this.ThirdDHKXNumberTB = new System.Windows.Forms.TextBox();
            this.FourthDHKXNumberTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // E2EESessionFolderCB
            // 
            this.E2EESessionFolderCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.E2EESessionFolderCB.FormattingEnabled = true;
            this.E2EESessionFolderCB.Location = new System.Drawing.Point(12, 38);
            this.E2EESessionFolderCB.Name = "E2EESessionFolderCB";
            this.E2EESessionFolderCB.Size = new System.Drawing.Size(295, 33);
            this.E2EESessionFolderCB.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Choose an established E2EE session";
            // 
            // CheckNumbersBTN
            // 
            this.CheckNumbersBTN.Location = new System.Drawing.Point(12, 77);
            this.CheckNumbersBTN.Name = "CheckNumbersBTN";
            this.CheckNumbersBTN.Size = new System.Drawing.Size(294, 64);
            this.CheckNumbersBTN.TabIndex = 50;
            this.CheckNumbersBTN.Text = "Check Security Numbers";
            this.CheckNumbersBTN.UseVisualStyleBackColor = true;
            this.CheckNumbersBTN.Click += new System.EventHandler(this.CheckNumbersBTN_Click);
            // 
            // SecurityNumberLabel
            // 
            this.SecurityNumberLabel.AutoSize = true;
            this.SecurityNumberLabel.Location = new System.Drawing.Point(12, 159);
            this.SecurityNumberLabel.Name = "SecurityNumberLabel";
            this.SecurityNumberLabel.Size = new System.Drawing.Size(230, 50);
            this.SecurityNumberLabel.TabIndex = 51;
            this.SecurityNumberLabel.Text = "Security Number\r\n(Your IKPK + Recipient IKPK)";
            // 
            // FirstDHKXNumberLabel
            // 
            this.FirstDHKXNumberLabel.AutoSize = true;
            this.FirstDHKXNumberLabel.Location = new System.Drawing.Point(507, 11);
            this.FirstDHKXNumberLabel.Name = "FirstDHKXNumberLabel";
            this.FirstDHKXNumberLabel.Size = new System.Drawing.Size(245, 50);
            this.FirstDHKXNumberLabel.TabIndex = 52;
            this.FirstDHKXNumberLabel.Text = "First DHKX Number\r\n(Your IKPK + Recipient SPKPK)";
            // 
            // SecondDHKXNumberLabel
            // 
            this.SecondDHKXNumberLabel.AutoSize = true;
            this.SecondDHKXNumberLabel.Location = new System.Drawing.Point(507, 174);
            this.SecondDHKXNumberLabel.Name = "SecondDHKXNumberLabel";
            this.SecondDHKXNumberLabel.Size = new System.Drawing.Size(234, 50);
            this.SecondDHKXNumberLabel.TabIndex = 53;
            this.SecondDHKXNumberLabel.Text = "Second DHKX Number\r\n(Your EKPK + Recipient IKPK)";
            // 
            // ThirdDHKXNumberLabel
            // 
            this.ThirdDHKXNumberLabel.AutoSize = true;
            this.ThirdDHKXNumberLabel.Location = new System.Drawing.Point(507, 340);
            this.ThirdDHKXNumberLabel.Name = "ThirdDHKXNumberLabel";
            this.ThirdDHKXNumberLabel.Size = new System.Drawing.Size(249, 50);
            this.ThirdDHKXNumberLabel.TabIndex = 54;
            this.ThirdDHKXNumberLabel.Text = "Third DHKX Number\r\n(Your EKPK + Recipient SPKPK)";
            // 
            // FourthDHKXNumberLabel
            // 
            this.FourthDHKXNumberLabel.AutoSize = true;
            this.FourthDHKXNumberLabel.Location = new System.Drawing.Point(507, 507);
            this.FourthDHKXNumberLabel.Name = "FourthDHKXNumberLabel";
            this.FourthDHKXNumberLabel.Size = new System.Drawing.Size(253, 50);
            this.FourthDHKXNumberLabel.TabIndex = 55;
            this.FourthDHKXNumberLabel.Text = "Fourth DHKX Number\r\n(Your EKPK + Recipient OPKPK)";
            // 
            // SecurityNumberTB
            // 
            this.SecurityNumberTB.Location = new System.Drawing.Point(12, 213);
            this.SecurityNumberTB.Multiline = true;
            this.SecurityNumberTB.Name = "SecurityNumberTB";
            this.SecurityNumberTB.ReadOnly = true;
            this.SecurityNumberTB.Size = new System.Drawing.Size(281, 95);
            this.SecurityNumberTB.TabIndex = 56;
            // 
            // FirstDHKXNumberTB
            // 
            this.FirstDHKXNumberTB.Location = new System.Drawing.Point(507, 64);
            this.FirstDHKXNumberTB.Multiline = true;
            this.FirstDHKXNumberTB.Name = "FirstDHKXNumberTB";
            this.FirstDHKXNumberTB.ReadOnly = true;
            this.FirstDHKXNumberTB.Size = new System.Drawing.Size(281, 95);
            this.FirstDHKXNumberTB.TabIndex = 57;
            // 
            // SecondDHKXNumberTB
            // 
            this.SecondDHKXNumberTB.Location = new System.Drawing.Point(507, 227);
            this.SecondDHKXNumberTB.Multiline = true;
            this.SecondDHKXNumberTB.Name = "SecondDHKXNumberTB";
            this.SecondDHKXNumberTB.ReadOnly = true;
            this.SecondDHKXNumberTB.Size = new System.Drawing.Size(281, 95);
            this.SecondDHKXNumberTB.TabIndex = 58;
            // 
            // ThirdDHKXNumberTB
            // 
            this.ThirdDHKXNumberTB.Location = new System.Drawing.Point(507, 393);
            this.ThirdDHKXNumberTB.Multiline = true;
            this.ThirdDHKXNumberTB.Name = "ThirdDHKXNumberTB";
            this.ThirdDHKXNumberTB.ReadOnly = true;
            this.ThirdDHKXNumberTB.Size = new System.Drawing.Size(281, 95);
            this.ThirdDHKXNumberTB.TabIndex = 59;
            // 
            // FourthDHKXNumberTB
            // 
            this.FourthDHKXNumberTB.Location = new System.Drawing.Point(507, 560);
            this.FourthDHKXNumberTB.Multiline = true;
            this.FourthDHKXNumberTB.Name = "FourthDHKXNumberTB";
            this.FourthDHKXNumberTB.ReadOnly = true;
            this.FourthDHKXNumberTB.Size = new System.Drawing.Size(281, 95);
            this.FourthDHKXNumberTB.TabIndex = 60;
            // 
            // E2EECheckThumbprints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 671);
            this.Controls.Add(this.FourthDHKXNumberTB);
            this.Controls.Add(this.ThirdDHKXNumberTB);
            this.Controls.Add(this.SecondDHKXNumberTB);
            this.Controls.Add(this.FirstDHKXNumberTB);
            this.Controls.Add(this.SecurityNumberTB);
            this.Controls.Add(this.FourthDHKXNumberLabel);
            this.Controls.Add(this.ThirdDHKXNumberLabel);
            this.Controls.Add(this.SecondDHKXNumberLabel);
            this.Controls.Add(this.FirstDHKXNumberLabel);
            this.Controls.Add(this.SecurityNumberLabel);
            this.Controls.Add(this.CheckNumbersBTN);
            this.Controls.Add(this.E2EESessionFolderCB);
            this.Controls.Add(this.label7);
            this.Name = "E2EECheckThumbprints";
            this.Text = "E2EECheckThumbprints";
            this.Load += new System.EventHandler(this.E2EECheckThumbprints_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox E2EESessionFolderCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CheckNumbersBTN;
        private System.Windows.Forms.Label SecurityNumberLabel;
        private System.Windows.Forms.Label FirstDHKXNumberLabel;
        private System.Windows.Forms.Label SecondDHKXNumberLabel;
        private System.Windows.Forms.Label ThirdDHKXNumberLabel;
        private System.Windows.Forms.Label FourthDHKXNumberLabel;
        private System.Windows.Forms.TextBox SecurityNumberTB;
        private System.Windows.Forms.TextBox FirstDHKXNumberTB;
        private System.Windows.Forms.TextBox SecondDHKXNumberTB;
        private System.Windows.Forms.TextBox ThirdDHKXNumberTB;
        private System.Windows.Forms.TextBox FourthDHKXNumberTB;
    }
}