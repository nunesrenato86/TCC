using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.PassaEsquerdaParaDireita
{
    public class MaoDireitaAntesDoOmbroCentral : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroCentral = esqueletoUsuario.Joints[JointType.ElbowRight];
            bool maoDireitaAntesCotoveloEsquerdo = maoDireita.Position.X < ombroCentral.Position.X;
            //bool maoDireitaDepoisCotoveloEsquerdo = maoDireita.Position.X > cotoveloDireito.Position.Y;

            return maoDireitaAntesCotoveloEsquerdo;
        }

    }
}
