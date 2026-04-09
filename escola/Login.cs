using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Login
{
    static Aluno Logar(string login, string senha)
    {
        List<Aluno> alunos = Arquivo.carregarAluno();
        foreach (Aluno aluno in alunos)
        {
            if (aluno.nome == login && aluno.Idade.ToString() == senha)
            {
                Console.WriteLine("Login bem-sucedido!");
                return aluno;
            }
        }
        Console.WriteLine("Login falhou!");
        return null;
    }
}
