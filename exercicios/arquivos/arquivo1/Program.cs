using arquivo1;

internal class Program
{
    static void Main(string[] args)
    {
        Boolean execute = true;
        string nomearquivo;
        int op;
        Arquivo a;
        nomearquivo = "email";
        a = new Arquivo(nomearquivo);
        while (execute == true)
        {
            Console.WriteLine("Digite:\n1 - Cadastrar um email\n" +
                "2 - Listar os emails\n" +
                "3 - Para sair do programa\n");

            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    a.criaAbreArquivo();
                    Console.WriteLine("Digite o email: ");
                    string msg = Console.ReadLine();
                    a.gravaMensagem(msg);
                    a.fechaArquivo();
                    break;
                case 2:
                    a.lerArquivo();
                    break;
                case 3:
                    execute = false;
                    break;

                default:
                    Console.WriteLine("digite um valor valido");
                    break;
            }
        }
    }
}