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
    public partial class CreateE2EERecipientKeys : Form
    {
        private SecureIDGenerator IDGenerator = new SecureIDGenerator();

        public CreateE2EERecipientKeys()
        {
            InitializeComponent();
        }

        private void CreateE2EERecipientKeys_Load(object sender, EventArgs e)
        {
            LoadRecipientKeysID();
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
            String E2EERecipientKeysDirectory = E2EERootDirectory + "\\Recipient_Keys\\";
            String RecipientKeysID = IDGenerator.GenerateUniqueString();
            Boolean IsCurve25519 = Curve25519RB.Checked;
            Boolean IsCurve448 = Curve448RB.Checked;
            Byte[] SignedBobSPKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobSPKX25519Or448PK = new Byte[] { };
            Byte[] SignedBobIKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobIKX25519Or448PK = new Byte[] { };
            Byte[] SignedBobOPKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobOPKX25519Or448PK = new Byte[] { };
            if (IsCurve25519 == true || IsCurve448 == true)
            {
                RecipientKeysID = RecipientKeysID.Substring(0, 16);
                while (Directory.Exists(E2EERecipientKeysDirectory + RecipientKeysID) == true)
                {
                    RecipientKeysID = IDGenerator.GenerateUniqueString();
                    RecipientKeysID = RecipientKeysID.Substring(0, 16);
                }
                Directory.CreateDirectory(E2EERecipientKeysDirectory + RecipientKeysID);
                if (IsCurve25519 == true)
                {
                    RevampedKeyPair BobSPKX25519KeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
                    RevampedKeyPair BobSPKED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    RevampedKeyPair BobIKX25519KeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
                    RevampedKeyPair BobIKED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    RevampedKeyPair BobOPKX25519KeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
                    RevampedKeyPair BobOPKED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    SignedBobSPKX25519Or448PK = SodiumPublicKeyAuth.Sign(BobSPKX25519KeyPair.PublicKey, BobSPKED25519KeyPair.PrivateKey, true);
                    MergedSignedBobSPKX25519Or448PK = BobSPKED25519KeyPair.PublicKey.Concat(SignedBobSPKX25519Or448PK).ToArray();
                    SignedBobIKX25519Or448PK = SodiumPublicKeyAuth.Sign(BobIKX25519KeyPair.PublicKey, BobIKED25519KeyPair.PrivateKey, true);
                    MergedSignedBobIKX25519Or448PK = BobIKED25519KeyPair.PublicKey.Concat(SignedBobIKX25519Or448PK).ToArray();
                    SignedBobOPKX25519Or448PK = SodiumPublicKeyAuth.Sign(BobOPKX25519KeyPair.PublicKey, BobOPKED25519KeyPair.PrivateKey, true);
                    MergedSignedBobOPKX25519Or448PK = BobOPKED25519KeyPair.PublicKey.Concat(SignedBobOPKX25519Or448PK).ToArray();
                    SPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobSPKX25519Or448PK);
                    IKBPKTB.Text = Convert.ToBase64String(MergedSignedBobIKX25519Or448PK);
                    OPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobOPKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKX25519Or448SK.txt", BobSPKX25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKX25519Or448PK.txt", BobSPKX25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKED25519Or448SK.txt", BobSPKED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKED25519Or448PK.txt", BobSPKED25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKX25519Or448SK.txt", BobIKX25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKX25519Or448PK.txt", BobIKX25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKED25519Or448SK.txt", BobIKED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKED25519Or448PK.txt", BobIKED25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKX25519Or448SK.txt", BobOPKX25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKX25519Or448PK.txt", BobOPKX25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKED25519Or448SK.txt", BobOPKED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKED25519Or448PK.txt", BobOPKED25519KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedEKX25519Or448PK.txt", MergedSignedBobSPKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedIKX25519Or448PK.txt", MergedSignedBobIKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedOPKX25519Or448PK.txt", MergedSignedBobOPKX25519Or448PK);
                    BobSPKX25519KeyPair.Clear();
                    BobSPKED25519KeyPair.Clear();
                    BobIKX25519KeyPair.Clear();
                    BobIKED25519KeyPair.Clear();
                    BobOPKX25519KeyPair.Clear();
                    BobOPKED25519KeyPair.Clear();
                }
                if (IsCurve448 == true)
                {
                    X448RevampedKeyPair BobSPKX448KeyPair = SecureX448.GenerateX448RevampedKeyPair();
                    ED448RevampedKeyPair BobSPKED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    X448RevampedKeyPair BobIKX448KeyPair = SecureX448.GenerateX448RevampedKeyPair();
                    ED448RevampedKeyPair BobIKED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    X448RevampedKeyPair BobOPKX448KeyPair = SecureX448.GenerateX448RevampedKeyPair();
                    ED448RevampedKeyPair BobOPKED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    SignedBobSPKX25519Or448PK = SecureED448.GenerateSignatureMessage(BobSPKED448KeyPair.PrivateKey, BobSPKX448KeyPair.PublicKey, new Byte[] { }, true);
                    MergedSignedBobSPKX25519Or448PK = BobSPKED448KeyPair.PublicKey.Concat(SignedBobSPKX25519Or448PK).ToArray();
                    SignedBobIKX25519Or448PK = SecureED448.GenerateSignatureMessage(BobIKED448KeyPair.PrivateKey, BobIKX448KeyPair.PublicKey, new Byte[] { }, true);
                    MergedSignedBobIKX25519Or448PK = BobIKED448KeyPair.PublicKey.Concat(SignedBobIKX25519Or448PK).ToArray();
                    SignedBobOPKX25519Or448PK = SecureED448.GenerateSignatureMessage(BobOPKED448KeyPair.PrivateKey, BobOPKX448KeyPair.PublicKey, new Byte[] { }, true);
                    MergedSignedBobOPKX25519Or448PK = BobOPKED448KeyPair.PublicKey.Concat(SignedBobOPKX25519Or448PK).ToArray();
                    SPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobSPKX25519Or448PK);
                    IKBPKTB.Text = Convert.ToBase64String(MergedSignedBobIKX25519Or448PK);
                    OPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobOPKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKX25519Or448SK.txt", BobSPKX448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKX25519Or448PK.txt", BobSPKX448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKED25519Or448SK.txt", BobSPKED448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\SPKED25519Or448PK.txt", BobSPKED448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKX25519Or448SK.txt", BobIKX448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKX25519Or448PK.txt", BobIKX448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKED25519Or448SK.txt", BobIKED448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\IKED25519Or448PK.txt", BobIKED448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKX25519Or448SK.txt", BobOPKX448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKX25519Or448PK.txt", BobOPKX448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKED25519Or448SK.txt", BobOPKED448KeyPair.PrivateKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\OPKED25519Or448PK.txt", BobOPKED448KeyPair.PublicKey);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedEKX25519Or448PK.txt", MergedSignedBobSPKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedIKX25519Or448PK.txt", MergedSignedBobIKX25519Or448PK);
                    File.WriteAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedOPKX25519Or448PK.txt", MergedSignedBobOPKX25519Or448PK);
                    BobSPKX448KeyPair.Clear();
                    BobSPKED448KeyPair.Clear();
                    BobIKX448KeyPair.Clear();
                    BobIKED448KeyPair.Clear();
                }
                IDTB.Text = RecipientKeysID;
                LoadRecipientKeysID();
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
                String E2EERecipientKeysDirectory = E2EERootDirectory + "\\Recipient_Keys\\";
                String RecipientKeysID = IDCB.Text;
                Byte[] MergedSignedBobSPKX25519Or448PK = new Byte[] { };
                Byte[] MergedSignedBobIKX25519Or448PK = new Byte[] { };
                Byte[] MergedSignedBobOPKX25519Or448PK = new Byte[] { };
                MergedSignedBobSPKX25519Or448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedEKX25519Or448PK.txt");
                MergedSignedBobIKX25519Or448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedIKX25519Or448PK.txt");
                MergedSignedBobOPKX25519Or448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + RecipientKeysID + "\\MergedOPKX25519Or448PK.txt");
                CSPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobSPKX25519Or448PK);
                CIKBPKTB.Text = Convert.ToBase64String(MergedSignedBobIKX25519Or448PK);
                COPKBPKTB.Text = Convert.ToBase64String(MergedSignedBobOPKX25519Or448PK);
            }
        }

        public void LoadRecipientKeysID()
        {
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EERecipientKeysDirectory = E2EERootDirectory + "\\Recipient_Keys\\";
            String[] RecipientKeysIDDirectories = new String[] { };
            String[] RecipientKeysID = new String[] { };
            int LoopCount = 0;
            if (Directory.GetDirectories(E2EERecipientKeysDirectory).Length != 0)
            {
                RecipientKeysIDDirectories = Directory.GetDirectories(E2EERecipientKeysDirectory);
                RecipientKeysID = new String[RecipientKeysIDDirectories.Length];
                while (LoopCount < RecipientKeysID.Length)
                {
                    RecipientKeysID[LoopCount] = RecipientKeysIDDirectories[LoopCount].Remove(0, E2EERecipientKeysDirectory.Length);
                    LoopCount += 1;
                }
                IDCB.Items.Clear();
                IDCB.Items.AddRange(RecipientKeysID);
            }
        }
    }
}
