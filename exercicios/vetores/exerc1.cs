internal class program
{
    static void Main(String[] args)
    {
        int[] vetor = new int[10];
        int par = 0, impar = 0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Digite o valor do " + i + " numero:");
            vetor[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 10; i++)
        {
            if (vetor[i] % 2 == 0)
            {
                par++;
            }
            if (vetor[i] % 2 != 0)
            {
                impar++;
            }
        }
        Console.WriteLine(par + " numeros pares e " + impar + " impares");
    }
}