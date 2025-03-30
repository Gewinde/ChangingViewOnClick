
using System.Collections.ObjectModel;
using System.Windows;

namespace ChangingViewOnClick
{
    class SubViewVM : BaseViewModel
    {
        //private IDialogService _dialogService;

        private Ingredient _selectedIngredient;
        private ObservableCollection<Ingredient> _ingredientList;
        private Window _mainWindow = Application.Current.MainWindow;

        public SubViewVM()
        {
            //Sollte in die Methode zum öffnen injected werden
            //_dialogService = new ShowDialogService();

            _ingredientList = new ObservableCollection<Ingredient>();
            DBCreation();

            DeleteIngredientCommand = new RelayCommand((o) => DeleteIngredientFromList((Ingredient)o));
            //OpenEditIngredientDialogCommand = new RelayCommand((o) => OpenEditIngredientDialog((Ingredient) o));
            OpenEditIngredientDialogCommand = new RelayCommand((o) => OpenIngredientEditor());
        }

        public RelayCommand DeleteIngredientCommand { get; set; }
        public RelayCommand OpenEditIngredientDialogCommand { get; set; }

        public Ingredient SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                if (_selectedIngredient != value)
                {
                    _selectedIngredient = value;
                    OnPropertyChanged(nameof(SelectedIngredient));
                }
            }
        }
        public ObservableCollection<Ingredient> IngredientList
        {
            get => _ingredientList;
            set
            {
                if(_ingredientList != value)
                {
                    _ingredientList = value;
                    OnPropertyChanged(nameof(IngredientList));
                }
            }
        }

        //private void OpenEditIngredientDialog(Ingredient x)
        //{
        //    _dialogService.ShowDialog();
        //}

        public event EventHandler OpenDialogWindow;

        private void OpenIngredientEditor()
        {
            var dialog = new IngredientEditorView
            {
                Owner = _mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            dialog.ShowDialog();
        }

        private void DeleteIngredientFromList(Ingredient x)
        {
            IngredientList.Remove(x);
        }

        private void DBCreation()
        {
            IngredientDataBase x = new IngredientDataBase();
            IngredientList = x.DataBase;
        }
    }
}
