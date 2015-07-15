using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Fluxos.Auxiliar
{

    public enum FormaDesenho
    {
        Retangulo,
        Elipse,
        Linha
    }

    public class ConfiguracaoDesenho
    {

        public ConfiguracaoDesenho()
        {
            this.Forma = FormaDesenho.Linha;
            this.Tamanho = 5;
            this.Cor = System.Windows.Media.Brushes.Red;
            this.TamanhoMaximo = 20;
            this.TamanhoMinimo = 5;
        }

        public FormaDesenho Forma { get; set; }
        public SolidColorBrush Cor { get; set; }
        private int Tamanho { get; set; }
        public bool DesenhoAtivo { get; set; }

        private int TamanhoMinimo { get; set; }
        private int TamanhoMaximo { get; set; }

        public bool SetouXInicialLinha { get; set; }
        public bool SetouYInicialLinha { get; set; }
        public bool SetouXFinalLinha { get; set; }
        public bool SetouYFinalLinha { get; set; }

        public int PosXInicialLinha { get; set; }
        public int PosYInicialLinha { get; set; }
        public int PosXFinalLinha { get; set; }
        public int PosYFinalLinha { get; set; }

        public void AumentarTamanhoDesenho()
        {
            int lNovoTamanho = this.Tamanho + 5;

            if (lNovoTamanho < this.TamanhoMaximo)
                this.Tamanho = this.Tamanho + 5;
            else
                this.Tamanho = TamanhoMaximo;
        }

        public void DiminuirTamanhoDesenho()
        {
            int lNovoTamanho = this.Tamanho - 5;

            if (lNovoTamanho > this.TamanhoMinimo)
                this.Tamanho = this.Tamanho - 5;
            else
                this.Tamanho = this.TamanhoMinimo;
        }

        public int GetTamanho() {
            return this.Tamanho;
        }
    }
}
