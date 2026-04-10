using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Cadastro / login {Sistema.barras}\n");
        Console.WriteLine("Digite seu login:");
        string login = Console.ReadLine();
        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        foreach (Usuario user in usuario)
        {   
            
            if (user.login == login && user.senha == senha)
            {
                Console.WriteLine($"Bem-vindo, {user.login}!");
                return user;
            }

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
            for (int i = 0; i < linhas.Count; i += 6)
            {
                
                Usuario user = new Usuario(int.Parse(linhas[i + 1]), linhas[i + 2], linhas[i + 3], Convert.ToChar(linhas[i + 4]));
                usuarios.Add(user);
            }
            
        }
        else 
        {
            Console.WriteLine("Nenhum usuário encontrado.");
        }
        return usuarios;
    }

    public static void Cadastro(List<Usuario> usuarios)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} CADASTRO {Sistema.barras}");
        Console.WriteLine("\nDigite um login para cadastro:");
        string login = Console.ReadLine();
        Console.WriteLine("Digite uma senha para cadastro:");
        string senha = Console.ReadLine();
        Console.WriteLine("Qual é a sua função?");
        char funcao = Console.ReadLine().ToUpper()[0];
        Usuario usuario = new Usuario(usuarios.Count + 1, login, senha, funcao);
        
        File.AppendAllText("usuarios.txt",  Environment.NewLine + "{" + Environment.NewLine);
        File.AppendAllText("usuarios.txt", usuario.id + Environment.NewLine);
        File.AppendAllText("usuarios.txt", usuario.login + Environment.NewLine);
        File.AppendAllText("usuarios.txt", usuario.senha + Environment.NewLine);
        File.AppendAllText("usuarios.txt", usuario.tipo + Environment.NewLine);
        File.AppendAllText("usuarios.txt", "}");
        Console.WriteLine("Cadastro bem sucedido!");
        
    }



}
