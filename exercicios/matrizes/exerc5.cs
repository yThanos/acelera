internal class program
{
    static void Main(String[] args)
    {
        double[,] m1 = new double[2, 3];
        double[,] m2 = new double[2, 3];
        double soma = 0;

        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Console.WriteLine("digite um valor para matriz 1");
                m1[i, j] = double.Parse(Console.ReadLine());
                Console.WriteLine("digite um valor para matriz 2");
                m2[i, j] = double.Parse(Console.ReadLine());
            }
        }
        for(int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                soma = soma + m1[i, j] + m2[i, j];
            }
        }
        Console.WriteLine("a soma das matrizes é: "+soma);
    }
}