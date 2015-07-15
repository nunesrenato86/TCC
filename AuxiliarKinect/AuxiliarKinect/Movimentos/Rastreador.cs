using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.Movimentos
{
    public class Rastreador<T> : IRastreador where T : Movimento, new()
    {
        private T movimento;
        public EstadoRastreamento EstadoAtual { get; private set; }
        public event EventHandler MovimentoIdentificado;
        public event EventHandler MovimentoEmProgresso;

        public Rastreador()
        {
            EstadoAtual = EstadoRastreamento.NaoIdentificado;
            movimento = Activator.CreateInstance<T>();
        }

        public void Rastrear(Skeleton pEsqueletoUsuario)
        {
            EstadoRastreamento lNovoEstado = movimento.Rastrear(pEsqueletoUsuario);

            if (lNovoEstado == EstadoRastreamento.Identificado 
                && EstadoAtual != EstadoRastreamento.Identificado)
                ChamarEvento(MovimentoIdentificado);

            if (lNovoEstado == EstadoRastreamento.EmExecucao 
                && (EstadoAtual == EstadoRastreamento.EmExecucao || EstadoAtual == EstadoRastreamento.NaoIdentificado))
                ChamarEvento(MovimentoEmProgresso);

            EstadoAtual = lNovoEstado;
        }

        private void ChamarEvento(EventHandler pEvento)
        {
            if (pEvento != null)
                pEvento(movimento, new EventArgs());
        }
    }
}
