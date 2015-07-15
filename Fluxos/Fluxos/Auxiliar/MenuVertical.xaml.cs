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

namespace Fluxos.Auxiliar
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuVertical : UserControl
    {
        public MenuVertical()
        {
            InitializeComponent();

            ControlaColuna(0, true);
            ControlaColuna(1, true);
            ControlaColuna(2, false);
            ControlaColuna(3, false);

            btnVermelho.IsChecked = true;
            btnVermelho.Foreground = Brushes.Red;
        }

        public void Iniciar()
        {
            SetMenuInicial();
            Visibility = System.Windows.Visibility.Visible;
        }

        public void SetMenuDesenho()
        {
            ControlaColuna(0, false);
            ControlaColuna(1, false);
            ControlaColuna(2, true);
            ControlaColuna(3, true);
        }

        public void SetMenuInicial()
        {
            ControlaColuna(0, true);
            ControlaColuna(1, true);
            ControlaColuna(2, false);
            ControlaColuna(3, false);
        }

        private void ControlaLinha(int pLinha, bool pHabilitar)
        {
            ((RowDefinitionExtended)GradeMenu.RowDefinitions[pLinha]).Visible = pHabilitar;
        }

        private void ControlaColuna(int pColuna, bool pHabilitar)
        {
            ((ColumnDefinitionExtended)GradeMenu.ColumnDefinitions[pColuna]).Visible = pHabilitar;
        }

    }
}
