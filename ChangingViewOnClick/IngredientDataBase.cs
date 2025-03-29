using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingViewOnClick
{
    class IngredientDataBase : BaseViewModel
    {
        private ObservableCollection<Ingredient> _dataBase;

        public IngredientDataBase()
        {
            _dataBase = new ObservableCollection<Ingredient>()
            {
                new Ingredient("Wurst"),
                new Ingredient("Wasser"),
                new Ingredient("Paprika"),
                new Ingredient("Brot"),
                new Ingredient("Fleisch"),
                new Ingredient("Tomate"),
                new Ingredient("Knoblauch"),
                new Ingredient("Marmelade"),
                new Ingredient("Hackfleisch"),
            };
        }

        public ObservableCollection<Ingredient> DataBase
        {
            get => _dataBase;
            set
            {
                if(_dataBase != value)
                {
                    _dataBase = value;
                    OnPropertyChanged(nameof(DataBase));
                }
            }
        }
    }
}
