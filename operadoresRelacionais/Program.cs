namespace operadoresRelacionais;

public class Program()
{
    public static void Main(string[] args)
    {

        Console.WriteLine("------ Operadores Relacionas ------");

        Console.WriteLine("Digite um número: ");
        int x = Convert.ToInt32(Console.ReadLine());
        //////////
        Console.WriteLine("Digite outro número: ");
        int y = Convert.ToInt32(Console.ReadLine());
        /////////

        if (x == y)
        {
            Console.WriteLine("X é igual a y");
        }
        else
        {
            Console.WriteLine("X é diferente de y");
        }
        ;


        //Resumindo: == é comparação/igualdade.
        //!= é diferende.
        //> maior < menor.
        // >= maior igual e <= menor igual.

    }
}