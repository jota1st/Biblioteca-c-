// Alunos: Túlio Thauã Dutra e José Pedro

namespace Biblioteca;

using System;

public class Program
{
    static void Main(string[] args)
    {
        Biblioteca minhaBiblioteca = new Biblioteca();

        while (true)
        {
            Console.WriteLine("\n--- Menu da Biblioteca ---");
            Console.WriteLine("1. Cadastrar Leitor");
            Console.WriteLine("2. Listar Todos os Leitores");
            Console.WriteLine("3. Buscar Leitor por CPF");
            Console.WriteLine("4. Editar Leitor");
            Console.WriteLine("5. Excluir Leitor");
            Console.WriteLine("6. Incluir Livro para Leitor");
            Console.WriteLine("7. Editar Livro Específico do Leitor");
            Console.WriteLine("8. Remover Livro do Leitor");
            Console.WriteLine("9. Doar Livro");
            Console.WriteLine("10. Pesquisar Livro por ISBN");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome do Leitor: ");
                    string nomeLeitor = Console.ReadLine()!;
                    Console.Write("CPF do Leitor: ");
                    string cpfLeitor = Console.ReadLine()!;
                    minhaBiblioteca.CadastrarLeitor(nomeLeitor, cpfLeitor);
                    break;
                case "2":
                    minhaBiblioteca.ListarTodosLeitores();
                    break;
                case "3":
                    Console.Write("CPF do Leitor a buscar: ");
                    string cpfBusca = Console.ReadLine()!;
                    Leitor leitorEncontrado = minhaBiblioteca.BuscarLeitorPorCpf(cpfBusca);
                    if (leitorEncontrado != null)
                    {
                        Console.WriteLine("\n--- Detalhes do Leitor ---");
                        leitorEncontrado.ExibirDetalhes();
                        Console.WriteLine("--------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Leitor com CPF \'{cpfBusca}\' não encontrado.");
                    }
                    break;
                case "4":
                    Console.Write("CPF do Leitor a editar: ");
                    string cpfEditar = Console.ReadLine()!;
                    Console.Write("Novo Nome do Leitor: ");
                    string novoNome = Console.ReadLine()!;
                    minhaBiblioteca.EditarLeitor(cpfEditar, novoNome);
                    break;
                case "5":
                    Console.Write("CPF do Leitor a excluir: ");
                    string cpfExcluir = Console.ReadLine()!;
                    minhaBiblioteca.ExcluirLeitor(cpfExcluir);
                    break;
                case "6":
                    Console.Write("CPF do Leitor para adicionar livro: ");
                    string cpfLeitorLivro = Console.ReadLine()!;
                    Console.Write("Título do Livro: ");
                    string tituloLivro = Console.ReadLine()!;
                    Console.Write("Autor do Livro: ");
                    string autorLivro = Console.ReadLine()!;
                    Console.Write("ISBN do Livro: ");
                    string isbnLivro = Console.ReadLine()!;
                    minhaBiblioteca.IncluirLivroLeitor(cpfLeitorLivro, tituloLivro, autorLivro, isbnLivro);
                    break;
                case "7":
                    Console.Write("CPF do Leitor dono do livro: ");
                    string cpfDonoLivro = Console.ReadLine()!;
                    Console.Write("ISBN do Livro a editar: ");
                    string isbnAntigo = Console.ReadLine()!;
                    Console.Write("Novo Título do Livro: ");
                    string novoTitulo = Console.ReadLine()!;
                    Console.Write("Novo Autor do Livro: ");
                    string novoAutor = Console.ReadLine()!;
                    Console.Write("Novo ISBN do Livro: ");
                    string novoIsbn = Console.ReadLine()!;
                    minhaBiblioteca.EditarLivroEspecificoLeitor(cpfDonoLivro, isbnAntigo, novoTitulo, novoAutor, novoIsbn);
                    break;
                case "8":
                    Console.Write("CPF do Leitor para remover livro: ");
                    string cpfLeitorRemoverLivro = Console.ReadLine()!;
                    Console.Write("ISBN do Livro a remover: ");
                    string isbnRemover = Console.ReadLine()!;
                    minhaBiblioteca.RemoverLivroLeitor(cpfLeitorRemoverLivro, isbnRemover);
                    break;
                case "9":
                    Console.Write("CPF do Leitor Doador: ");
                    string cpfDoador = Console.ReadLine()!;
                    Console.Write("ISBN do Livro a doar: ");
                    string isbnDoacao = Console.ReadLine()!;
                    Console.Write("CPF do Leitor Recebedor: ");
                    string cpfRecebedor = Console.ReadLine()!;
                    minhaBiblioteca.DoarLivro(cpfDoador, isbnDoacao, cpfRecebedor);
                    break;
                case "10":
                    Console.Write("ISBN do Livro a pesquisar: ");
                    string isbnPesquisa = Console.ReadLine()!;
                    minhaBiblioteca.PesquisarLivro(isbnPesquisa);
                    break;
                case "0":
                    Console.WriteLine("Saindo da aplicação. Até mais!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
