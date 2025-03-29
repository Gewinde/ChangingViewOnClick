using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChangingViewOnClick
{
    /// <summary>
    /// Interaktionslogik für SubView.xaml
    /// </summary>
    public partial class SubView : Page
    {
        public SubView()
        {
            InitializeComponent();
            var vm = (SubViewVM)this.DataContext;
            vm.OpenDialogWindow += Vm_OnOpenDialogWindow;
        }

        private void Vm_OnOpenDialogWindow(object sender, EventArgs e)
        {
            var dialog = new IngredientEditorView();
            dialog.ShowDialog();
        }
    }
}
