using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E2EETLS.Helper;
using System.IO;
using ASodium;
using BCASodium;

namespace E2EETLS
{
    public partial class CreateE2EESenderKeys : Form
    {
        private SecureIDGenerator IDGenerator = new SecureIDGenerator();

        public CreateE2EESenderKeys()
        {
            InitializeComponent();
        }

        private void CreateE2EESenderKeys_Load(object sender, EventArgs e)
        {
            LoadSenderKeysID();
        }

        private void IDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDCB.SelectedIndex != -1)
            {
                MessageBox.Show(IDCB.Text, "Selected ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerateKeysBTN_Click(object sender, EventArgs e)
        {
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESenderKeysDirectory = E2EERootDirectory + "\\Sender_Keys\\";
            String SenderKeysID = IDGenerator.GenerateUniqueString();
            Boolean IsCurve25519 = Curve25519RB.Checked;
            Boolean IsCurve448 = Curve448RB.Checked;
            Byte[] SignedAliceEKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedAliceEKX25519Or448PK = new Byte[] { };
            Byte[] SignedAliceIKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedAliceIKX25519Or448PK = new Byte[] { };
            if (IsCurve25519 == true || IsCurve448 == true)
            {
                SenderKeysID = SenderKeysID.Substring(0, 16);
                while (Directory.Exists(E2EESenderKeysDirectory + SenderKeysID) == true)
                {
                    SenderKeysID = IDGenerator.GenerateUniqueString();
                    SenderKeysID = SenderKeysID.Substring(0, 16);
                }
                Directory.CreateDirectory(E2EESenderKeysDirectory + SenderKeysID);
                if (IsCurve25519 == true)
                {
                    RevampedKeyPair AliceEKX25519KeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
                    RevampedKeyPair AliceEKED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    RevampedKeyPair AliceIKX25519KeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
                    RevampedKeyPair AliceIKED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    SignedAliceEKX25519Or448PK = SodiumPublicKeyAuth.Sign(AliceEKX25519KeyPair.PublicKey, AliceEKED25519KeyPair.PrivateKey, true);
                    MergedSignedAliceEKX25519Or448PK = AliceEKED25519KeyPair.PublicKey.Concat(SignedAliceEKX25519Or448PK).ToArray();
                    SignedAliceIKX25519Or448PK = SodiumPublicKeyAuth.Sign(AliceIKX25519KeyPair.PublicKey, AliceIKED25519KeyPair.PrivateKey, true);
                    MergedSignedAliceIKX25519Or448PK = AliceIKED25519KeyPair.PublicKey.Concat(SignedAliceIKX25519Or448PK).ToArray();
                    EKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceEKX25519Or448PK);
                    IKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceIKX25519Or448PK);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKX25519Or448SK.txt", AliceEKX25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKX25519Or448PK.txt", AliceEKX25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKED25519Or448SK.txt", AliceEKED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKED25519Or448PK.txt", AliceEKED25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKX25519Or448SK.txt", AliceIKX25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKX25519Or448PK.txt", AliceIKX25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKED25519Or448SK.txt", AliceIKED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKED25519Or448PK.txt", AliceIKED25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedEKX25519Or448PK.txt", MergedSignedAliceEKX25519Or448PK);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedIKX25519Or448PK.txt", MergedSignedAliceIKX25519Or448PK);
                    AliceEKX25519KeyPair.Clear();
                    AliceEKED25519KeyPair.Clear();
                    AliceIKX25519KeyPair.Clear();
                    AliceIKED25519KeyPair.Clear();
                }
                if (IsCurve448 == true)
                {
                    X448RevampedKeyPair AliceEKX448KeyPair = SecureX448.GenerateX448RevampedKeyPair();
                    ED448RevampedKeyPair AliceEKED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    X448RevampedKeyPair AliceIKX448KeyPair = SecureX448.GenerateX448RevampedKeyPair();
                    ED448RevampedKeyPair AliceIKED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    SignedAliceEKX25519Or448PK = SecureED448.GenerateSignatureMessage(AliceEKED448KeyPair.PrivateKey, AliceEKX448KeyPair.PublicKey, new Byte[] { }, true);
                    MergedSignedAliceEKX25519Or448PK = AliceEKED448KeyPair.PublicKey.Concat(SignedAliceEKX25519Or448PK).ToArray();
                    SignedAliceIKX25519Or448PK = SecureED448.GenerateSignatureMessage(AliceIKED448KeyPair.PrivateKey, AliceIKX448KeyPair.PublicKey, new Byte[] { }, true);
                    MergedSignedAliceIKX25519Or448PK = AliceIKED448KeyPair.PublicKey.Concat(SignedAliceIKX25519Or448PK).ToArray();
                    EKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceEKX25519Or448PK);
                    IKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceIKX25519Or448PK);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKX25519Or448SK.txt", AliceEKX448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKX25519Or448PK.txt", AliceEKX448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKED25519Or448SK.txt", AliceEKED448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\EKED25519Or448PK.txt", AliceEKED448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKX25519Or448SK.txt", AliceIKX448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKX25519Or448PK.txt", AliceIKX448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKED25519Or448SK.txt", AliceIKED448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\IKED25519Or448PK.txt", AliceIKED448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedEKX25519Or448PK.txt", MergedSignedAliceEKX25519Or448PK);
                    File.WriteAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedIKX25519Or448PK.txt", MergedSignedAliceIKX25519Or448PK);
                    AliceEKX448KeyPair.Clear();
                    AliceEKED448KeyPair.Clear();
                    AliceIKX448KeyPair.Clear();
                    AliceIKED448KeyPair.Clear();
                }
                IDTB.Text = SenderKeysID;
                LoadSenderKeysID();
            }
            else
            {
                MessageBox.Show("Please pick a key exchange method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBTN_Click(object sender, EventArgs e)
        {
            if (IDCB.SelectedIndex != -1)
            {
                String StartUpDirectory = Application.StartupPath;
                String E2EERootDirectory = StartUpDirectory + "\\E2EE";
                String E2EESenderKeysDirectory = E2EERootDirectory + "\\Sender_Keys\\";
                String SenderKeysID = IDCB.Text;
                Byte[] MergedSignedAliceEKX25519Or448PK = new Byte[] { };
                Byte[] MergedSignedAliceIKX25519Or448PK = new Byte[] { };
                MergedSignedAliceEKX25519Or448PK = File.ReadAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedEKX25519Or448PK.txt");
                MergedSignedAliceIKX25519Or448PK = File.ReadAllBytes(E2EESenderKeysDirectory + SenderKeysID + "\\MergedIKX25519Or448PK.txt");
                CEKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceEKX25519Or448PK);
                CIKAPKTB.Text = Convert.ToBase64String(MergedSignedAliceIKX25519Or448PK);
            }
        }

        public void LoadSenderKeysID()
        {
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESenderKeysDirectory = E2EERootDirectory + "\\Sender_Keys\\";
            String[] SenderKeysIDDirectories = new String[] { };
            String[] SenderKeysID = new String[] { };
            int LoopCount = 0;
            if (Directory.GetDirectories(E2EESenderKeysDirectory).Length != 0)
            {
                SenderKeysIDDirectories = Directory.GetDirectories(E2EESenderKeysDirectory);
                SenderKeysID = new String[SenderKeysIDDirectories.Length];
                while (LoopCount < SenderKeysID.Length)
                {
                    SenderKeysID[LoopCount] = SenderKeysIDDirectories[LoopCount].Remove(0, E2EESenderKeysDirectory.Length);
                    LoopCount += 1;
                }
                IDCB.Items.Clear();
                IDCB.Items.AddRange(SenderKeysID);
            }
        }
    }
}
