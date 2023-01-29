using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Spy : IProvjera
    {
        public List<Glasac> glasaci = Izbori.glasaci;
        public bool DaLiJeVecGlasao(string IDBroj)
        {
            bool postoji = false;
            foreach (Glasac glasac in glasaci)
            {
                if (glasac.JedinstveniIdentifikacijskiKod.Equals(IDBroj))
                {
                    postoji = true;
                    if (glasac.StrankaZaKojuGlasacGlasa == -1 && glasac.KandidatiZaKojeGlasacGlasa.Count == 0) return false; 
                }
            }
            return postoji;
        }
    }
}
