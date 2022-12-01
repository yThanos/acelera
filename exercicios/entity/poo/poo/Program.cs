using Microsoft.EntityFrameworkCore;
using poo.DataModels;

namespace poo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Contexto contexto= new Contexto();

            bool teste = true;

            while (teste == true)
            {

                Console.WriteLine("Digite:\n" +
                "1- para criar uma pessoa\n" +
                "2- para alterar o nome da pessoa\n" +
                "3- para inserir um email\n" +
                "4- para excluir uma pessoa\n" +
                "5- para consultar tudo\n" +
                "6- para consultar pelo ID\n" +
                "7- para consultar pelo nome");

                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Inserir o nome da pessoa: ");
                            Pessoa p = new Pessoa();
                            p.nome = Console.ReadLine();

                            Console.WriteLine("Informe um email");
                            String emailTemp = Console.ReadLine();

                            p.Emails = new List<Email>()
                        {
                            new Email()
                            {
                                email = emailTemp
                            }
                        };
                            contexto.pessoas.Add(p);
                            contexto.SaveChanges();

                            Console.WriteLine("Pessoa inserida com sucesso!");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Informe o ID da pessoa: ");
                            int id = int.Parse(Console.ReadLine());

                            Pessoa palt = contexto.pessoas.Find(id);

                            Console.WriteLine("Informe o nome correto: ");
                            palt.nome = Console.ReadLine();

                            contexto.pessoas.Update(palt);
                            contexto.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Informe o ID da pessoa: ");
                            int id = int.Parse(Console.ReadLine());
                            Pessoa p = contexto.pessoas.Find(id);

                            Console.WriteLine("Informe o novo email: ");
                            String emailtemp = Console.ReadLine();

                            p.Emails = new List<Email>()
                        {
                            new Email()
                            {
                                email = emailtemp
                            }
                        };

                            contexto.pessoas.Update(p);
                            contexto.SaveChanges();
                            Console.WriteLine("Inserido com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Informe o ID da pessoa a ser deletada: ");
                            int id = int.Parse(Console.ReadLine());
                            Pessoa p = contexto.pessoas.Find(id);

                            Console.WriteLine("confirmar a exclusao de " + p.nome);
                            Console.WriteLine("e dos seus emails ");

                            foreach (Email item in p.Emails)
                            {
                                Console.WriteLine("\t" + item.email);
                            }

                            Console.WriteLine("1 para SIM outra tecla para NÃO");
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                contexto.pessoas.Remove(p);
                                contexto.SaveChanges();
                                Console.WriteLine(p.nome + " excluido com sucesso!");
                            }
                            else
                            {
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:
                        try
                        {
                            List<Pessoa> lista = (from Pessoa p in contexto.pessoas
                                                  select p).Include(pes => pes.Emails).ToList<Pessoa>();
                            foreach (Pessoa item in lista)
                            {
                                Console.WriteLine(item.Id + "- " + item.nome);

                                foreach (Email itemE in item.Emails)
                                {
                                    Console.WriteLine("\t" + itemE.email);
                                }
                                Console.WriteLine();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("Informe o ID da pessoa a ser pesquisada: ");
                            int idPessoa = int.Parse(Console.ReadLine());
                            Pessoa pessoa = contexto.pessoas.Include(p => p.Emails).FirstOrDefault(x => x.Id == idPessoa);
                            Console.WriteLine(pessoa.nome);

                            if (pessoa.Emails != null)
                            {
                                foreach (Email item in pessoa.Emails)
                                {
                                    Console.WriteLine("\t" + item.email);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("Informe o nome da pessoa a ser pesquisa: ");
                            String nome = Console.ReadLine();
                            Pessoa pessoa = contexto.pessoas.Include(p => p.Emails).FirstOrDefault(x => x.nome == nome);
                            Console.WriteLine(pessoa.nome);

                            if (pessoa.Emails != null)
                            {
                                foreach (Email item in pessoa.Emails)
                                {
                                    Console.WriteLine("\t" + item.email);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("seu animal!");
                        teste = false;
                        break;
                }
            }
        }   
    }
}