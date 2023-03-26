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

        private Action _goBackAction;
        private RelayCommand<object> _returnCommand;
        private RelayCommand<object> _closeCommand;

        #endregion

        public ShowResultsViewModel(Action a)
        {
            _goBackAction = a;
        }

        public ShowResultsViewModel() { }

        #region Properties

        public Person Person => StateManager.CurrentPerson;

        public string FirstName => Person.FirstName;

        public string LastName => Person.LastName;

        public string Email => Person.Email;

        public string DateOfBirth => Person.BirthDate.ToString("d");

        public bool IsAdult => Person.IsAdult;

        public string SunSign => Person.SunSign;

        public string ChineseSign => Person.ChineseSign;

        public bool IsBirthday => Person.IsBirthday;

        public RelayCommand<object> CloseCommand => _closeCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
        public RelayCommand<object> ReturnCommand => _returnCommand ??= new RelayCommand<object>(_ => ReturnBack());

        #endregion

        public void ReturnBack()
        {
            _goBackAction?.Invoke();
        }
    }
}
