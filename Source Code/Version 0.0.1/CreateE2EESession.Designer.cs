
namespace E2EETLS
{
    partial class CreateE2EESession
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
            this.E2EEFolderNameTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateSessionBTN = new System.Windows.Forms.Button();
            this.AliceBobE2EEIDTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AliceBobE2EEIDCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CTB3 = new System.Windows.Forms.TextBox();
            this.CLabel3 = new System.Windows.Forms.Label();
            this.CTB2 = new System.Windows.Forms.TextBox();
            this.CLabel2 = new System.Windows.Forms.Label();
            this.CTB1 = new System.Windows.Forms.TextBox();
            this.CLabel1 = new System.Windows.Forms.Label();
            this.UserAgentCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // E2EEFolderNameTB
            // 
            this.E2EEFolderNameTB.Location = new System.Drawing.Point(368, 265);
            this.E2EEFolderNameTB.Multiline = true;
            this.E2EEFolderNameTB.Name = "E2EEFolderNameTB";
            this.E2EEFolderNameTB.Size = new System.Drawing.Size(330, 108);
            this.E2EEFolderNameTB.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "E2EE Folder Name";
            // 
            // CreateSessionBTN
            // 
            this.CreateSessionBTN.Location = new System.Drawing.Point(368, 397);
            this.CreateSessionBTN.Name = "CreateSessionBTN";
            this.CreateSessionBTN.Size = new System.Drawing.Size(330, 71);
            this.CreateSessionBTN.TabIndex = 27;
            this.CreateSessionBTN.Text = "Create E2EE Session";
            this.CreateSessionBTN.UseVisualStyleBackColor = true;
            this.CreateSessionBTN.Click += new System.EventHandler(this.CreateSessionBTN_Click);
            // 
            // AliceBobE2EEIDTB
            // 
            this.AliceBobE2EEIDTB.Location = new System.Drawing.Point(368, 111);
            this.AliceBobE2EEIDTB.Multiline = true;
            this.AliceBobE2EEIDTB.Name = "AliceBobE2EEIDTB";
            this.AliceBobE2EEIDTB.ReadOnly = true;
            this.AliceBobE2EEIDTB.Size = new System.Drawing.Size(330, 108);
            this.AliceBobE2EEIDTB.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Chosen P-I E2EE ID";
            // 
            // AliceBobE2EEIDCB
            // 
            this.AliceBobE2EEIDCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AliceBobE2EEIDCB.FormattingEnabled = true;
            this.AliceBobE2EEIDCB.Location = new System.Drawing.Point(368, 42);
            this.AliceBobE2EEIDCB.Name = "AliceBobE2EEIDCB";
            this.AliceBobE2EEIDCB.Size = new System.Drawing.Size(330, 33);
            this.AliceBobE2EEIDCB.TabIndex = 24;
            this.AliceBobE2EEIDCB.SelectedIndexChanged += new System.EventHandler(this.AliceBobE2EEIDCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Choose a pre-initiated E2EE ID";
            // 
            // CTB3
            // 
            this.CTB3.Location = new System.Drawing.Point(11, 426);
            this.CTB3.Multiline = true;
            this.CTB3.Name = "CTB3";
            this.CTB3.ReadOnly = true;
            this.CTB3.Size = new System.Drawing.Size(330, 108);
            this.CTB3.TabIndex = 22;
            // 
            // CLabel3
            // 
            this.CLabel3.AutoSize = true;
            this.CLabel3.Location = new System.Drawing.Point(11, 397);
            this.CLabel3.Name = "CLabel3";
            this.CLabel3.Size = new System.Drawing.Size(135, 25);
            this.CLabel3.TabIndex = 21;
            this.CLabel3.Text = "Custom Label 3";
            // 
            // CTB2
            // 
            this.CTB2.Location = new System.Drawing.Point(11, 265);
            this.CTB2.Multiline = true;
            this.CTB2.Name = "CTB2";
            this.CTB2.ReadOnly = true;
            this.CTB2.Size = new System.Drawing.Size(330, 108);
            this.CTB2.TabIndex = 20;
            // 
            // CLabel2
            // 
            this.CLabel2.AutoSize = true;
            this.CLabel2.Location = new System.Drawing.Point(11, 236);
            this.CLabel2.Name = "CLabel2";
            this.CLabel2.Size = new System.Drawing.Size(135, 25);
            this.CLabel2.TabIndex = 19;
            this.CLabel2.Text = "Custom Label 2";
            // 
            // CTB1
            // 
            this.CTB1.Location = new System.Drawing.Point(12, 111);
            this.CTB1.Multiline = true;
            this.CTB1.Name = "CTB1";
            this.CTB1.ReadOnly = true;
            this.CTB1.Size = new System.Drawing.Size(330, 108);
            this.CTB1.TabIndex = 18;
            // 
            // CLabel1
            // 
            this.CLabel1.AutoSize = true;
            this.CLabel1.Location = new System.Drawing.Point(12, 82);
            this.CLabel1.Name = "CLabel1";
            this.CLabel1.Size = new System.Drawing.Size(135, 25);
            this.CLabel1.TabIndex = 17;
            this.CLabel1.Text = "Custom Label 1";
            // 
            // UserAgentCB
            // 
            this.UserAgentCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserAgentCB.FormattingEnabled = true;
            this.UserAgentCB.Items.AddRange(new object[] {
            "Sender",
            "Recipient"});
            this.UserAgentCB.Location = new System.Drawing.Point(12, 42);
            this.UserAgentCB.Name = "UserAgentCB";
            this.UserAgentCB.Size = new System.Drawing.Size(329, 33);
            this.UserAgentCB.TabIndex = 16;
            this.UserAgentCB.SelectedIndexChanged += new System.EventHandler(this.UserAgentCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Are you sender or recipient?";
            // 
            // CreateE2EESession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.E2EEFolderNameTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CreateSessionBTN);
            this.Controls.Add(this.AliceBobE2EEIDTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AliceBobE2EEIDCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CTB3);
            this.Controls.Add(this.CLabel3);
            this.Controls.Add(this.CTB2);
            this.Controls.Add(this.CLabel2);
            this.Controls.Add(this.CTB1);
            this.Controls.Add(this.CLabel1);
            this.Controls.Add(this.UserAgentCB);
            this.Controls.Add(this.label1);
            this.Name = "CreateE2EESession";
            this.Text = "CreateE2EESession";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox E2EEFolderNameTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateSessionBTN;
        private System.Windows.Forms.TextBox AliceBobE2EEIDTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AliceBobE2EEIDCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CTB3;
        private System.Windows.Forms.Label CLabel3;
        private System.Windows.Forms.TextBox CTB2;
        private System.Windows.Forms.Label CLabel2;
        private System.Windows.Forms.TextBox CTB1;
        private System.Windows.Forms.Label CLabel1;
        private System.Windows.Forms.ComboBox UserAgentCB;
        private System.Windows.Forms.Label label1;
    }
}