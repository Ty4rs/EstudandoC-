using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace escola;

public class Usuario
{
    public string login, senha;
    public int id;
    public char tipo; // A - Aluno, P - Professor.
    private Aluno aluno;
    public Usuario(int id, string login, string senha, char tipo)
    {
        this.id = id;
        this.login = login;
        this.senha = senha;
        this.tipo = tipo;
        
    }

    public static Usuario Login(List<Usuario> usuario)
    {   
        foreach (Usuario user in usuario)
        {   
            Console.Clear();
            Console.WriteLine($"{Sistema.barras} Cadastro / login {Sistema.barras}\n");
            Console.WriteLine("Digite seu login:");
            string login = Console.ReadLine();
            Console.WriteLine("Digite sua senha:");
            string senha = Console.ReadLine();
            if (user.login == login && user.senha == senha)
            {
                Console.WriteLine($"Bem-vindo, {user.login}!");
                return user;
            }
            break;
        }
        Console.WriteLine("Login ou senha incorretos. Tente novamente.");
        return null;
    }

    public static List<Usuario> carregarUsuario()
    {

        List<Usuario> usuarios = new List<Usuario>();
        if (File.ReadAllLines("usuarios.txt").Any() && File.Exists("usuarios.txt"))
        {

            var linhas = File.ReadAllLines("usuarios.txt").ToList();
            for (int i = 0; i < linhas.Count; i += 5)
            {
                if (i + 4 >= linhas.Count) break; // protege contra registros incompletos
                //Console.WriteLine(linhas[i + 1]);
                //Console.WriteLine(linhas[i + 2]);
                //Console.WriteLine(linhas[i + 3]);
                //Console.WriteLine(linhas[i + 4]);
                Usuario user = new Usuario(int.Parse(linhas[i + 1]), linhas[i + 2], linhas[i + 3], Convert.ToChar(linhas[i + 4]));
                usuarios.Add(user);
            }
            
        }
        else {
            Console.WriteLine("Nenhum usuário encontrado.");
            

        }
        return usuarios;
    }



}
