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
    
}
