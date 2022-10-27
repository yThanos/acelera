internal class program
{
    static void Main(String[] args)
    {
        int[,] matriz = new int[3, 3];
        int soma;
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++) {
                Console.WriteLine("Digite o valor da posiçãp " + i + " x " + j + ":");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for(int i = 0; i < 3; i++)
        {
            soma = 0;
            for (int j = 0; j < 3; j++)
            {
                if(i == 0)
                {
                    soma += matriz[i, j];
                    if(j == 2)
                    {
                        Console.WriteLine("soma da linha 0: " + soma);
                    }
                } else if(i == 1)
                {
                    soma += matriz[i, j];
                    if (j == 2)
                    {
                        Console.WriteLine("soma da linha 1: " + soma);
                    }
                } else if (i == 2)
                {
                    soma += matriz[i, j];
                    if (j == 2)
                    {
                        Console.WriteLine("soma da linha 2: " + soma);
                    }
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            soma = 0;
            for (int j = 0; j < 3; j++)
            {
                if (i == 0)
                {
                    soma += matriz[j,i];
                    if (j == 2)
                    {
                        Console.WriteLine("soma da Coluna 0: " + soma);
                    }
                }
                else if (i == 1)
                {
                    soma += matriz[j,i];
                    if (j == 2)
                    {
                        Console.WriteLine("soma da Coluna 1: " + soma);
                    }
                }
                else if (i == 2)
                {
                    soma += matriz[j,i];
                    if (j == 2)
                    {
                        Console.WriteLine("soma da Coluna 2: " + soma);
                    }
                }
            }
        }
    }
}