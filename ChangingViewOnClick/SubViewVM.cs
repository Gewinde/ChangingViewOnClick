
using System.Collections.ObjectModel;

namespace ChangingViewOnClick
{
    class SubViewVM : BaseViewModel
    {
        //private IDialogService _dialogService;

        private Ingredient _selectedIngredient;
        private ObservableCollection<Ingredient> _ingredientList;

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
            OpenDialogWindow?.Invoke(this, EventArgs.Empty);
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
