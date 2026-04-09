namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        //1- primeira forma de declarar é com os valores nos indices preenchidos
        //o tamanho da lista já é especificado pela quantidade preenchida no inicio
        string[] compras = { "arroz", "feijão", "farinha" };
        Console.Write("Eu Preciso comprar");
        foreach (string i in compras){
            Console.Write($" {i},");
        }

        //2- A segunda forma é instanciando do tipo específico.
        //!!!!!Sempre que eu fazer assim, obrigatoriamente preciso dizer o tamanho da lista.

        int[] listNumber = new int[10];

        for (int i = 0; i < listNumber.Length; i++)
        {
            listNumber[i] = i;
            Console.Write($"{listNumber[i], 8}");
        }
}
}