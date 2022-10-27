internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[80];
        int menor;
        for(int i = 0; i < 80; i++)
        {
            Console.WriteLine("digite um valor para a posição " + i + " do vetor:");
            vetor[i] = int.Parse(Console.ReadLine());
        }
        menor = vetor[0];
        for (int i = 0; i < 80; i++)
        {
            if(vetor[i] < menor)
            {
                menor = vetor[i];
            }
        }
        for (int i = 0; i < 80; i++)
        {
            if(menor == vetor[i])
            {
                Console.WriteLine("o menor numero é " + menor + " que esta na posição " + i + " do vetor!");
            }
        }
    }
}