using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO
{
    public class Pessoa
    {
        private String nome;
        private String email;
        private String endereco;
        private String telefone;

        public Pessoa(String nome, String email, String endereco, String telefone)
        {
            this.nome = nome;
            this.email = email;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        public void getPessoa()
        {
            Console.WriteLine(nome);
            Console.WriteLine(email);
            Console.WriteLine(endereco);
            Console.WriteLine(telefone);
        }
        
        public static void Main(String[] args)
        {

            bool loop = true;
            String nome = "";
            String email = "";
            String endereco = "";
            String telefone = "";
            Pessoa pessoa = new Pessoa(nome, email, endereco, telefone);

            while (loop)
            {
                Console.WriteLine("Digite 1 para cadastrar/editar a pessoa \n" +
                    "Digite 2 para visualizar a pessoa \n" +
                    "Digite 3 para sair");
                int op = int.Parse(Console.ReadLine());

                

                switch (op) {
                    case 1:
                        Console.WriteLine("digite o nome");
                        nome = Console.ReadLine();
                        Console.WriteLine("digite o email");
                        email = Console.ReadLine();
                        Console.WriteLine("digite o endereço");
                        endereco = Console.ReadLine();
                        Console.WriteLine("digite o telefone");
                        telefone = Console.ReadLine();
                        pessoa = new Pessoa(nome, email, endereco, telefone);
                        break;
                    case 2:
                        pessoa.getPessoa();
                        break;
                    case 3:
                        loop= false;
                        break;
                    default:
                        Console.WriteLine("Digite uma opção valida");
                        break;
                }
            }
        }
    }
}
