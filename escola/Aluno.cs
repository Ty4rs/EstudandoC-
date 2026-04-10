using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Aluno
{
    public string nome;
    public int Idade, id;
    public double altura;
    

    public Aluno(int id, string nome, int idade, double altura)
    {
        this.id = id;
        this.nome = nome;
        this.Idade = idade;
        this.altura = altura;
        
    }
    public static Aluno carregarAluno(Usuario usuario)
    {

        Aluno aluno = null;
        var linhas = File.ReadAllLines("alunos.txt").ToList();
        for (int i = 0; i < linhas.Count; i += 6)
        {
            
            if((linhas[i + 1]) == usuario.id.ToString()) {
                 aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
                 break;
            }
        }
        return aluno;
    }

    public static void Cadastro(Usuario user)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Cadastro de Aluno {Sistema.barras}\n");
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite sua idade:");
        int idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite sua altura:");
        double altura = double.Parse(Console.ReadLine());
        Aluno aluno = new Aluno(user.id, nome, idade, altura);

        File.AppendAllText("alunos.txt", Environment.NewLine + "{" + Environment.NewLine);
        File.AppendAllText("alunos.txt", aluno.id + Environment.NewLine);
        File.AppendAllText("alunos.txt", aluno.nome + Environment.NewLine);
        File.AppendAllText("alunos.txt", aluno.Idade + Environment.NewLine);
        File.AppendAllText("alunos.txt", aluno.altura + Environment.NewLine);
        File.AppendAllText("alunos.txt", "}");

        Console.WriteLine("Matricula realizada com sucesso!");

    }

}
