namespace operadoresAritmeticos;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("------ Calculadora Simples ------");
        Console.WriteLine("Digite um número: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite outro número: ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        int soman1n2 = n1 + n2; // O operador + que soma variáveis e valores.
        Console.WriteLine("O valor da soma é: " + soman1n2); // O operador + também tem a função de contatenar, que é juntar textos e strings.

        Console.WriteLine("Somando dentro do método: " + (4 + 6)); //Dá pra fazer calculos direto aqui dentro.

        
        int subn1n2 = n1 - n2; // O operador - que subtrai variáveis e valores.
        Console.WriteLine("O valor da subtração é: " + subn1n2);

        int multn1n2 = n1 * n2; // O operador * que multiplica variáveis e valores.
        Console.WriteLine("O valor da multiplicação é: " + multn1n2); 

        double divn1n2 = (double)n1 / n2; // O operador / que subtrai variáveis e valores.
        Console.WriteLine("O valor da divisão é: " + (divn1n2));
        //

        int reston1n2 = n1 % n2;
        Console.WriteLine("O valor do resto da divisão é: " + reston1n2);
    }
}