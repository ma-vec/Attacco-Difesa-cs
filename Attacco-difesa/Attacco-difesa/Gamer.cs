using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attacco_difesa
{
    class Gamer
    {
        private int id;
        public int Id { get; }
        private bool isFighter;
        public bool IsFighter { get; }
        private int puntiFerita;
        public int PuntiFerita { get; }
        private int ptdannoAttacco;
        public int PtDannoAttacco { get; }
        private int percDif;
        public int PercDif { get; }

        public void SubisciAttacco(int valoreAttacco)
        {
            if (valoreAttacco >= percDif)
            { //il giocatore si para 50-100% danni
                Random random = new Random();
                int randomRiparazioneDanni = random.Next(50, 101); //riparazione in percentuale dei danni subiti
                puntiFerita -= valoreAttacco - (valoreAttacco * randomRiparazioneDanni / 100);
            } else //subisce tutti i danni
            {
                puntiFerita -= valoreAttacco;
            }
        }


        public Gamer(int id, bool isFighter, int puntiFerita, int ptdannoAttacco, int percDif)
        {
            Id = id;
            IsFighter = isFighter;
            PuntiFerita = puntiFerita;
            PtDannoAttacco = ptdannoAttacco;
            PercDif = percDif;
        }
    }
}
