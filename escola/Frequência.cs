using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class Frequencia
{
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "materias.txt");
    int Id, IdMateria, IdAluno;
    string Data;
    public bool Presente;

    public Frequencia(int Id, int IdMateria, int IdAluno, string Data, bool Presente)
    {
        this.Id = Id;
        this.IdMateria = IdMateria;
        this.IdAluno = 0;
        this.Data = Data;
        this.Presente = Presente;
    }

    public List<Frequencia> carregarFrequencias()
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
            var alunosmatriculados = alunos.Where(u => matriculasporMaterias.Any(m => m.idAluno == u.id)).ToList();
            foreach (Aluno aluno in alunosmatriculados)
            {
                Console.WriteLine($"ID: {aluno.id} - {aluno.nome}");
            }
        }
    }

}
