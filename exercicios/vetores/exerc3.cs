internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Digite o valor do " + i + " numero:");
            vetor[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 10; i++)
        {
            int teste = 1;
            for (int j = 1; j < vetor[i]; j++)
            {
                if (vetor[i] % j == 0)
                {
                    teste = teste + 1;
                }
            }
            if (teste == 2)
            {
                Console.WriteLine("o numero " + vetor[i] + " é primo");
            }
        }
    }
}