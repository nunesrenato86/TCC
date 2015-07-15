using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.DeBaixoParaCima
{
    class MaoAbaixoCintura : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint cinturaDireita = esqueletoUsuario.Joints[JointType.HipRight];
            bool maoDireitaDireitaCintura = maoDireita.Position.X > cinturaDireita.Position.X;
            bool maoDireitaAbaixoCintura = maoDireita.Position.Y < cinturaDireita.Position.Y;
            
            return maoDireitaAbaixoCintura && maoDireitaDireitaCintura;
        }
    }
}
