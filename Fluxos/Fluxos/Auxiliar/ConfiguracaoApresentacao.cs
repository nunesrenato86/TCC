using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxos.Auxiliar
{
    public class ConfiguracaoApresentacao
    {
        private int MinSlides { get; set; }
        private int MaxSlides { get; set; }
        private int SlideAtual { get; set; }

        private string PastaApresentacaoAtual { get; set; }
        private string PastaDesenhosApresentacaoAtual { get; set; }
        private string PastaTempApresentacaoAtual { get; set; }
        private string ArquivoApresentacaoZipado { get; set; }
        private string NomeApresentacaoAtual { get; set; }  

        private EstadosApresentacao EstadoAtualApresentacao { get; set; }

        private TiposApresentacao TipoApresentacao { get; set; }

        private bool MostrarEsqueletoUsuario { get; set; }

        private bool PausarMovimentos { get; set; }

        private bool Canhoto { get; set; }

        //private bool Salvando { get; set; }

        //private bool Excluindo { get; set; }



        //construtor
        public ConfiguracaoApresentacao()
        {
            SetMinSlides(1);
            SetEstadoApresentacaoAtual(EstadosApresentacao.ModoApresentacao);
            SetMostrarEsqueletoUsuario(false);
            SetPausarMovimentos(false);
            SetSlideAtual(1);
        }

        //gets
        public int GetTotalSlides()
        {
            return this.MaxSlides;
        }

        public EstadosApresentacao GetEstadoApresentacaoAtual()
        {
            return this.EstadoAtualApresentacao;
        }

        public string GetPastaApresentacaoAtual()
        {
            return this.PastaApresentacaoAtual;
        }

        public string GetPastaTemp()
        {
            return this.PastaTempApresentacaoAtual;
        }

        public string GetArquivoApresentacaoZipado()
        {
            return this.ArquivoApresentacaoZipado;
        }

        public string GetNomeApresentacaoAtual()
        {
            return this.NomeApresentacaoAtual;
        }

        public string GetPastaDesenhosApresentacao()
        {
            return this.PastaDesenhosApresentacaoAtual;
        }

        public int GetSlideAtual()
        {
            return this.SlideAtual;
        }

        public bool GetMostrarEsqueletoUsuario() 
        {
            return this.MostrarEsqueletoUsuario;
        }

        public bool GetPausarMovimentos()
        {
            return this.PausarMovimentos;
        }

        /*public bool GetSalvando()
        {
            return this.Salvando;
        }*/

        /*public bool GetExcluindo()
        {
            return this.Excluindo;
        }*/

        public bool GetModoCanhoto()
        {
            return this.Canhoto;
        }

        public TiposApresentacao GetTipoApresentacao()
        {
            return this.TipoApresentacao;
        }

        //sets

        public void SetSlideAtual(int pSlide)
        {
            this.SlideAtual = pSlide;
        }

        public void AvancaSlide()
        {
            if (this.SlideAtual < this.MaxSlides)
                this.SlideAtual = this.SlideAtual + 1;
        }

        public void VoltaSlide()
        {
            if (this.SlideAtual > this.MinSlides)
                this.SlideAtual = this.SlideAtual - 1;

        }

        public void SetMaxSlides(int pMaxSlides)
        {
            this.MaxSlides = pMaxSlides;
        }

        public void SetMinSlides(int pMinSlides)
        {
            this.MinSlides = pMinSlides;
        }

        public void SetEstadoApresentacaoAtual(EstadosApresentacao pEstado)
        {
            this.EstadoAtualApresentacao = pEstado;
        }        

        public void SetPastaApresentacaoAtual(string pPastaApresentacao)
        {
            this.PastaApresentacaoAtual = pPastaApresentacao;

            if (!System.IO.Directory.Exists(PastaApresentacaoAtual))
                System.IO.Directory.CreateDirectory(PastaApresentacaoAtual);

            PastaDesenhosApresentacaoAtual = PastaApresentacaoAtual + "\\Desenhos\\";

            PastaTempApresentacaoAtual = PastaApresentacaoAtual + "\\Temp\\";

            if (!System.IO.Directory.Exists(PastaDesenhosApresentacaoAtual))
                System.IO.Directory.CreateDirectory(PastaDesenhosApresentacaoAtual);

            if (!System.IO.Directory.Exists(PastaTempApresentacaoAtual))
                System.IO.Directory.CreateDirectory(PastaTempApresentacaoAtual);

            if (System.IO.File.Exists(PastaApresentacaoAtual + "\\apresentacao.zip"))
                System.IO.File.Delete(PastaApresentacaoAtual + "\\apresentacao.zip");

            ArquivoApresentacaoZipado = PastaApresentacaoAtual + "\\apresentacao.zip";
        }

        public void SetMostrarEsqueletoUsuario(bool pMostrarEsqueleto)
        {
            this.MostrarEsqueletoUsuario = pMostrarEsqueleto;
        }

        public void SetPausarMovimentos(bool pPausarMovimentos)
        {
            this.PausarMovimentos = pPausarMovimentos;
        }

        public void SetCanhoto(bool pCanhoto)
        {
            this.Canhoto = pCanhoto;
        }

        public void SetNomeApresentacaoAtual(string pNomeApresentacao) 
        {
            this.NomeApresentacaoAtual = pNomeApresentacao;        
        }

        /*public void SetSalvando(bool pSalvando)
        {
            this.Salvando = pSalvando;
        }*/

        /*public void SetExcluindo(bool pExcluindo)
        {
            this.Excluindo = pExcluindo;
        }*/

        public void SetTipoApresentacao(TiposApresentacao pTipoApresentacao)
        {
            this.TipoApresentacao = pTipoApresentacao;
        }

        
    }
}
