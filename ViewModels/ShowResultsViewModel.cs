using Lab02.Models;
using Lab02.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.ViewModels
{
    internal class ShowResultsViewModel
    {
        #region Fields

        private Action _gotoFormView;
        private RelayCommand<object> _returnCommand;

        #endregion

        public ShowResultsViewModel(Action gotoFormView)
        {
            _gotoFormView = gotoFormView;
        }

        #region Properties

        public Person Person => StateManager.CurrentPerson;

        public string FirstName => Person.FirstName;

        public string LastName => Person.LastName;

        public string Email => Person.Email;

        public DateTime DateOfBirth => Person.BirthDate;

        public bool IsAdult => Person.IsAdult;

        public string WesternZodiac => Person.WesternZodiac;

        public string ChineseZodiac => Person.ChineseZodiac;

        public bool IsBirthday => Person.IsBirthday;

        public RelayCommand<object> ReturnCommand => _returnCommand ??= new RelayCommand<object>(_ => ReturnToForm());

        #endregion

        public void ReturnToForm()
        {
            _gotoFormView?.Invoke();
        }
    }
}
