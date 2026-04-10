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
    

}
