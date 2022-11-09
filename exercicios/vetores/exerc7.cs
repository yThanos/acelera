internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[10];
        int[] vetor2 = new int[10];
        int p = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Digite o valor da posição: " + i);
            vetor[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 10; i++)
        {
            if(vetor[i] % 2 == 0)
            {
                vetor2[p] = vetor[i];
                p = p + 1;
            }
        }
        for(int i = 0; i < 10; i++)
        {
            if (vetor[i] % 2 != 0)
            {
                vetor2[p] = vetor[i];
                p = p + 1;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(vetor2[i]);
        }
    }
}