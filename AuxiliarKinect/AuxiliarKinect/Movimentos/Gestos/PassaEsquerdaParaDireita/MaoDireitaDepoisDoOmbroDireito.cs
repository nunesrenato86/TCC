using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.PassaEsquerdaParaDireita
{
    public class MaoDireitaDepoisDoOmbroDireito : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ElbowRight];
            bool maoDireitaDepoisCotoveloDireito = maoDireita.Position.X > ombroDireito.Position.X;
            //bool maoDireitaDepoisCotoveloEsquerdo = maoDireita.Position.X > cotoveloDireito.Position.Y;

            return maoDireitaDepoisCotoveloDireito;
        }
    }
}
