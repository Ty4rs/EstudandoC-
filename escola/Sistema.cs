using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

internal class Sistema
{
    public static string barras = "=========";
    public static void Interface()
    {
        List<Usuario> usuarios = Usuario.carregarUsuario();
        foreach (Usuario usuario in usuarios)
        {
            Console.WriteLine($"Id: {usuario.id} ,Nome: {usuario.login}, senha: {usuario.senha}, tipo: {usuario.tipo}");
        }

        Usuario user;

        Console.WriteLine($"{barras} Portal Escolar {barras}");
        Console.WriteLine("\nSeja bem vindo ao portal escolar! pressione enter para continuar...");
        Console.ReadLine();
        Console.Clear();
        while (true)
        {
            Console.WriteLine($"{barras} Cadastro / login {barras}\n");
            Console.WriteLine("Escolha um para continuar:");
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Cadastro");
            Console.WriteLine("3 - Sair");
            string escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                    user = Usuario.Login(usuarios);
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
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }


    }
}
