using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace escola;

public class Arquivo()
{
    public static void escreverAluno(Aluno aluno)
    {
        
        File.AppendAllText("arquivo.txt", "{" + Environment.NewLine);
        File.AppendAllText("arquivo.txt", aluno.id + Environment.NewLine);
        File.AppendAllText("arquivo.txt", aluno.nome + Environment.NewLine);
        File.AppendAllText("arquivo.txt", aluno.Idade + Environment.NewLine);
        File.AppendAllText("arquivo.txt", aluno.altura + Environment.NewLine);
        File.AppendAllText("arquivo.txt", "}" + Environment.NewLine);
        
    }
    public static List<Aluno> carregarAluno()
    {

        List<Aluno> alunos = new List<Aluno>();
        var linhas = File.ReadAllLines("arquivo.txt").ToList();
        for (int i = 0; i < linhas.Count; i += 6)
        {
            if (i + 4 >= linhas.Count) break; // protege contra registros incompletos
            //Console.WriteLine(linhas[i + 1]);
            //Console.WriteLine(linhas[i + 2]);
            //Console.WriteLine(linhas[i + 3]);
            //Console.WriteLine(linhas[i + 4]);
            Aluno aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
            alunos.Add(aluno);
        }
        return alunos;
    }

}
