

using System.Windows;

namespace ChangingViewOnClick
{
    class IngredientEditorViewVM : BaseViewModel
    {
        private Ingredient _ingredientToEdit;
        private string _newIngredientName;

        public IngredientEditorViewVM()
        {
            EditIngredientCommand = new RelayCommand((o) => AddEditIngredientToList((Ingredient) o));
            //CloseDialogWindow = new RelayCommand((o) => CloseDialog());
        }

        public Ingredient IngredientToEdit
        {
            get => _ingredientToEdit;
            set
            {
                if(_ingredientToEdit != value)
                {
                    _ingredientToEdit = value;
                    OnPropertyChanged(nameof(IngredientToEdit));
                }
            }
        }
        public string NewIngredientName
        {
            get => _newIngredientName;
            set
            {
                if(_newIngredientName != value)
                {
                    _newIngredientName = value;
                    OnPropertyChanged(nameof(NewIngredientName));
                }
            }
        }

        public RelayCommand EditIngredientCommand { get; set; }
        public RelayCommand CloseDialogWindow { get; set; }



        private void AddEditIngredientToList(Ingredient x)
        {
            _ingredientToEdit = x;
        }
    }
}
