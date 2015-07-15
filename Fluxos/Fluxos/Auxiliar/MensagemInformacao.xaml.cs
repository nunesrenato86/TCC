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
    /// Interaction logic for MensagemInformacao.xaml
    /// </summary>
    public partial class MensagemInformacao : UserControl
    {
        public MensagemInformacao()
        {
            InitializeComponent();
        }

        public void SetMensagem(string pMensagem, bool pMostrarBotaoOk)
        {
            InitializeComponent();

            this.lblMensagem.Text = pMensagem;

            if (pMostrarBotaoOk)
                this.btnOk.Visibility = System.Windows.Visibility.Visible;
            else
                this.btnOk.Visibility = System.Windows.Visibility.Hidden;
        }


    }
}
