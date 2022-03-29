
namespace E2EETLS
{
    partial class CreateE2EERecipientKeys
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
            this.label6 = new System.Windows.Forms.Label();
            this.GenerateKeysBTN = new System.Windows.Forms.Button();
            this.Curve448RB = new System.Windows.Forms.RadioButton();
            this.IDCB = new System.Windows.Forms.ComboBox();
            this.CSPKBPKTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Curve25519RB = new System.Windows.Forms.RadioButton();
            this.COPKBPKTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OPKBPKTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CheckBTN = new System.Windows.Forms.Button();
            this.CIKBPKTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IKBPKTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SPKBPKTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 25);
            this.label6.TabIndex = 42;
            this.label6.Text = "Choose Recipient Keys ID";
            // 
            // GenerateKeysBTN
            // 
            this.GenerateKeysBTN.Location = new System.Drawing.Point(12, 785);
            this.GenerateKeysBTN.Name = "GenerateKeysBTN";
            this.GenerateKeysBTN.Size = new System.Drawing.Size(283, 66);
            this.GenerateKeysBTN.TabIndex = 41;
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
            // IDCB
            // 
            this.IDCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDCB.FormattingEnabled = true;
            this.IDCB.Location = new System.Drawing.Point(437, 42);
            this.IDCB.Name = "IDCB";
            this.IDCB.Size = new System.Drawing.Size(388, 33);
            this.IDCB.TabIndex = 48;
            this.IDCB.SelectedIndexChanged += new System.EventHandler(this.IDCB_SelectedIndexChanged);
            // 
            // CSPKBPKTB
            // 
            this.CSPKBPKTB.Location = new System.Drawing.Point(437, 128);
            this.CSPKBPKTB.Multiline = true;
            this.CSPKBPKTB.Name = "CSPKBPKTB";
            this.CSPKBPKTB.ReadOnly = true;
            this.CSPKBPKTB.Size = new System.Drawing.Size(388, 114);
            this.CSPKBPKTB.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 25);
            this.label5.TabIndex = 43;
            this.label5.Text = "Chosen Bob Signed Pre Key KeyPair Public Key";
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
            // COPKBPKTB
            // 
            this.COPKBPKTB.Location = new System.Drawing.Point(437, 461);
            this.COPKBPKTB.Multiline = true;
            this.COPKBPKTB.Name = "COPKBPKTB";
            this.COPKBPKTB.ReadOnly = true;
            this.COPKBPKTB.Size = new System.Drawing.Size(388, 114);
            this.COPKBPKTB.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(388, 25);
            this.label8.TabIndex = 52;
            this.label8.Text = "Chosen Bob OneTime PreKey KeyPair Public Key";
            // 
            // OPKBPKTB
            // 
            this.OPKBPKTB.Location = new System.Drawing.Point(11, 527);
            this.OPKBPKTB.Multiline = true;
            this.OPKBPKTB.Name = "OPKBPKTB";
            this.OPKBPKTB.ReadOnly = true;
            this.OPKBPKTB.Size = new System.Drawing.Size(314, 114);
            this.OPKBPKTB.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 498);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(324, 25);
            this.label7.TabIndex = 50;
            this.label7.Text = "Bob OneTime PreKey KeyPair Public Key";
            // 
            // CheckBTN
            // 
            this.CheckBTN.Location = new System.Drawing.Point(437, 599);
            this.CheckBTN.Name = "CheckBTN";
            this.CheckBTN.Size = new System.Drawing.Size(388, 66);
            this.CheckBTN.TabIndex = 47;
            this.CheckBTN.Text = "Check Keys Information";
            this.CheckBTN.UseVisualStyleBackColor = true;
            this.CheckBTN.Click += new System.EventHandler(this.CheckBTN_Click);
            // 
            // CIKBPKTB
            // 
            this.CIKBPKTB.Location = new System.Drawing.Point(437, 291);
            this.CIKBPKTB.Multiline = true;
            this.CIKBPKTB.Name = "CIKBPKTB";
            this.CIKBPKTB.ReadOnly = true;
            this.CIKBPKTB.Size = new System.Drawing.Size(388, 114);
            this.CIKBPKTB.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Chosen Bob Identity KeyPair Public Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Curve448RB);
            this.groupBox1.Controls.Add(this.Curve25519RB);
            this.groupBox1.Location = new System.Drawing.Point(12, 647);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 132);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a key exchange";
            // 
            // IKBPKTB
            // 
            this.IKBPKTB.Location = new System.Drawing.Point(12, 366);
            this.IKBPKTB.Multiline = true;
            this.IKBPKTB.Name = "IKBPKTB";
            this.IKBPKTB.ReadOnly = true;
            this.IKBPKTB.Size = new System.Drawing.Size(313, 114);
            this.IKBPKTB.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Bob Identity Key KeyPair Public Key";
            // 
            // SPKBPKTB
            // 
            this.SPKBPKTB.Location = new System.Drawing.Point(12, 203);
            this.SPKBPKTB.Multiline = true;
            this.SPKBPKTB.Name = "SPKBPKTB";
            this.SPKBPKTB.ReadOnly = true;
            this.SPKBPKTB.Size = new System.Drawing.Size(313, 114);
            this.SPKBPKTB.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Bob Signed Pre Key KeyPair Public Key";
            // 
            // IDTB
            // 
            this.IDTB.Location = new System.Drawing.Point(12, 42);
            this.IDTB.Multiline = true;
            this.IDTB.Name = "IDTB";
            this.IDTB.ReadOnly = true;
            this.IDTB.Size = new System.Drawing.Size(313, 114);
            this.IDTB.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "The Recipient Keys ID";
            // 
            // CreateE2EERecipientKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 875);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GenerateKeysBTN);
            this.Controls.Add(this.IDCB);
            this.Controls.Add(this.CSPKBPKTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.COPKBPKTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OPKBPKTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CheckBTN);
            this.Controls.Add(this.CIKBPKTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IKBPKTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SPKBPKTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDTB);
            this.Controls.Add(this.label1);
            this.Name = "CreateE2EERecipientKeys";
            this.Text = "CreateE2EERecipientKeys";
            this.Load += new System.EventHandler(this.CreateE2EERecipientKeys_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GenerateKeysBTN;
        private System.Windows.Forms.RadioButton Curve448RB;
        private System.Windows.Forms.ComboBox IDCB;
        private System.Windows.Forms.TextBox CSPKBPKTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Curve25519RB;
        private System.Windows.Forms.TextBox COPKBPKTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox OPKBPKTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CheckBTN;
        private System.Windows.Forms.TextBox CIKBPKTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IKBPKTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SPKBPKTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDTB;
        private System.Windows.Forms.Label label1;
    }
}