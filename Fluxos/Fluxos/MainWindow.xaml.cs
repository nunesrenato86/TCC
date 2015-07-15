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
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;
using Fluxos.Auxiliar;
using AuxiliarKinect.Movimentos;
using AuxiliarKinect.Movimentos.Poses;
using AuxiliarKinect.Movimentos.Gestos.Aceno;
using AuxiliarKinect.Movimentos.Gestos.DeBaixoParaCima;
using AuxiliarKinect.Movimentos.Gestos.PassaEsquerdaParaDireita;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using Microsoft.Kinect.Toolkit.Interaction;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Kinect.Toolkit.Controls;
using System.Globalization;
using LightBuzz.Vitruvius;
using LightBuzz.Vitruvius.WPF;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Net.Mail;
using Microsoft.Kinect.Toolkit;
using System.ComponentModel;

namespace Fluxos
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //link dos metodos do menu

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Abrir = new RoutedUICommand("", "Abrir", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand EntrarModoDesenho = new RoutedUICommand("", "EntrarModoDesenho", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Canhoto = new RoutedUICommand("", "Canhoto", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand SairApp = new RoutedUICommand("", "SairApp", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand AumentarLinha = new RoutedUICommand("", "AumentarLinha", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand DiminuirLinha = new RoutedUICommand("", "DiminuirLinha", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Vermelho = new RoutedUICommand("", "Vermelho", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Azul = new RoutedUICommand("", "Azul", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Verde = new RoutedUICommand("", "Verde", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand ApagarDesenho = new RoutedUICommand("", "ApagarDesenho", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand ApagarArquivo = new RoutedUICommand("", "ApagarArquivo", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand EntrarModoApresentacao = new RoutedUICommand("", "EntrarModoApresentacao", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand SlideClick = new RoutedUICommand("", "SlideClick", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand OkInformacao = new RoutedUICommand("", "OkInformacao", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Email = new RoutedUICommand("", "Email", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand Help = new RoutedUICommand("", "Help", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand HideHelp = new RoutedUICommand("", "HideHelp", typeof(MainWindow));

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "There is no immutable RoutedUICommand variant, and readonly provides some measure of protection")]
        public static readonly RoutedUICommand OkInputBox = new RoutedUICommand("", "OkInputBox", typeof(MainWindow));

        KinectSensor Kinect;
        List<IRastreador> Rastreadores;
        InteractionStream fluxoInteracao;
        ConfiguracaoDesenho configuracaoMaoDireita;
        ConfiguracaoDesenho configuracaoMaoEsquerda;
        ConfiguracaoApresentacao configuracaoApresentacao;

        GestureController _gestureController;

        //variaveis de controle
        bool AbrindoApresentacao = false;
        static bool EnviandoEmail = false;

        //metodos dos menus

        private void OnOkInputBox(object sender, ExecutedRoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Hidden;
            InputBox.kinectRegionInputBox.KinectSensor = null;

            AssociarKinectAosMenus();

            string lDestinatarios = InputBox.edtDestinatarios.Text;

            if (lDestinatarios != "")
            {
                lDestinatarios = ValidarEmails(lDestinatarios);

                if (lDestinatarios != "")
                {
                    EnviarArquivosPastaTemp();

                    ZiparApresentacao();

                    try
                    {
                        EnviarEmail(lDestinatarios);
                    }
                    catch
                    {
                        MostrarInformacao("E-mail não enviado", true);
                        EnviandoEmail = false;
                    }
                }
                else
                    MostrarInformacao("Nenhum endereço de e-mail válido foi encontrado", true);

            }
        }

        private string ValidarEmails(string pEmails)
        {
            //desmembra a string em um array
            string lEmailsValidos = "";

            string[] emailAddresses = pEmails.Split(';', ',');

            //foreach (string item in split)
            //{
            //    Console.WriteLine(item);
            //}

            RegexUtilities util = new RegexUtilities();
            /*
            string[] emailAddresses = { "david.jones@proseware.com", "d.j@server1.proseware.com", 
                                  "jones@ms1.proseware.com", "j.@server1.proseware.com", 
                                  "j@proseware.com9", "js#internal@proseware.com", 
                                  "j_9@[129.126.118.1]", "j..s@proseware.com", 
                                  "js*@proseware.com", "js@proseware..com", 
                                  "js@proseware.com9", "j.s@server1.proseware.com" };
             * */

            string lEmailAddress = "";

            foreach (var emailAddress in emailAddresses)
            {
                lEmailAddress = emailAddress.Trim();

                if (util.IsValidEmail(lEmailAddress))
                {
                    if (lEmailsValidos == "")
                        lEmailsValidos = lEmailAddress;
                    else
                        lEmailsValidos = lEmailsValidos + "," + lEmailAddress;
                }

                //Console.WriteLine("Valid: {0}", emailAddress);
                //Console.WriteLine("Invalid: {0}", emailAddress);
            }

            return lEmailsValidos;

        }

        private void OnOkInformacao(object sender, ExecutedRoutedEventArgs e)
        {
            EsconderMsgInformacao();
        }

        private void OnAbrir(object sender, ExecutedRoutedEventArgs e)
        {
            AbrirApresentacao();
        }

        private void OnHelp(object sender, ExecutedRoutedEventArgs e)
        {
            DesassociarKinectAosMenus();

            if ((hlpHelp.kinectRegionHelp.KinectSensor == null) && (Kinect != null))
                hlpHelp.kinectRegionHelp.KinectSensor = Kinect;

            hlpHelp.Visibility = System.Windows.Visibility.Visible;
            EsconderMenuLateral();
        }

        private void OnHideHelp(object sender, ExecutedRoutedEventArgs e)
        {
            AssociarKinectAosMenus();

            hlpHelp.Visibility = System.Windows.Visibility.Hidden;

            if (hlpHelp.kinectRegionHelp.KinectSensor != null)
                hlpHelp.kinectRegionHelp.KinectSensor = null;
        }

        private void OnEmail(object sender, ExecutedRoutedEventArgs e)
        {
            if (configuracaoApresentacao != null)
            {
                if (EnviandoEmail)
                    MostrarInformacao("Aguarde até que o seu último e-mail seja enviado", true);
                else
                    MostrarInputDestinatarios();

                //while (AguardandoDestinatarios) ;

                //string lDestinatarios = InputBox.edtDestinatarios.Text;

                //EnviarArquivosPastaTemp();

                //ZiparApresentacao();

                //EnviarEmail(lDestinatarios);                

            }
        }

        private void OnEntrarModoDesenho(object sender, ExecutedRoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("OnEntrarModoDesenho");
            //menuVertical.SetMenuDesenho();

            EntrarEmModoDesenho();
        }

        private void OnCanhoto(object sender, ExecutedRoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("OnCanhoto");
            if (configuracaoApresentacao != null)
                configuracaoApresentacao.SetCanhoto(menuVertical.btnCanhoto.IsChecked);
        }

        private void OnSairApp(object sender, ExecutedRoutedEventArgs e)
        {
            SairAppOriginal();
        }

        private void OnAumentarLinha(object sender, ExecutedRoutedEventArgs e)
        {
            AumentarLinhaOriginal();
        }

        private void OnDiminuirLinha(object sender, ExecutedRoutedEventArgs e)
        {
            DiminuirLinhaOriginal();
        }

        private void OnVermelho(object sender, ExecutedRoutedEventArgs e)
        {
            SetVermelho();
        }

        private void OnVerde(object sender, ExecutedRoutedEventArgs e)
        {
            SetVerde();
        }

        private void OnAzul(object sender, ExecutedRoutedEventArgs e)
        {
            SetAzul();
        }

        private void OnApagarDesenho(object sender, ExecutedRoutedEventArgs e)
        {
            ApagarDesenhoOriginal();
        }

        private void OnApagarArquivo(object sender, ExecutedRoutedEventArgs e)
        {
            ExcluirArquivoDesenho();
        }

        private void OnEntrarModoApresentacao(object sender, ExecutedRoutedEventArgs e)
        {
            //menuVertical.SetMenuInicial();
            EntrarModoApresentacaoOriginal();
        }

        private void OnSlideClick(object sender, ExecutedRoutedEventArgs e)
        {
            var button = (KinectTileButton)e.OriginalSource;

            int lSlide = Convert.ToInt16(button.Label);

            if (configuracaoApresentacao != null)
            {
                ApagarDesenhoOriginal();
                configuracaoApresentacao.SetSlideAtual(lSlide);
                AddPPTCanvasKinect(lSlide);
                EsconderMenuInferior();
            }
        }


        //metodos tratamentos dos fluxos

        private BitmapSource ReconhecerHumanos(DepthImageFrame pQuadro)
        {
            if (pQuadro == null) return null;

            using (pQuadro)
            {
                DepthImagePixel[] lImagemProfundidade = new DepthImagePixel[pQuadro.PixelDataLength];

                pQuadro.CopyDepthImagePixelDataTo(lImagemProfundidade);

                byte[] lBytesImagem = new byte[lImagemProfundidade.Length * 4]; //pois cada pixel tem 1 pixel para R G B e Depht

                for (int lIndice = 0; lIndice < lBytesImagem.Length; lIndice += 4)
                {
                    if (lImagemProfundidade[lIndice / 4].PlayerIndex != 0)
                    {
                        lBytesImagem[lIndice + 1] = 255; //pinta de verde o pixel que faz parte de um humeno
                    }
                }

                return BitmapSource.Create(pQuadro.Width,
                        pQuadro.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null,
                        lBytesImagem,
                        pQuadro.Width * 4);
            }
        }


        //private void kinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        //{
        //    imagemCamera.Source = ReconhecerHumanos(e.OpenDepthImageFrame());
        //}



        //private void kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        //{
        //    imagemCamera.Source = ObterImagemSensorRGB(e.OpenColorImageFrame());
        //}


        private byte[] ObterImagemSensorRGB(ColorImageFrame pQuadro)
        {
            if (pQuadro == null) return null;

            using (pQuadro)
            {
                byte[] lBytesImagem = new byte[pQuadro.PixelDataLength];

                pQuadro.CopyPixelDataTo(lBytesImagem);

                return lBytesImagem;


                /*
                
                if (chkEscalaCinza.IsChecked.HasValue && chkEscalaCinza.IsChecked.Value)
                {
                    for (int lIndice = 0; lIndice < lBytesImagem.Length; lIndice += pQuadro.BytesPerPixel)
                    {
                        byte lMaiorValorCor = Math.Max(lBytesImagem[lIndice],
                            Math.Max(lBytesImagem[lIndice + 1],
                            lBytesImagem[lIndice + 2]));

                        lBytesImagem[lIndice] = lMaiorValorCor;
                        lBytesImagem[lIndice + 1] = lMaiorValorCor;
                        lBytesImagem[lIndice + 2] = lMaiorValorCor;
                    }

                }

                return BitmapSource.Create(pQuadro.Width,
                    pQuadro.Height,
                    96,
                    96,
                    PixelFormats.Bgr32,
                    null,
                    lBytesImagem,
                    pQuadro.Width * pQuadro.BytesPerPixel);

                */
            }

        }


        private void FuncoesProfundidade(DepthImageFrame pQuadro, byte[] pBytesImagem, int pDistanciaMaxima)
        {
            if (pQuadro == null || pBytesImagem == null) return;

            using (pQuadro)
            {
                DepthImagePixel[] imagemProfundidade = new DepthImagePixel[pQuadro.PixelDataLength];

                pQuadro.CopyDepthImagePixelDataTo(imagemProfundidade);

                //if (btnDesenhar.IsChecked)
                if ((configuracaoApresentacao != null)
                    && (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoDesenho))
                    fluxoInteracao.ProcessDepth(imagemProfundidade, pQuadro.Timestamp);

                //else if (btnEscalaCinza.IsChecked)
                //    ReconhecerProfundidade(bytesImagem, pDistanciaMaxima, imagemProfundidade);
            }
        }


        /*private void ReconhecerProfundidade(byte[] bytesImagem, int pDistanciaMaxima, DepthImagePixel[] imagemProfundidade)
        {
            DepthImagePoint[] pontosImagemProfundidade = new DepthImagePoint[640 * 480];

            Kinect.CoordinateMapper.MapColorFrameToDepthFrame(
                Kinect.ColorStream.Format,
                Kinect.DepthStream.Format,
                imagemProfundidade,
                pontosImagemProfundidade);

            for (int i = 0; i < pontosImagemProfundidade.Length; i++)
            {
                var point = pontosImagemProfundidade[i];

                if (point.Depth < pDistanciaMaxima && KinectSensor.IsKnownPoint(point))
                {
                    var pixelDataIndex = i * 4;
                    byte maiorValorCor = Math.Max(bytesImagem[pixelDataIndex],
                        Math.Max(bytesImagem[pixelDataIndex + 1],
                        bytesImagem[pixelDataIndex + 2]));
                    bytesImagem[pixelDataIndex] = maiorValorCor;
                    bytesImagem[pixelDataIndex + 1] = maiorValorCor;
                    bytesImagem[pixelDataIndex + 2] = maiorValorCor;
                }
            }
        }*/


        private ColorImagePoint ConverterCoordenadasArticulacao(Joint pArticulacao, double pLarguraCanvas, double pAlturaCanvas)
        {
            ColorImagePoint lPosicaoArticulacao = Kinect.CoordinateMapper.MapSkeletonPointToColorPoint(
                pArticulacao.Position,
                Kinect.ColorStream.Format);

            lPosicaoArticulacao.X = (int)(lPosicaoArticulacao.X * pLarguraCanvas) / Kinect.ColorStream.FrameWidth;
            lPosicaoArticulacao.Y = (int)(lPosicaoArticulacao.Y * pAlturaCanvas) / Kinect.ColorStream.FrameHeight;
            return lPosicaoArticulacao;
        }


        private void FuncoesEsqueletoUsuario(SkeletonFrame pQuadro)
        {
            if (pQuadro == null) return;

            using (pQuadro)
            {
                Skeleton lEsqueletoUsuario = pQuadro.ObterEsqueletoUsuario();

                if (lEsqueletoUsuario == null) return;

                //teste aqui
                _gestureController.Update(lEsqueletoUsuario);

                //if (btnDesenhar.IsChecked)
                if ((configuracaoApresentacao != null)
                    && (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoDesenho))
                {
                    foreach (IRastreador rastreador in Rastreadores)
                        rastreador.Rastrear(lEsqueletoUsuario);

                    if (configuracaoApresentacao != null)
                    {
                        AddPPTCanvasKinect(configuracaoApresentacao.GetSlideAtual());

                        //if (btnEsqueletoUsuario.IsChecked)
                        if (configuracaoApresentacao.GetMostrarEsqueletoUsuario())
                            pQuadro.DesenharEsqueletoUsuario(Kinect, canvasKinect);
                        else
                        {
                            ConfiguracaoDesenho lConfiguracaoDesenho;
                            JointType lMao;

                            if (configuracaoApresentacao.GetModoCanhoto())
                            {
                                lConfiguracaoDesenho = configuracaoMaoEsquerda;
                                lMao = JointType.HandLeft;
                            }
                            else
                            {
                                lConfiguracaoDesenho = configuracaoMaoDireita;
                                lMao = JointType.HandRight;
                            }

                            if (lConfiguracaoDesenho != null)
                                pQuadro.DesenharMaosUsuario(Kinect, canvasKinect, lConfiguracaoDesenho.Cor, lMao);
                            else
                                pQuadro.DesenharMaosUsuario(Kinect, canvasKinect, System.Windows.Media.Brushes.Red, lMao);

                        }
                    }

                    Skeleton[] esqueletos = new Skeleton[6];

                    pQuadro.CopySkeletonDataTo(esqueletos);

                    fluxoInteracao.ProcessSkeleton(
                        esqueletos,
                        Kinect.AccelerometerGetCurrentReading(),
                        pQuadro.Timestamp);

                    EsqueletoUsuarioAuxiliar esqueletoAuxiliar = new EsqueletoUsuarioAuxiliar(Kinect);

                    if (configuracaoMaoDireita.Forma != FormaDesenho.Linha
                        && configuracaoMaoEsquerda.Forma != FormaDesenho.Linha)
                    {
                        if (configuracaoMaoDireita.DesenhoAtivo)
                            esqueletoAuxiliar.InteracaoDesenhar(lEsqueletoUsuario.Joints[JointType.HandRight],
                                canvasDesenho,
                                configuracaoMaoDireita);

                        if (configuracaoMaoEsquerda.DesenhoAtivo)
                            esqueletoAuxiliar.InteracaoDesenhar(lEsqueletoUsuario.Joints[JointType.HandLeft],
                                canvasDesenho,
                                configuracaoMaoEsquerda);
                    }
                    else //interacaoLinha
                    {
                        if ((configuracaoApresentacao != null) && (configuracaoApresentacao.GetModoCanhoto()))
                        {//modo canhoto
                            //if (configuracaoMaoDireita.DesenhoAtivo
                            //    && !((RowDefinitionExtended)GradePrincipal.RowDefinitions[3]).Visible)
                            if (configuracaoMaoEsquerda.DesenhoAtivo
                                && MenusEstaoEscondidos())
                            {
                                if (configuracaoMaoEsquerda.SetouXFinalLinha == false
                                    && configuracaoMaoEsquerda.SetouXInicialLinha == false
                                    && configuracaoMaoEsquerda.SetouYFinalLinha == false
                                    && configuracaoMaoEsquerda.SetouYInicialLinha == false)
                                {//nao setou nada, seta a pos inicial e desenha uma bola
                                    ColorImagePoint lPosicaoArticulacaoOrigem = ConverterCoordenadasArticulacao(
                                        lEsqueletoUsuario.Joints[JointType.HandLeft],
                                        canvasDesenho.ActualWidth,
                                        canvasDesenho.ActualHeight);

                                    configuracaoMaoEsquerda.PosXInicialLinha = lPosicaoArticulacaoOrigem.X;
                                    configuracaoMaoEsquerda.PosYInicialLinha = lPosicaoArticulacaoOrigem.Y;

                                    configuracaoMaoEsquerda.SetouXInicialLinha = true;
                                    configuracaoMaoEsquerda.SetouYInicialLinha = true;

                                    esqueletoAuxiliar.InteracaoDesenharLinhaEntreDoisPontosMao(
                                        lEsqueletoUsuario,
                                        esqueletoAuxiliar,
                                        canvasDesenho,
                                        configuracaoMaoEsquerda);
                                }
                                else if (configuracaoMaoEsquerda.SetouXFinalLinha == false
                                    && configuracaoMaoEsquerda.SetouXInicialLinha == true
                                    && configuracaoMaoEsquerda.SetouYFinalLinha == false
                                    && configuracaoMaoEsquerda.SetouYInicialLinha == true)
                                {//setou a pos inicial, seto a final
                                    ColorImagePoint lPosicaoArticulacaoOrigem = ConverterCoordenadasArticulacao(
                                        lEsqueletoUsuario.Joints[JointType.HandLeft],
                                        canvasDesenho.ActualWidth,
                                        canvasDesenho.ActualHeight);

                                    configuracaoMaoEsquerda.PosXFinalLinha = lPosicaoArticulacaoOrigem.X;
                                    configuracaoMaoEsquerda.PosYFinalLinha = lPosicaoArticulacaoOrigem.Y;

                                    configuracaoMaoEsquerda.SetouXFinalLinha = true;
                                    configuracaoMaoEsquerda.SetouYFinalLinha = true;

                                    esqueletoAuxiliar.InteracaoDesenharLinhaEntreDoisPontosMao(
                                        lEsqueletoUsuario,
                                        esqueletoAuxiliar,
                                        canvasDesenho,
                                        configuracaoMaoEsquerda);

                                    configuracaoMaoEsquerda.PosXInicialLinha = configuracaoMaoEsquerda.PosXFinalLinha;
                                    configuracaoMaoEsquerda.PosYInicialLinha = configuracaoMaoEsquerda.PosYFinalLinha;

                                    configuracaoMaoEsquerda.SetouXInicialLinha = true;
                                    configuracaoMaoEsquerda.SetouYInicialLinha = true;
                                    configuracaoMaoEsquerda.SetouXFinalLinha = false;
                                    configuracaoMaoEsquerda.SetouYFinalLinha = false;

                                }
                            }
                            else
                            {
                                //para quando abrir a mão, começar um novo desenho
                                configuracaoMaoEsquerda.SetouXInicialLinha = false;
                                configuracaoMaoEsquerda.SetouYInicialLinha = false;
                                configuracaoMaoEsquerda.SetouXFinalLinha = false;
                                configuracaoMaoEsquerda.SetouYFinalLinha = false;
                            }
                        }
                        else //modo nao canhoto
                        {
                            //if (configuracaoMaoDireita.DesenhoAtivo
                            //    && !((RowDefinitionExtended)GradePrincipal.RowDefinitions[3]).Visible)
                            if (configuracaoMaoDireita.DesenhoAtivo
                                && MenusEstaoEscondidos())
                            {
                                if (configuracaoMaoDireita.SetouXFinalLinha == false
                                    && configuracaoMaoDireita.SetouXInicialLinha == false
                                    && configuracaoMaoDireita.SetouYFinalLinha == false
                                    && configuracaoMaoDireita.SetouYInicialLinha == false)
                                {//nao setou nada, seta a pos inicial e desenha uma bola
                                    ColorImagePoint lPosicaoArticulacaoOrigem = ConverterCoordenadasArticulacao(
                                        lEsqueletoUsuario.Joints[JointType.HandRight],
                                        canvasDesenho.ActualWidth,
                                        canvasDesenho.ActualHeight);

                                    configuracaoMaoDireita.PosXInicialLinha = lPosicaoArticulacaoOrigem.X;
                                    configuracaoMaoDireita.PosYInicialLinha = lPosicaoArticulacaoOrigem.Y;

                                    configuracaoMaoDireita.SetouXInicialLinha = true;
                                    configuracaoMaoDireita.SetouYInicialLinha = true;

                                    esqueletoAuxiliar.InteracaoDesenharLinhaEntreDoisPontosMao(
                                        lEsqueletoUsuario,
                                        esqueletoAuxiliar,
                                        canvasDesenho,
                                        configuracaoMaoDireita);
                                }
                                else if (configuracaoMaoDireita.SetouXFinalLinha == false
                                    && configuracaoMaoDireita.SetouXInicialLinha == true
                                    && configuracaoMaoDireita.SetouYFinalLinha == false
                                    && configuracaoMaoDireita.SetouYInicialLinha == true)
                                {//setou a pos inicial, seto a final
                                    ColorImagePoint lPosicaoArticulacaoOrigem = ConverterCoordenadasArticulacao(
                                        lEsqueletoUsuario.Joints[JointType.HandRight],
                                        canvasDesenho.ActualWidth,
                                        canvasDesenho.ActualHeight);

                                    configuracaoMaoDireita.PosXFinalLinha = lPosicaoArticulacaoOrigem.X;
                                    configuracaoMaoDireita.PosYFinalLinha = lPosicaoArticulacaoOrigem.Y;

                                    configuracaoMaoDireita.SetouXFinalLinha = true;
                                    configuracaoMaoDireita.SetouYFinalLinha = true;

                                    esqueletoAuxiliar.InteracaoDesenharLinhaEntreDoisPontosMao(
                                        lEsqueletoUsuario,
                                        esqueletoAuxiliar,
                                        canvasDesenho,
                                        configuracaoMaoDireita);


                                    configuracaoMaoDireita.PosXInicialLinha = configuracaoMaoDireita.PosXFinalLinha;
                                    configuracaoMaoDireita.PosYInicialLinha = configuracaoMaoDireita.PosYFinalLinha;

                                    configuracaoMaoDireita.SetouXInicialLinha = true;
                                    configuracaoMaoDireita.SetouYInicialLinha = true;
                                    configuracaoMaoDireita.SetouXFinalLinha = false;
                                    configuracaoMaoDireita.SetouYFinalLinha = false;

                                }
                            }
                            else
                            {
                                //para quando abrir a mão, começar um novo desenho
                                configuracaoMaoDireita.SetouXInicialLinha = false;
                                configuracaoMaoDireita.SetouYInicialLinha = false;
                                configuracaoMaoDireita.SetouXFinalLinha = false;
                                configuracaoMaoDireita.SetouYFinalLinha = false;
                            }
                        }
                    }
                }
                else
                {
                    if (configuracaoApresentacao != null)
                        AddPPTCanvasKinect(configuracaoApresentacao.GetSlideAtual());

                    foreach (IRastreador rastreador in Rastreadores)
                        rastreador.Rastrear(lEsqueletoUsuario);

                    if (configuracaoApresentacao != null && configuracaoApresentacao.GetMostrarEsqueletoUsuario())
                        //if (btnEsqueletoUsuario.IsChecked)
                        pQuadro.DesenharEsqueletoUsuario(Kinect, canvasKinect);
                }


            }
        }


        private void slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (Kinect != null)
                Kinect.ElevationAngle = Convert.ToInt32(slider.Value);
        }

        //reconhecimento de quadros

        private void kineckt_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            byte[] lImagem = ObterImagemSensorRGB(e.OpenColorImageFrame());

            //if (btnEscalaCinza.IsChecked)
            FuncoesProfundidade(e.OpenDepthImageFrame(), lImagem, 2000);

            if ((lImagem != null) && (Kinect.ColorStream.IsEnabled))
                canvasKinect.Background = new ImageBrush(
                    BitmapSource.Create(
                    Kinect.ColorStream.FrameWidth,
                    Kinect.ColorStream.FrameHeight,
                    96,
                    96,
                    PixelFormats.Bgr32,
                    null,
                    lImagem,
                    Kinect.ColorStream.FrameBytesPerPixel * Kinect.ColorStream.FrameWidth)
                    );

            canvasKinect.Children.Clear();

            // if (chkEsqueleto.IsChecked.HasValue && chkEsqueleto.IsChecked.Value)
            FuncoesEsqueletoUsuario(e.OpenSkeletonFrame());
        }


        private void fluxoInteracao_InteractionFrameReady(object sender, InteractionFrameReadyEventArgs e)
        {
            using (InteractionFrame quadro = e.OpenInteractionFrame())
            {
                if (quadro == null) return;

                UserInfo[] informacoesUsuarios = new UserInfo[6];

                quadro.CopyInteractionDataTo(informacoesUsuarios);

                IEnumerable<UserInfo> usuariosRastreados = informacoesUsuarios.Where(
                    info => info.SkeletonTrackingId != 0);

                if (usuariosRastreados.Count() > 0)
                {
                    UserInfo usuarioPrincipal = usuariosRastreados.First();

                    if (usuarioPrincipal.HandPointers[0].HandEventType == InteractionHandEventType.Grip)
                    {
                        configuracaoMaoEsquerda.DesenhoAtivo = true;
                    }
                    else if (usuarioPrincipal.HandPointers[0].HandEventType == InteractionHandEventType.GripRelease)
                    {
                        configuracaoMaoEsquerda.DesenhoAtivo = false;
                    }


                    if (usuarioPrincipal.HandPointers[1].HandEventType == InteractionHandEventType.Grip)
                    {
                        configuracaoMaoDireita.DesenhoAtivo = true;
                    }
                    else if (usuarioPrincipal.HandPointers[1].HandEventType == InteractionHandEventType.GripRelease)
                    {
                        configuracaoMaoDireita.DesenhoAtivo = false;
                    }
                }
            }
        }


        //metodos da janela principal


        public MainWindow()
        {
            InitializeComponent();

            InicializarSeletor();

            InicializarRastreadores();

            InicializarConfiguracoesDesenho();


            ControlaColuna(0, false);
            ControlaLinha(3, false);

            EsconderTodosMenus();

            menuVertical.Iniciar();
            menuSlides.Visibility = System.Windows.Visibility.Hidden;


            //String lnomecompleto;
            //lnomecompleto = System.Windows.Forms.Application.StartupPath + "\\Imagens\\power.png";

            //carregar uma imagem no botao
            /*if (File.Exists(lnomecompleto))
            {
                ImageBrush lImageBrush = new ImageBrush(
                    new BitmapImage(
                        new Uri(lnomecompleto,
                            UriKind.Relative)
                            ));

                btnFechar.Background = lImageBrush;
                btnFechar.Content = "";
                
                //button.
            }*/

            //if (kinectRegion.KinectSensor == null)
            //    kinectRegion.KinectSensor = Kinect;

            AssociarKinectAosMenus();

            _gestureController = new GestureController(GestureType.All);
            _gestureController.GestureRecognized += GestureController_GestureRecognized;

        }


        private void Window_Closed(object sender, EventArgs e)
        {
            if (Kinect != null)
            {
                if (Kinect.ElevationAngle != 0)
                    Kinect.ElevationAngle = 0;

                Kinect.Stop();
            }
        }

        //inicializacoes

        private void InicializarRastreadores()
        {
            Rastreadores = new List<IRastreador>();

            //mostra ou esconde o esqueleto
            Rastreador<PoseT> lRastreadorPoseT = new Rastreador<PoseT>();
            lRastreadorPoseT.MovimentoIdentificado += PoseTIdentificada;

            //pausa
            Rastreador<PoseMaosCintura> lRastreadorPoseMaosCintura = new Rastreador<PoseMaosCintura>();
            lRastreadorPoseMaosCintura.MovimentoIdentificado += PoseMaosCinturaIdentificada;
            lRastreadorPoseMaosCintura.MovimentoEmProgresso += PoseMaosCinturaEmProgresso;

            //volta slide
            Rastreador<PosePauseEsquerda> rastreadorPosePauseEsquerda = new Rastreador<PosePauseEsquerda>();
            rastreadorPosePauseEsquerda.MovimentoIdentificado += PosePauseEsquerdaIdentificada;
            rastreadorPosePauseEsquerda.MovimentoEmProgresso += PosePauseEsquerdaEmProgresso;

            //avança slide
            Rastreador<PosePauseDireita> rastreadorPosePauseDireita = new Rastreador<PosePauseDireita>();
            rastreadorPosePauseDireita.MovimentoIdentificado += PosePauseDireitaIdentificada;
            rastreadorPosePauseDireita.MovimentoEmProgresso += PosePauseDireitaEmProgresso;

            //aceno
            Rastreador<Aceno> rastreadorAceno = new Rastreador<Aceno>();
            rastreadorAceno.MovimentoIdentificado += AcenoIndentificado;

            //Mostra Menu Inferior
            Rastreador<BaixoParaCima> rastreadorBaixoParaCima = new Rastreador<BaixoParaCima>();
            rastreadorBaixoParaCima.MovimentoIdentificado += BaixoParaCimaIdentificado;

            //essa tem q melhorar se for virar o passador de slide
            Rastreador<PassaEsquerdaParaDireita> rastreadorPassaEsquerdaParaDireita = new Rastreador<PassaEsquerdaParaDireita>();
            rastreadorPassaEsquerdaParaDireita.MovimentoIdentificado += PassaEsquerdaParaDireitaIdentificado;


            Rastreadores.Add(lRastreadorPoseT);
            Rastreadores.Add(rastreadorPosePauseEsquerda);
            Rastreadores.Add(rastreadorPosePauseDireita);
            Rastreadores.Add(rastreadorAceno);
            Rastreadores.Add(rastreadorBaixoParaCima);
            Rastreadores.Add(lRastreadorPoseMaosCintura);
            //Rastreadores.Add(rastreadorPassaEsquerdaParaDireita);
        }


        public void InicializarSeletor()
        {
            InicializadorKinect lInicializador = new InicializadorKinect();

            lInicializador.MetodoInicializadorKinect = InicializarKinect;

            seletorSensorUI.KinectSensorChooser = lInicializador.SeletorKinect;
            menuVertical.seletorSensorUI.KinectSensorChooser = lInicializador.SeletorKinect;

            menuVertical.seletorSensorUI.KinectSensorChooser.KinectChanged += SensorChooserOnKinectChanged;
        }

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            //System.Windows.MessageBox.Show(args.NewSensor == null ? "No Kinect" : args.NewSensor.Status.ToString());

            if (args.NewSensor == null) //desconectou            
                DesassociarKinectAosMenus();
            else //conectou
                AssociarKinectAosMenus();
        }

        private void InicializarKinect(KinectSensor pKinectSensor)
        {
            Kinect = pKinectSensor;
            slider.Value = Kinect.ElevationAngle;

            //para usar o fluxo de profundidade
            Kinect.DepthStream.Enable();
            //Kinect.DepthFrameReady += kinect_DepthFrameReady;

            //sensor de esqueleto

            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.7f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 0.0f,
                MaxDeviationRadius = 0.0f
            };

            /*
             var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.7f,
                Correction = 0.3f,
                Prediction = 0.3f,
                JitterRadius = 0.4f,
                MaxDeviationRadius = 0.5f
            };
             */

            Kinect.SkeletonStream.Enable(parameters);
            //Kinect.SkeletonStream.Enable();


            //Kinect.SkeletonStream.Enable();

            //pata usar o fluxo de cores
            //Kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            Kinect.ColorStream.Enable();

            //Kinect.ColorFrameReady += kinect_ColorFrameReady;

            Kinect.AllFramesReady += kineckt_AllFramesReady;


            //if (kinectRegion.KinectSensor == null)
            //    kinectRegion.KinectSensor = Kinect;

            AssociarKinectAosMenus();
        }

        private void InicializarConfiguracoesDesenho()
        {
            configuracaoMaoDireita = new ConfiguracaoDesenho();
            configuracaoMaoDireita.Cor = System.Windows.Media.Brushes.Red;
            //configuracaoMaoDireita.Forma = FormaDesenho.Linha;
            //configuracaoMaoDireita.Tamanho = 5;


            configuracaoMaoEsquerda = new ConfiguracaoDesenho();
            configuracaoMaoEsquerda.Cor = System.Windows.Media.Brushes.Red;
            //configuracaoMaoEsquerda.Forma = FormaDesenho.Linha;
            //configuracaoMaoEsquerda.Tamanho = 10;
        }


        private void InicializarFluxoInteracao()
        {
            if (Kinect == null) return;

            fluxoInteracao = new InteractionStream(Kinect, canvasDesenho);
            fluxoInteracao.InteractionFrameReady += fluxoInteracao_InteractionFrameReady;
        }


        //cliques botoes

        private void btnDesenharClick(object sender, RoutedEventArgs e)
        {
            EntrarEmModoDesenho();
        }

        /*
        private void btnVoltarClick(object sender, RoutedEventArgs e)
        {
            if (kinectRegion.KinectSensor != null)
                kinectRegion.KinectSensor = null;

            if (Kinect.ColorStream.IsEnabled == true)
            {
                Kinect.ColorStream.Disable();
            }
            else
            {
                Kinect.ColorStream.Enable();
            }
        }
         * */


        private void btnFecharClick(object sender, RoutedEventArgs e)
        {
            SairAppOriginal();
        }

        private void SairAppOriginal()
        {
            if (EnviandoEmail)
                MostrarInformacao("Seu e-mail ainda está sendo enviado", true);
            else
                System.Windows.Application.Current.Shutdown();
        }

        /*
        public object CurrentPopup
        {
            get { return _currentPopup; }
            set
            {
                _currentPopup = value;

                Teste.Content = _currentPopup;
            }
        }
        private object _currentPopup;
        */

        private void AbrirApresentacao()
        {
            AbrindoApresentacao = true;

            bool AbrirAutomatico = false;
            String lNomeCompletoArquivoOrigem;
            bool lAbriu = false;

            menuSlides.Visibility = System.Windows.Visibility.Hidden;

            MostrarInformacao("Aguarde até que a sua apresentação seja carregada...", false);

            lNomeCompletoArquivoOrigem = "E:\\TCCA Renato Nunes.ppt";

            if (!AbrirAutomatico)
            {
                OpenFileDialog lOpenFileDialog = new OpenFileDialog();

                lOpenFileDialog.Filter = "Apresentações (*.ppt; *.pptx; *.pdf)|*.ppt; *.pptx; *.pdf|"
                                       + "Apresentação do Microsoft Power Point (*.ppt; *.pptx)|*.ppt; *.pptx|"
                                       + "Apresentação do Adobe Acrobat (*.pdf)|*.pdf";

                if (lOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lNomeCompletoArquivoOrigem = lOpenFileDialog.FileName;
                    lAbriu = true;
                }
            }
            else
                lAbriu = true;

            if (lAbriu)
            {
                int i = 0;
                String lNomeCompleto = "";
                String lNomeSlide = "";

                //cria objeto de configuracao
                configuracaoApresentacao = new ConfiguracaoApresentacao();

                //cria pastas desta apresentacao
                String lNomeArquivoOrigem = System.IO.Path.GetFileNameWithoutExtension(lNomeCompletoArquivoOrigem);

                configuracaoApresentacao.SetNomeApresentacaoAtual(lNomeArquivoOrigem);

                configuracaoApresentacao.SetPastaApresentacaoAtual(System.Windows.Forms.Application.StartupPath + "\\" + lNomeArquivoOrigem + "\\");

                //verifica extensao do arquivo escolhido
                String lExtensao = System.IO.Path.GetExtension(lNomeCompletoArquivoOrigem);

                this.wrapPanel.Children.Clear();
                menuSlides.wrapPanel.Children.Clear();

                if (((lExtensao.ToUpper()) == ".PPT") || ((lExtensao.ToUpper()) == ".PPTX"))
                {
                    //carregando PPT
                    configuracaoApresentacao.SetTipoApresentacao(TiposApresentacao.PPT);

                    Microsoft.Office.Interop.PowerPoint.Application pptApplication =
                        new Microsoft.Office.Interop.PowerPoint.Application();

                    Microsoft.Office.Interop.PowerPoint.Presentation pptPresentation =
                        pptApplication.Presentations.Open(
                        lNomeCompletoArquivoOrigem,
                        MsoTriState.msoFalse,
                        MsoTriState.msoFalse,
                        MsoTriState.msoFalse);

                    configuracaoApresentacao.SetMaxSlides(pptPresentation.Slides.Count);

                    // Adiciona figuras ao warppanel da lateral esquerda                   
                    foreach (Microsoft.Office.Interop.PowerPoint.Slide pptSlide in pptPresentation.Slides)
                    {
                        i = i + 1;

                        //double lPercentual = (i * 100) / lTotalSlides;

                        //MostrarBarraProgresso(lPercentual);

                        lNomeSlide = Convert.ToString(i) + ".png";

                        //lnomecompleto = "E://" + lnomeslide;                    

                        lNomeCompleto = configuracaoApresentacao.GetPastaApresentacaoAtual() + lNomeSlide;

                        pptSlide.Export(lNomeCompleto, "PNG", 1024, 768);

                        var button = new KinectTileButton { Label = (i).ToString(CultureInfo.CurrentCulture) };

                        button.Command = SlideClick;
                        //button.Name = Convert.ToString(i);

                        if (File.Exists(lNomeCompleto))
                        {
                            ImageBrush lImageBrush = new ImageBrush(
                                new BitmapImage(
                                    new Uri(lNomeCompleto,
                                        UriKind.Relative)
                                        ));

                            button.Background = lImageBrush;
                        }
                        //this.wrapPanel.Children.Add(button);

                        menuSlides.wrapPanel.Children.Add(button);
                    }
                }
                else
                {
                    //carregando PDF
                    configuracaoApresentacao.SetTipoApresentacao(TiposApresentacao.PDF);

                    FuncoesAuxiliares.ConvertSingleImage(lNomeCompletoArquivoOrigem, configuracaoApresentacao.GetPastaApresentacaoAtual());

                    PreparaArquivosPDF(configuracaoApresentacao.GetPastaApresentacaoAtual());

                }

                if (configuracaoApresentacao != null)
                    AddPPTCanvasKinect(configuracaoApresentacao.GetSlideAtual());
            }

            EsconderMsgInformacao();

            EsconderTodosMenus();

            AbrindoApresentacao = false;
        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            AbrirApresentacao();
        }

        private void PreparaArquivosPDF(string pCaminho)
        {
            try
            {
                // Caminho real da pasta informada 
                DirectoryInfo lDirInfo = new DirectoryInfo(pCaminho);

                // Pega todas as informações dos arquivos dentro do diretório informado 
                FileInfo[] lInformacoesArquivos = lDirInfo.GetFiles();

                string lNomeArquivo;
                int i;

                menuSlides.wrapPanel.Children.Clear();

                //para adicionar no warp
                for (i = 0; i < lInformacoesArquivos.Length; i++)
                {
                    if (lInformacoesArquivos[i].Name.Contains(".png"))
                    {
                        lNomeArquivo = pCaminho + "\\" + Convert.ToString(i + 1) + ".png";

                        var button = new KinectTileButton { Label = (i + 1).ToString(CultureInfo.CurrentCulture) };

                        button.Command = SlideClick;

                        if (File.Exists(lNomeArquivo))
                        {
                            ImageBrush lImageBrush = new ImageBrush(
                                new BitmapImage(
                                    new Uri(lNomeArquivo,
                                        UriKind.Relative)
                                        ));

                            button.Background = lImageBrush;
                        }
                        //this.wrapPanel.Children.Add(button);
                        menuSlides.wrapPanel.Children.Add(button);
                    }
                }

                configuracaoApresentacao.SetMaxSlides(i);

            }
            catch// (Exception ex)
            {
                // Se der erro, exibe o que aconteceu MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //gestos

        private void AcenoIndentificado(object sender, EventArgs e)
        {
            //Application.Current.Shutdown();

            //if (kinectRegion.KinectSensor == null)
            //    kinectRegion.KinectSensor = Kinect;




        }

        private void PassaEsquerdaParaDireitaIdentificado(object sender, EventArgs e)
        {
            //btnEsqueletoUsuario.IsChecked = false;
        }

        private void BaixoParaCimaIdentificado(object sender, EventArgs e)
        {

            //btnEsqueletoUsuario.IsChecked = false;
            if (configuracaoApresentacao != null)
            {
                //ControlaLinha(2, configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao);
                //ControlaLinha(3, configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoApresentacao);
            }
        }

        public GestureType GestureNameToGetureType(string pGestureName)
        {
            GestureType lResult;
            //None = Undefined gesture.        
            //All = All of the predefined gestures.
            //JoinedHands = Hands joined in front of chest.        
            //WaveRight = Waving using the right hand.        
            //WaveLeft = Waving using the left hand.        
            //Menu = Hand slightly bent above hip (XBOX-like gesture).
            //SwipeLeft = Hand moved horizontally from right to left.        
            //SwipeRight = Hand moved horizontally from left to right.        
            //SwipeUp = Hand moved vertically from hip center to head.        
            //SwipeDown = Hand moved vertically from head to hip center.        
            //ZoomIn = Both hands extended closer to the chest.
            //ZoomOut = Both hands extended farther from the chest.
            if (pGestureName == "All")
                lResult = GestureType.All;
            else if (pGestureName == "JoinedHands")
                lResult = GestureType.JoinedHands;
            else if (pGestureName == "Menu")
                lResult = GestureType.Menu;
            else if (pGestureName == "SwipeDown")
                lResult = GestureType.SwipeDown;
            else if (pGestureName == "SwipeLeft")
                lResult = GestureType.SwipeLeft;
            else if (pGestureName == "SwipeRight")
                lResult = GestureType.SwipeRight;
            else if (pGestureName == "SwipeUp")
                lResult = GestureType.SwipeUp;
            else if (pGestureName == "WaveLeft")
                lResult = GestureType.WaveLeft;
            else if (pGestureName == "WaveRight")
                lResult = GestureType.WaveRight;
            else if (pGestureName == "ZoomIn")
                lResult = GestureType.ZoomIn;
            else if (pGestureName == "ZoomOut")
                lResult = GestureType.ZoomOut;
            else
                lResult = GestureType.None;

            return lResult;
        }

        void GestureController_GestureRecognized(object sender, GestureEventArgs e)
        {
            // Display the gesture type.
            tblGestures.Text = e.Name;

            GestureType lTipo = GestureNameToGetureType(e.Name);

            // Do something according to the type of the gesture.
            //switch (e.Type)
            switch (lTipo)
            {
                case GestureType.JoinedHands:
                    break;
                case GestureType.Menu:  //entra no modo desenho
                    break;
                case GestureType.SwipeDown: //esconde menu inferior
                    {
                        //ESCONDER O WRAP
                        if ((configuracaoApresentacao != null) && (!configuracaoApresentacao.GetPausarMovimentos()))
                            EsconderMenuInferior();

                        /*
                        if (configuracaoApresentacao != null)
                        {
                            if (configuracaoMaoDireita != null && !configuracaoMaoDireita.DesenhoAtivo)
                            {
                                //esconde menu abrir
                                ControlaLinha(2, false);
                                //esconde menu desenho
                                ControlaLinha(3, false);

                                //esconde linha statuskinect
                                ControlaLinha(0, false);
                                //esconde coluna do slide do kinect
                                ControlaColuna(2, false);
                            }
                        }
                         * */
                        break;
                    }

                case GestureType.SwipeLeft: //esconde menu lateral
                    {
                        //ESCONDER O MENU INICIAL/DESENHO
                        if ((configuracaoApresentacao != null) && (!configuracaoApresentacao.GetPausarMovimentos()))
                            EsconderMenuLateral();

                        /*
                        if (configuracaoApresentacao != null)
                        {
                            if (configuracaoMaoDireita != null && !configuracaoMaoDireita.DesenhoAtivo)
                                ControlaColuna(0, false);
                        }
                         * */
                        break;
                    }
                case GestureType.SwipeRight: //mostra menu lateral
                    {
                        //MOSTRAR O MENU INICIAL/DESENHO
                        if ((configuracaoApresentacao != null) && (!configuracaoApresentacao.GetPausarMovimentos()))
                            MostrarMenuLateral();

                        /*
                        if (configuracaoApresentacao != null)
                        {
                            //mostra menu lateral se estiver em modo apresentacao
                            ControlaColuna(0, configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao);
                        }
                         * */
                        break;
                    }
                case GestureType.SwipeUp: //mostra menu inferior
                    {
                        //MOSTRAR O MENU DO WRAP
                        if ((configuracaoApresentacao != null) && (!configuracaoApresentacao.GetPausarMovimentos()))
                        {
                            if (menuSlides.Visibility == System.Windows.Visibility.Hidden)
                                MostrarMenuInferior();
                            else
                                EsconderMenuInferior();
                        }

                        /*
                        if (configuracaoApresentacao != null)
                        {
                            if (configuracaoMaoDireita != null && !configuracaoMaoDireita.DesenhoAtivo)
                            {
                                //mostra menu abrir se estiver em modo apresentacao
                                ControlaLinha(2, configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao);
                                //mostra menu desenhar se estiver em modo apresentacao
                                ControlaLinha(3, configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoApresentacao);

                                //esconde linha statuskinect
                                ControlaLinha(0, false);
                                //esconde coluna do slide do kinect
                                ControlaColuna(2, false);
                            }
                        }
                         * */
                        break;
                    }
                case GestureType.WaveLeft:
                    //SALVAR DESENHO

                    //destro - desenha com a direita, salva com a esquerda
                    if ((configuracaoApresentacao != null)
                        && (!configuracaoApresentacao.GetModoCanhoto())
                        && (!configuracaoApresentacao.GetPausarMovimentos()))
                    {
                        if (msgInformacao.Visibility == System.Windows.Visibility.Hidden) //teste
                        {
                            SalvarDesenho();

                            if (MenusEstaoEscondidos())
                                MostrarInformacao("Desenho salvo com sucesso", true);
                        }
                        else
                            EsconderMsgInformacao();
                    }


                    break;
                case GestureType.WaveRight: //some todos menus
                    {
                        //canhoto - desenha com a esquerda, salva com a direita
                        if ((configuracaoApresentacao != null)
                            && (configuracaoApresentacao.GetModoCanhoto())
                            && (!configuracaoApresentacao.GetPausarMovimentos()))
                        {
                            if (msgInformacao.Visibility == System.Windows.Visibility.Hidden) //teste
                            {
                                SalvarDesenho();

                                if (MenusEstaoEscondidos())
                                    MostrarInformacao("Desenho salvo com sucesso", true);
                            }
                            else
                                EsconderMsgInformacao();
                        }

                        break;
                    }
                case GestureType.ZoomIn:
                    //ABRIR APRESENTACAO

                    if ((configuracaoApresentacao == null) && (!AbrindoApresentacao))
                        AbrirApresentacao();

                    break;
                case GestureType.ZoomOut:
                    //System.Windows.Application.Current.Shutdown();
                    if ((configuracaoApresentacao != null) && (!configuracaoApresentacao.GetPausarMovimentos()))
                        AlternarEstadoApresentacao();

                    break;
                default:
                    break;
            }
        }

        //poses
        private void PoseMaosCinturaIdentificada(object sender, EventArgs e)
        {
            if (configuracaoApresentacao != null && configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho)
                configuracaoApresentacao.SetPausarMovimentos(!configuracaoApresentacao.GetPausarMovimentos());
        }

        private void PoseMaosCinturaEmProgresso(object sender, EventArgs e)
        {
            if (configuracaoApresentacao != null && configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho)
            {
                PoseMaosCintura pose = sender as PoseMaosCintura;

                MostrarBarraProgresso(pose.PercentualProgresso);
            }
        }

        private void PosePauseEsquerdaIdentificada(object sender, EventArgs e)
        {
            //btnEscalaCinza.IsChecked = !btnEscalaCinza.IsChecked;

            if ((configuracaoApresentacao != null)
                && (configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho)
                && (InputBox.Visibility == System.Windows.Visibility.Hidden)
                && (!configuracaoApresentacao.GetPausarMovimentos()))
            {
                configuracaoApresentacao.VoltaSlide();
                AddPPTCanvasKinect(configuracaoApresentacao.GetSlideAtual());
                ApagarDesenhoOriginal();
                EsconderMsgInformacao();
            }
        }

        private void PosePauseDireitaIdentificada(object sender, EventArgs e)
        {
            //btnEscalaCinza.IsChecked = !btnEscalaCinza.IsChecked;

            if ((configuracaoApresentacao != null)
                && (configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho)
                && (InputBox.Visibility == System.Windows.Visibility.Hidden)
                && (!configuracaoApresentacao.GetPausarMovimentos()))
            {
                configuracaoApresentacao.AvancaSlide();
                AddPPTCanvasKinect(configuracaoApresentacao.GetSlideAtual());
                ApagarDesenhoOriginal();
                EsconderMsgInformacao();
            }
        }

        private void PoseTIdentificada(object sender, EventArgs e)
        {
            //btnEsqueletoUsuario.IsChecked = !btnEsqueletoUsuario.IsChecked;
            if (configuracaoApresentacao != null)
                configuracaoApresentacao.SetMostrarEsqueletoUsuario(!configuracaoApresentacao.GetMostrarEsqueletoUsuario());

            //ControlaLinha(2, true);
            //ControlaColuna(0, false);

        }

        private void ControlaLinha(int pLinha, bool pHabilitar)
        {
            ((RowDefinitionExtended)GradePrincipal.RowDefinitions[pLinha]).Visible = pHabilitar;
        }

        private void ControlaColuna(int pColuna, bool pHabilitar)
        {
            ((ColumnDefinitionExtended)GradePrincipal.ColumnDefinitions[pColuna]).Visible = pHabilitar;
        }

        private void PosePauseEsquerdaEmProgresso(object sender, EventArgs e)
        {
            if (configuracaoApresentacao != null 
                && configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho
                && (!configuracaoApresentacao.GetPausarMovimentos()))
            {
                PosePauseEsquerda pose = sender as PosePauseEsquerda;

                MostrarBarraProgresso(pose.PercentualProgresso);
            }
        }

        private void PosePauseDireitaEmProgresso(object sender, EventArgs e)
        {
            if (configuracaoApresentacao != null && configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho
                && (!configuracaoApresentacao.GetPausarMovimentos()))
            {
                PosePauseDireita pose = sender as PosePauseDireita;

                MostrarBarraProgresso(pose.PercentualProgresso);
            }
        }

        private void MostrarBarraProgresso(double pPercentualProgresso)
        {

            System.Windows.Shapes.Rectangle retangulo = new System.Windows.Shapes.Rectangle();
            retangulo.Width = canvasKinect.ActualWidth;
            retangulo.Height = 20;
            retangulo.Fill = System.Windows.Media.Brushes.Black;
            System.Windows.Shapes.Rectangle poseRetangulo = new System.Windows.Shapes.Rectangle();
            poseRetangulo.Width =
            canvasKinect.ActualWidth * pPercentualProgresso / 100;
            poseRetangulo.Height = 20;
            poseRetangulo.Fill = System.Windows.Media.Brushes.BlueViolet;

            /*
            if (configuracaoApresentacao != null && configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho) { 
            
            }
            else
            {


            }
             */

            //if (!btnDesenhar.IsChecked)
            if ((configuracaoApresentacao != null) && (configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho))
            {
                canvasKinect.Children.Add(retangulo);
                canvasKinect.Children.Add(poseRetangulo);
            }
            else
            {
                canvasDesenho.Children.Add(retangulo);
                canvasDesenho.Children.Add(poseRetangulo);
            }


        }

        //botoes do menu fixo
        private void KinectTileButtonClick(object sender, RoutedEventArgs e)
        {
            if (configuracaoApresentacao != null)
            {
                var button = (KinectTileButton)e.OriginalSource;

                int lSlide = Convert.ToInt16(button.Label);

                configuracaoApresentacao.SetSlideAtual(lSlide);
                AddPPTCanvasKinect(lSlide);
            }

        }

        private void btnApresentacao_Click(object sender, RoutedEventArgs e)
        {
            EntrarModoApresentacaoOriginal();
        }

        private void EntrarModoApresentacaoOriginal()
        {
            if (configuracaoApresentacao != null)
                configuracaoApresentacao.SetEstadoApresentacaoAtual(EstadosApresentacao.ModoApresentacao);

            //ControlaLinha(2, false);
            //ControlaLinha(3, false);

            //menuVertical.SetMenuInicial();
            EsconderMsgInformacao();

            EsconderMenuLateral();
        }

        private void btnAumentaLinha_Click(object sender, RoutedEventArgs e)
        {
            AumentarLinhaOriginal();
        }

        private void AumentarLinhaOriginal()
        {
            if (configuracaoMaoDireita != null)
                configuracaoMaoDireita.AumentarTamanhoDesenho();

            if (configuracaoMaoEsquerda != null)
                configuracaoMaoEsquerda.AumentarTamanhoDesenho();
        }

        private void btnDiminuirLinha_Click(object sender, RoutedEventArgs e)
        {
            DiminuirLinhaOriginal();
        }

        private void DiminuirLinhaOriginal()
        {
            if (configuracaoMaoDireita != null)
                configuracaoMaoDireita.DiminuirTamanhoDesenho();

            if (configuracaoMaoEsquerda != null)
                configuracaoMaoEsquerda.DiminuirTamanhoDesenho();

        }

        private void btnVermelho_Click(object sender, RoutedEventArgs e)
        {
            SetVermelho();
        }

        private void SetVermelho()
        {
            if (configuracaoMaoDireita != null)
                configuracaoMaoDireita.Cor = System.Windows.Media.Brushes.Red;

            if (configuracaoMaoEsquerda != null)
                configuracaoMaoEsquerda.Cor = System.Windows.Media.Brushes.Red;

            menuVertical.btnVerde.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnVerde.IsChecked = false;

            menuVertical.btnAzul.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnAzul.IsChecked = false;
        }

        private void btnVerde_Click(object sender, RoutedEventArgs e)
        {
            SetVerde();
        }

        private void SetVerde()
        {
            if (configuracaoMaoDireita != null)
                configuracaoMaoDireita.Cor = System.Windows.Media.Brushes.Green;

            if (configuracaoMaoEsquerda != null)
                configuracaoMaoEsquerda.Cor = System.Windows.Media.Brushes.Green;


            menuVertical.btnVermelho.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnVermelho.IsChecked = false;

            menuVertical.btnAzul.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnAzul.IsChecked = false;
        }

        private void btnAzul_Click(object sender, RoutedEventArgs e)
        {
            SetAzul();
        }

        private void SetAzul()
        {
            if (configuracaoMaoDireita != null)
                configuracaoMaoDireita.Cor = System.Windows.Media.Brushes.Blue;

            if (configuracaoMaoEsquerda != null)
                configuracaoMaoEsquerda.Cor = System.Windows.Media.Brushes.Blue;

            menuVertical.btnVermelho.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnVermelho.IsChecked = false;

            menuVertical.btnVerde.Foreground = System.Windows.Media.Brushes.RoyalBlue;
            menuVertical.btnVerde.IsChecked = false;
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            ApagarDesenhoOriginal();
        }

        private void ApagarDesenhoOriginal()
        {
            canvasDesenho.Children.Clear();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirArquivoDesenho();
        }

        private void ExcluirArquivoDesenho()
        {
            if (configuracaoApresentacao != null)
            {
                string lNomeSlide = Convert.ToString(configuracaoApresentacao.GetSlideAtual()) + ".png";

                if (configuracaoApresentacao != null)
                    System.IO.File.Delete(configuracaoApresentacao.GetPastaDesenhosApresentacao() + lNomeSlide);
            }

            //ControlaLinha(3, false);
            //System.Threading.Thread.Sleep(5000);           

            //SaveWindow(this, 96, "E:\\window.png");
            //SaveCanvas(this, canvasKinect, 96, "E:\\kinect.png");
            //SaveCanvas(this, canvasDesenho, 96, "E:\\desenho.png");
            //System.Threading.Thread.Sleep(5000);
            //ControlaLinha(3, true);


            //System.Windows.MessageBox.Show("Salvar");
            /*
            Rect bounds = VisualTreeHelper.GetDescendantBounds(canvasDesenho);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);


            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(canvasKinect);
                dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), bounds.Size));
            }

            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();

                System.IO.File.WriteAllBytes("E:\\teste.png", ms.ToArray());
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             * */
        }

        //tratamento das imagens

        private void AddPPTCanvasKinect(int pSlide)
        {
            canvasKinect.Children.Clear();

            string lNomeSlide = Convert.ToString(pSlide) + ".png";

            String lArquivo;

            //string lNomeArquivoTempTeste = configuracaoApresentacao.GetPastaTemp()
            //                                + "\\"
            //                                + Convert.ToString(configuracaoApresentacao.GetSlideAtual())
            //                                + ".png";


            //se carrego o do desenho direto, nao consigo salvar a segunda vez pq ta em uso
            //    fazer trocas

            //if ((File.Exists(configuracaoApresentacao.GetPastaDesenhosApresentacao() + lNomeSlide))
            //    && (!configuracaoApresentacao.GetExcluindo())
            //    && (!configuracaoApresentacao.GetSalvando()))
            if (File.Exists(configuracaoApresentacao.GetPastaDesenhosApresentacao() + lNomeSlide))
            {
                lArquivo = configuracaoApresentacao.GetPastaDesenhosApresentacao() + lNomeSlide;
            }
            else
            {
                lArquivo = configuracaoApresentacao.GetPastaApresentacaoAtual() + lNomeSlide;
            }

            if (File.Exists(lArquivo))
            {
                //modo antigo que deixa o arquivo preso
                /*
                 Uri lUri = new Uri(lArquivo, UriKind.Relative);
                 * 
                 * BitmapImage lBitmap = new BitmapImage(lUri);
                 * 
                 * ImageBrush lImageBrush = new ImageBrush(lBitmap);
                 */

                Uri lUri = new Uri(lArquivo, UriKind.Relative);

                BitmapImage lBitmap = new BitmapImage();
                lBitmap.BeginInit();
                lBitmap.CacheOption = BitmapCacheOption.OnLoad;
                lBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                lBitmap.UriSource = lUri;
                lBitmap.EndInit();

                ImageBrush lImageBrush = new ImageBrush(lBitmap);


                /* modo novo nao prende o arquivo, porem fica mtu lento
                BitmapImage image = new BitmapImage();

                MemoryStream mstream = new MemoryStream();
                System.Drawing.Bitmap bitmap = new Bitmap(lArquivo);
                bitmap.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap.Dispose(); // Releases the file.

                mstream.Position = 0;

                image.BeginInit();
                image.StreamSource = mstream;
                image.EndInit();

                ImageBrush lImageBrush = new ImageBrush(image);
                 * */

                canvasKinect.Background = lImageBrush;

                /*
                if (configuracaoApresentacao.GetExcluindo())
                {
                    System.IO.File.Delete(configuracaoApresentacao.GetPastaDesenhosApresentacao() + lNomeSlide);
                    configuracaoApresentacao.SetExcluindo(false);
                }
                else if (configuracaoApresentacao.GetSalvando())
                {
                    //pego do temp e coloco na pasta de desenho atual
                    string lNomeArquivoTemp = configuracaoApresentacao.GetPastaTemp()
                                            + "\\"
                                            + Convert.ToString(configuracaoApresentacao.GetSlideAtual())
                                            + ".png";

                    string lNomeArquivoDesenho = configuracaoApresentacao.GetPastaDesenhosApresentacao()
                                               + "\\"
                                               + Convert.ToString(configuracaoApresentacao.GetSlideAtual())
                                               + ".png";

                    if (System.IO.File.Exists(lNomeArquivoDesenho))
                        System.IO.File.Delete(lNomeArquivoDesenho);

                    System.IO.File.Move(lNomeArquivoTemp, lNomeArquivoDesenho);

                    configuracaoApresentacao.SetSalvando(false);
                }
                 * */
            }
        }

        private void AddPPTCanvasDesenho()
        {
            canvasDesenho.Children.Clear();

            ImageBrush lImageBrush = new ImageBrush(new BitmapImage(new Uri(@"E:\download.jpg", UriKind.Relative)));

            canvasDesenho.Background = lImageBrush;
        }

        private static void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }

        public static void SaveWindow(Window window, int dpi, string filename, int pWidth, int pHeight)
        {

            var rtb = new RenderTargetBitmap(
                pWidth,//(int)window.Width, //width 
                pHeight,//(int)window.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(window);

            SaveRTBAsPNG(rtb, filename);

        }

        public static void SaveCanvas(Window window, Canvas canvas, int dpi, string filename)
        {
            System.Windows.Size size = new System.Windows.Size(window.Width, window.Height);
            canvas.Measure(size);
            //canvas.Arrange(new Rect(size));

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width 
                (int)window.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(canvas);

            SaveRTBAsPNG(rtb, filename);
        }


        //acoes a serem usados por outros metodos

        private void EntrarEmModoDesenho()
        {
            if ((configuracaoApresentacao != null) && (configuracaoApresentacao.GetEstadoApresentacaoAtual() != EstadosApresentacao.ModoDesenho))
            {
                EsconderMsgInformacao();

                InicializarFluxoInteracao();

                configuracaoMaoDireita.SetouXInicialLinha = false;
                configuracaoMaoDireita.SetouYInicialLinha = false;
                configuracaoMaoDireita.SetouXFinalLinha = false;
                configuracaoMaoDireita.SetouYFinalLinha = false;

                //ControlaLinha(2, false);
                //ControlaLinha(3, false);
                EsconderTodosMenus();

                if (configuracaoApresentacao != null)
                    configuracaoApresentacao.SetEstadoApresentacaoAtual(EstadosApresentacao.ModoDesenho);

            }
            else //ja esta em modo desenho
            {
                if (configuracaoApresentacao != null)
                    configuracaoApresentacao.SetEstadoApresentacaoAtual(EstadosApresentacao.ModoApresentacao);

                canvasDesenho.Children.Clear();
                //canvasDesenho.Background = null;                
            }

        }

        private void SalvarDesenho()
        {
            //if (!MenusEstaoEscondidos())
            //    EsconderTodosMenus();

            if ((configuracaoApresentacao != null) && (MenusEstaoEscondidos()))
            {
                //configuracaoApresentacao.SetSalvando(true);

                string lNomeArquivo = configuracaoApresentacao.GetPastaDesenhosApresentacao()
                                    + "\\"
                                    + Convert.ToString(configuracaoApresentacao.GetSlideAtual())
                                    + ".png";

                SaveWindow(this, 96, lNomeArquivo, (int)canvasKinect.ActualWidth, (int)canvasKinect.ActualHeight);

                canvasDesenho.Children.Clear();
                //SaveCanvas(this, canvasKinect, 96, "E:\\kinect.png");
                //SaveCanvas(this, canvasDesenho, 96, "E:\\desenho.png");

                //System.Windows.MessageBox.Show("Salvou");

                //if (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao)
                //{
                //EntrarEmModoDesenho();
                //}
            }
        }

        private void ZiparApresentacao()
        {
            //if (configuracaoApresentacao != null)

            if (System.IO.File.Exists(configuracaoApresentacao.GetArquivoApresentacaoZipado()))
                System.IO.File.Delete(configuracaoApresentacao.GetArquivoApresentacaoZipado());

            ZipFile.CreateFromDirectory(
            configuracaoApresentacao.GetPastaTemp(),
            configuracaoApresentacao.GetArquivoApresentacaoZipado());
        }

        private void EnviarEmail(string pDestinatarios)
        {
            EnviandoEmail = true;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("apresentacaokslide@gmail.com", "tcc2014kslide");

            string lNomeApresentacao = "Apresentacao";

            if (configuracaoApresentacao != null)
                lNomeApresentacao = lNomeApresentacao + " " + configuracaoApresentacao.GetNomeApresentacaoAtual();

            //MailMessage mm = new MailMessage("apresentacaokslide@gmail.com", "nunesrenato86@gmail.com,rnn12345@hotmail.com", lNomeApresentacao, "Em anexo os arquivos da " + lNomeApresentacao);
            MailMessage mm = new MailMessage("apresentacaokslide@gmail.com",
                pDestinatarios,
                lNomeApresentacao, "Em anexo os arquivos da " + lNomeApresentacao);

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //msg.To.Add(new MailAddress("your@email1.com", "Your name 1"));
            //msg.To.Add(new MailAddress("your@email2.com", "Your name 2"));

            Attachment at = new Attachment(configuracaoApresentacao.GetArquivoApresentacaoZipado());
            mm.Attachments.Add(at);

            //client.Send(mm);

            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);

            string userState = "apresentacao";

            client.SendAsync(mm, userState);
        }

        //private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                System.Windows.MessageBox.Show("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                System.Windows.MessageBox.Show("[{0}] {1}", e.Error.ToString());
            }
            else
            {
                //System.Windows.MessageBox.Show("Message sent.");
                MostrarInformacao("E-mail enviado", true);
            }
            //mailSent = true;
            EnviandoEmail = false;
        }

        private void EnviarArquivosPastaTemp()
        {

            string lArquivoOrigem;
            string lArquivoDestino;

            //if (configuracaoApresentacao != null)
            {
                //msgInformacao.SetMensagem("Movendo arquivos", false);

                //msgInformacao.Visibility = System.Windows.Visibility.Visible;

                for (int i = 1; i <= configuracaoApresentacao.GetTotalSlides(); i++)
                {
                    lArquivoOrigem = configuracaoApresentacao.GetPastaDesenhosApresentacao() + Convert.ToString(i) + ".png";

                    if (!System.IO.File.Exists(lArquivoOrigem))
                        lArquivoOrigem = configuracaoApresentacao.GetPastaApresentacaoAtual() + Convert.ToString(i) + ".png";

                    lArquivoDestino = configuracaoApresentacao.GetPastaTemp() + Convert.ToString(i) + ".png";

                    if (System.IO.File.Exists(lArquivoDestino))
                        System.IO.File.Delete(lArquivoDestino);

                    System.IO.File.Copy(lArquivoOrigem, lArquivoDestino);
                }

                //msgInformacao.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void AlternarEstadoApresentacao()
        {
            if (configuracaoApresentacao != null)
            {
                EsconderMsgInformacao();

                if (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao)
                {
                    EntrarEmModoDesenho();
                }
                else //esta em modo desenho
                {
                    //so entra em apresentacao se o menu estiver desativado
                    //if (configuracaoMaoDireita != null && !configuracaoMaoDireita.DesenhoAtivo)
                    EntrarModoApresentacaoOriginal();
                }

            }

        }

        private void AssociarKinectAosMenus()
        {
            if (Kinect != null)
            {
                if (menuVertical.kinectRegionMenu.KinectSensor == null)
                    menuVertical.kinectRegionMenu.KinectSensor = Kinect;

                if (menuSlides.kinectRegionSlides.KinectSensor == null)
                    menuSlides.kinectRegionSlides.KinectSensor = Kinect;
            }
        }

        public void DesassociarKinectAosMenus()
        {
            if (menuVertical.kinectRegionMenu.KinectSensor != null)
                menuVertical.kinectRegionMenu.KinectSensor = null;

            if (menuSlides.kinectRegionSlides.KinectSensor != null)
                menuSlides.kinectRegionSlides.KinectSensor = null;
        }

        public void MostrarInformacao(string pMensagem, bool pMostrarBotaoOk)
        {
            msgInformacao.SetMensagem(pMensagem, pMostrarBotaoOk);
            msgInformacao.Visibility = System.Windows.Visibility.Visible;

            if ((msgInformacao.kinectRegionInformacao.KinectSensor == null) && pMostrarBotaoOk)
            {
                DesassociarKinectAosMenus();
                msgInformacao.kinectRegionInformacao.KinectSensor = Kinect;
            }
        }

        public void MostrarInputDestinatarios()
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;

            if (InputBox.kinectRegionInputBox.KinectSensor == null)
            {
                DesassociarKinectAosMenus();
                //InputBox.kinectRegionInputBox.KinectSensor = Kinect;
            }

        }

        //controles dos menus

        private void EsconderTodosMenus()
        {
            //if (configuracaoApresentacao != null)
            {
                //esconde menu apresentacao
                ControlaLinha(2, false);
                //esconde menu desenho
                ControlaLinha(3, false);
                //esconde menu lateral
                ControlaColuna(0, false);

                //esconde linha statuskinect
                ControlaLinha(0, false);
                //esconde coluna do slide do kinect
                ControlaColuna(2, false);
            }

            EsconderMenuInferior();
            EsconderMenuLateral();
        }

        private void MostrarMenuInferior()
        {
            if ((configuracaoApresentacao != null)
                && (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao)
                && (InputBox.Visibility == System.Windows.Visibility.Hidden))
            {
                EsconderMsgInformacao();

                menuVertical.Visibility = System.Windows.Visibility.Hidden;
                menuSlides.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void EsconderMenuInferior()
        {
            menuSlides.Visibility = System.Windows.Visibility.Hidden;
        }

        private void EsconderMsgInformacao()
        {
            if (msgInformacao.kinectRegionInformacao.KinectSensor != null)
                msgInformacao.kinectRegionInformacao.KinectSensor = null;

            if (msgInformacao.Visibility == System.Windows.Visibility.Visible)
                msgInformacao.Visibility = System.Windows.Visibility.Hidden;

            AssociarKinectAosMenus();
        }

        private void MostrarMenuLateral()
        {
            /*original
            menuVertical.Visibility = System.Windows.Visibility.Visible;
            menuSlides.Visibility = System.Windows.Visibility.Hidden;

            if ((configuracaoApresentacao != null)
                            && (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao))
            {
                menuVertical.SetMenuInicial();
            }
            else
                menuVertical.SetMenuDesenho();
             */
            if (configuracaoApresentacao != null)
            {

                bool lPodeMostrarMenuLateral = (configuracaoApresentacao.GetModoCanhoto() && (!configuracaoMaoEsquerda.DesenhoAtivo))
                    || (!configuracaoApresentacao.GetModoCanhoto());

                lPodeMostrarMenuLateral = lPodeMostrarMenuLateral && (InputBox.Visibility == System.Windows.Visibility.Hidden);

                if (lPodeMostrarMenuLateral)
                {
                    menuVertical.Visibility = System.Windows.Visibility.Visible;
                    menuSlides.Visibility = System.Windows.Visibility.Hidden;

                    EsconderMsgInformacao();

                    if (configuracaoApresentacao.GetEstadoApresentacaoAtual() == EstadosApresentacao.ModoApresentacao)
                    {
                        menuVertical.SetMenuInicial();
                    }
                    else
                        menuVertical.SetMenuDesenho();

                }

            }


        }

        private void EsconderMenuLateral()
        {
            if (configuracaoApresentacao != null)
                menuVertical.Visibility = System.Windows.Visibility.Hidden;
        }

        public bool MenusEstaoEscondidos()
        {
            bool lMenuInferiorEscondido = menuSlides.Visibility == System.Windows.Visibility.Hidden;
            bool lMenuLateraEscondido = menuVertical.Visibility == System.Windows.Visibility.Hidden;
            bool lHelpEscondido = hlpHelp.Visibility == System.Windows.Visibility.Hidden;
            bool lInputBoxEscondido = InputBox.Visibility == System.Windows.Visibility.Hidden;

            return lMenuInferiorEscondido && lMenuLateraEscondido && lHelpEscondido && lInputBoxEscondido;
        }
    }
}


//public byte[] imageToByteArray(System.Drawing.Image imageIn)
//{
//    MemoryStream ms = new MemoryStream();
//    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
//    return ms.ToArray();
//}