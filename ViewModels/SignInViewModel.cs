using Lab02.Models;
using Lab02.Tools;
using Lab02.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool _isEnabled = true;
        private RelayCommand<object> _proceedCommand;
        private Action _gotoResultView;

        public SignInViewModel(Action gotoResultView)
        {
            _gotoResultView = gotoResultView;
        }

        #endregion

        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<object> ProceedCommand =>
            _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), BoxesFilled);

        #endregion

        internal async void Proceed()
        {
            IsEnabled = false;
            Person person;
            try
            {
                await Task.Delay(1000);
                person = new Person(FirstName, LastName, Email, DateOfBirth);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                IsEnabled = true;
                return;
            }

            if (person.IsIncomplete())
            {
                IsEnabled = true;
                return;
            }
            await Task.Delay(1000);
            StateManager.CurrentPerson = person;
            try
            {
                await Task.Run(() => { Thread.Sleep(3000); });
                _gotoResultView?.Invoke();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private bool BoxesFilled(object obj)
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) &&
                   !String.IsNullOrWhiteSpace(Email);
        }

        #region PropChangedImplementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
