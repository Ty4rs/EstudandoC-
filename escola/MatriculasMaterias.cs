using System;
using System.Collections.Generic;
using System.Text;

namespace escola;

public class MatriculasMaterias
{
    static string arquivo = Path.Combine(AppContext.BaseDirectory, "matriculas-materias.txt");
    public int idAluno, idMateria;
    
    public MatriculasMaterias(int idAluno, int idMateria)
    {
        this.idAluno = idAluno;
        this.idMateria = idMateria;

    }

    public static void Cadastro(Aluno aluno)
    {
        Console.Clear();
        Console.WriteLine($"{Sistema.barras} Matricular em Materias {Sistema.barras}\n");

        List<Materia> materias = Materia.carregarMaterias();
        Console.WriteLine("Materias Disponiveis:");
        if(materias is null)
        {
            Console.WriteLine("\nNenhuma matéria disponível para matrícula...");
            Console.WriteLine("\nPrecione enter para continuar...");
            Console.ReadLine();
            return;
        }
        foreach (Materia materia in materias)
        {
            Console.WriteLine($"ID: {materia.id} - {materia.nome}");
        }
        Console.WriteLine("\nDigite o ID da materia que deseja se matricular:");
        int idMateria = int.Parse(Console.ReadLine());
        MatriculasMaterias matricula = new MatriculasMaterias(aluno.id, idMateria);
        if (string.IsNullOrWhiteSpace(File.ReadLines(MatriculasMaterias.arquivo).FirstOrDefault()))
        {
            File.AppendAllText(MatriculasMaterias.arquivo, "{" + Environment.NewLine);
        }
        else
        {
            File.AppendAllText(MatriculasMaterias.arquivo, Environment.NewLine + "{" + Environment.NewLine);
        }
        File.AppendAllText(MatriculasMaterias.arquivo, matricula.idAluno + Environment.NewLine);
        File.AppendAllText(MatriculasMaterias.arquivo, matricula.idMateria + Environment.NewLine);
        File.AppendAllText(MatriculasMaterias.arquivo, "}");
    }

    public static List<MatriculasMaterias> carregarTodasMatriculasMaterias()
    {   
        var matriculas = new List<MatriculasMaterias>{};
        List<string> linhas = File.ReadAllLines(arquivo).ToList();
        for(int i=0; i < linhas.Count; i+=4)
        {
            int.TryParse(linhas[i+1], out int idAluno);
            int.TryParse(linhas[i+2], out int idMateria);
            MatriculasMaterias  matriculaMateria = new MatriculasMaterias(idAluno, idMateria);
            matriculas.Add(matriculaMateria);
        }
        return matriculas;

    }

    public static List<MatriculasMaterias> carregarAlunosPorMateria()
    {
        List<Materia> materiasTotais = Materia.carregarMaterias();
        Console.WriteLine("Materias Disponiveis:");
        if(materiasTotais is null)
        {
            Console.WriteLine("\nNão existe nenhuma matéria cadastrada ainda...");
            Console.WriteLine("Precione enter para continuar...");
            return null;
        }
        foreach (Materia materia in materiasTotais)
        {
            Console.WriteLine($"ID: {materia.id} - {materia.nome}");
        }
        Console.WriteLine("\nDigite o ID da materia que deseja buscar:");
        
        int.TryParse(Console.ReadLine(), out int idMateria);
        
        List<MatriculasMaterias> materias = new List<MatriculasMaterias> { };
        var linhas = File.ReadAllLines(MatriculasMaterias.arquivo).ToList();
        if (linhas.Count > 0)
        {
            for (int i = 0; i < linhas.Count; i += 4)
            {
                Materia materiaLinha = materiasTotais.FirstOrDefault(mat => mat.id == Convert.ToInt32(linhas[i + 2]));
                if (materiaLinha.id == idMateria)
                {
                    
                    MatriculasMaterias materia = new MatriculasMaterias(int.Parse(linhas[i + 1]), int.Parse(linhas[i + 2]));
                    materias.Add(materia);
                    


                }
            }
        }
        
        return materias;
    }
}
