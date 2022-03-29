using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ASodium;

namespace E2EETLS
{
    public partial class E2EEActionChooser : Form
    {
        public E2EEActionChooser()
        {
            InitializeComponent();
        }

        private void CreateSenderKeysBTN_Click(object sender, EventArgs e)
        {
            CreateE2EESenderKeys NewForm = new CreateE2EESenderKeys();
            NewForm.Show();
        }

        private void CreateRecipientKeysBTN_Click(object sender, EventArgs e)
        {
            CreateE2EERecipientKeys NewForm = new CreateE2EERecipientKeys();
            NewForm.Show();
        }

        private void CreateE2EESessionBTN_Click(object sender, EventArgs e)
        {
            CreateE2EESession NewForm = new CreateE2EESession();
            NewForm.Show();
        }

        private void EncryptBTN_Click(object sender, EventArgs e)
        {
            EncryptWE2EE NewForm = new EncryptWE2EE();
            NewForm.Show();
        }

        private void DecryptBTN_Click(object sender, EventArgs e)
        {
            DecryptWE2EE NewForm = new DecryptWE2EE();
            NewForm.Show();
        }

        private void CheckSecurityNumberBTN_Click(object sender, EventArgs e)
        {
            E2EECheckThumbprints NewForm = new E2EECheckThumbprints();
            NewForm.Show();
        }

        private void DeleteSessionBTN_Click(object sender, EventArgs e)
        {
            DeleteE2EESession NewForm = new DeleteE2EESession();
            NewForm.Show();
        }

        private void E2EEActionChooser_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\E2EE") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\E2EE");
            }
            if (Directory.Exists(Application.StartupPath + "\\E2EE\\Sender_Keys") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\E2EE\\Sender_Keys");
            }
            if (Directory.Exists(Application.StartupPath + "\\E2EE\\Recipient_Keys") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\E2EE\\Recipient_Keys");
            }
            if (Directory.Exists(Application.StartupPath + "\\E2EE\\E2EESession") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\E2EE\\E2EESession");
            }
        }
    }
}
