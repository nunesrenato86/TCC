using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;

namespace AuxiliarKinect.Movimentos.Poses
{
    public class PoseT : Pose
    {
        public PoseT()
        {
            this.Nome = "PoseT";
            this.QuadroIdentificacao = 10;
        }

        protected override bool PosicaoValida(Skeleton pEsqueletoUsuario)
        {
            Joint lCentroOmbros = pEsqueletoUsuario.Joints[JointType.ShoulderCenter];

            Joint lMaoDireita = pEsqueletoUsuario.Joints[JointType.HandRight];

            Joint lCotoveloDireito = pEsqueletoUsuario.Joints[JointType.ElbowRight];

            Joint lMaoEsquerda = pEsqueletoUsuario.Joints[JointType.HandLeft];

            Joint lCotoveloEsquerdo = pEsqueletoUsuario.Joints[JointType.ElbowLeft];

            double lMargemErro = 0.30;

            bool lMaoDireitaAlturaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lMaoDireita.Position.Y,
                lCentroOmbros.Position.Y);

            bool lMaoDireitaDistanciaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lMaoDireita.Position.Z,
                lCentroOmbros.Position.Z);

            bool lMaoDireitaAposCotovelo = lMaoDireita.Position.X > lCotoveloDireito.Position.X;

            bool lCotoveloDireitoAlturaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lCotoveloDireito.Position.Y,
                lCentroOmbros.Position.Y);

            bool lCotoveloEsquerdoAlturaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lCotoveloEsquerdo.Position.Y,
                lCentroOmbros.Position.Y);

            bool lMaoEsquerdaAlturaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lMaoEsquerda.Position.Y,
                lCentroOmbros.Position.Y);

            bool lMaoEsquerdaDistanciaCorreta = Util.CompararComMargemErro(
                lMargemErro,
                lMaoEsquerda.Position.Z, 
                lCentroOmbros.Position.Z);

            bool maoEsquerdaAposCotovelo = lMaoEsquerda.Position.X < lCotoveloEsquerdo.Position.X;

            return lMaoDireitaAlturaCorreta
                && lMaoDireitaDistanciaCorreta
                && lMaoDireitaAposCotovelo
                && lCotoveloDireitoAlturaCorreta
                && lMaoEsquerdaAlturaCorreta
                && lCotoveloEsquerdoAlturaCorreta;
        }
    }
}
