namespace listas;

public class Program()
{
    public static void Main(string[] args)
    {
        List<string> lista = new List<string>()
        {
            "fruta1", "fruta2", "fruta3"
        };

        lista.Add("fruta9"); //adiciona 1 item

        for (int i = 0; i < lista.Count; i++)
        {
            Console.Write(lista[i]);
        }
        lista.Remove("fruta3"); //remove um item
        Console.WriteLine("\n-----------");
        for (int i = 0; i < lista.Count; i++)  //O Count é usado para contar a quantidade de elementos dentro da lista (semelhante ao .Length)
        {
            Console.Write(lista[i]);
        }
        lista[0] = "apenas fruta"; //remove um item
        Console.WriteLine("\n-----------");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.Write(lista[i]);
        }

        lista.Clear();
        Console.WriteLine($"\nQuantidade de itens na lista após o clear: {lista.Count}.");



    }
}