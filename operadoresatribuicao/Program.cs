namespace operadoresatribuicao;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("------ Operadores de Atribuição ------");

        int x = 10;
        Console.WriteLine("\nValor inicial da var X: " + x);

        //Operador de atribuição simples '='
        x = 20;
        Console.WriteLine("\nValor de X após a tribuição Simples: " + x);

        //Atribuição Composta '++'
        x++; // X vai receber o valor dela mais 1, x = x+1
        Console.WriteLine("\nValor de X após a tribuição composta (++): " + x);


        //Atribuição Composta '+='
        x+= 10; // X vai receber o valor dela mais 10, x = x+10
        Console.WriteLine("\nValor de X após a tribuição composta (+=10): " + x);


        //Atribuição Composta '*='
        x *= 2; // X vai receber o valor dela multiplicado por 2, x = x*2
        Console.WriteLine("\nValor de X após a tribuição composta (*=2): " + x);

        //Atribuição Composta '/='
        x /= 2; // X vai receber o valor dela dividido por 2, x = x/2
        Console.WriteLine("\nValor de X após a tribuição composta (/=2): " + x);
    }
}