using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.DeBaixoParaCima
{
    class MaoAcimaOmbro : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ShoulderRight];
            bool maoDireitaADireitaOmbroDireito = maoDireita.Position.X > ombroDireito.Position.X;
            bool maoDireitaAcimaOmbroDireito = maoDireita.Position.Y > ombroDireito.Position.Y;

            return maoDireitaADireitaOmbroDireito && maoDireitaAcimaOmbroDireito;
        }
    }
}
