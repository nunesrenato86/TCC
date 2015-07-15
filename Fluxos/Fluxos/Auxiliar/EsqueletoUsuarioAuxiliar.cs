using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using Fluxos.Auxiliar;
using System.Windows;

namespace Fluxos
{
    public class EsqueletoUsuarioAuxiliar
    {
        private KinectSensor Kinect;

        public EsqueletoUsuarioAuxiliar(KinectSensor pKinect)
        {
            this.Kinect = pKinect;
        }


        private ColorImagePoint ConverterCoordenadasArticulacao(Joint pArticulacao, double pLarguraCanvas, double pAlturaCanvas)
        {
            ColorImagePoint lPosicaoArticulacao = Kinect.CoordinateMapper.MapSkeletonPointToColorPoint(
                pArticulacao.Position,
                Kinect.ColorStream.Format);

            lPosicaoArticulacao.X = (int)(lPosicaoArticulacao.X * pLarguraCanvas) / Kinect.ColorStream.FrameWidth;

            lPosicaoArticulacao.Y = (int)(lPosicaoArticulacao.Y * pAlturaCanvas) / Kinect.ColorStream.FrameHeight;

            return lPosicaoArticulacao;
        }


        private void ConfigurarComponenteVisualArticulacao(Shape pForma, int pDiametroArticulacao,
            int pLarguraDesenho, Brush pCorDesenho, bool pPreencheComGradiente, bool pColorirGradienteMesmaCorDoPincel)
        {
            pForma.Height = pDiametroArticulacao;
            pForma.Width = pDiametroArticulacao;
            pForma.StrokeThickness = pLarguraDesenho;

            if (pPreencheComGradiente)
            {
                pForma.Stroke = Brushes.Black;

                RadialGradientBrush lGradiente = new RadialGradientBrush();
                lGradiente.GradientOrigin = new Point(0.5, 0.5);
                lGradiente.Center = new Point(0.5, 0.5);
                lGradiente.RadiusX = 0.5;
                lGradiente.RadiusY = 0.5;

                Color lCor1;
                Color lCor2;

                if (pColorirGradienteMesmaCorDoPincel)
                {
                    if (pCorDesenho == Brushes.Green)
                    {
                        lCor1 = Colors.Lime;
                        lCor2 = Colors.DarkGreen;
                    }
                    else if (pCorDesenho == Brushes.Blue)
                    {
                        lCor1 = Colors.RoyalBlue;
                        lCor2 = Colors.DarkBlue;
                    }
                    else
                    {
                        lCor1 = Colors.OrangeRed;
                        lCor2 = Colors.DarkRed;
                    }
                }
                else
                {
                    lCor1 = Colors.OrangeRed;
                    lCor2 = Colors.DarkRed;
                }

                //lCor1 = Colors.Lime;
                //lCor2 = Colors.DarkGreen;

                lGradiente.GradientStops.Add(new GradientStop(lCor1, 0.5));

                lGradiente.GradientStops.Add(new GradientStop(lCor2, 1));

                pForma.Fill = lGradiente;
            }
            else
            {
                pForma.Stroke = pCorDesenho;
            }
        }


        private void PosicionarDesenho(Joint pArticulacao, Canvas pCanvasParaDesenhar, Shape pObjetoArticulacao)
        {
            ColorImagePoint posicaoArticulacao = ConverterCoordenadasArticulacao(
                pArticulacao,
                pCanvasParaDesenhar.ActualWidth,
                pCanvasParaDesenhar.ActualHeight);

            double deslocamentoHorizontal = posicaoArticulacao.X - pObjetoArticulacao.Width / 2;
            double deslocamentoVertical = (posicaoArticulacao.Y - pObjetoArticulacao.Height / 2);

            if (deslocamentoVertical >= 0
                && deslocamentoVertical < pCanvasParaDesenhar.ActualHeight
                && deslocamentoHorizontal >= 0
                && deslocamentoHorizontal < pCanvasParaDesenhar.ActualWidth)
            {
                Canvas.SetLeft(pObjetoArticulacao, deslocamentoHorizontal);
                Canvas.SetTop(pObjetoArticulacao, deslocamentoVertical);
                Canvas.SetZIndex(pObjetoArticulacao, 100);

                pCanvasParaDesenhar.Children.Add(pObjetoArticulacao);
            }
        }


        private void PosicionarDesenhoSoPelaPosicao(int pPosX, int pPosY, Canvas pCanvasParaDesenhar, Shape pObjetoArticulacao)
        {
            double deslocamentoHorizontal = pPosX - pObjetoArticulacao.Width / 2;
            double deslocamentoVertical = (pPosY - pObjetoArticulacao.Height / 2);

            if (deslocamentoVertical >= 0
                && deslocamentoVertical < pCanvasParaDesenhar.ActualHeight
                && deslocamentoHorizontal >= 0
                && deslocamentoHorizontal < pCanvasParaDesenhar.ActualWidth)
            {
                Canvas.SetLeft(pObjetoArticulacao, deslocamentoHorizontal);
                Canvas.SetTop(pObjetoArticulacao, deslocamentoVertical);
                Canvas.SetZIndex(pObjetoArticulacao, 100);

                pCanvasParaDesenhar.Children.Add(pObjetoArticulacao);
            }
        }


        public Ellipse DesenharArticulacao(Joint pArticulacao, Canvas pCanvasParaDesenhar)
        {
            //int diametroArticulacao = articulacao.JointType == JointType.Head ? 50 : 10;

            int diametroArticulacao;

            if (pArticulacao.JointType == JointType.Head)
                diametroArticulacao = 50;
            else if (pArticulacao.JointType == JointType.HandLeft || pArticulacao.JointType == JointType.HandRight)
                diametroArticulacao = 25;
            else
                diametroArticulacao = 10;

            int larguraDesenho = 4;
            Brush corDesenho = Brushes.Red;
            Ellipse objetoArticulacao = new Ellipse();

            ConfigurarComponenteVisualArticulacao(
                objetoArticulacao,
                diametroArticulacao,
                larguraDesenho,
                corDesenho,
                true,
                false);

            PosicionarDesenho(pArticulacao, pCanvasParaDesenhar, objetoArticulacao);

            return objetoArticulacao;
        }


        public Ellipse DesenharUmaMaoPintura(Joint pArticulacao, Canvas pCanvasParaDesenhar, Brush pCor)
        {
            int diametroArticulacao = 25;
            int larguraDesenho = 4;
            Ellipse objetoArticulacao = new Ellipse();

            objetoArticulacao.Fill = pCor;

            ConfigurarComponenteVisualArticulacao(
                objetoArticulacao,
                diametroArticulacao,
                larguraDesenho,
                pCor,
                true,
                true);

            PosicionarDesenho(pArticulacao, pCanvasParaDesenhar, objetoArticulacao);

            return objetoArticulacao;
        }


        public void DesenharOsso(Joint pArticulacaoOrigem, Joint pArticulacaoDestino, Canvas pCanvasParaDesenhar)
        {
            int lLarguraDesenho = 6;

            Brush lCorDesenho = Brushes.YellowGreen;

            ColorImagePoint lPosicaoArticulacaoOrigem = ConverterCoordenadasArticulacao(
                pArticulacaoOrigem,
                pCanvasParaDesenhar.ActualWidth,
                pCanvasParaDesenhar.ActualHeight);

            ColorImagePoint lPosicaoArticulacaoDestino = ConverterCoordenadasArticulacao(
                pArticulacaoDestino,
                pCanvasParaDesenhar.ActualWidth,
                pCanvasParaDesenhar.ActualHeight);

            Line lObjetoOsso = CriarComponenteVisualOsso(
                lLarguraDesenho,
                lCorDesenho,
                lPosicaoArticulacaoOrigem.X,
                lPosicaoArticulacaoOrigem.Y,
                lPosicaoArticulacaoDestino.X,
                lPosicaoArticulacaoDestino.Y);

            if (Math.Max(lObjetoOsso.X1, lObjetoOsso.X2) < pCanvasParaDesenhar.ActualWidth
                && Math.Min(lObjetoOsso.X1, lObjetoOsso.X2) > 0
                && Math.Max(lObjetoOsso.Y1, lObjetoOsso.Y2) < pCanvasParaDesenhar.ActualHeight
                && Math.Min(lObjetoOsso.Y1, lObjetoOsso.Y2) > 0)
                pCanvasParaDesenhar.Children.Add(lObjetoOsso);
        }


        private Line CriarComponenteVisualOsso(int pLarguraDesenho, Brush pCorDesenho,
                    double pOrigemX, double pOrigemY, double pDestinoX, double pDestinoY)
        {
            Line lObjetoOsso = new Line();
            lObjetoOsso.StrokeThickness = pLarguraDesenho;
            lObjetoOsso.Stroke = pCorDesenho;
            lObjetoOsso.X1 = pOrigemX;
            lObjetoOsso.X2 = pDestinoX;
            lObjetoOsso.Y1 = pOrigemY;
            lObjetoOsso.Y2 = pDestinoY;
            return lObjetoOsso;
        }


        public void DesenharLinhaEntreDoisPontos(ConfiguracaoDesenho pCofiguracaoDesenho, Canvas pCanvasParaDesenhar)
        {
            int lLarguraDesenho = pCofiguracaoDesenho.GetTamanho();

            Brush lCorDesenho = pCofiguracaoDesenho.Cor;

            Line lObjetoOsso = CriarComponenteVisualOsso(
                lLarguraDesenho,
                lCorDesenho,
                pCofiguracaoDesenho.PosXInicialLinha,
                pCofiguracaoDesenho.PosYInicialLinha,
                pCofiguracaoDesenho.PosXFinalLinha,
                pCofiguracaoDesenho.PosYFinalLinha);

            if (Math.Max(lObjetoOsso.X1, lObjetoOsso.X2) < pCanvasParaDesenhar.ActualWidth
                && Math.Min(lObjetoOsso.X1, lObjetoOsso.X2) > 0
                && Math.Max(lObjetoOsso.Y1, lObjetoOsso.Y2) < pCanvasParaDesenhar.ActualHeight
                && Math.Min(lObjetoOsso.Y1, lObjetoOsso.Y2) > 0)
                pCanvasParaDesenhar.Children.Add(lObjetoOsso);
        }

        public void InteracaoDesenharLinhaEntreDuasMaos(Skeleton pEsqueletoUsuario,
            EsqueletoUsuarioAuxiliar pEsqueletoAuxiliar, Canvas pCanvasDesenho,
            ConfiguracaoDesenho pConfiguracaoMaoEsquerda, ConfiguracaoDesenho pConfiguracaoMaoDireita)
        {
            pEsqueletoAuxiliar.DesenharOsso(
                        pEsqueletoUsuario.Joints[JointType.HandLeft],
                        pEsqueletoUsuario.Joints[JointType.HandRight],
                        pCanvasDesenho);
        }

        public void InteracaoDesenharLinhaEntreDoisPontosMao(Skeleton pEsqueletoUsuario,
            EsqueletoUsuarioAuxiliar pEsqueletoAuxiliar, Canvas pCanvasDesenho,
            ConfiguracaoDesenho pConfiguracaoMao)
        {
            if (pConfiguracaoMao.SetouXFinalLinha == true
                && pConfiguracaoMao.SetouXInicialLinha == true
                && pConfiguracaoMao.SetouYFinalLinha == true
                && pConfiguracaoMao.SetouYInicialLinha == true)
            { //configurou tudo > desenha a linha
                DesenharLinhaEntreDoisPontos(pConfiguracaoMao, pCanvasDesenho);
                //return true;
            }
            else if (pConfiguracaoMao.SetouXFinalLinha == false
                && pConfiguracaoMao.SetouXInicialLinha == true
                && pConfiguracaoMao.SetouYFinalLinha == false
                && pConfiguracaoMao.SetouYInicialLinha == true)
            {//configurou o inicial só > desenha uma bola inicial
                int larguraDesenho = 10;
                Shape objetoArticulacao;

                objetoArticulacao = new Ellipse();

                ConfigurarComponenteVisualArticulacao(
                    objetoArticulacao,
                    pConfiguracaoMao.GetTamanho(),
                    larguraDesenho,
                    pConfiguracaoMao.Cor,
                    false,
                    false);

                objetoArticulacao.Fill = pConfiguracaoMao.Cor;

                PosicionarDesenhoSoPelaPosicao(
                    pConfiguracaoMao.PosXInicialLinha,
                    pConfiguracaoMao.PosYInicialLinha,
                    pCanvasDesenho,
                    objetoArticulacao);

            }
        }

        public Shape InteracaoDesenhar(Joint pArticulacao, Canvas pCanvasParaDesenhar, ConfiguracaoDesenho pConfiguracao)
        {

            int larguraDesenho = 5;
            Shape objetoArticulacao;

            if (pConfiguracao.Forma == FormaDesenho.Elipse)
                objetoArticulacao = new Ellipse();
            else //if (configuracao.Forma == FormaDesenho.Retangulo)
                objetoArticulacao = new Rectangle();

            ConfigurarComponenteVisualArticulacao(
                objetoArticulacao,
                pConfiguracao.GetTamanho(),
                larguraDesenho,
                pConfiguracao.Cor,
                false,
                false);

            objetoArticulacao.Fill = pConfiguracao.Cor;

            PosicionarDesenho(
                pArticulacao,
                pCanvasParaDesenhar,
                objetoArticulacao);


            return objetoArticulacao;


            /*
            int larguraDesenho = 5;
            Shape objetoArticulacao;

            if (configuracao.Forma == FormaDesenho.Elipse)
                objetoArticulacao = new Ellipse();
            else
                objetoArticulacao = new Rectangle();

            ConfigurarComponenteVisualArticulacao(
                objetoArticulacao,
                configuracao.Tamanho,
                larguraDesenho,
                configuracao.Cor);

            //objetoArticulacao.Fill = configuracao.Cor;

            PosicionarDesenho(
                articulacao,
                canvasParaDesenhar,
                objetoArticulacao);

            return objetoArticulacao;
             * 
             * */

        }


    }
}
