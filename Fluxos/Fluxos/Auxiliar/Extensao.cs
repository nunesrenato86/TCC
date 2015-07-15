using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fluxos.Auxiliar
{
    public static class Extensao
    {

        public static void DesenharMaosUsuario(
            this SkeletonFrame pQuadro,
            KinectSensor pKinectSensor,
            Canvas pCanvasParaDesenhar,
            Brush pCorDesenho,
            JointType pMaoParaDesenhar)
        {
            if (pKinectSensor == null)
                throw new ArgumentNullException("kinectSensor");

            if (pCanvasParaDesenhar == null)
                throw new ArgumentNullException("canvasParaDesenhar");

            Skeleton lEsqueleto = ObterEsqueletoUsuario(pQuadro);

            if (lEsqueleto != null)
            {
                EsqueletoUsuarioAuxiliar lEsqueletoUsuarioAuxiliar = new EsqueletoUsuarioAuxiliar(pKinectSensor);

                //desenha mao direita
                //lEsqueletoUsuarioAuxiliar.DesenharUmaMaoPintura(
                //    lEsqueleto.Joints[JointType.HandRight],
                //    pCanvasParaDesenhar,
                //    Brushes.Aquamarine);

                //desenha mao esquerda
                lEsqueletoUsuarioAuxiliar.DesenharUmaMaoPintura(
                        //lEsqueleto.Joints[JointType.HandRight],
                        lEsqueleto.Joints[pMaoParaDesenhar],
                        pCanvasParaDesenhar,
                        pCorDesenho);

            }
        }

        public static void DesenharEsqueletoUsuario(
            this SkeletonFrame pQuadro,
            KinectSensor pKinectSensor,
            Canvas pCanvasParaDesenhar)
        {
            if (pKinectSensor == null)
                throw new ArgumentNullException("kinectSensor");

            if (pCanvasParaDesenhar == null)
                throw new ArgumentNullException("canvasParaDesenhar");

            Skeleton lEsqueleto = ObterEsqueletoUsuario(pQuadro);

            if (lEsqueleto != null)
            {
                EsqueletoUsuarioAuxiliar lEsqueletoUsuarioAuxiliar = new EsqueletoUsuarioAuxiliar(pKinectSensor);

                foreach (BoneOrientation lOsso in lEsqueleto.BoneOrientations)
                {
                    lEsqueletoUsuarioAuxiliar.DesenharOsso(
                        lEsqueleto.Joints[lOsso.StartJoint],
                        lEsqueleto.Joints[lOsso.EndJoint],
                        pCanvasParaDesenhar);

                    lEsqueletoUsuarioAuxiliar.DesenharArticulacao(
                        lEsqueleto.Joints[lOsso.EndJoint],
                        pCanvasParaDesenhar);
                }
            }
        }


        public static Skeleton ObterEsqueletoUsuario(this SkeletonFrame pQuadro)
        {
            Skeleton lEsqueletoUsuario = null;

            Skeleton[] lEsqueletos = new Skeleton[pQuadro.SkeletonArrayLength];

            pQuadro.CopySkeletonDataTo(lEsqueletos);

            IEnumerable<Skeleton> lEsqueletosRastreados = lEsqueletos.Where(
                esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (lEsqueletosRastreados.Count() > 0)
                lEsqueletoUsuario = lEsqueletosRastreados.First();

            return lEsqueletoUsuario;

        }



    }
}
