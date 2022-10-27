internal class program
{
    static void Main(String[] args)
    {
        int[,] matriz = new int[4, 4];
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Console.WriteLine("Digite o valor da posiçãp " + i + " x " + j + ":");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(i == j)
                {
                    Console.WriteLine(matriz[i, j]);
                }
            }
        }
    }
}