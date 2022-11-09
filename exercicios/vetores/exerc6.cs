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
        for(int i = 9; i >= 0; i--)
        {
            vetor2[i] = vetor[p];
            p++;
        }
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(vetor[i]);
            Console.WriteLine(vetor2[i]);
        }
    }
}