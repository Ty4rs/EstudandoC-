using escola;
using System;
using System.Collections.Generic;
using System.Text;

namespace escola;
public class Materia
{   
    static string arquivo = "materias.txt";
    public string nome;
    public int id, cargaHoraria, IDProfessor;
    
    public Materia(int id, int IDProfessor, string nome, int cargaHoraria)
    {
        this.IDProfessor = IDProfessor;
        this.id = id;
        this.nome = nome;
        this.cargaHoraria = cargaHoraria;
        
    }

    public static List<Materia> carregarMaterias()
    {
        List<Materia> materias = new List<Materia> { };
        var linhas = File.ReadAllLines(Materia.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i < linhas.Count; i += 6)
            {

                
                Materia materia = new Materia(int.Parse(linhas[i + 1]), int.Parse(linhas[i + 2]), linhas[i + 3], int.Parse(linhas[i + 4]));
                materias.Add(materia);
                Console.WriteLine("aa" + materia.ToString());
                    

            }
        }
        else
        {
            return null;
        }
        return materias;
    }
    public static List<Materia> carregarMateriasPorProfessor(Professor professor)
    {
        List<Materia> materias = new List<Materia> {};
        var linhas = File.ReadAllLines(Materia.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i<linhas.Count; i += 6)
            {

                if ((linhas[i + 1]) == professor.id.ToString())
                {
                    Materia materia = new Materia(int.Parse(linhas[i + 1]), int.Parse(linhas[i + 2]), linhas[i + 3], int.Parse(linhas[i + 4]));
                    materias.Add(materia);
                    Console.WriteLine("aa" +materia.ToString());
                    continue;
                    

                }
            }
        }
        else
        {
            return null;
        }
        return materias;
    }

    public static void Cadastro(Professor professor)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Cadastro de Materias {Sistema.barras}\n");
        Console.WriteLine("Digite o nome da materia:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a carga horária:");
        int cargaHoraria = int.Parse(Console.ReadLine());
        Materia materia = new Materia(professor.id, professor.id, nome, cargaHoraria);
        if (string.IsNullOrWhiteSpace(File.ReadLines(Materia.arquivo).FirstOrDefault()))
        {
            File.AppendAllText(Materia.arquivo, "{" + Environment.NewLine);
        }
        else
        {
            File.AppendAllText(Materia.arquivo, Environment.NewLine + "{" + Environment.NewLine);
        }
        File.AppendAllText(Materia.arquivo, materia.id + Environment.NewLine);
        File.AppendAllText(Materia.arquivo, materia.IDProfessor + Environment.NewLine);
        File.AppendAllText(Materia.arquivo, materia.nome + Environment.NewLine);
        File.AppendAllText(Materia.arquivo, materia.cargaHoraria.ToString() + Environment.NewLine);
        File.AppendAllText(Materia.arquivo, "}");
    }

    




}