namespace switchCase;


public class Program()
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---- Switch ----");
        //Basicamente, o switch é uma estrutura condicional semelhante ao if só que com a sintaxe mais rápida e menor.
        //Ele é melhor utilizados em condições que possuem vários casos condicionais.


        Console.WriteLine("Digite um numero: ");
        int x = Convert.ToInt32(Console.ReadLine());

        switch (x)
        {


            case 0:
            case 1:
                Console.WriteLine("seu número é zero ou um");
                //um case embaixo fica como se por ex ele for igual a um ou outro
                break;
            case < 5:
                Console.WriteLine("Ele é menor que 5");
                break;

            case < 10:
                Console.WriteLine("Ele é menor que 10");
                break;
            
            

        }

        
    }
}