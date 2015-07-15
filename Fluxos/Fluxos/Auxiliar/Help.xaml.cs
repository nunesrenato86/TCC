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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : UserControl
    {
        private int NumTotalHelps { get; set; }
        private int HelpAtual { get; set; }
        private int ProximoHelp { get; set; }

        private List<string> Helps { get; set; }
        private List<string> Titulos { get; set; }
        private List<string> Observacoes { get; set; }

        public Help()
        {
            InitializeComponent();

            InicializarMsgsHelps();
        }

        public void InicializarMsgsHelps()
        {
            this.Helps = new List<string>();
            this.Titulos = new List<string>();
            this.Observacoes = new List<string>();
            //0
            Helps.Add("AFASTE SEUS BRAÇOS PARA ABRIR A SELEÇÃO DA PRIMEIRA APRESENTAÇÃO.");
            Titulos.Add("INICIANDO:");
            Observacoes.Add("");
            //1
            Helps.Add("MOVA A MÃO ESQUERDA PARA A DIREITA DO OMBRO DIREITO PARA MOSTRAR O MENU LATERAL.");
            Titulos.Add("MENUS:");
            Observacoes.Add("");
            //2
            Helps.Add("MOVA A MÃO DIREITA PARA A ESQUERDA DO OMBRO ESQUERDO PARA ESCONDER O MENU LATERAL.");
            Titulos.Add("MENUS:");
            Observacoes.Add("");
            //3
            Helps.Add("USE A MÃO (DESTRO OU CANHOTO) PARA MOVIMENTAR O CURSOR.");
            Titulos.Add("MOVER O CURSOR:");
            Observacoes.Add("OBS: USE A MÃO ESQUERDA QUANDO EM MODO CANHOTO.");
            //4
            Helps.Add("EMPURRE A SUA MÃO EM DIREÇÃO AO SENSOR PARA CLICAR.");
            Titulos.Add("APERTAR BOTÕES:");
            Observacoes.Add("");
            //5
            Helps.Add("AFASTE O BRAÇO DIREITO DO CORPO PARA AVANÇAR O SLIDE.");
            Titulos.Add("EM MODO APRESENTAÇÃO:");
            Observacoes.Add("OBS: UMA BARRA DE PROGRESSO SERÁ EXIBIDA AO DETECTAR.");
            //6
            Helps.Add("AFASTE O BRAÇO ESQUERDO DO CORPO PARA VOLTAR O SLIDE.");
            Titulos.Add("EM MODO APRESENTAÇÃO:");
            Observacoes.Add("OBS: UMA BARRA DE PROGRESSO SERÁ EXIBIDA AO DETECTAR.");
            //7
            Helps.Add("FAÇA UMA POSE DE T PARA MOSTRAR E ESCONDER SEU ESQUELETO RASTREADO.");
            Titulos.Add("ESTOU SENDO RASTREADO?");
            Observacoes.Add("");
            //8
            Helps.Add("JUNTE SEUS BRAÇOS PARA ALTERNAR ENTRE MODO DE APRESENTAÇÃO E MODO DE DESENHO.");
            Titulos.Add("ALTERNAR MODOS:");
            Observacoes.Add("");
            //9
            Helps.Add("FECHE A SUA MÃO (DESTRO OU CANHOTO) PARA DESENHAR.");
            Titulos.Add("EM MODO DESENHO:");
            Observacoes.Add("");
            //10
            Helps.Add("ABRA A SUA MÃO (DESTRO OU CANHOTO) PARA PARAR DE DESENHAR.");
            Titulos.Add("EM MODO DESENHO:");
            Observacoes.Add("");
            //11
            Helps.Add("ABANE COM A MÃO OPOSTA A SUA MÃO DE DESENHO.");
            Titulos.Add("SALVANDO DESENHOS:");
            Observacoes.Add("OBS: ABANE NOVAMENTE PARA ELIMINAR A MENSAGEM DE DESENHO SALVO");
            //12
            Helps.Add("MOVA A MÃO DIREITA PARA CIMA DA CABEÇA PARA ABRIR O MENU INFERIOR");
            Titulos.Add("MENU DE NAVEGAÇÃO:");
            Observacoes.Add("");
            //13
            Helps.Add("MOVA A MÃO DIREITA PARA BAIXO DA CINTURA PARA FECHAR O MENU INFERIOR.");
            Titulos.Add("MENU DE NAVEGAÇÃO:");
            Observacoes.Add("OBS: ESSE MENU PODE SER FECHADO COM O MESMO MOVIMENTO UTILIZADO PARA MOSTRÁ-LO");
            //14
            Helps.Add("FECHE A MÃO PARA SEGURAR E MOVA PARA OS LADOS PARA MOVIMENTAR O MENU.");
            Titulos.Add("MENU DE NAVEGAÇÃO:");
            Observacoes.Add("");
            //15
            Helps.Add("ABRA A MÃO PARA SOLTAR A SELEÇÃO.");
            Titulos.Add("MENU DE NAVEGAÇÃO:");
            Observacoes.Add("");
            //16
            Helps.Add("PARA SELECIONAR UM SLIDE NO MENU DE NAVEGAÇÃO, PRESSIONE O SLIDE DESEJADO.");
            Titulos.Add("MENU DE NAVEGAÇÃO:");
            Observacoes.Add("");
            //17
            Helps.Add("COLOQUE AS MÃOS NA CINTURA PARA BLOQUEAR OS MOVIMENTOS.");
            Titulos.Add("PAUSA:");
            Observacoes.Add("OBS: REPIRA ESTA POSE PARA VOLTAR AO NORMAL.");

            this.NumTotalHelps = 18;
            this.HelpAtual = 0;
            this.ProximoHelp = 1;

            this.lblMensagem.Text = this.Helps.ElementAt(HelpAtual);

            this.lblTitulo.Text = this.Titulos.ElementAt(HelpAtual) + " Ajuda " + Convert.ToString(this.HelpAtual + 1)
                + " de " + Convert.ToString(this.NumTotalHelps);

            this.lblObs.Text = this.Observacoes.ElementAt(HelpAtual);

            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.HelpAtual = ProximoHelp;
            this.ProximoHelp++;

            if (this.ProximoHelp > (this.NumTotalHelps - 1))
                this.ProximoHelp = 0;

            this.lblMensagem.Text = this.Helps.ElementAt(HelpAtual);

            this.lblTitulo.Text = this.Titulos.ElementAt(HelpAtual) + " Ajuda " + Convert.ToString(this.HelpAtual + 1)
                + " de " + Convert.ToString(this.NumTotalHelps);

            this.lblObs.Text = this.Observacoes.ElementAt(HelpAtual);

            string lImagemHelp = "C:\\Users\\Renato\\Documents\\Visual Studio 2013\\Projects\\Fluxos\\Fluxos\\bin\\Debug\\Help//"
                + Convert.ToString(this.HelpAtual)
                + ".png";

            if (System.IO.File.Exists(lImagemHelp))
            {
                this.imgHelp.Source = (new ImageSourceConverter()).ConvertFromString(lImagemHelp) as ImageSource;
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if ((this.HelpAtual - 1) < 0)
                this.HelpAtual = this.NumTotalHelps - 1;
            else
                this.HelpAtual--;

            this.ProximoHelp = this.HelpAtual + 1;

            if (this.ProximoHelp > (this.NumTotalHelps - 1))
                this.ProximoHelp = 0;

            this.lblMensagem.Text = this.Helps.ElementAt(HelpAtual);

            this.lblTitulo.Text = this.Titulos.ElementAt(HelpAtual) + " Ajuda " + Convert.ToString(this.HelpAtual + 1) 
                + " de " + Convert.ToString(this.NumTotalHelps);

            this.lblObs.Text = this.Observacoes.ElementAt(HelpAtual);

            string lImagemHelp = "C:\\Users\\Renato\\Documents\\Visual Studio 2013\\Projects\\Fluxos\\Fluxos\\bin\\Debug\\Help//"
                + Convert.ToString(this.HelpAtual)
                + ".png";

            if (System.IO.File.Exists(lImagemHelp))
            {
                this.imgHelp.Source = (new ImageSourceConverter()).ConvertFromString(lImagemHelp) as ImageSource;
            }
        }
    }
}
