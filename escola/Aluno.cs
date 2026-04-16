using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Aluno
{   
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "alunos.txt");
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
        var linhas = File.ReadAllLines(Aluno.arquivo).ToList();
        for (int i = 0; i < linhas.Count; i += 6)
        {
            
            if((linhas[i + 1]) == usuario.id.ToString()) {
                 aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
                 break;
            }
        }
        return aluno;
    }
    public static List<Aluno> carregarTodosAlunos()
    {
        List<Aluno> alunos = new List<Aluno>();
        var linhas = File.ReadAllLines(Aluno.arquivo).ToList();
        for (int i = 0; i < linhas.Count; i += 6)
        {
            Aluno aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
            alunos.Add(aluno);
        }
        return alunos;
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

        if (string.IsNullOrWhiteSpace(File.ReadLines(Aluno.arquivo).FirstOrDefault()))
        {
            File.AppendAllText(Aluno.arquivo, "{" + Environment.NewLine);
        }
        else
        {
            File.AppendAllText(Aluno.arquivo, Environment.NewLine + "{" + Environment.NewLine);
        }
        File.AppendAllText(Aluno.arquivo, aluno.id + Environment.NewLine);
        File.AppendAllText(Aluno.arquivo, aluno.nome + Environment.NewLine);
        File.AppendAllText(Aluno.arquivo, aluno.Idade + Environment.NewLine);
        File.AppendAllText(Aluno.arquivo, aluno.altura + Environment.NewLine);
        File.AppendAllText(Aluno.arquivo, "}");

        Console.WriteLine("Matricula realizada com sucesso!");

    }

}
