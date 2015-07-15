using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.Movimentos
{
    public interface IRastreador
    {
        void Rastrear(Skeleton pEsqueletoUsuario);

        EstadoRastreamento EstadoAtual { get; }
    }
}
