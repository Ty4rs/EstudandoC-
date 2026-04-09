namespace manipulandoArquivos;

using System;
using System.IO;



public class Program()
{
    public static void Main(string[] args)
    {   
        //Criando um arquivo:
        System.IO.File.WriteAllText("teste.txt", "Hello Wordaaaa!");
        //Console.WriteLine("Arquico criado com sucesso!");

        //criando em um lugar especifico:
        string path = @"C:\Users\joaocl\Pictures\file.txt";
        //System.IO.File.WriteAllText(path, "hello word");

        //Adicionando ao final do arquivo:
        File.AppendAllText(path, "qual o nome seu?");
        
        //Lendo o arquivo:
        Console.WriteLine(File.ReadAllText(path));
        //O File.ReadAllText Lê o texto, mas eu também posso usar o File.ReadAllLines(path) para ler cara linha como se fosse um indice de uma linha
        //também posso usar o File.WriteAllLines(path, arrayComLinhas)


    }
}