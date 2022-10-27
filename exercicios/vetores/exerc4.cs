internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[10];
        int[] vetor2 = new int[10];
        int[] vetor3 = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Digite o valor do " + i + " numero para o vetor 1:");
            vetor[i] = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do " + i + " numero para o vetor 2:");
            vetor2[i] = int.Parse(Console.ReadLine());
            vetor3[i] = vetor[i] * vetor2[i];
        }
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("valor " + i + " do vetor resultante: " + vetor3[i]);
        }
    }
}