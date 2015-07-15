using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Poses
{
    public class PoseMaosCintura : Pose
    {
        public PoseMaosCintura()
        {
            this.Nome = "PoseMaosCintura";
            this.QuadroIdentificacao = 30;
        }

        protected override bool PosicaoValida(Skeleton pEsqueletoUsuario)
        {
            Joint lCentroOmbros = pEsqueletoUsuario.Joints[JointType.ShoulderCenter];

            Joint lMaoDireita = pEsqueletoUsuario.Joints[JointType.HandRight];

            Joint lCotoveloDireito = pEsqueletoUsuario.Joints[JointType.ElbowRight];

            Joint lOmbroDireito = pEsqueletoUsuario.Joints[JointType.ShoulderRight];

            Joint lMaoEsquerda = pEsqueletoUsuario.Joints[JointType.HandLeft];

            Joint lCotoveloEsquerdo = pEsqueletoUsuario.Joints[JointType.ElbowLeft];                        

            Joint lOmbroEsquerdo = pEsqueletoUsuario.Joints[JointType.ShoulderLeft];

            Joint lQuadrilDireito = pEsqueletoUsuario.Joints[JointType.HipRight];

            Joint lQuadrilEsquerdo = pEsqueletoUsuario.Joints[JointType.HipLeft];

            double lMargemErro = 0.30;


            //direita
            /*
            bool lMaoDireitaAlturaDoQuadrilDireito = Util.CompararComMargemErro(
                lMargemErro,
                lMaoDireita.Position.Y,
                lQuadrilDireito.Position.Y);
             */

            bool lMaoDireitaAlturaDoQuadrilDireito = lMaoDireita.Position.Y > lQuadrilDireito.Position.Y; 

            bool lMaoDireitaAposOmbroDireito = lMaoDireita.Position.X > lOmbroDireito.Position.X;

            bool lMaoDireitaAntesCotoveloDireito = lMaoDireita.Position.X < lCotoveloDireito.Position.X;

            bool lCotoveloDireitoAbaixoOmbroDireito = lCotoveloDireito.Position.Y < lOmbroDireito.Position.Y;

            bool lMaoDireitaAbaixoCotoveloDireito = lMaoDireita.Position.Y < lCotoveloDireito.Position.Y;

            bool lOmbroDireitoAbaixoCentroOmbros = lOmbroDireito.Position.Y < lCentroOmbros.Position.Y;

            //esquerda
            /*
            bool lMaoEsquerdaAlturaDoQuadrilEsquerdo = Util.CompararComMargemErro(
                lMargemErro,
                lMaoEsquerda.Position.Y,
                lQuadrilEsquerdo.Position.Y);
             * */

            bool lMaoEsquerdaAlturaDoQuadrilEsquerdo = lMaoEsquerda.Position.Y > lQuadrilEsquerdo.Position.Y; 

            bool lMaoEsquerdaAposOmbroEsquerdo = lMaoEsquerda.Position.X < lOmbroEsquerdo.Position.X;

            bool lMaoEsquerdaAntesCotoveloEsquerdo = lMaoEsquerda.Position.X > lCotoveloEsquerdo.Position.X;

            bool lCotoveloEsquerdoAbaixoOmbroEsquerdo = lCotoveloEsquerdo.Position.Y < lOmbroEsquerdo.Position.Y;

            bool lMaoEsquerdaAbaixoCotoveloEsquerdo = lMaoEsquerda.Position.Y < lCotoveloEsquerdo.Position.Y;

            bool lOmbroEsquerdoAbaixoCentroOmbros = lOmbroEsquerdo.Position.Y < lCentroOmbros.Position.Y;

            
            return lMaoDireitaAlturaDoQuadrilDireito
                && lMaoDireitaAposOmbroDireito
                && lMaoDireitaAntesCotoveloDireito
                && lCotoveloDireitoAbaixoOmbroDireito
                && lMaoDireitaAbaixoCotoveloDireito
                && lOmbroDireitoAbaixoCentroOmbros

                && lMaoEsquerdaAlturaDoQuadrilEsquerdo
                && lMaoEsquerdaAposOmbroEsquerdo
                && lMaoEsquerdaAntesCotoveloEsquerdo
                && lCotoveloEsquerdoAbaixoOmbroEsquerdo
                && lMaoEsquerdaAbaixoCotoveloEsquerdo
                && lOmbroEsquerdoAbaixoCentroOmbros;
            


        }
    }
}
