using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using AuxiliarKinect.Movimentos;

namespace AuxiliarKinect.Movimentos
{
    public abstract class Movimento
    {
        protected int ContadorQuadros { get; set; }
        public string Nome { get; set; }

        public abstract EstadoRastreamento Rastrear(Skeleton pEsqueletoUsuario);

        protected abstract bool PosicaoValida(Skeleton pEsqueletoUsuario);
    }



    public abstract class Pose : Movimento
    {
        protected int QuadroIdentificacao { get; set; }


        public override EstadoRastreamento Rastrear(Skeleton pEsqueletoUsuario)
        {
            EstadoRastreamento lNovoEstado;            

            if (pEsqueletoUsuario != null 
                && PosicaoValida(pEsqueletoUsuario))
            {
                if (QuadroIdentificacao == ContadorQuadros)
                    lNovoEstado = EstadoRastreamento.Identificado;
                else
                {
                    lNovoEstado = EstadoRastreamento.EmExecucao;
                    ContadorQuadros += 1;
                }
            }
            else
            {
                lNovoEstado = EstadoRastreamento.NaoIdentificado;
                ContadorQuadros = 0;
            }

            return lNovoEstado;
        }

        public int PercentualProgresso
        {
            get
            {
                return ContadorQuadros * 100 / QuadroIdentificacao;
            }
        }
    }
}
