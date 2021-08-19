using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario;
            int indiceAluno = 0;

            opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        
                        Aluno aluno = new Aluno();
                        Console.Write("Informe o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Informe a nota: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser numérico decimal!");
                        }
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (a != null)
                            {
                                Console.WriteLine("Aluno: {0}, Nota: {1}", a.Nome, a.Nota);
                            }
                            
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (alunos[i] == null) continue;

                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoNota conceitoMedia;

                        switch (mediaGeral)
                        {
                            case decimal n when (n >= 0 && n <= 2) :
                                conceitoMedia = ConceitoNota.E;
                                break;
                            
                            case decimal n when (n > 2 && n < 5):
                                conceitoMedia = ConceitoNota.D;
                                break;
                            case decimal n when (n >= 5 && n < 6):
                                conceitoMedia = ConceitoNota.C;
                                break;

                            case decimal n when (n >= 7 && n < 9):
                                conceitoMedia = ConceitoNota.B;
                                break;
                            case decimal n when (n >= 9 && n <= 10):
                                conceitoMedia = ConceitoNota.A;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        Console.WriteLine("Média geral: {0}", mediaGeral);
                        Console.WriteLine($"Conceito Média: {conceitoMedia}", mediaGeral);
                        Console.ReadLine();

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            //Console.Clear();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1. Inserir novo aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Calcular média geral");
            Console.WriteLine("X. Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
