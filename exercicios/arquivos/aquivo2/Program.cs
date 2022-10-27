namespace ConsoleApp2
{
    internal class program
    {
        static void Main(String[] args)
        {
            Boolean exec = true;
            int op;
            String nome;
            String selecao;
            String codigo;
            Figurinha f = new Figurinha();
            Repetida r = new Repetida();

            while (exec == true)
            {
                Console.WriteLine("Opções:\r\n1 - Cadastrar figurinha repetida\r\n2 - Cadastrar figurinha faltante\r\n3 - Listar figurinhas repetidas\r\n4 - Listar figurinhas faltantes\r\n5 - Sair");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 2:
                        f.criaAbre();
                        Console.WriteLine("Digite o codigo:");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Digite a seleção:");
                        selecao = Console.ReadLine();
                        Console.WriteLine("Digite o nome do jogador:");
                        nome = Console.ReadLine();
                        f.gravaFigura(codigo, selecao, nome);
                        f.fechaArquivo();
                        break;
                    case 1:
                        r.criaAbre();
                        Console.WriteLine("Digite o codigo:");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Digite a seleção:");
                        selecao = Console.ReadLine();
                        Console.WriteLine("Digite o nome do jogador:");
                        nome = Console.ReadLine();
                        r.gravaFigura(codigo, selecao, nome);
                        r.fechaArquivo();
                        break;
                    case 3:
                        r.lerArquivo();
                        break;
                    case 4:
                        f.lerArquivo();
                        break;
                    case 5:
                        exec = false;
                        break;
                    default:
                        Console.WriteLine("Digite uma opção valida!");
                        break;
                }
            }
        }
    }
}
