using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO
{
    public class Personagem
    {
        private String nome;
        private int posicaoX;
        private int posicaoY;
        private int[,] tabuleiro;
        private int vida;
        private int itensColetados;

        public void atualizaTab()
        {
            this.tabuleiro[posicaoX,posicaoY] = 1;
        }

        public void start(String nome)
        {
            this.nome = nome;
            this.tabuleiro = new int[10, 10];
            this.posicaoX= 5;
            this.posicaoY= 5;
            atualizaTab();
            this.vida = 100;
            this.itensColetados= 0;
        }

        public void tomarDano(int dano)
        {
            this.vida = vida - dano;
        }

        public void beberPocao()
        {
            this.vida = vida + 25;
            if(this.vida > 100)
            {
                this.vida = 100;
            }
        }
        public void coletarItem()
        {
            this.itensColetados++;
        }
        public void cima()
        {
            this.tabuleiro[posicaoX, posicaoY] = 0;
            posicaoY--;
            atualizaTab();
        }
        public void baixo()
        {
            this.tabuleiro[posicaoX, posicaoY] = 0;
            posicaoY++;
            atualizaTab();
        }
        public void esquerda()
        {
            this.tabuleiro[posicaoX, posicaoY] = 0;
            posicaoX--;
            atualizaTab();
        }
        public void direita()
        {
            this.tabuleiro[posicaoX, posicaoY] = 0;
            posicaoX++;
            atualizaTab();
        }
    }
}