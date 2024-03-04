// BirthdayViewModel.cs
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Lab1CSharp_Frankiv.Models;

namespace Lab1CSharp_Frankiv.ViewModels
{
    public class BirthdayViewModel : INotifyPropertyChanged
    {
        private User _user = new User();
        private RelayCommand<object> _birthdayCommand;

        public int Age
        {
            get { return _user.Age; }
            set
            {
                _user.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string WesternZodiacSign
        {
            get { return _user.WesternZodiacSign; }
            set
            {
                _user.WesternZodiacSign = value;
                OnPropertyChanged(nameof(WesternZodiacSign));
            }
        }

        public string ChineseZodiacSign
        {
            get { return _user.ChineseZodiacSign; }
            set
            {
                _user.ChineseZodiacSign = value;
                OnPropertyChanged(nameof(ChineseZodiacSign));
            }
        }

        public DateTime BirthDate
        {
            get { return _user.BirthDate; }
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public RelayCommand<object> BirthdayCommand
        {
            get { return _birthdayCommand ??= new RelayCommand<object>(_ => Calculate(), CanExecute); }
        }

        private bool CanExecute()
        {
            if (BirthDate == DateTime.MinValue)
            {
                return false;
            }
            return true;
        }

        public void Calculate()
        {
            CalculateAge();
            CalculateZodiacSigns();
        }

        public void CalculateAge()
        {
            int ageCandidate = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now < BirthDate.AddYears(ageCandidate)) ageCandidate--;
            if (ageCandidate < 0 || ageCandidate > 135)
            {
                MessageBox.Show("Enter the valid birth date!!!");
                Age = 0;
                WesternZodiacSign = "";
                ChineseZodiacSign = "";
                return;
            }
            if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day == BirthDate.Day)
            {
                MessageBox.Show("Happy birthday!!!");
            }
            Age = ageCandidate;
        }

        public void CalculateZodiacSigns()
        {
            if (Age == 0)
            {
                return;
            }
            int month = BirthDate.Month;
            int day = BirthDate.Day;
            if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
            {
                WesternZodiacSign = "Capricornus";
            }
            else if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
            {
                WesternZodiacSign = "Aquarius";
            }
            else if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
            {
                WesternZodiacSign = "Pisces";
            }
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                WesternZodiacSign = "Aries";
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                WesternZodiacSign = "Taurus";
            }
            else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
            {
                WesternZodiacSign = "Gemini";
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                WesternZodiacSign = "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                WesternZodiacSign = "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 23))
            {
                WesternZodiacSign = "Virgo";
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
            {
                WesternZodiacSign = "Libra";
            }
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
            {
                WesternZodiacSign = "Scorpio";
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                WesternZodiacSign = "Sagittarius";
            }

            int startYear = 1900;
            string[] chineseZodiacSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            ChineseZodiacSign = chineseZodiacSigns[(_user.BirthDate.Year - startYear) % 12];

       
    }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
