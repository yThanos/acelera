using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO
{
    public class Televisao
    {
        private String marca;
        private String modelo;
        private int polegadas;
        private int canal;
        private int volume;
        private bool ligada;

        public Televisao(string marca, string modelo, int polegadas)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.polegadas = polegadas;
        }

        public void ligar()
        {
            this.ligada = true;
        }
        public void aumetaVolume()
        {
            if (this.ligada)
            {
                this.volume++;
            }
        }
        public void diminuiVolume()
        {
            if (this.ligada)
            {
                this.volume--;
            }
        }
        public void nextChannel()
        {
            if (this.ligada)
            {
                this.canal++;
            }
        }
        public void prevChannel()
        {
            if (this.ligada)
            {
                this.canal--;
            }
        }
    }
}
