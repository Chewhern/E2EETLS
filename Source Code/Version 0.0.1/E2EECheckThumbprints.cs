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
using System.Numerics;

namespace E2EETLS
{
    public partial class E2EECheckThumbprints : Form
    {
        public E2EECheckThumbprints()
        {
            InitializeComponent();
        }

        private void E2EECheckThumbprints_Load(object sender, EventArgs e)
        {
            ReloadE2EESessionIDs();
        }

        private void CheckNumbersBTN_Click(object sender, EventArgs e)
        {
            if (E2EESessionFolderCB.SelectedIndex != -1)
            {
                String StartUpDirectory = Application.StartupPath;
                String E2EERootDirectory = StartUpDirectory + "\\E2EE";
                String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
                String E2EESessionID = E2EESessionFolderCB.Text;
                Byte[] SecurityThumbPrint = new Byte[] { };
                Byte[] FirstDHKXThumbPrint = new Byte[] { };
                Byte[] SecondDHKXThumbPrint = new Byte[] { };
                Byte[] ThirdDHKXThumbPrint = new Byte[] { };
                Byte[] FourthDHKXThumbPrint = new Byte[] { };
                BigInteger SecurityNumber = new BigInteger();
                BigInteger FirstDHKXNumber = new BigInteger();
                BigInteger SecondDHKXNumber = new BigInteger();
                BigInteger ThirdDHKXNumber = new BigInteger();
                BigInteger FourthDHKXNumber = new BigInteger();
                String SenderRecipientResult = "";
                String MainStatusString = "";
                String FirstStatusString = "";
                String SecondStatusString = "";
                String ThirdStatusString = "";
                String FourthStatusString = "";
                Boolean IsSender = true;
                SenderRecipientResult = File.ReadAllText(E2EESessionDirectory + E2EESessionID + "\\UserType.txt");
                if (SenderRecipientResult.CompareTo("Alice/Sender") == 0)
                {
                    IsSender = true;
                }
                else
                {
                    IsSender = false;
                }
                if (IsSender == true)
                {
                    MainStatusString = "Security Number" + Environment.NewLine
                        + "(Your IKPK + Recipient IKPK)";
                    FirstStatusString = "First DHKX Number" + Environment.NewLine
                        + "(Your IKPK + Recipient SPKPK)";
                    SecondStatusString = "Second DHKX Number" + Environment.NewLine
                        + "(Your EKPK + Recipient IKPK)";
                    ThirdStatusString = "Third DHKX Number" + Environment.NewLine
                        + "(Your EKPK + Recipient SPKPK)";
                    FourthStatusString = "Fourth DHKX Number" + Environment.NewLine
                        + "(Your EKPK + Recipient OPKPK)";
                }
                else
                {
                    MainStatusString = "Security Number" + Environment.NewLine
                        + "(Sender IKPK + Your IKPK)";
                    FirstStatusString = "First DHKX Number" + Environment.NewLine
                        + "(Sender IKPK + Your SPKPK)";
                    SecondStatusString = "Second DHKX Number" + Environment.NewLine
                        + "(Sender EKPK + Your IKPK)";
                    ThirdStatusString = "Third DHKX Number" + Environment.NewLine
                        + "(Sender EKPK + Your SPKPK)";
                    FourthStatusString = "Fourth DHKX Number" + Environment.NewLine
                        + "(Sender EKPK + Your OPKPK)";
                }
                SecurityThumbPrint = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\MutualSecurityNumber.txt");
                FirstDHKXThumbPrint = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\1stMutualSecurityNumber.txt");
                SecondDHKXThumbPrint = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\2ndMutualSecurityNumber.txt");
                ThirdDHKXThumbPrint = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\3rdMutualSecurityNumber.txt");
                FourthDHKXThumbPrint = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\4thMutualSecurityNumber.txt");
                SecurityNumber = new BigInteger(SecurityThumbPrint);
                FirstDHKXNumber = new BigInteger(FirstDHKXThumbPrint);
                SecondDHKXNumber = new BigInteger(SecondDHKXThumbPrint);
                ThirdDHKXNumber = new BigInteger(ThirdDHKXThumbPrint);
                FourthDHKXNumber = new BigInteger(FourthDHKXThumbPrint);
                SecurityNumberLabel.Text = MainStatusString;
                FirstDHKXNumberLabel.Text = FirstStatusString;
                SecondDHKXNumberLabel.Text = SecondStatusString;
                ThirdDHKXNumberLabel.Text = ThirdStatusString;
                FourthDHKXNumberLabel.Text = FourthStatusString;
                SecurityNumberTB.Text = SecurityNumber.ToString();
                FirstDHKXNumberTB.Text = FirstDHKXNumber.ToString();
                SecondDHKXNumberTB.Text = SecondDHKXNumber.ToString();
                ThirdDHKXNumberTB.Text = ThirdDHKXNumber.ToString();
                FourthDHKXNumberTB.Text = FourthDHKXNumber.ToString();
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
