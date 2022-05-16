using MinimalMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using UserLogin;

namespace StudentInfoSystem
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private DelegateCommand loginCommand;
        private User user;
        private Action CloseDelegate;
        public User User
        {
            get => user;

            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public DelegateCommand LoginCommand => loginCommand ?? (loginCommand = new DelegateCommand(Login1));

        public delegate void Login(User user);

        private Login login;

        public LoginViewModel(Login login, Action closeDelegate)
        {
            this.CloseDelegate = closeDelegate;
            this.login = login;
            User = new User();
        }


        private void Login1()
        {
            LoginValidation loginValidation = new LoginValidation(User.Username, User.Password, UserLogin.Program.Message);
            User validatedUser;
            if (loginValidation.ValidateUserInput(out validatedUser))
            {
                login?.Invoke(validatedUser);
                CloseDelegate?.Invoke();
            }
            else
            {
                MessageBox.Show("Invalid data");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
