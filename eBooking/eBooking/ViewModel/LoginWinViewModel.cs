using CommunityToolkit.Mvvm.Input;
using eBooking.Model;
using eBooking.Repository;
using eBooking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace eBooking.ViewModel
{
    public class LoginWinViewModel
    {
        private readonly UserRepository userRepository;
        CustomerMainWin customerMainWin;

        public string usernameInput { get; set; }
        public PasswordBox passwordInput { get; set; }

        public ICommand MinimizeCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginWinViewModel(PasswordBox passwordInput) 
        {
            customerMainWin = new CustomerMainWin();    
            userRepository = new UserRepository();
            this.passwordInput = passwordInput;

            MinimizeCommand = new RelayCommand(MinimizeExecute);
            ExitCommand = new RelayCommand(ExitExecute);
            LoginCommand = new RelayCommand(LoginExecute);
        }

        private void MinimizeExecute()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ExitExecute()
        {
            Application.Current.Shutdown();
        }

        private void LoginExecute()
        {
            User user = userRepository.GetUserByUsername(usernameInput);

            if (user != null && user.password == passwordInput.Password)
            {
                App.Current.MainWindow.Close();
                customerMainWin.Show();                               
            }
            else
            {
                MessageBox.Show("Wrong username or password.");
            }                                       
        }    
    }
}
