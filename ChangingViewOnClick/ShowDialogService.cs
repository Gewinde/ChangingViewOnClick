using System.Windows;

namespace ChangingViewOnClick
{
    class ShowDialogService : IDialogService
    {

        public void ShowDialog()
        {
            var dialog = new IngredientEditorView();
            dialog.ShowDialog();
        }
    }
}
