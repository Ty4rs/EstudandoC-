using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Frequencia
{
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "frequencia.txt");
    public int Id, IdMateria, IdAluno;
    public string Data;
    public bool Presente;

    public Frequencia(int Id, int IdMateria, int IdAluno, string Data, bool Presente)
    {
        this.Id = Id;
        this.IdMateria = IdMateria;
        this.IdAluno = IdAluno;
        this.Data = Data;
        this.Presente = Presente;
    }

    public static List<Frequencia> carregarFrequencias()
    {
        List<Frequencia> frequencias = new List<Frequencia> { };
        var linhas = File.ReadAllLines(Frequencia.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i < linhas.Count; i += 7)
            {
                Frequencia frequencia = new Frequencia(int.Parse(linhas[i + 1]), int.Parse(linhas[i + 2]), int.Parse(linhas[i + 3]), linhas[i + 4], bool.Parse(linhas[i + 5]));
                frequencias.Add(frequencia);
                Console.WriteLine("aa" + frequencia.ToString());
            }
        }
        return frequencias;
    }

    public static List<Frequencia> CarregarFrequenciasPorMateria(int idMateria)
    {
        List<Frequencia> frequencias = new List<Frequencia> { };
        var linhas = File.ReadAllLines(Frequencia.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i < linhas.Count; i += 7)
            {
                if ((linhas[i + 2]) == idMateria.ToString())
                {
                    Frequencia frequencia = new Frequencia(int.Parse(linhas[i + 1]), int.Parse(linhas[i + 2]), int.Parse(linhas[i + 3]), linhas[i + 4], bool.Parse(linhas[i + 5]));
                    frequencias.Add(frequencia);
                }
            }
        }
        return frequencias;
    }

    

    public static void Cadastro(Professor professor)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Lançar Frequencia {Sistema.barras}\n");
        //List<Materia> materias = Materia.carregarMateriasPorProfessor(professor);
        //Console.WriteLine("Materias Disponiveis:");
        //if (materias is null)
        //{
        //    Console.WriteLine("\nNenhuma matéria disponível para lançar frequência...");
        //    Console.WriteLine("\nPrecione enter para continuar...");
        //    Console.ReadLine();
        //    return;
        //}
        //foreach (Materia materia in materias)
        //{
        //    Console.WriteLine($"ID: {materia.id} - {materia.nome}");
        //}
        //Console.WriteLine("\nDigite o ID da materia que deseja lançar frequência:");
        //int idMateria = int.Parse(Console.ReadLine());

        List<MatriculasMaterias> matriculasporMaterias = MatriculasMaterias.carregarAlunosPorMateria(professor);
        List<Aluno> alunos = Aluno.carregarTodosAlunos();
        if (matriculasporMaterias is null)
        {
            Console.WriteLine("\nNão foi encontrada nenhuma matrícula ou aluno...");
            Console.WriteLine("Pressione enter para continuar...");
            Console.ReadLine();

        }
        else
        {   
            Console.WriteLine("\nDigite a data da frequência (dd/mm/yyyy):");
            string data = Console.ReadLine();
            var alunosmatriculados = alunos.Where(u => matriculasporMaterias.Any(m => m.idAluno == u.id)).ToList();
            foreach (Aluno aluno in alunosmatriculados)
            {
                Console.WriteLine($"ID: {aluno.id} - {aluno.nome}");
                Console.WriteLine("O aluno está presente? (s/n)");
                bool resposta = Console.ReadLine()== "s" ? true : false;

                Frequencia frequencia = new Frequencia(carregarFrequencias().Count + 1, matriculasporMaterias[0].idMateria, aluno.id, data, resposta);
                


                if (string.IsNullOrWhiteSpace(File.ReadLines(Frequencia.arquivo).FirstOrDefault()))
                {
                    File.AppendAllText(Frequencia.arquivo, "{" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(Frequencia.arquivo, Environment.NewLine + "{" + Environment.NewLine);
                }
                File.AppendAllText(Frequencia.arquivo, frequencia.Id + Environment.NewLine);
                File.AppendAllText(Frequencia.arquivo, frequencia.IdMateria + Environment.NewLine);
                File.AppendAllText(Frequencia.arquivo, frequencia.IdAluno + Environment.NewLine);
                File.AppendAllText(Frequencia.arquivo, frequencia.Data + Environment.NewLine);
                File.AppendAllText(Frequencia.arquivo, frequencia.Presente.ToString() + Environment.NewLine);
                File.AppendAllText(Frequencia.arquivo, "}");

            }
        }
    }

}
