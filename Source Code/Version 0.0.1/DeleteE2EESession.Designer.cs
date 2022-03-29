
namespace E2EETLS
{
    partial class DeleteE2EESession
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
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // E2EESessionFolderCB
            // 
            this.E2EESessionFolderCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.E2EESessionFolderCB.FormattingEnabled = true;
            this.E2EESessionFolderCB.Location = new System.Drawing.Point(248, 186);
            this.E2EESessionFolderCB.Name = "E2EESessionFolderCB";
            this.E2EESessionFolderCB.Size = new System.Drawing.Size(295, 33);
            this.E2EESessionFolderCB.TabIndex = 49;
            this.E2EESessionFolderCB.SelectedIndexChanged += new System.EventHandler(this.E2EESessionFolderCB_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Choose an established E2EE session";
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(249, 226);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(294, 70);
            this.DeleteBTN.TabIndex = 50;
            this.DeleteBTN.Text = "Delete established E2EE session";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // DeleteE2EESession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.E2EESessionFolderCB);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DeleteE2EESession";
            this.Text = "DeleteE2EESession";
            this.Load += new System.EventHandler(this.DeleteE2EESession_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox E2EESessionFolderCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button DeleteBTN;
    }
}