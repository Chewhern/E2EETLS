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
    public partial class EncryptWE2EE : Form
    {
        private SecureIDGenerator IDGenerator = new SecureIDGenerator();

        public EncryptWE2EE()
        {
            InitializeComponent();
        }

        private void EncryptWE2EE_Load(object sender, EventArgs e)
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
            PlainTextFileChooserDialog.ShowDialog();
        }

        private void PlainTextFileChooserDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileNameTB.Text = PlainTextFileChooserDialog.SafeFileName;
            int FileSize = File.ReadAllBytes(PlainTextFileChooserDialog.FileName).Length;
            FileSizeTB.Text = FileSize.ToString();
        }

        private async void EncryptBTN_Click(object sender, EventArgs e)
        {
            EncryptedFilesFolderChooserDialog.ShowDialog();
            if(EncryptedFilesFolderChooserDialog.SelectedPath!=null && EncryptedFilesFolderChooserDialog.SelectedPath.CompareTo("") != 0) 
            {
                if (FileNameTB.Text != null && FileNameTB.Text.CompareTo("") != 0 && (DefaultRB.Checked == true || XChaCha20Poly1305RB.Checked == true || AES256GCMRB.Checked == true))
                {
                    int FileSize = int.Parse(FileSizeTB.Text);
                    String StartUpDirectory = Application.StartupPath;
                    String E2EERootDirectory = StartUpDirectory + "\\E2EE";
                    String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
                    String E2EESessionID = E2EESessionFolderCB.Text;
                    String FileName = PlainTextFileChooserDialog.SafeFileName;
                    String DirectoryPath = EncryptedFilesFolderChooserDialog.SelectedPath;
                    String RandomFileName = IDGenerator.GenerateUniqueString();
                    Byte[] Nonce = SodiumSecretBox.GenerateNonce();
                    Byte[] XChaCha20Poly1305Nonce = SodiumSecretBoxXChaCha20Poly1305.GenerateNonce();
                    Byte[] AES256GCMNonce = SodiumSecretAeadAES256GCM.GeneratePublicNonce();
                    Byte[] Key = new Byte[] { };
                    Byte[] PreviousKey = new Byte[] { };
                    Byte[] CurrentKey = new Byte[] { };
                    Byte[] ActualKey = new Byte[] { };
                    Byte[] FileBytes = new Byte[] { };
                    Byte[] EncryptedFileBytes = new Byte[] { };
                    Byte[] CombinedEncryptedFileBytes = new Byte[] { };
                    int ActualProgressBarMaximum = 0;
                    int RachetCount = 0;
                    int RachetLoopCount = 0;
                    String RachetCountString = "";
                    if (Directory.Exists(E2EESessionDirectory + E2EESessionID) == true)
                    {
                        if (FileSize <= FileBytesChunkClass.MaximumChunksFileBytesLength)
                        {
                            if (Directory.Exists(DirectoryPath + "\\Encrypted_Files") == false)
                            {
                                Directory.CreateDirectory(DirectoryPath + "\\Encrypted_Files");
                            }
                            if (RandomFileName.Length > 16)
                            {
                                RandomFileName = RandomFileName.Substring(0, 16);
                            }
                            if (File.Exists(DirectoryPath + "\\Encrypted_Files\\" + RandomFileName + ".cipher") == true)
                            {
                                while (File.Exists(DirectoryPath + "\\Encrypted_Files\\" + RandomFileName + ".cipher") == true)
                                {
                                    RandomFileName = IDGenerator.GenerateUniqueString();
                                    if (RandomFileName.Length > 16)
                                    {
                                        RandomFileName = RandomFileName.Substring(0, 16);
                                    }
                                }
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
                            FileBytes = File.ReadAllBytes(PlainTextFileChooserDialog.FileName);
                            if (DefaultRB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey, true);
                                CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                                File.WriteAllBytes(DirectoryPath + "\\Encrypted_Files\\" + RandomFileName + ".cipher", CombinedEncryptedFileBytes);
                                EncryptionProgressBar.Value = 100;
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey, true);
                                CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                                File.WriteAllBytes(DirectoryPath + "\\Encrypted_Files\\" + RandomFileName + ".cipher", CombinedEncryptedFileBytes);
                                EncryptionProgressBar.Value = 100;
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey, null, null, true);
                                    CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
                                    File.WriteAllBytes(DirectoryPath + "\\Encrypted_Files\\" + RandomFileName + ".cipher", CombinedEncryptedFileBytes);
                                    EncryptionProgressBar.Value = 100;
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
                            if (FileSize % FileBytesChunkClass.MaximumChunksFileBytesLength != 0)
                            {
                                ActualProgressBarMaximum = (FileSize / FileBytesChunkClass.MaximumChunksFileBytesLength) + 1;
                            }
                            else
                            {
                                ActualProgressBarMaximum = FileSize / FileBytesChunkClass.MaximumChunksFileBytesLength;
                            }
                            EncryptionProgressBar.Maximum = ActualProgressBarMaximum;
                            EncryptionProgressBar.Value = 0;
                            EncryptionProgressBar.Step = 1;
                            var progress = new Progress<int>(percent =>
                            {
                                EncryptionProgressBar.PerformStep();
                            });
                            await Task.Run(() => BackGroundEncrypt(progress,E2EESessionID,ref RachetCount));
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
                    MessageBox.Show("You haven't choose a file yet or choose a symmetric encryption algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Please select a folder for storing encrypted files", "Status");
            }            
        }

        public void BackGroundEncrypt(IProgress<int> progress,String E2EEFolderName,ref int RefRachetCount)
        {
            int FileSize = int.Parse(FileSizeTB.Text);
            String DirectoryPath = EncryptedFilesFolderChooserDialog.SelectedPath;
            String FileName = PlainTextFileChooserDialog.SafeFileName;
            String RandomFileName = IDGenerator.GenerateUniqueString();
            if (RandomFileName.Length > 16) 
            {
                RandomFileName = RandomFileName.Substring(0, 16);
            }
            String StartUpDirectory = Application.StartupPath;
            String E2EERootDirectory = StartUpDirectory + "\\E2EE";
            String E2EESessionDirectory = E2EERootDirectory + "\\E2EESession\\";
            String E2EESessionID = E2EEFolderName;
            Boolean HasRemainder = false;
            Boolean GeneralChecker = true;
            Byte[] Nonce = SodiumSecretBox.GenerateNonce();
            Byte[] XChaCha20Poly1305Nonce = SodiumSecretBoxXChaCha20Poly1305.GenerateNonce();
            Byte[] AES256GCMNonce = SodiumSecretAeadAES256GCM.GeneratePublicNonce();
            Byte[] Key = new Byte[] { };
            Byte[] PreviousKey = new Byte[] { };
            Byte[] CurrentKey = new Byte[] { };
            Byte[] ActualKey = new Byte[] { };
            Byte[] FileBytes = new Byte[] { };
            Byte[] EncryptedFileBytes = new Byte[] { };
            Byte[] CombinedEncryptedFileBytes = new Byte[] { };
            FileStream MessageFileStream = File.OpenRead(PlainTextFileChooserDialog.FileName);
            if (Directory.Exists(DirectoryPath + "\\Encrypted_Files") == false)
            {
                Directory.CreateDirectory(DirectoryPath + "\\Encrypted_Files");
            }
            FileStream EncryptedFileStream = File.OpenWrite(EncryptedFilesFolderChooserDialog.SelectedPath+"\\Encrypted_Files\\"+RandomFileName+".cipher");
            int Count = 0;
            int Remainder = 0;
            int LoopCount = 1;
            int EndOfFile = 0;
            int RachetCount = 0;
            int RachetLoopCount = 0;
            String RachetCountString = "";
            Count = FileSize / FileBytesChunkClass.MaximumChunksFileBytesLength;
            Remainder = FileSize % FileBytesChunkClass.MaximumChunksFileBytesLength;
            if (Remainder != 0)
            {
                HasRemainder = true;
                Count += 1;
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
            //==Starting code snippet==
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
            while (LoopCount <= Count)
            {
                Thread.Sleep(100);
                if (HasRemainder == true)
                {
                    if (LoopCount == 1)
                    {
                        if (Count == 1)
                        {
                            FileBytes = new Byte[Remainder];
                            EncryptedFileBytes = new Byte[] { };
                            CombinedEncryptedFileBytes = new Byte[] { };
                            EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                                CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                                CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                    CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
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
                            FileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength];
                            EncryptedFileBytes = new Byte[] { };
                            CombinedEncryptedFileBytes = new Byte[] { };
                            EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                                CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                                CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                    CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
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
                        Nonce = new Byte[] { };
                        XChaCha20Poly1305Nonce = new Byte[] { };
                        AES256GCMNonce = new Byte[] { };
                        Nonce = SodiumSecretBox.GenerateNonce();
                        XChaCha20Poly1305Nonce = SodiumSecretBoxXChaCha20Poly1305.GenerateNonce();
                        AES256GCMNonce = SodiumSecretAeadAES256GCM.GeneratePublicNonce();
                        if (LoopCount == Count)
                        {
                            FileBytes = new Byte[Remainder];
                            EncryptedFileBytes = new Byte[] { };
                            CombinedEncryptedFileBytes = new Byte[] { };
                            EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                                CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                                CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                    CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
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
                            FileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength];
                            EncryptedFileBytes = new Byte[] { };
                            CombinedEncryptedFileBytes = new Byte[] { };
                            EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                            if (DefaultRB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                                CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (XChaCha20Poly1305RB.Checked == true)
                            {
                                EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                                CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            if (AES256GCMRB.Checked == true)
                            {
                                if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                                {
                                    EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                    CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
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
                    FileBytes = new Byte[FileBytesChunkClass.MaximumChunksFileBytesLength];
                    EncryptedFileBytes = new Byte[] { };
                    CombinedEncryptedFileBytes = new Byte[] { };
                    if (LoopCount == 1)
                    {
                        EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                        if (DefaultRB.Checked == true)
                        {
                            EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                            CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                        }
                        if (XChaCha20Poly1305RB.Checked == true)
                        {
                            EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                        }
                        if (AES256GCMRB.Checked == true)
                        {
                            if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                            {
                                EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
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
                        Nonce = new Byte[] { };
                        XChaCha20Poly1305Nonce = new Byte[] { };
                        AES256GCMNonce = new Byte[] { };
                        Nonce = SodiumSecretBox.GenerateNonce();
                        XChaCha20Poly1305Nonce = SodiumSecretBoxXChaCha20Poly1305.GenerateNonce();
                        AES256GCMNonce = SodiumSecretAeadAES256GCM.GeneratePublicNonce();
                        EndOfFile = MessageFileStream.Read(FileBytes, 0, FileBytes.Length);
                        if (DefaultRB.Checked == true)
                        {
                            EncryptedFileBytes = SodiumSecretBox.Create(FileBytes, Nonce, ActualKey);
                            CombinedEncryptedFileBytes = Nonce.Concat(EncryptedFileBytes).ToArray();
                        }
                        if (XChaCha20Poly1305RB.Checked == true)
                        {
                            EncryptedFileBytes = SodiumSecretBoxXChaCha20Poly1305.Create(FileBytes, XChaCha20Poly1305Nonce, ActualKey);
                            CombinedEncryptedFileBytes = XChaCha20Poly1305Nonce.Concat(EncryptedFileBytes).ToArray();
                        }
                        if (AES256GCMRB.Checked == true)
                        {
                            if (SodiumSecretAeadAES256GCM.IsAES256GCMAvailable() == true)
                            {
                                EncryptedFileBytes = SodiumSecretAeadAES256GCM.Encrypt(FileBytes, AES256GCMNonce, ActualKey);
                                CombinedEncryptedFileBytes = AES256GCMNonce.Concat(EncryptedFileBytes).ToArray();
                            }
                            else
                            {
                                GeneralChecker = false;
                                break;
                            }
                        }
                    }
                }
                if (progress != null)
                {
                    progress.Report(LoopCount);
                }
                EncryptedFileStream.Write(CombinedEncryptedFileBytes, 0, CombinedEncryptedFileBytes.Length);
                LoopCount += 1;
            }
            if (GeneralChecker == true)
            {
                MessageBox.Show("Backgound encryption process completed"+Environment.NewLine+"The random generated file name for confusion is "+RandomFileName, "Encryption Progress Status Report");
            }
            RefRachetCount = RachetCount;
            MessageFileStream.Close();
            EncryptedFileStream.Close();
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
