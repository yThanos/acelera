internal class program
{
    static void Main(String[] args)
    {
        int maior;
        int menor;
        int l = 0, c = 0;
        int[,] matriz = new int[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("valor " + i + " x " + j + " :");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        maior = matriz[0, 0];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (matriz[i, j] > maior)
                {
                    l = i;
                    c = j;
                    maior = matriz[i, j];
                }
            }
        }
        menor = matriz[l, c];
        for (int j = 0; j < 10; j++)
        {
            if (matriz[l, j] < menor)
            {
                menor = matriz[l, j];
                c = j;
            }
        }
        Console.WriteLine("o minimax é " + menor + " na linha " + l + " coluna " + c);
    }
}