
namespace E2EETLS
{
    partial class CreateE2EESenderKeys
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
            this.IDCB = new System.Windows.Forms.ComboBox();
            this.CheckBTN = new System.Windows.Forms.Button();
            this.CIKAPKTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CEKAPKTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GenerateKeysBTN = new System.Windows.Forms.Button();
            this.Curve448RB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Curve25519RB = new System.Windows.Forms.RadioButton();
            this.IKAPKTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EKAPKTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDCB
            // 
            this.IDCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDCB.FormattingEnabled = true;
            this.IDCB.Location = new System.Drawing.Point(468, 42);
            this.IDCB.Name = "IDCB";
            this.IDCB.Size = new System.Drawing.Size(354, 33);
            this.IDCB.TabIndex = 29;
            this.IDCB.SelectedIndexChanged += new System.EventHandler(this.IDCB_SelectedIndexChanged);
            // 
            // CheckBTN
            // 
            this.CheckBTN.Location = new System.Drawing.Point(468, 432);
            this.CheckBTN.Name = "CheckBTN";
            this.CheckBTN.Size = new System.Drawing.Size(354, 66);
            this.CheckBTN.TabIndex = 28;
            this.CheckBTN.Text = "Check Keys Information";
            this.CheckBTN.UseVisualStyleBackColor = true;
            this.CheckBTN.Click += new System.EventHandler(this.CheckBTN_Click);
            // 
            // CIKAPKTB
            // 
            this.CIKAPKTB.Location = new System.Drawing.Point(468, 291);
            this.CIKAPKTB.Multiline = true;
            this.CIKAPKTB.Name = "CIKAPKTB";
            this.CIKAPKTB.ReadOnly = true;
            this.CIKAPKTB.Size = new System.Drawing.Size(354, 114);
            this.CIKAPKTB.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Chosen Alice Identity KeyPair Public Key";
            // 
            // CEKAPKTB
            // 
            this.CEKAPKTB.Location = new System.Drawing.Point(468, 128);
            this.CEKAPKTB.Multiline = true;
            this.CEKAPKTB.Name = "CEKAPKTB";
            this.CEKAPKTB.ReadOnly = true;
            this.CEKAPKTB.Size = new System.Drawing.Size(354, 114);
            this.CEKAPKTB.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Chosen Alice Ephemeral KeyPair Public Key";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Choose Sender Keys ID";
            // 
            // GenerateKeysBTN
            // 
            this.GenerateKeysBTN.Location = new System.Drawing.Point(13, 625);
            this.GenerateKeysBTN.Name = "GenerateKeysBTN";
            this.GenerateKeysBTN.Size = new System.Drawing.Size(283, 66);
            this.GenerateKeysBTN.TabIndex = 22;
            this.GenerateKeysBTN.Text = "Generate Keys";
            this.GenerateKeysBTN.UseVisualStyleBackColor = true;
            this.GenerateKeysBTN.Click += new System.EventHandler(this.GenerateKeysBTN_Click);
            // 
            // Curve448RB
            // 
            this.Curve448RB.AutoSize = true;
            this.Curve448RB.Location = new System.Drawing.Point(6, 74);
            this.Curve448RB.Name = "Curve448RB";
            this.Curve448RB.Size = new System.Drawing.Size(137, 29);
            this.Curve448RB.TabIndex = 1;
            this.Curve448RB.Text = "X448-ED448";
            this.Curve448RB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Curve448RB);
            this.groupBox1.Controls.Add(this.Curve25519RB);
            this.groupBox1.Location = new System.Drawing.Point(13, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 132);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a key exchange";
            // 
            // Curve25519RB
            // 
            this.Curve25519RB.AutoSize = true;
            this.Curve25519RB.Checked = true;
            this.Curve25519RB.Location = new System.Drawing.Point(6, 39);
            this.Curve25519RB.Name = "Curve25519RB";
            this.Curve25519RB.Size = new System.Drawing.Size(177, 29);
            this.Curve25519RB.TabIndex = 0;
            this.Curve25519RB.TabStop = true;
            this.Curve25519RB.Text = "X25519-ED25519";
            this.Curve25519RB.UseVisualStyleBackColor = true;
            // 
            // IKAPKTB
            // 
            this.IKAPKTB.Location = new System.Drawing.Point(13, 366);
            this.IKAPKTB.Multiline = true;
            this.IKAPKTB.Name = "IKAPKTB";
            this.IKAPKTB.ReadOnly = true;
            this.IKAPKTB.Size = new System.Drawing.Size(283, 114);
            this.IKAPKTB.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Alice Identity KeyPair Public Key";
            // 
            // EKAPKTB
            // 
            this.EKAPKTB.Location = new System.Drawing.Point(13, 203);
            this.EKAPKTB.Multiline = true;
            this.EKAPKTB.Name = "EKAPKTB";
            this.EKAPKTB.ReadOnly = true;
            this.EKAPKTB.Size = new System.Drawing.Size(283, 114);
            this.EKAPKTB.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Alice Ephemeral KeyPair Public Key";
            // 
            // IDTB
            // 
            this.IDTB.Location = new System.Drawing.Point(13, 42);
            this.IDTB.Multiline = true;
            this.IDTB.Name = "IDTB";
            this.IDTB.ReadOnly = true;
            this.IDTB.Size = new System.Drawing.Size(283, 114);
            this.IDTB.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "The Sender Keys ID";
            // 
            // CreateE2EESenderKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 723);
            this.Controls.Add(this.IDCB);
            this.Controls.Add(this.CheckBTN);
            this.Controls.Add(this.CIKAPKTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CEKAPKTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GenerateKeysBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IKAPKTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EKAPKTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDTB);
            this.Controls.Add(this.label1);
            this.Name = "CreateE2EESenderKeys";
            this.Text = "CreateE2EESenderKeys";
            this.Load += new System.EventHandler(this.CreateE2EESenderKeys_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox IDCB;
        private System.Windows.Forms.Button CheckBTN;
        private System.Windows.Forms.TextBox CIKAPKTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CEKAPKTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GenerateKeysBTN;
        private System.Windows.Forms.RadioButton Curve448RB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Curve25519RB;
        private System.Windows.Forms.TextBox IKAPKTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EKAPKTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDTB;
        private System.Windows.Forms.Label label1;
    }
}