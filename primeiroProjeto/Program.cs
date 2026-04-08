using System.Runtime.CompilerServices;

namespace primeiroProjeto;



public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello word");
        //Escreve no console do terminal.

        string nome = "joao";
        int idade = 18;
        double altura = 1.87;
        Console.WriteLine("Olá " + nome + ", Você tem " + idade + " anos e " +  altura + "m de altura");
        bool SouN = false; //Tipo boolean, True ou False.
        char sexo = 'F'; //O valor precisa ser entre aspas simples.
        Console.WriteLine("É homem? " + SouN + ", Qual o seu sexo? " + sexo);


        //--------- Constantes ---------

        const string nome2 = "joao"; //Uma constante só pode ser preenchida uma unica vez.
        //nome2 = "jose"; --> isso gera um erro pois eu estaria tentando reescreve-la, o que não é possível para uma String.

        //--------- Vars ---------

        var nome3 = "nome"; // O tipo var tem tipagem dinâmica na sua declaração, ou seja, o tipo que foi declarado no primeiro preenchimento dela.
        Console.WriteLine(nome3.GetType()); //.GetType() retorna o tipo da variável

        //--------- dinamico ---------
        dynamic nome4 = 2;
        nome4 = "joao4";
        Console.WriteLine(nome4);


        Console.Write($"{nome4} olá {nome4, 10}");
    }
}