namespace inputEOutputs;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-------- Cadastro de Usuários");

        //Solicitando o nome do usuário:
        Console.WriteLine("Digite o seu nome: ");
        String nome = Console.ReadLine();


        //Solicitando a idade do usuário:
        Console.WriteLine("Digite a sua idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());

        //Solicitando altura:
        Console.WriteLine("Digite a sua altura: ");
        double altura = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("---------//---------");

        Console.WriteLine("Nome do Usuário: " + nome);
        Console.WriteLine("Idade do Usuário: " + idade);
        Console.WriteLine("Altura do Usuário: " + altura);



    }
}