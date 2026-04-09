namespace escola;
using System;
public class Program()
{
    public static void Main(string[] args)
    {
        Aluno joao = new Aluno(1, "joao", 20, 1.6);
        Aluno jose = new Aluno(2, "jose", 22, 1.3);
        Sistema.Interface();

        //List<Aluno> alunos = new List<Aluno>()
        //{
        //    joao, jose
        //};
        //Arquivo.escreverAluno(alunos);

        //foreach (Aluno aluno in alunos)
        //{
        //    Console.WriteLine($"Id: {aluno.id} ,Nome: {aluno.nome}, Idade: {aluno.Idade}, Altura: {aluno.altura}");
        //}

        List<Usuario> usuarios = Usuario.carregarUsuario();
        foreach (Usuario usuario in usuarios)
        {
            Console.WriteLine($"Id: {usuario.id} ,Nome: {usuario.login}, senha: {usuario.senha}, tipo: {usuario.tipo}");
        }

        Usuario user = Usuario.Login(usuarios);
        if (user is not null)
        {
            switch (user.tipo)
            {
                case 'A':
                    Aluno aluno = Aluno.carregarAluno(user);
                    Console.WriteLine(aluno.nome);
                    break;
            }
        } 

    }
}