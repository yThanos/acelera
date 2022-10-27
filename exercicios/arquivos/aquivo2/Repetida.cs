using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Repetida
    {
        StreamWriter sw;
        StreamReader sr;

        public void criaAbre()
        {
            sw = new StreamWriter("C:\\Arquivo\\Repetida.csv", true, Encoding.UTF8);
        }

        public void gravaFigura(String codigo, String selecao, String jogador)
        {
            sw.WriteLine(codigo + ";" + selecao + ";" + jogador);
            sw.Flush();
        }

        public void lerArquivo()
        {
            string linha;
            sr = new StreamReader("C:\\Arquivo\\Repetida.csv");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Console.WriteLine(linha);
                linha = sr.ReadLine();
            }
            sr.Close();
        }

        public void fechaArquivo()
        {
            sw.Close();
        }

    }
}