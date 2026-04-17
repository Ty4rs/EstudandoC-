using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            //Console.WriteLine($"Id: {usuario.id} ,Nome: {usuario.login}, senha: {usuario.senha}, tipo: {usuario.tipo}");
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
                    usuarios = Usuario.carregarUsuario();
                    user = Usuario.Login(usuarios);
                    if (user is not null)
                    {
                        switch (user.tipo)
                        {
                            case 'A':
                                Aluno aluno = Aluno.carregarAluno(user);
                                if (aluno is null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Mátricula de aluno não encontrada nesso LOGIN.");
                                    Console.WriteLine("Precione enter para proseguir com a mátricula!");
                                    Console.ReadLine();
                                    Aluno.Cadastro(user);
                                }

                                Console.Clear();
                                Console.WriteLine("Login realizado com sucesso!");
                                InterfaceAluno(aluno);
                                break;
                            case 'P':
                                Professor professor = Professor.carregarProfessor(user);
                                if (professor is null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Mátricula de professor não encontrada nesso LOGIN.");
                                    Console.WriteLine("Precione enter para proseguir com a mátricula!");
                                    Console.ReadLine();
                                    Professor.Cadastro(user);
                                }

                                Console.Clear();
                                Console.WriteLine("Login realizado com sucesso!");
                                var materias = Materia.carregarMateriasPorProfessor(professor);
                                InterfaceProfessor(professor);
                                break;
                        }
                    }
                    break;

                case "2":
                    usuarios = Usuario.carregarUsuario();
                    Usuario.Cadastro(usuarios);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public static void InterfaceAluno(Aluno aluno)
    {
        Console.WriteLine("\n" + barras + " Portal do Aluno " + barras);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n" + barras + " Portal do Professor " + barras);
            Console.WriteLine("Escolha uma atividade para realizar: ");
            Console.WriteLine("1 - Listar minhas matérias.");
            Console.WriteLine("2 - Cadastrar na matéria.");
            Console.WriteLine("3 - Voltar");
            string escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    List<MatriculasMaterias> todasMatriculas = MatriculasMaterias.carregarTodasMatriculasMaterias();
                    List<Materia> todasAsMaterias = Materia.carregarMaterias();
                    if(todasMatriculas is null || todasAsMaterias is null)
                    {
                        break;
                    }
                    var materiasDoAluno = todasAsMaterias.Where(mat => todasMatriculas.Any(matricula => matricula.idMateria == mat.id && matricula.idAluno == aluno.id)).ToList();

                    foreach (var m in materiasDoAluno)
                    {
                        Console.WriteLine($"Você está matriculado em: {m.nome}");
                    }
                    Console.WriteLine("\n \nPrecione enter para continuar...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    MatriculasMaterias.Cadastro(aluno);
                    break;
                default:
                    Console.Clear();
                    return;
            }

        }
    }
    public static void InterfaceProfessor(Professor professor)
    {
        while (true)
        {
            
            Console.Clear();
            Console.WriteLine("\n" + barras + " Portal do Professor " + barras);
            Console.WriteLine("Escolha uma atividade para realizar: ");
            Console.WriteLine("1 - Lstar minhas matérias.");
            Console.WriteLine("2 - Cadastrar matéria.");
            Console.WriteLine("3 - Consultar alunos de minhas matérias.");
            Console.WriteLine("4 - Cadastrar Frequência.");
            Console.WriteLine("5 - Consultar Frequências por matéria.");
            Console.WriteLine("6 - Voltar");
            string escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    List<Materia> materias = Materia.carregarMateriasPorProfessor(professor);
                    if(materias is null)
                    {
                        Console.WriteLine("\nVocê ainda não possuí nenhuma matéria...");
                        Console.WriteLine("Pressione enter para continuar");
                        Console.ReadLine();
                        break;
                    }
                    foreach (Materia mat in materias)
                    {
                        Console.WriteLine($"Matéria: {mat.nome}, Carga Horária: {mat.cargaHoraria}");
                        
                    }
                    Console.WriteLine("\n \nPrecione enter para continuar...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Materia.Cadastro(professor);
                    break;
                case "3":
                    Console.Clear();
                        
                    //List<MatriculasMaterias> matriculasporMaterias = MatriculasMaterias.carregarAlunosPorMateria();
                    //List<Usuario> usuarios = Usuario.carregarUsuario();
                    //if(matriculasporMaterias is null)
                    //{
                    //    Console.WriteLine("\nNão foi encontrada nenhuma matrícula ou aluno...");
                    //    Console.WriteLine("Pressione enter para continuar...");
                    //    Console.ReadLine();
                    //    break;
                    //}
                    //var usuariosMatriculados = usuarios.Where(u => matriculasporMaterias.Any(m => m.idAluno == u.id)).ToList();
                    
                    //foreach (Usuario usuario in usuariosMatriculados)
                    //{
                    //    Console.WriteLine($"Aluno: {Aluno.carregarAluno(usuario).nome}");
                    //}

                    List<Materia> materiasDoProfessor = Materia.carregarMateriasPorProfessor(professor);
                    List<MatriculasMaterias> matriculas = MatriculasMaterias.carregarAlunosPorMateria(professor);

                    if (matriculas == null || materiasDoProfessor == null || materiasDoProfessor.Count == 0)
                    {
                        Console.WriteLine("\nNão foi encontrada nenhuma matrícula ou matéria para este professor...");
                        Console.WriteLine("Pressione enter para continuar...");
                        Console.ReadLine();
                        break;
                    }

                    var matriculasDoProfessor = matriculas.Where(m => materiasDoProfessor.Any(mat => mat.id == m.idMateria)).ToList();
                    var usuariosMatriculados = Usuario.carregarUsuario().Where(u => matriculasDoProfessor.Any(m => m.idAluno == u.id)).ToList();

                    if (usuariosMatriculados.Count == 0)
                    {
                        Console.WriteLine("\nNão foi encontrada nenhuma matrícula ou aluno para este professor...");
                        Console.WriteLine("Pressione enter para continuar...");
                        Console.ReadLine();
                        break;
                    }

                    foreach (Usuario usuario in usuariosMatriculados)
                    {
                        Console.WriteLine($"Aluno: {Aluno.carregarAluno(usuario).nome}");
                    }

                    Console.ReadLine();
                    break;
                    case "4":
                    Console.Clear();
                    Frequencia.Cadastro(professor);

                    
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine($"{barras} Frequencias {barras}");
                    List<Frequencia> frequencias = Frequencia.carregarFrequencias();
                    if (frequencias is null || frequencias.Count == 0)
                    {
                        Console.WriteLine("\nNão foi encontrada nenhuma frequência para este professor...");
                        Console.WriteLine("Pressione enter para continuar...");
                        Console.ReadLine();
                        break;
                    }
                    
                    

                    List<Materia> materiasProfessor = Materia.carregarMateriasPorProfessor(professor);
                    var materiasFrequencia = materiasProfessor.Join(frequencias, mp => mp.id, f => f.IdMateria, (mp, f) => new
                    {
                        mp, f
                    });

                    materias = Materia.carregarMaterias();
                    Console.WriteLine("Materias Disponiveis:");
                    if (materias is null)
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
                    
                    if (int.TryParse(Console.ReadLine(), out int idMateria))
                    {
                        var alunoMatfrequencia = materiasFrequencia.Where(mf => mf.f.IdMateria == idMateria).
                            Join(Aluno.carregarTodosAlunos(), mfw => mfw.f.IdAluno, a => a.id, (mfw, a) => new {mfw, a});

                        Console.Clear();
                        Console.WriteLine($"{barras}{materiasFrequencia.FirstOrDefault().mp.nome} {barras}");
                        foreach (var mat in alunoMatfrequencia.Where(mf => mf.mfw.f.IdMateria == idMateria))
                        {
                           Console.WriteLine($"Aluno: {mat.a.nome} Data: {mat.mfw.f.Data} Presente: {(mat.mfw.f.Presente ? "Sim" : "Não")}");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    }
                    
                    Console.WriteLine("Id inválido, pressione ENTER para continuar...");
                    Console.ReadLine();
                    
                    
                    

                    break;
                default:
                    Console.Clear();
                    return;
            }
        }


}
}
