namespace condicoeslogicas;

public class Program
{
    public static void Main(string[] args)
    {
        //Estruturas condicionais!

        Console.WriteLine("Digite um numero para veríficar a paridade: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if ((number % 2) == 0)
        {
            Console.WriteLine("O número é par");
        }
        else
        {
            Console.WriteLine("O numero é ímpar");
        }
    }
}