
using System.ComponentModel;

namespace Lab1CSharp_Frankiv.Models
{
    public class User : INotifyPropertyChanged
    {
        private DateTime _birthDate;
        private int _age;
        private string _westernZodiacSign;
        private string _chineseZodiacSign;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string WesternZodiacSign
        {
            get { return _westernZodiacSign; }
            set
            {
                _westernZodiacSign = value;
                OnPropertyChanged(nameof(WesternZodiacSign));
            }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiacSign; }
            set
            {
                _chineseZodiacSign = value;
                OnPropertyChanged(nameof(ChineseZodiacSign));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
