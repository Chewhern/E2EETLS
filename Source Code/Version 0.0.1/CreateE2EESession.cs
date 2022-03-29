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
using BCASodium;

namespace E2EETLS
{
    public partial class CreateE2EESession : Form
    {
        public CreateE2EESession()
        {
            InitializeComponent();
        }

        private void UserAgentCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserAgentCB.SelectedIndex != -1)
            {
                if (UserAgentCB.SelectedIndex == 0)
                {
                    LoadSenderKeysID();
                    CLabel1.Text = "Bob SPK Public Key";
                    CLabel2.Text = "Bob IK Public Key";
                    CLabel3.Text = "Bob OPK Public Key";
                    CTB1.ReadOnly = false;
                    CTB2.ReadOnly = false;
                    CTB3.ReadOnly = false;
                }
                else
                {
                    LoadRecipientKeysID();
                    CLabel1.Text = "Alice EK Public Key";
                    CLabel2.Text = "Alice IK Public Key";
                    CLabel3.Text = "Custom Label 3";
                    CTB1.ReadOnly = false;
                    CTB2.ReadOnly = false;
                    CTB3.ReadOnly = true;
                }
            }
        }

        private void AliceBobE2EEIDCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AliceBobE2EEIDCB.SelectedIndex != -1)
            {
                AliceBobE2EEIDTB.Text = AliceBobE2EEIDCB.Text;
            }
        }

        private void CreateSessionBTN_Click(object sender, EventArgs e)
        {
            Boolean IsSender = true;
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESenderKeysDirectory = E2EERootDirectory + "\\Sender_Keys\\";
            String E2EERecipientKeysDirectory = E2EERootDirectory + "\\Recipient_Keys\\";
            String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
            String AliceBobPIE2EEID = "";
            String E2EEFolderName = "";
            String FirstCryptographyKeyMaterialString = "";
            String SecondCryptographyKeyMaterialString = "";
            String ThirdCryptographyKeyMaterialString = "";
            Byte[] BobSPKED25519Or448PK = new Byte[] { };
            Byte[] SignedBobSPKX25519Or448PK = new Byte[] { };
            Byte[] BobSPKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobSPKX25519Or448PK = new Byte[] { };
            Byte[] BobIKED25519Or448PK = new Byte[] { };
            Byte[] SignedBobIKX25519Or448PK = new Byte[] { };
            Byte[] BobIKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobIKX25519Or448PK = new Byte[] { };
            Byte[] BobOPKED25519Or448PK = new Byte[] { };
            Byte[] SignedBobOPKX25519Or448PK = new Byte[] { };
            Byte[] BobOPKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedBobOPKX25519Or448PK = new Byte[] { };
            Byte[] AliceIKED25519Or448PK = new Byte[] { };
            Byte[] SignedAliceIKX25519Or448PK = new Byte[] { };
            Byte[] AliceIKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedAliceIKX25519Or448PK = new Byte[] { };
            Byte[] AliceEKED25519Or448PK = new Byte[] { };
            Byte[] SignedAliceEKX25519Or448PK = new Byte[] { };
            Byte[] AliceEKX25519Or448PK = new Byte[] { };
            Byte[] MergedSignedAliceEKX25519Or448PK = new Byte[] { };
            Byte[] AliceIKX25519SK = new Byte[] { };
            Byte[] AliceEKX25519SK = new Byte[] { };
            Byte[] AliceIKX448SK = new Byte[] { };
            Byte[] AliceEKX448SK = new Byte[] { };
            Byte[] AliceIKX25519PK = new Byte[] { };
            Byte[] AliceEKX25519PK = new Byte[] { };
            Byte[] AliceIKX448PK = new Byte[] { };
            Byte[] AliceEKX448PK = new Byte[] { };
            Byte[] BobSPKX25519SK = new Byte[] { };
            Byte[] BobIKX25519SK = new Byte[] { };
            Byte[] BobOPKX25519SK = new Byte[] { };
            Byte[] BobSPKX448SK = new Byte[] { };
            Byte[] BobIKX448SK = new Byte[] { };
            Byte[] BobOPKX448SK = new Byte[] { };
            Byte[] BobSPKX25519PK = new Byte[] { };
            Byte[] BobIKX25519PK = new Byte[] { };
            Byte[] BobOPKX25519PK = new Byte[] { };
            Byte[] BobSPKX448PK = new Byte[] { };
            Byte[] BobIKX448PK = new Byte[] { };
            Byte[] BobOPKX448PK = new Byte[] { };
            Byte[] SharedSecret1 = new Byte[] { };
            Byte[] SharedSecret2 = new Byte[] { };
            Byte[] SharedSecret3 = new Byte[] { };
            Byte[] SharedSecret4 = new Byte[] { };
            Byte[] ConcatedSharedSecret = new Byte[] { };
            Byte[] MasterSharedSecret = new Byte[] { };
            Byte[] MainConcatedPKs = new Byte[] { };
            Byte[] FirstConcatedPKs = new Byte[] { };
            Byte[] SecondConcatedPKs = new Byte[] { };
            Byte[] ThirdConcatedPKs = new Byte[] { };
            Byte[] FourthConcatedPKs = new Byte[] { };
            Byte[] MainMutualThumbprint = new Byte[] { };
            Byte[] FirstMutualThumbprint = new Byte[] { };
            Byte[] SecondMutualThumbprint = new Byte[] { };
            Byte[] ThirdMutualThumbprint = new Byte[] { };
            Byte[] FourthMutualThumbprint = new Byte[] { };
            if (UserAgentCB.SelectedIndex != -1)
            {
                if (UserAgentCB.SelectedIndex == 0)
                {
                    IsSender = true;
                }
                else
                {
                    IsSender = false;
                }
                if (IsSender == true)
                {
                    if (AliceBobE2EEIDCB.SelectedIndex != -1)
                    {
                        if (E2EEFolderNameTB.Text != null && E2EEFolderNameTB.Text.CompareTo("") != 0)
                        {
                            AliceBobPIE2EEID = AliceBobE2EEIDCB.Text;
                            E2EEFolderName = E2EEFolderNameTB.Text;
                            if (Directory.Exists(E2EESessionDirectory + E2EEFolderName) == false)
                            {
                                Directory.CreateDirectory(E2EESessionDirectory + E2EEFolderName);
                                AliceEKX448SK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\EKX25519Or448SK.txt");
                                AliceIKX448SK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448SK.txt");
                                AliceEKX25519SK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\EKX25519Or448SK.txt");
                                AliceIKX25519SK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448SK.txt");
                                AliceEKX448PK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\EKX25519Or448PK.txt");
                                AliceIKX448PK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448PK.txt");
                                AliceEKX25519PK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\EKX25519Or448PK.txt");
                                AliceIKX25519PK = File.ReadAllBytes(E2EESenderKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448PK.txt");
                                //If after converting from Base64, its byte size was 227 (First 57 bytes were ED448's public key)
                                //(Second 114 bytes were the signature) (Last 56 bytes were X448's public key) then it's Curve448
                                //else it's Curve25519
                                if (CTB1.Text != null && CTB1.Text.CompareTo("") != 0 && CTB2.Text != null && CTB2.Text.CompareTo("") != 0 && CTB3.Text != null && CTB3.Text.CompareTo("") != 0)
                                {
                                    FirstCryptographyKeyMaterialString = CTB1.Text;
                                    SecondCryptographyKeyMaterialString = CTB2.Text;
                                    ThirdCryptographyKeyMaterialString = CTB3.Text;
                                    MergedSignedBobSPKX25519Or448PK = Convert.FromBase64String(FirstCryptographyKeyMaterialString);
                                    MergedSignedBobIKX25519Or448PK = Convert.FromBase64String(SecondCryptographyKeyMaterialString);
                                    MergedSignedBobOPKX25519Or448PK = Convert.FromBase64String(ThirdCryptographyKeyMaterialString);
                                    if (MergedSignedBobSPKX25519Or448PK.Length == 227 && MergedSignedBobIKX25519Or448PK.Length == 227 && MergedSignedBobOPKX25519Or448PK.Length == 227)
                                    {
                                        BobSPKED25519Or448PK = new Byte[57];
                                        Array.Copy(MergedSignedBobSPKX25519Or448PK, 0, BobSPKED25519Or448PK, 0, 57);
                                        BobIKED25519Or448PK = new Byte[57];
                                        Array.Copy(MergedSignedBobIKX25519Or448PK, 0, BobIKED25519Or448PK, 0, 57);
                                        BobOPKED25519Or448PK = new Byte[57];
                                        Array.Copy(MergedSignedBobOPKX25519Or448PK, 0, BobOPKED25519Or448PK, 0, 57);
                                        SignedBobSPKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 57];
                                        Array.Copy(MergedSignedBobSPKX25519Or448PK, 57, SignedBobSPKX25519Or448PK, 0, SignedBobSPKX25519Or448PK.Length);
                                        SignedBobIKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 57];
                                        Array.Copy(MergedSignedBobIKX25519Or448PK, 57, SignedBobIKX25519Or448PK, 0, SignedBobIKX25519Or448PK.Length);
                                        SignedBobOPKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 57];
                                        Array.Copy(MergedSignedBobOPKX25519Or448PK, 57, SignedBobOPKX25519Or448PK, 0, SignedBobOPKX25519Or448PK.Length);
                                        BobSPKX25519Or448PK = SecureED448.GetMessageFromSignatureMessage(BobSPKED25519Or448PK, SignedBobSPKX25519Or448PK, new Byte[] { });
                                        BobIKX25519Or448PK = SecureED448.GetMessageFromSignatureMessage(BobIKED25519Or448PK, SignedBobIKX25519Or448PK, new Byte[] { });
                                        BobOPKX25519Or448PK = SecureED448.GetMessageFromSignatureMessage(BobOPKED25519Or448PK, SignedBobOPKX25519Or448PK, new Byte[] { });
                                        SharedSecret1 = SecureX448.CalculateSecret(BobSPKX25519Or448PK, AliceIKX448SK, true);
                                        SharedSecret2 = SecureX448.CalculateSecret(BobIKX25519Or448PK, AliceEKX448SK);
                                        SharedSecret3 = SecureX448.CalculateSecret(BobSPKX25519Or448PK, AliceEKX448SK);
                                        SharedSecret4 = SecureX448.CalculateSecret(BobOPKX25519Or448PK, AliceEKX448SK, true);
                                        ConcatedSharedSecret = SharedSecret1.Concat(SharedSecret2).Concat(SharedSecret3).Concat(SharedSecret4).ToArray();
                                        MasterSharedSecret = SodiumKDF.KDFFunction(32, 1, "X3DHSKey", ConcatedSharedSecret, true);
                                        MainConcatedPKs = AliceIKX448PK.Concat(BobIKX25519Or448PK).ToArray();
                                        FirstConcatedPKs = AliceIKX448PK.Concat(BobSPKX25519Or448PK).ToArray();
                                        SecondConcatedPKs = AliceEKX448PK.Concat(BobIKX25519Or448PK).ToArray();
                                        ThirdConcatedPKs = AliceEKX448PK.Concat(BobSPKX25519Or448PK).ToArray();
                                        FourthConcatedPKs = AliceEKX448PK.Concat(BobOPKX25519Or448PK).ToArray();
                                        MainMutualThumbprint = SodiumGenericHash.ComputeHash(64, MainConcatedPKs);
                                        FirstMutualThumbprint = SodiumGenericHash.ComputeHash(64, FirstConcatedPKs);
                                        SecondMutualThumbprint = SodiumGenericHash.ComputeHash(64, SecondConcatedPKs);
                                        ThirdMutualThumbprint = SodiumGenericHash.ComputeHash(64, ThirdConcatedPKs);
                                        FourthMutualThumbprint = SodiumGenericHash.ComputeHash(64, FourthConcatedPKs);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MutualSecurityNumber.txt", MainMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\1stMutualSecurityNumber.txt", FirstMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\2ndMutualSecurityNumber.txt", SecondMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\3rdMutualSecurityNumber.txt", ThirdMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\4thMutualSecurityNumber.txt", FourthMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MasterKey.txt", MasterSharedSecret);
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserType.txt", "Alice/Sender");
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserKeysID.txt", AliceBobPIE2EEID);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret1);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret2);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret3);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret4);
                                        SodiumSecureMemory.SecureClearBytes(MasterSharedSecret);
                                    }
                                    else if (MergedSignedBobSPKX25519Or448PK.Length == 128 && MergedSignedBobIKX25519Or448PK.Length == 128 && MergedSignedBobOPKX25519Or448PK.Length == 128)
                                    {
                                        BobSPKED25519Or448PK = new Byte[32];
                                        Array.Copy(MergedSignedBobSPKX25519Or448PK, 0, BobSPKED25519Or448PK, 0, 32);
                                        BobIKED25519Or448PK = new Byte[32];
                                        Array.Copy(MergedSignedBobIKX25519Or448PK, 0, BobIKED25519Or448PK, 0, 32);
                                        BobOPKED25519Or448PK = new Byte[32];
                                        Array.Copy(MergedSignedBobOPKX25519Or448PK, 0, BobOPKED25519Or448PK, 0, 32);
                                        SignedBobSPKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 32];
                                        Array.Copy(MergedSignedBobSPKX25519Or448PK, 32, SignedBobSPKX25519Or448PK, 0, SignedBobSPKX25519Or448PK.Length);
                                        SignedBobIKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 32];
                                        Array.Copy(MergedSignedBobIKX25519Or448PK, 32, SignedBobIKX25519Or448PK, 0, SignedBobIKX25519Or448PK.Length);
                                        SignedBobOPKX25519Or448PK = new Byte[MergedSignedBobSPKX25519Or448PK.Length - 32];
                                        Array.Copy(MergedSignedBobOPKX25519Or448PK, 32, SignedBobOPKX25519Or448PK, 0, SignedBobOPKX25519Or448PK.Length);
                                        BobSPKX25519Or448PK = SodiumPublicKeyAuth.Verify(SignedBobSPKX25519Or448PK, BobSPKED25519Or448PK);
                                        BobIKX25519Or448PK = SodiumPublicKeyAuth.Verify(SignedBobIKX25519Or448PK, BobIKED25519Or448PK);
                                        BobOPKX25519Or448PK = SodiumPublicKeyAuth.Verify(SignedBobOPKX25519Or448PK, BobOPKED25519Or448PK);
                                        SharedSecret1 = SodiumPublicKeyBox.GenerateSharedSecret(AliceIKX25519SK, BobSPKX25519Or448PK, true);
                                        SharedSecret2 = SodiumPublicKeyBox.GenerateSharedSecret(AliceEKX25519SK, BobIKX25519Or448PK);
                                        SharedSecret3 = SodiumPublicKeyBox.GenerateSharedSecret(AliceEKX25519SK, BobSPKX25519Or448PK);
                                        SharedSecret4 = SodiumPublicKeyBox.GenerateSharedSecret(AliceEKX25519SK, BobOPKX25519Or448PK, true);
                                        ConcatedSharedSecret = SharedSecret1.Concat(SharedSecret2).Concat(SharedSecret3).Concat(SharedSecret4).ToArray();
                                        MasterSharedSecret = SodiumKDF.KDFFunction(32, 1, "X3DHSKey", ConcatedSharedSecret, true);
                                        MainConcatedPKs = AliceIKX25519PK.Concat(BobIKX25519Or448PK).ToArray();
                                        FirstConcatedPKs = AliceIKX25519PK.Concat(BobSPKX25519Or448PK).ToArray();
                                        SecondConcatedPKs = AliceEKX25519PK.Concat(BobIKX25519Or448PK).ToArray();
                                        ThirdConcatedPKs = AliceEKX25519PK.Concat(BobSPKX25519Or448PK).ToArray();
                                        FourthConcatedPKs = AliceEKX25519PK.Concat(BobOPKX25519Or448PK).ToArray();
                                        MainMutualThumbprint = SodiumGenericHash.ComputeHash(64, MainConcatedPKs);
                                        FirstMutualThumbprint = SodiumGenericHash.ComputeHash(64, FirstConcatedPKs);
                                        SecondMutualThumbprint = SodiumGenericHash.ComputeHash(64, SecondConcatedPKs);
                                        ThirdMutualThumbprint = SodiumGenericHash.ComputeHash(64, ThirdConcatedPKs);
                                        FourthMutualThumbprint = SodiumGenericHash.ComputeHash(64, FourthConcatedPKs);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MutualSecurityNumber.txt", MainMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\1stMutualSecurityNumber.txt", FirstMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\2ndMutualSecurityNumber.txt", SecondMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\3rdMutualSecurityNumber.txt", ThirdMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\4thMutualSecurityNumber.txt", FourthMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MasterKey.txt", MasterSharedSecret);
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserType.txt", "Alice/Sender");
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserKeysID.txt", AliceBobPIE2EEID);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret1);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret2);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret3);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret4);
                                        SodiumSecureMemory.SecureClearBytes(MasterSharedSecret);
                                    }
                                    else
                                    {
                                        MessageBox.Show("The cryptography public keys you input does not match with 2 of the available formats", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please input cryptography public keys", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please input any folder name that has not yet exists for the E2EE session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please input a folder name for the E2EE session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (AliceBobE2EEIDCB.SelectedIndex != -1)
                    {
                        if (E2EEFolderNameTB.Text != null && E2EEFolderNameTB.Text.CompareTo("") != 0)
                        {
                            AliceBobPIE2EEID = AliceBobE2EEIDCB.Text;
                            E2EEFolderName = E2EEFolderNameTB.Text;
                            if (Directory.Exists(E2EESessionDirectory + E2EEFolderName) == false)
                            {
                                Directory.CreateDirectory(E2EESessionDirectory + E2EEFolderName);
                                BobSPKX448SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\SPKX25519Or448SK.txt");
                                BobIKX448SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448SK.txt");
                                BobOPKX448SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\OPKX25519Or448SK.txt");
                                BobSPKX25519SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\SPKX25519Or448SK.txt");
                                BobIKX25519SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448SK.txt");
                                BobOPKX25519SK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\OPKX25519Or448SK.txt");
                                BobSPKX448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\SPKX25519Or448PK.txt");
                                BobIKX448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448PK.txt");
                                BobOPKX448PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\OPKX25519Or448PK.txt");
                                BobSPKX25519PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\SPKX25519Or448PK.txt");
                                BobIKX25519PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\IKX25519Or448PK.txt");
                                BobOPKX25519PK = File.ReadAllBytes(E2EERecipientKeysDirectory + AliceBobPIE2EEID + "\\OPKX25519Or448PK.txt");
                                //If after converting from Base64, its byte size was 227 (First 57 bytes were ED448's public key)
                                //(Second 114 bytes were the signature) (Last 56 bytes were X448's public key) then it's Curve448
                                //else it's Curve25519
                                if (CTB1.Text != null && CTB1.Text.CompareTo("") != 0 && CTB2.Text != null && CTB2.Text.CompareTo("") != 0)
                                {
                                    FirstCryptographyKeyMaterialString = CTB1.Text;
                                    SecondCryptographyKeyMaterialString = CTB2.Text;
                                    MergedSignedAliceEKX25519Or448PK = Convert.FromBase64String(FirstCryptographyKeyMaterialString);
                                    MergedSignedAliceIKX25519Or448PK = Convert.FromBase64String(SecondCryptographyKeyMaterialString);
                                    if (MergedSignedAliceEKX25519Or448PK.Length == 227 && MergedSignedAliceIKX25519Or448PK.Length == 227)
                                    {
                                        AliceEKED25519Or448PK = new Byte[57];
                                        Array.Copy(MergedSignedAliceEKX25519Or448PK, 0, AliceEKED25519Or448PK, 0, 57);
                                        AliceIKED25519Or448PK = new Byte[57];
                                        Array.Copy(MergedSignedAliceIKX25519Or448PK, 0, AliceIKED25519Or448PK, 0, 57);
                                        SignedAliceEKX25519Or448PK = new Byte[MergedSignedAliceEKX25519Or448PK.Length - 57];
                                        Array.Copy(MergedSignedAliceEKX25519Or448PK, 57, SignedAliceEKX25519Or448PK, 0, SignedAliceEKX25519Or448PK.Length);
                                        SignedAliceIKX25519Or448PK = new Byte[MergedSignedAliceIKX25519Or448PK.Length - 57];
                                        Array.Copy(MergedSignedAliceIKX25519Or448PK, 57, SignedAliceIKX25519Or448PK, 0, SignedAliceIKX25519Or448PK.Length);
                                        AliceEKX25519Or448PK = SecureED448.GetMessageFromSignatureMessage(AliceEKED25519Or448PK, SignedAliceEKX25519Or448PK, new Byte[] { });
                                        AliceIKX25519Or448PK = SecureED448.GetMessageFromSignatureMessage(AliceIKED25519Or448PK, SignedAliceIKX25519Or448PK, new Byte[] { });
                                        SharedSecret1 = SecureX448.CalculateSecret(AliceIKX25519Or448PK, BobSPKX448SK);
                                        SharedSecret2 = SecureX448.CalculateSecret(AliceEKX25519Or448PK, BobIKX448SK, true);
                                        SharedSecret3 = SecureX448.CalculateSecret(AliceEKX25519Or448PK, BobSPKX448SK, true);
                                        SharedSecret4 = SecureX448.CalculateSecret(AliceEKX25519Or448PK, BobOPKX448SK, true);
                                        ConcatedSharedSecret = SharedSecret1.Concat(SharedSecret2).Concat(SharedSecret3).Concat(SharedSecret4).ToArray();
                                        MasterSharedSecret = SodiumKDF.KDFFunction(32, 1, "X3DHSKey", ConcatedSharedSecret, true);
                                        MainConcatedPKs = AliceIKX25519Or448PK.Concat(BobIKX448PK).ToArray();
                                        FirstConcatedPKs = AliceIKX25519Or448PK.Concat(BobSPKX448PK).ToArray();
                                        SecondConcatedPKs = AliceEKX25519Or448PK.Concat(BobIKX448PK).ToArray();
                                        ThirdConcatedPKs = AliceEKX25519Or448PK.Concat(BobSPKX448PK).ToArray();
                                        FourthConcatedPKs = AliceEKX25519Or448PK.Concat(BobOPKX448PK).ToArray();
                                        MainMutualThumbprint = SodiumGenericHash.ComputeHash(64, MainConcatedPKs);
                                        FirstMutualThumbprint = SodiumGenericHash.ComputeHash(64, FirstConcatedPKs);
                                        SecondMutualThumbprint = SodiumGenericHash.ComputeHash(64, SecondConcatedPKs);
                                        ThirdMutualThumbprint = SodiumGenericHash.ComputeHash(64, ThirdConcatedPKs);
                                        FourthMutualThumbprint = SodiumGenericHash.ComputeHash(64, FourthConcatedPKs);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MutualSecurityNumber.txt", MainMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\1stMutualSecurityNumber.txt", FirstMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\2ndMutualSecurityNumber.txt", SecondMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\3rdMutualSecurityNumber.txt", ThirdMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\4thMutualSecurityNumber.txt", FourthMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MasterKey.txt", MasterSharedSecret);
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserType.txt", "Bob/Recipient");
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserKeysID.txt", AliceBobPIE2EEID);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret1);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret2);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret3);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret4);
                                        SodiumSecureMemory.SecureClearBytes(MasterSharedSecret);
                                    }
                                    else if (MergedSignedAliceEKX25519Or448PK.Length == 128 && MergedSignedAliceIKX25519Or448PK.Length == 128)
                                    {
                                        AliceEKED25519Or448PK = new Byte[32];
                                        Array.Copy(MergedSignedAliceEKX25519Or448PK, 0, AliceEKED25519Or448PK, 0, 32);
                                        AliceIKED25519Or448PK = new Byte[32];
                                        Array.Copy(MergedSignedAliceIKX25519Or448PK, 0, AliceIKED25519Or448PK, 0, 32);
                                        SignedAliceEKX25519Or448PK = new Byte[MergedSignedAliceEKX25519Or448PK.Length - 32];
                                        Array.Copy(MergedSignedAliceEKX25519Or448PK, 32, SignedAliceEKX25519Or448PK, 0, SignedAliceEKX25519Or448PK.Length);
                                        SignedAliceIKX25519Or448PK = new Byte[MergedSignedAliceIKX25519Or448PK.Length - 32];
                                        Array.Copy(MergedSignedAliceIKX25519Or448PK, 32, SignedAliceIKX25519Or448PK, 0, SignedAliceIKX25519Or448PK.Length);
                                        AliceEKX25519Or448PK = SodiumPublicKeyAuth.Verify(SignedAliceEKX25519Or448PK, AliceEKED25519Or448PK);
                                        AliceIKX25519Or448PK = SodiumPublicKeyAuth.Verify(SignedAliceIKX25519Or448PK, AliceIKED25519Or448PK);
                                        SharedSecret1 = SodiumPublicKeyBox.GenerateSharedSecret(BobSPKX25519SK, AliceIKX25519Or448PK);
                                        SharedSecret2 = SodiumPublicKeyBox.GenerateSharedSecret(BobIKX25519SK, AliceEKX25519Or448PK, true);
                                        SharedSecret3 = SodiumPublicKeyBox.GenerateSharedSecret(BobSPKX25519SK, AliceEKX25519Or448PK, true);
                                        SharedSecret4 = SodiumPublicKeyBox.GenerateSharedSecret(BobOPKX25519SK, AliceEKX25519Or448PK, true);
                                        ConcatedSharedSecret = SharedSecret1.Concat(SharedSecret2).Concat(SharedSecret3).Concat(SharedSecret4).ToArray();
                                        MasterSharedSecret = SodiumKDF.KDFFunction(32, 1, "X3DHSKey", ConcatedSharedSecret, true);
                                        MainConcatedPKs = AliceIKX25519Or448PK.Concat(BobIKX25519PK).ToArray();
                                        FirstConcatedPKs = AliceIKX25519Or448PK.Concat(BobSPKX25519PK).ToArray();
                                        SecondConcatedPKs = AliceEKX25519Or448PK.Concat(BobIKX25519PK).ToArray();
                                        ThirdConcatedPKs = AliceEKX25519Or448PK.Concat(BobSPKX25519PK).ToArray();
                                        FourthConcatedPKs = AliceEKX25519Or448PK.Concat(BobOPKX25519PK).ToArray();
                                        MainMutualThumbprint = SodiumGenericHash.ComputeHash(64, MainConcatedPKs);
                                        FirstMutualThumbprint = SodiumGenericHash.ComputeHash(64, FirstConcatedPKs);
                                        SecondMutualThumbprint = SodiumGenericHash.ComputeHash(64, SecondConcatedPKs);
                                        ThirdMutualThumbprint = SodiumGenericHash.ComputeHash(64, ThirdConcatedPKs);
                                        FourthMutualThumbprint = SodiumGenericHash.ComputeHash(64, FourthConcatedPKs);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MutualSecurityNumber.txt", MainMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\1stMutualSecurityNumber.txt", FirstMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\2ndMutualSecurityNumber.txt", SecondMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\3rdMutualSecurityNumber.txt", ThirdMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\4thMutualSecurityNumber.txt", FourthMutualThumbprint);
                                        File.WriteAllBytes(E2EESessionDirectory + E2EEFolderName + "\\MasterKey.txt", MasterSharedSecret);
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserType.txt", "Bob/Recipient");
                                        File.WriteAllText(E2EESessionDirectory + E2EEFolderName + "\\UserKeysID.txt", AliceBobPIE2EEID);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret1);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret2);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret3);
                                        SodiumSecureMemory.SecureClearBytes(SharedSecret4);
                                        SodiumSecureMemory.SecureClearBytes(MasterSharedSecret);
                                    }
                                    else
                                    {
                                        MessageBox.Show("The cryptography public keys you input does not match with 2 of the available formats", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please input cryptography public keys", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please input any folder name that has not yet exists for the E2EE session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please input a folder name for the E2EE session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Are you a sender or recipient?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                AliceBobE2EEIDCB.Items.Clear();
                AliceBobE2EEIDCB.Items.AddRange(SenderKeysID);
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
                AliceBobE2EEIDCB.Items.Clear();
                AliceBobE2EEIDCB.Items.AddRange(RecipientKeysID);
            }
        }
    }
}
