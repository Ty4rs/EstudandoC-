using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Professor
{   
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "professores.txt");
    public int id;
    public string nome, cpf, formacao;
    public Professor(int id, string nome, string cpf, string formacao)
    {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.formacao = formacao;

    }

    public static Professor carregarProfessor(Usuario usuario)
    {

        Professor professor = null;
        var linhas = File.ReadAllLines(Professor.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i < linhas.Count; i += 6)
            {

                if ((linhas[i + 1]) == usuario.id.ToString())
                {
                    professor = new Professor(int.Parse(linhas[i + 1]), linhas[i + 2], linhas[i + 3], linhas[i + 4]);
                    break;

                }
            }
        }
        else
        {
            return null;
        }
        return professor;
    }

    public static void Cadastro(Usuario user)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Cadastro de Professores {Sistema.barras}\n");
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite seu CPF:");
        string cpf = Console.ReadLine();
        Console.WriteLine("Qual é a sua formação:");
        string formacao = Console.ReadLine();
        Professor professor = new Professor(user.id, nome, cpf, formacao);
        if (string.IsNullOrWhiteSpace(File.ReadLines(Professor.arquivo).FirstOrDefault()))
        {
            File.AppendAllText(Professor.arquivo, "{" + Environment.NewLine);
        }
        else
        {
            File.AppendAllText(Professor.arquivo, Environment.NewLine + "{" + Environment.NewLine);
        }
        File.AppendAllText(Professor.arquivo, professor.id + Environment.NewLine);
        File.AppendAllText(Professor.arquivo, professor.nome + Environment.NewLine);
        File.AppendAllText(Professor.arquivo, professor.cpf + Environment.NewLine);
        File.AppendAllText(Professor.arquivo, professor.formacao + Environment.NewLine);
        File.AppendAllText(Professor.arquivo, "}");

        Console.WriteLine("Matricula realizada com sucesso!");

    }

}
