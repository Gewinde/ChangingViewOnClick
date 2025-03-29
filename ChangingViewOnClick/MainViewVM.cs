using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingViewOnClick
{
    class MainViewVM : BaseViewModel
    {
        private BaseViewModel _currentViewModel { get; set; }
        private ObservableCollection<BaseViewModel> _navigationList;

        public MainViewVM()
        {
            _navigationList = new ObservableCollection<BaseViewModel>()
            {
                new SubViewVM(),
                new SubSubViewVM()
            };

            SwitchToSubViewCommand = new RelayCommand((o) => ChangeSubView());
            SwitchToSubSubViewCommand = new RelayCommand((o) => ChangeSubSubView());
        }

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if(_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                }
            }
        }
        public ObservableCollection<BaseViewModel> NavigationList
        {
            get => _navigationList;
            set
            {
                if(_navigationList != value)
                {
                    _navigationList = value;
                    OnPropertyChanged(nameof(NavigationList));
                }
            }
        }

        public RelayCommand SwitchToSubViewCommand { get; set; }
        public RelayCommand SwitchToSubSubViewCommand { get; set; }

        private void ChangeSubView()
        {
            foreach(BaseViewModel x in NavigationList)
            {
                if(x.GetType() == typeof(SubViewVM))
                {
                    CurrentViewModel = x;
                }
            }
        }
        private void ChangeSubSubView()
        {
            foreach(BaseViewModel x in NavigationList)
            {
                if(x.GetType() == typeof(SubSubViewVM))
                {
                    CurrentViewModel = x;
                }
            }
        }
    }
}
