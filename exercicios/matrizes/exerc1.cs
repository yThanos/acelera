internal class program
{
    static void Main(String[] args)
    {
        int[,] matriz = new int[5, 3];
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Digite o valor do " + i + " elemento da coluna 0");
            matriz[i, 0] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 5; i++)
        {
            matriz[i, 1] = matriz[i, 0] + 10;
        }
        for (int i = 0; i < 5; i++)
        {
            matriz[i, 2] = matriz[i, 0] * 2;
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("matriz " + i + " x " + j + " = " + matriz[i, j]);
            }
        }
    }
}
