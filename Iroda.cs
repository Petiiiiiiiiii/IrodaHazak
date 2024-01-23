using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA240119
{
    internal class Iroda
    {
        public string Kod { get; set; }
        public int Evjarat { get; set; }
        public List<int> Irodak { get; set; }
        public string IrodakString { get; set; }
        public int OsszDolgozo { get; set; }

        public Iroda(string sor)
        {
            var atmeneti = sor.Split(' ');
            this.Kod = atmeneti[0];
            this.Evjarat = Convert.ToInt32(atmeneti[1]);
            this.Irodak = new();

            for (int i = 2; i < atmeneti.Length; i++)
                this.Irodak.Add(Convert.ToInt32(atmeneti[i]));

            for (int i = 0; i < Irodak.Count; i++)
                this.IrodakString += $"{Irodak[i],-4}";

            this.OsszDolgozo = 0;
        }

        public override string ToString()
        {
            return $"{this.Kod,-15}{this.Evjarat,-10}{this.IrodakString}";
        }

        public int DolgozoSzamolo() 
        {
            return Irodak.Sum();
        }
    }
}
