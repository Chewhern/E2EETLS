using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASodium;
using System.IO;
using E2EETLS.Helper;
using System.Threading;

namespace E2EETLS
{
    public partial class DecryptWE2EE : Form
    {
        public DecryptWE2EE()
        {
            InitializeComponent();
        }

        private void DecryptWE2EE_Load(object sender, EventArgs e)
        {
            ReloadE2EESessionIDs();
        }

        private void E2EESessionFolderCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E2EESessionFolderCB.SelectedIndex != -1)
            {
                MessageBox.Show(E2EESessionFolderCB.Text, "Selected E2EE Session ID/Folder");
            }
        }

        private void ChooseFileBTN_Click(object sender, EventArgs e)
        {
            EncryptedFileChooserDialog.ShowDialog();
        }

        private void EncryptedFileChooserDialog_FileOk(object sender, CancelEventArgs e)
        {
            int FileSize = File.ReadAllBytes(EncryptedFileChooserDialog.FileName).Length;
            FileSizeTB.Text = FileSize.ToString();
        }

        private async void DecryptBTN_Click(object sender, EventArgs e)
        {
            DecryptedFilesFolderChooserDialog.ShowDialog();
            if (DecryptedFilesFolderChooserDialog.SelectedPath != null && DecryptedFilesFolderChooserDialog.SelectedPath.CompareTo("") != 0)
            {
                if (OriginalFileNameTB.Text!=null && OriginalFileNameTB.Text.CompareTo("")!=0 && (DefaultRB.Checked == true || XChaCha20Poly1305RB.Checked == true || AES256GCMRB.Checked == true))
                {
                    int FileSize = int.Parse(FileSizeTB.Text);
                    String StartUpDirectory = Application.StartupPath;
                    String E2EERootDirectory = StartUpDirectory + "\\E2EE";
                    String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
                    String E2EESessionID = E2EESessionFolderCB.Text;
                    String DirectoryPath = DecryptedFilesFolderChooserDialog.SelectedPath;
                    String FileName = EncryptedFileChooserDialog.SafeFileName;
                    String OriginalFileName = OriginalFileNameTB.Text;
                    Byte[] Nonce = SodiumSecretBox.GenerateNonce();
                    Byte[] XChaCha20Poly1305Nonce = SodiumSecretBoxXChaCha20Poly1305.GenerateNonce();
                    Byte[] AES256GCMNonce = SodiumSecretAeadAES256GCM.GeneratePublicNonce();
                    Byte[] Key = new Byte[] { };
                    Byte[] PreviousKey = new Byte[] { };
                    Byte[] CurrentKey = new Byte[] { };
                    Byte[] ActualKey = new Byte[] { };
                    Byte[] UnfilterEncryptedFileBytes = new Byte[] { };
                    Byte[] EncryptedFileBytes = new Byte[] { };
                    Byte[] FileBytes = new Byte[] { };
                    int ActualProgressBarMaximum = 0;
                    int RachetCount = 0;
                    int RachetLoopCount = 0;
                    String RachetCountString = "";
                    if (Directory.Exists(E2EESessionDirectory + E2EESessionID) == true)
                    {
                        if (FileSize <= FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength)
                        {
                            if (Directory.Exists(DirectoryPath + "\\Decrypted_Files") == false)
                            {
                                Directory.CreateDirectory(DirectoryPath + "\\Decrypted_Files");
                            }
                            if (File.Exists(E2EESessionDirectory + E2EESessionFolderCB.Text + "\\RachetCount.txt") == false)
                            {
                                File.WriteAllText(E2EESessionDirectory + E2EESessionFolderCB.Text + "\\RachetCount.txt", RachetCount.ToString());
                            }
                            else
                            {
                                RachetCountString = File.ReadAllText(E2EESessionDirectory + E2EESessionFolderCB.Text + "\\RachetCount.txt");
                                RachetCount = int.Parse(RachetCountString);
                            }
                            RachetCount += 1;
                            File.WriteAllText(E2EESessionDirectory + E2EESessionFolderCB.Text + "\\RachetCount.txt", RachetCount.ToString());
                            Key = File.ReadAllBytes(E2EESessionDirectory + E2EESessionFolderCB.Text + "\\MasterKey.txt");
                            while (RachetLoopCount < RachetCount)
                            {
                                if (RachetCount == 1)
                                {
                                    ActualKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", Key, true);
                                }
                                else
                                {
                                    if (RachetCount == 1)
                                    {
                                        CurrentKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", Key, true);
                                    }
                                    else
                                    {
                                        PreviousKey = CurrentKey;
                                        CurrentKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", PreviousKey, true);
                                    }
                                    ActualKey = CurrentKey;
                                }
                                RachetLoopCount += 1;
                            }
                            UnfilterEncryptedFileBytes = File.ReadAllBytes(EncryptedFileChooserDialog.FileName);
                            if (DefaultRB.Checked == true)
                            {
                                Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey, true);
                                File.WriteAllBytes(DirectoryPath + "\\Decrypted_Files\\" + OriginalFileName, FileBytes);
                                DecryptionProgressBar.Value = 100;
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey, true);
                                File.WriteAllBytes(DirectoryPath + "\\Decrypted_Files\\" + OriginalFileName, FileBytes);
                                DecryptionProgressBar.Value = 100;
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                    EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - AES256GCMNonce.Length];
                                    Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, AES256GCMNonce.Length);
                                    Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                    FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey, null, null, true);
                                    File.WriteAllBytes(DirectoryPath + "\\Decrypted_Files\\" + OriginalFileName, FileBytes);
                                    DecryptionProgressBar.Value = 100;
                                }
                                else
                                {
                                    MessageBox.Show("Your device does not support AES256 GCM", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            RachetCountTB.Text = RachetCount.ToString();
                        }
                        else
                        {
                            if (DefaultRB.Checked == true || XChaCha20Poly1305RB.Checked == true)
                            {
                                if (FileSize % FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength != 0)
                                {
                                    ActualProgressBarMaximum = (FileSize / FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength) + 1;
                                }
                                else
                                {
                                    ActualProgressBarMaximum = FileSize / FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength;
                                }
                            }
                            else
                            {
                                if (FileSize % (FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength()) != 0)
                                {
                                    ActualProgressBarMaximum = FileSize / (FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength()) + 1;
                                }
                                else
                                {
                                    ActualProgressBarMaximum = FileSize / (FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength());
                                }
                            }
                            DecryptionProgressBar.Maximum = ActualProgressBarMaximum;
                            DecryptionProgressBar.Value = 0;
                            DecryptionProgressBar.Step = 1;
                            var progress = new Progress<int>(percent =>
                            {
                                DecryptionProgressBar.PerformStep();
                            });
                            await Task.Run(() => BackGroundDecrypt(progress, E2EESessionID, ref RachetCount,OriginalFileName));
                            RachetCountTB.Text = RachetCount.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This chosen E2EE session does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You haven't choose a file yet/ choose a symmetric encryption algorithm/ type in the original file name with its extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a folder for storing decrypted files", "Status");
            }
        }

        public void BackGroundDecrypt(IProgress<int> progress, String E2EEFolderName, ref int RefRachetCount, String CopiedFileName)
        {
            int FileSize = int.Parse(FileSizeTB.Text);
            String DirectoryPath = DecryptedFilesFolderChooserDialog.SelectedPath;
            String FileName = EncryptedFileChooserDialog.SafeFileName;
            String OriginalFileName = CopiedFileName;
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
            String E2EESessionID = E2EEFolderName;
            Boolean HasRemainder = false;
            Boolean GeneralChecker = true;
            Byte[] Nonce = new Byte[] { };
            Byte[] XChaCha20Poly1305Nonce = new Byte[] { };
            Byte[] AES256GCMNonce = new Byte[] { };
            Byte[] Key = new Byte[] { };
            Byte[] PreviousKey = new Byte[] { };
            Byte[] CurrentKey = new Byte[] { };
            Byte[] ActualKey = new Byte[] { };
            Byte[] FileBytes = new Byte[] { };
            Byte[] EncryptedFileBytes = new Byte[] { };
            Byte[] UnfilterEncryptedFileBytes = new Byte[] { };
            FileStream EncryptedFileStream = File.OpenRead(EncryptedFileChooserDialog.FileName);
            FileStream DecryptedFileStream;
            int Count = 0;
            int Remainder = 0;
            int LoopCount = 1;
            int EndOfFile = 0;
            int RachetCount = 0;
            int RachetLoopCount = 0;
            String RachetCountString = "";
            if (Directory.Exists(DirectoryPath + "\\Decrypted_Files") == false)
            {
                Directory.CreateDirectory(DirectoryPath + "\\Decrypted_Files");
            }
            if(DefaultRB.Checked==true|| XChaCha20Poly1305RB.Checked == true) 
            {
                Count = FileSize / FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength;
                Remainder = FileSize % FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength;
                if (Remainder != 0)
                {
                    HasRemainder = true;
                    Count += 1;
                }
            }
            else 
            {
                Count = FileSize / FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength();
                Remainder = FileSize % FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength();
                if (Remainder != 0)
                {
                    HasRemainder = true;
                    Count += 1;
                }
            }            
            Key = File.ReadAllBytes(E2EESessionDirectory + E2EESessionID + "\\MasterKey.txt");
            if (File.Exists(E2EESessionDirectory + E2EESessionID + "\\RachetCount.txt") == false)
            {
                File.WriteAllText(E2EESessionDirectory + E2EESessionID + "\\RachetCount.txt", RachetCount.ToString());
            }
            else
            {
                RachetCountString = File.ReadAllText(E2EESessionDirectory + E2EESessionID + "\\RachetCount.txt");
                RachetCount = int.Parse(RachetCountString);
            }
            RachetCount += 1;
            File.WriteAllText(E2EESessionDirectory + E2EESessionID + "\\RachetCount.txt", RachetCount.ToString());
            //==Signal's KDF rachet Part 1==
            //Following code snippet was following
            //Signal's KDF rachet
            //which provides forward secrecy
            //However, for perfect future forward secrecy
            //users are advised to delete sessions
            //with any of the duration of 7 days,14 days
            //or 1 month
            //This is only valid before alien quantum
            //computer exists.
            while (RachetLoopCount < RachetCount)
            {
                if (RachetCount == 1)
                {
                    ActualKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", Key, true);
                }
                else
                {
                    if (RachetCount == 1)
                    {
                        CurrentKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", Key, true);
                    }
                    else
                    {
                        PreviousKey = CurrentKey;
                        CurrentKey = SodiumKDF.KDFFunction(32, 1, "X3DHUKDF", PreviousKey, true);
                    }
                    ActualKey = CurrentKey;
                }
                RachetLoopCount += 1;
            }
            //==Ending code snippet==
            DecryptedFileStream = File.OpenWrite(DecryptedFilesFolderChooserDialog.SelectedPath + "\\Decrypted_Files\\" + OriginalFileName);
            while (LoopCount <= Count)
            {
                Thread.Sleep(100);                
                if (HasRemainder == true)
                {
                    if (LoopCount == 1)
                    {
                        if (Count == 1)
                        {
                            EncryptedFileBytes = new Byte[] { };
                            UnfilterEncryptedFileBytes = new Byte[Remainder];
                            EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length-Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey);
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                    EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length-AES256GCMNonce.Length];
                                    Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, XChaCha20Poly1305Nonce.Length);
                                    Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                    FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey);
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            EncryptedFileBytes = new Byte[] { };
                            EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                            EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey);
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                    EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - AES256GCMNonce.Length];
                                    Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, XChaCha20Poly1305Nonce.Length);
                                    Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                    FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey);
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (LoopCount == Count)
                        {
                            EncryptedFileBytes = new Byte[] { };
                            UnfilterEncryptedFileBytes = new Byte[Remainder];
                            EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey);
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                    EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - AES256GCMNonce.Length];
                                    Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, XChaCha20Poly1305Nonce.Length);
                                    Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                    FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey);
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            EncryptedFileBytes = new Byte[] { };
                            if (DefaultRB.Checked == true)
                            {
                                UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                            EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey);
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                                EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                                Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                                Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                                    EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - AES256GCMNonce.Length];
                                    Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, XChaCha20Poly1305Nonce.Length);
                                    Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                                    FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey);
                                }
                                else
                                {
                                    GeneralChecker = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    EncryptedFileBytes = new Byte[] { };
                    if (DefaultRB.Checked == true)
                    {
                        UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                    }
                    if (XChaCha20Poly1305RB.Checked == true)
                    {
                        UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.NonceMaximumChunksFileBytesWithMACLength];
                    }
                    if (AES256GCMRB.Checked == true)
                    {
                        if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                        {
                            UnfilterEncryptedFileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength + SodiumSecretAeadAES256GCM.GetABytesLength() + SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                        }
                        else
                        {
                            GeneralChecker = false;
                            break;
                        }
                    }
                    EndOfFile = EncryptedFileStream.Read(UnfilterEncryptedFileBytes, 0, UnfilterEncryptedFileBytes.Length);
                    if (DefaultRB.Checked == true)
                    {
                        Nonce = new Byte[SodiumSecretBox.GenerateNonce().Length];
                        EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - Nonce.Length];
                        Array.Copy(UnfilterEncryptedFileBytes, 0, Nonce, 0, Nonce.Length);
                        Array.Copy(UnfilterEncryptedFileBytes, Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                        FileBytes = SodiumSecretBox.Open(EncryptedFileBytes, Nonce, ActualKey);
                    }
                    if (XChaCha20Poly1305RB.Checked == true)
                    {
                        XChaCha20Poly1305Nonce = new Byte[SodiumSecretBoxXChaCha20Poly1305.GetNonceBytesLength()];
                        EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - XChaCha20Poly1305Nonce.Length];
                        Array.Copy(UnfilterEncryptedFileBytes, 0, XChaCha20Poly1305Nonce, 0, XChaCha20Poly1305Nonce.Length);
                        Array.Copy(UnfilterEncryptedFileBytes, XChaCha20Poly1305Nonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                        FileBytes = SodiumSecretBoxXChaCha20Poly1305.Open(EncryptedFileBytes, XChaCha20Poly1305Nonce, ActualKey);
                    }
                    if (AES256GCMRB.Checked == true)
                    {
                        if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                        {
                            AES256GCMNonce = new Byte[SodiumSecretAeadAES256GCM.GetNoncePublicLength()];
                            EncryptedFileBytes = new Byte[UnfilterEncryptedFileBytes.Length - AES256GCMNonce.Length];
                            Array.Copy(UnfilterEncryptedFileBytes, 0, AES256GCMNonce, 0, XChaCha20Poly1305Nonce.Length);
                            Array.Copy(UnfilterEncryptedFileBytes, AES256GCMNonce.Length, EncryptedFileBytes, 0, EncryptedFileBytes.Length);
                            FileBytes = SodiumSecretAeadAES256GCM.Decrypt(EncryptedFileBytes, AES256GCMNonce, ActualKey);
                        }
                        else
                        {
                            GeneralChecker = false;
                            break;
                        }
                    }
                }
                if (progress != null)
                {
                    progress.Report(LoopCount);
                }
                DecryptedFileStream.Write(FileBytes, 0, FileBytes.Length);
                LoopCount += 1;
            }
            if (GeneralChecker == true)
            {
                MessageBox.Show("Backgound decryption process completed" + Environment.NewLine + "The original file name for the encrypted file was " + OriginalFileName, "Decryption Progress Status Report");
            }
            RefRachetCount = RachetCount;
            EncryptedFileStream.Close();
            DecryptedFileStream.Close();
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
