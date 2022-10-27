internal class program
{
    static void Main(String[] args)
    {
        int[,] matriz = new int[5, 5];
        int par = 0, impar = 0, positivo = 0, negativo = 0, zero = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine("Digite o valor da posiçãp " + i + " x " + j + ":");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if(matriz[i, j] == 0)
                {
                    zero = zero + 1;
                } 
                if(matriz[i, j] > 0)
                {
                    positivo = positivo + 1;
                }
                if (matriz[i,j] < 0)
                {
                    negativo = negativo + 1;
                }
                if (matriz[i,j] %2 == 0)
                {
                    par = par + 1;
                }
                if(matriz[i,j]%2 != 0)
                {
                    impar = impar +1;
                }
            }
        }
        Console.WriteLine(par + " Pares, " + impar + " Impares, " + positivo + " Positivos, " + negativo + " Negativos, " + zero + " zeros!");
    }
}