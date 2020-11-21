using System.ComponentModel;
using MyVault.Core;

namespace MyVault.Mobile.Models
{
    public class GeneratePasswordViewModel : INotifyPropertyChanged
    {
        public GeneratePasswordViewModel()
        {
            GeneratedPassword = Password.Generate();
            IncludeSpecialChars = true;
            OnlyUpperCase = false;
        }

        private string generatedPassword;
        public string GeneratedPassword
        {
            get
            {
                return generatedPassword;
            }
            set
            {
                if (generatedPassword != value)
                {
                    generatedPassword = value;
                    OnPropertyChanged("GeneratedPassword");
                }
            }
        }

        private int length = 8;
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (length != value)
                {
                    length = value;
                    OnPropertyChanged("Length");
                }
            }
        }


        private bool includeSpecialChars = true;
        public bool IncludeSpecialChars
        {
            get
            {
                return includeSpecialChars;
            }
            set
            {
                if (includeSpecialChars != value)
                {
                    includeSpecialChars = value;
                    OnPropertyChanged("IncludeSpecialChars");
                }
            }
        }


        private bool onlyUpperCase = false;
        public bool OnlyUpperCase
        {
            get
            {
                return onlyUpperCase;
            }
            set
            {
                if (onlyUpperCase != value)
                {
                    onlyUpperCase = value;
                    OnPropertyChanged("OnlyUpperCase");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)         
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }

        public void Refresh()
        {
            GeneratedPassword = Password.Generate(Length, IncludeSpecialChars, OnlyUpperCase);
        }
    }
}
