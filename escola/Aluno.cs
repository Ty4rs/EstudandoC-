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
    public static Aluno carregarAluno(Usuario user)
    {

        Aluno aluno = null;
        var linhas = File.ReadAllLines("arquivo.txt").ToList();
        for (int i = 0; i < linhas.Count; i += 6)
        {
            if (i + 4 >= linhas.Count) break; // protege contra registros incompletos
            
            if(linhas[i + 1] == user.id.ToString()) {
                
                 aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
                 break;
            }
            
            
        }
        return aluno;
    }

}
