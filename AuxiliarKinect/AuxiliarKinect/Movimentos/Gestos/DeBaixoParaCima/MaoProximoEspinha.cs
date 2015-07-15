using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AuxiliarKinect.FuncoesBasicas;namespace AuxiliarKinect.Movimentos.Gestos.DeBaixoParaCima
{
    class MaoProximoEspinha : Pose
    {
        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];
            Joint espinha = esqueletoUsuario.Joints[JointType.Spine];

            bool maoDireitaADireitaEspinha = maoDireita.Position.X > espinha.Position.X;
            bool maoDireitaMesmaAlturaEspinha = Util.CompararComMargemErro(
                10,
                maoDireita.Position.Y,                
                espinha.Position.Y);

            return maoDireitaADireitaEspinha && maoDireitaMesmaAlturaEspinha;
        }
    }
}
