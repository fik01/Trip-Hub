using CommunityToolkit.Mvvm.Input;
using eBooking.Model;
using eBooking.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace eBooking.ViewModel
{
    public class CustomerMainWinViewModel : INotifyPropertyChanged
    {
        public ICommand MinimizeCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        TourRepository tourRepository;

        private string searchLocation;
        private int searchDuration;
        private string searchLanguage;
        private int searchGuestNumber;
        public ObservableCollection<Tour> tours { get; set; }
        public CustomerMainWinViewModel()
        {
            tourRepository = new TourRepository();
            tours = new ObservableCollection<Tour>(tourRepository.GetAll());

            MinimizeCommand = new RelayCommand(MinimizeExecute);
            ExitCommand = new RelayCommand(ExitExecute);
        }

        private void MinimizeExecute()
        {
            //Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ExitExecute()
        {
            Application.Current.Shutdown();
        }

        public string SearchLocation
        {
            get { return searchLocation; }
            set
            {
                searchLocation = value;
                OnPropertyChanged(nameof(filteredData));
            }
        }

        public int SearchDuration
        {
            get { return searchDuration; }
            set
            {
                searchDuration = value;
                OnPropertyChanged(nameof(filteredData));
            }
        }
        public string SearchLanguage
        {
            get { return searchLanguage; }
            set
            {
                searchLanguage = value;
                OnPropertyChanged(nameof(filteredData));
            }
        }
        public int SearchGuestNumber
        {
            get { return searchGuestNumber; }
            set
            {
                searchGuestNumber = value;
                OnPropertyChanged(nameof(filteredData));
            }
        }

        public ObservableCollection<Tour> filteredData
        {
            get
            {
                var result = tours;

                if (!string.IsNullOrEmpty(searchLocation))
                {
                    result = new ObservableCollection<Tour>(result.Where(t => t.city.ToLower().Contains(searchLocation)));
                }

                if (searchDuration != 0)
                {
                    result = new ObservableCollection<Tour>(result.Where(t => t.duration == searchDuration));
                }

                if (!string.IsNullOrEmpty(searchLanguage))
                {
                    result = new ObservableCollection<Tour>(result.Where(t => t.language.ToLower().Contains(searchLanguage)));
                }

                if (searchGuestNumber != 0)
                {
                    result = new ObservableCollection<Tour>(result.Where(t => t.maxGuests >= searchGuestNumber));
                }

                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
