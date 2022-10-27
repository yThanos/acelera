internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[20];
        int[] vetor2 = new int[20];

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Digite o valor do " + i + " numero:");
            vetor[i] = int.Parse(Console.ReadLine());
            vetor2[i] = vetor[i] + vetor[i];
        }
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("valor do vet1 : " + vetor[i] + " valor do vet2: " + vetor2[i]);
        }
    }
}