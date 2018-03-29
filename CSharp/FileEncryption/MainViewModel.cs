using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileEncryption
{
    public sealed class MainViewModel : ViewModel
    {
        private string currentFolder;
        private string encryptDecryptLabel;
        private EncryptionService encryption;
        private HashingService hashing;
        private string hashresult;
        private string message;
        private string selectedHashtype = "MD5";
        private string selectedFolder = string.Empty;
        private string selectedFile = string.Empty;

        public MainViewModel(EncryptionService encryptionService, HashingService hashingService)
        {
            encryption = encryptionService;
            hashing = hashingService;
            DoubleClickCommand = new DelegateCommand<string>(DoubleClickExecute);
            EncryptDecryptCommand = new DelegateCommand<string>(EncryptDecryptExecute);
            HashCommand = new DelegateCommand<string>(HashExecute);

            EncryptDecryptLabel = "Encrypt";
            CurrentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public DelegateCommand<string> DoubleClickCommand { get; private set; }

        public DelegateCommand<string> EncryptDecryptCommand { get; private set; }

        public DelegateCommand<string> HashCommand { get; private set; }

        public string CurrentFolder
        {
            get
            {
                return currentFolder;
            }

            private set
            {
                if (currentFolder != value)
                {
                    currentFolder = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Folders");
                    NotifyPropertyChanged("Files");
                }
            }
        }

        public string EncryptDecryptLabel
        {
            get
            {
                return encryptDecryptLabel;
            }

            private set
            {
                if (encryptDecryptLabel != value)
                {
                    encryptDecryptLabel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public IEnumerable<string> Files
        {
            get
            {
                try
                {
                    Message = string.Empty;
                    return Directory.EnumerateFiles(CurrentFolder + SelectedFolder).Select(x => Path.GetFileName(x));
                }
                catch (UnauthorizedAccessException)
                {
                    Message = "Unauthorized access.";
                    return Enumerable.Empty<string>();
                }
            }
        }

        public IEnumerable<string> Folders
        {
            get
            {
                IEnumerable<string> up = new List<string> { ".." };
                IEnumerable<string> directories;

                try
                {
                    directories = Directory.EnumerateDirectories(CurrentFolder).Select(x => Path.GetFileName(x));
                }
                catch (UnauthorizedAccessException)
                {
                    Message = "Unauthorized access.";
                    CurrentFolder = Path.GetFullPath(Path.Combine(CurrentFolder, @"..\"));
                    directories = Directory.EnumerateDirectories(CurrentFolder).Select(x => Path.GetFileName(x));
                }

                return up.Concat(directories);
            }
        }

        public IEnumerable<string> Hashtypes
        {
            get
            {
                return new List<string> { "MD5", "SHA256", "SHA512" };
            }
        }

        public string Hashresult
        {
            get
            {
                return hashresult;
            }

            private set
            {
                if (hashresult != value)
                {
                    hashresult = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            private set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public string SelectedHashtype
        {
            get
            {
                return selectedHashtype;
            }

            set
            {
                if (selectedHashtype != value)
                {
                    selectedHashtype = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SelectedFolder
        {
            get
            {
                return selectedFolder;
            }

            set
            {
                if (selectedFolder != value)
                {
                    selectedFolder = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Files");
                }
            }
        }

        public string SelectedFile
        {
            get
            {
                return selectedFile;
            }

            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;

                    if (selectedFile != null)
                    {
                        FileAttributes attributes = File.GetAttributes(Path.GetFullPath(Path.Combine(CurrentFolder, SelectedFolder, selectedFile)));
                        EncryptDecryptLabel = (attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted ? "Decrypt" : "Encrypt";
                    }

                    NotifyPropertyChanged();
                }
            }
        }

        private void DoubleClickExecute(string chosenDirectory)
        {
            CurrentFolder = Path.GetFullPath(Path.Combine(CurrentFolder, $"{chosenDirectory}\\"));
        }

        private void EncryptDecryptExecute(string parameter)
        {
            if (SelectedFile == null)
            {
                Debug.WriteLine(SelectedFile);
                Message = "Choose a file.";
                return;
            }

            string path = Path.GetFullPath(Path.Combine(CurrentFolder, SelectedFolder, SelectedFile));

            if (EncryptDecryptLabel == "Encrypt")
            {
                encryption.EncryptFile(path);
                EncryptDecryptLabel = "Decrypt";
            }
            else
            {
                encryption.DecryptFile(path);
                EncryptDecryptLabel = "Encrypt";
            }
        }

        private void HashExecute(string parameter)
        {
            if (SelectedHashtype == null)
            {
                Message = "Choose hash type.";
                return;
            }
            else if (SelectedFile == null)
            {
                Message = "Choose file.";
                return;
            }

            Message = string.Empty;
            string path = Path.GetFullPath(Path.Combine(CurrentFolder, SelectedFolder, SelectedFile));
            byte[] hash;

            if (SelectedHashtype == "MD5")
                hash = hashing.HashWithMD5(path);
            else if (SelectedHashtype == "SHA256")
                hash = hashing.HashWithSHA256(path);
            else if (SelectedHashtype == "SHA512")
                hash = hashing.HashWithSHA512(path);
            else
                throw new ArgumentException("Unsupported hashtype selected.");

            Hashresult = BitConverter.ToString(hash);
        }
    }
}
