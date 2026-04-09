namespace escola;
using System;
public class Program()
{
    public static void Main(string[] args)
    {
        Aluno joao = new Aluno(1, "joao", 20, 1.6);
        Aluno jose = new Aluno(2, "jose", 22, 1.3);

        //List<Aluno> alunos = new List<Aluno>()
        //{
        //    joao, jose
        //};
        //Arquivo.escreverAluno(alunos);
        List<Aluno> alunos = Arquivo.carregarAluno();
        foreach (Aluno aluno in alunos)
        {
            Console.WriteLine($"Id: {aluno.id} ,Nome: {aluno.nome}, Idade: {aluno.Idade}, Altura: {aluno.altura}");
        }
    }
}