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

namespace E2EETLS
{
    public partial class DeleteE2EESession : Form
    {
        public DeleteE2EESession()
        {
            InitializeComponent();
        }

        private void DeleteE2EESession_Load(object sender, EventArgs e)
        {
            ReloadE2EESessionIDs();
        }

        private void E2EESessionFolderCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E2EESessionFolderCB.SelectedIndex != -1)
            {
                MessageBox.Show(E2EESessionFolderCB.Text, "Selected E2EE Session ID");
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (E2EESessionFolderCB.SelectedIndex != -1) 
            {
                String StartUpDirectory = Application.StartupPath;
                String E2EERootDirectory = StartUpDirectory + "\\E2EE";
                String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
                Directory.Delete(E2EESessionDirectory + E2EESessionFolderCB.Text, true);
            }
        }

        public void ReloadE2EESessionIDs()
        {
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
            String[] E2EESessionIDDirectories = new String[] { };
            String[] E2EESessionID = new String[] { };
            int LoopCount = 0;
            if (Directory.GetDirectories(E2EESessionDirectory).Length != 0)
            {
                E2EESessionIDDirectories = Directory.GetDirectories(E2EESessionDirectory);
                E2EESessionID = new String[E2EESessionIDDirectories.Length];
                while (LoopCount < E2EESessionID.Length)
                {
                    E2EESessionID[LoopCount] = E2EESessionIDDirectories[LoopCount].Remove(0, E2EESessionDirectory.Length);
                    LoopCount += 1;
                }
                E2EESessionFolderCB.Items.Clear();
                E2EESessionFolderCB.Items.AddRange(E2EESessionID);
            }
        }
    }
}
