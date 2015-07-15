using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuxiliarKinect.Movimentos.Gestos.PassaEsquerdaParaDireita
{
    public class PassaEsquerdaParaDireita : Gesto
    {
        public PassaEsquerdaParaDireita()
        {
            InicializaQuadrosChave();

            Nome = "PassaEsquerdaParaDireita";
            ContadorQuadros = 0;
            QuadroChaveAtual = QuadrosChave.First;
        }
        private void InicializaQuadrosChave()
        {
            QuadrosChave = new LinkedList<GestoQuadroChave>();
            QuadrosChave.AddFirst(new GestoQuadroChave(new MaoDireitaAntesDoOmbroCentral(), 0, 0));

            QuadrosChave.AddLast(new GestoQuadroChave(new MaoDireitaDepoisDoOmbroDireito(), 1, 25));

           // QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 1, 25));

            //QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 29));

            //QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAposCotovelo(), 1, 25));

            //QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoSobreCotovelo(), 1, 25));

            //QuadrosChave.AddLast(new GestoQuadroChave(new AcenoMaoAntesCotovelo(), 1, 25));
        }


        protected override bool PosicaoValida(Skeleton esqueletoUsuario)
        {
            EstadoRastreamento estado = QuadroChaveAtual.Value.PoseChave.Rastrear(esqueletoUsuario);

            return estado == EstadoRastreamento.Identificado;
        }
    }
}
