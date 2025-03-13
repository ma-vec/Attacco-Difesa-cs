using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attacco_difesa
{
    class Gamer
    {
        public string Id { get; private set; }
        public bool IsFighter { get; private set; }
        public int PuntiFerita { get; private set; }
        public int PtDannoAttacco { get; private set; }
        public int PercDif { get; private set; }

        private static Random random = new Random();

        public Gamer(string id, bool isFighter, int puntiFerita, int ptdannoAttacco, int percDif)
        {
            Id = id;
            IsFighter = isFighter;
            PuntiFerita = puntiFerita;
            PtDannoAttacco = ptdannoAttacco;
            PercDif = percDif;
        }

        public int Attacca(Gamer avversario)
        {
            int percSingoloAttacco = random.Next(1, 101);

            if (percSingoloAttacco >= avversario.PercDif)
            {
                // Il difensore riesce a parare parzialmente il colpo
                int riduzioneDanni = random.Next(50, 101);
                int danniEffettivi = PtDannoAttacco * (100 - riduzioneDanni) / 100;
                avversario.PuntiFerita -= danniEffettivi;
            }
            else
            {
                // Subisce il danno pieno
                avversario.PuntiFerita -= PtDannoAttacco;
            }
            return percSingoloAttacco;
        }

        public void SwitchRole()
        {
            IsFighter = !IsFighter;
        }
    }

}
