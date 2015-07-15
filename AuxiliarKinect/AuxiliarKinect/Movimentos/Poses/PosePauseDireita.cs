using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Poses
{
    public class PosePauseDireita : Pose
    {
        public PosePauseDireita()
        {
            this.Nome = "PosePauseeDireita";
            this.QuadroIdentificacao = 30;
        }


        protected override bool PosicaoValida(Microsoft.Kinect.Skeleton esqueletoUsuario)
        {
            const double ANGULO_ESPERADO = 25;

            double margemErroPosicao = 0.30;

            double margemErroAngulo = 10;

            Joint quadrilDireito = esqueletoUsuario.Joints[JointType.HipRight];

            Joint ombroDireito = esqueletoUsuario.Joints[JointType.ShoulderRight];

            Joint maoDireita = esqueletoUsuario.Joints[JointType.HandRight];

            Joint cotoveloDireito = esqueletoUsuario.Joints[JointType.ElbowRight];

            double resultadoAngulo = Util.CalcularProdutoEscalar(quadrilDireito, ombroDireito, maoDireita);

            bool anguloCorreto = Util.CompararComMargemErro(
                margemErroAngulo,
                resultadoAngulo, 
                ANGULO_ESPERADO);

            bool maoDireitaDistanciaCorreta = Util.CompararComMargemErro(
                margemErroPosicao,
                maoDireita.Position.Z, 
                quadrilDireito.Position.Z);

            bool maoDireitaAposCotovelo = maoDireita.Position.X > cotoveloDireito.Position.X;

            bool maoDireitaAbaixoCotovelo = maoDireita.Position.Y < cotoveloDireito.Position.Y;

            return anguloCorreto
                && maoDireitaDistanciaCorreta
                && maoDireitaAposCotovelo 
                && maoDireitaAbaixoCotovelo;
        }


    }
}
