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
            Console.WriteLine("4 - Voltar");
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
                        
                    List<MatriculasMaterias> matriculasporMaterias = MatriculasMaterias.carregarAlunosPorMateria();
                    List<Usuario> usuarios = Usuario.carregarUsuario();
                    if(matriculasporMaterias is null)
                    {
                        Console.WriteLine("\nNão foi encontrada nenhuma matrícula ou aluno...");
                        Console.WriteLine("Pressione enter para continuar...");
                        Console.ReadLine();
                        break;
                    }
                    var usuariosMatriculados = usuarios.Where(u => matriculasporMaterias.Any(m => m.idAluno == u.id)).ToList();
                    
                    foreach (Usuario usuario in usuariosMatriculados)
                    {
                        Console.WriteLine($"Aluno: {Aluno.carregarAluno(usuario).nome}");
                    }
                    
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    return;
            }
        }


}
}
