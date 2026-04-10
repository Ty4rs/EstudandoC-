

namespace teste3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

public static List<Aluno> carregarAluno()
{

    List<Aluno> alunos = new List<Aluno>();
    var linhas = File.ReadAllLines("alunos.txt").ToList();
    for (int i = 0; i < linhas.Count; i += 6)
    {
        if (i + 4 >= linhas.Count) break; // protege contra registros incompletos
                                          //Console.WriteLine(linhas[i + 1]);
                                          //Console.WriteLine(linhas[i + 2]);
                                          //Console.WriteLine(linhas[i + 3]);
                                          //Console.WriteLine(linhas[i + 4]);
        Aluno aluno = new Aluno(int.Parse(linhas[i + 1]), linhas[i + 2], int.Parse(linhas[i + 3]), double.Parse(linhas[i + 4]));
        alunos.Add(aluno);
    }
    return alunos;
}





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