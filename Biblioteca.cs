// Alunos: Túlio Thauã Dutra e José Pedro

namespace Biblioteca;

using System;
using System.Collections.Generic;

public class Biblioteca
{
    private List<Leitor> leitores;

    public Biblioteca()
    {
        leitores = new List<Leitor>();
    }

    public void CadastrarLeitor(string nome, string cpf)
    {
        bool cpfJaExiste = false;
        foreach (var leitorExistente in leitores)
        {
            if (leitorExistente.Cpf == cpf)
            {
                cpfJaExiste = true;
                break;
            }
        }

        if (cpfJaExiste)
        {
            Console.WriteLine("Erro: Já existe um leitor cadastrado com este CPF.");
            return;
        }
        Leitor novoLeitor = new Leitor(nome, cpf);
        leitores.Add(novoLeitor);
        Console.WriteLine($"Leitor '{nome}' cadastrado com sucesso!");
    }

    public Leitor BuscarLeitorPorCpf(string cpf)
    {
        foreach (var leitor in leitores)
        {
            if (leitor.Cpf == cpf)
            {
                return leitor;
            }
        }
        return null!;
    }

    public void ListarTodosLeitores()
    {
        if (leitores.Count > 0)
        {
            Console.WriteLine("\n--- Leitores Cadastrados ---");
            foreach (var leitor in leitores)
            {
                leitor.ExibirDetalhes();
                Console.WriteLine("----------------------------");
            }
        }
        else
        {
            Console.WriteLine("Nenhum leitor cadastrado.");
        }
    }

    public void EditarLeitor(string cpf, string novoNome)
    {
        Leitor leitor = BuscarLeitorPorCpf(cpf);
        if (leitor != null)
        {
            leitor.Nome = novoNome;
            Console.WriteLine($"Nome do leitor com CPF '{cpf}' atualizado para '{novoNome}'.");
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpf}' não encontrado.");
        }
    }

    public void ExcluirLeitor(string cpf)
    {
        Leitor leitorParaRemover = BuscarLeitorPorCpf(cpf);
        if (leitorParaRemover != null)
        {
            leitores.Remove(leitorParaRemover);
            Console.WriteLine($"Leitor com CPF '{cpf}' removido com sucesso.");
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpf}' não encontrado.");
        }
    }

    public void IncluirLivroLeitor(string cpfLeitor, string titulo, string autor, string isbn)
    {
        Leitor leitor = BuscarLeitorPorCpf(cpfLeitor);
        if (leitor != null)
        {
            Livro novoLivro = new Livro(titulo, autor, isbn);
            leitor.AdicionarLivro(novoLivro);
            Console.WriteLine($"Livro '{titulo}' adicionado ao leitor '{leitor.Nome}'.");
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpfLeitor}' não encontrado.");
        }
    }

    public void EditarLivroEspecificoLeitor(string cpfLeitor, string isbnAntigo, string novoTitulo, string novoAutor, string novoIsbn)
    {
        Leitor leitor = BuscarLeitorPorCpf(cpfLeitor);
        if (leitor != null)
        {
            Livro livroParaEditar = null!;
            foreach (var livro in leitor.Livros)
            {
                if (livro.Isbn == isbnAntigo)
                {
                    livroParaEditar = livro;
                    break;
                }
            }

            if (livroParaEditar != null)
            {
                livroParaEditar.Titulo = novoTitulo;
                livroParaEditar.Autor = novoAutor;
                livroParaEditar.Isbn = novoIsbn;
                Console.WriteLine($"Livro com ISBN '{isbnAntigo}' do leitor '{leitor.Nome}' atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Erro: Livro com ISBN '{isbnAntigo}' não encontrado para o leitor '{leitor.Nome}'.");
            }
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpfLeitor}' não encontrado.");
        }
    }

    public void RemoverLivroLeitor(string cpfLeitor, string isbnLivro)
    {
        Leitor leitor = BuscarLeitorPorCpf(cpfLeitor);
        if (leitor != null)
        {
            int countBefore = leitor.Livros.Count;
            leitor.RemoverLivro(isbnLivro);
            if (leitor.Livros.Count < countBefore)
            {
                Console.WriteLine($"Livro com ISBN '{isbnLivro}' removido do leitor '{leitor.Nome}'.");
            }
            else
            {
                Console.WriteLine($"Erro: Livro com ISBN '{isbnLivro}' não encontrado para o leitor '{leitor.Nome}'.");
            }
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpfLeitor}' não encontrado.");
        }
    }

    public void DoarLivro(string cpfDoador, string isbnLivro, string cpfRecebedor)
    {
        Leitor doador = BuscarLeitorPorCpf(cpfDoador);
        Leitor recebedor = BuscarLeitorPorCpf(cpfRecebedor);

        if (doador == null)
        {
            Console.WriteLine($"Erro: Doador com CPF '{cpfDoador}' não encontrado.");
            return;
        }
        if (recebedor == null)
        {
            Console.WriteLine($"Erro: Recebedor com CPF '{cpfRecebedor}' não encontrado.");
            return;
        }

        Livro livroParaDoar = null!;
        foreach (var livro in doador.Livros)
        {
            if (livro.Isbn == isbnLivro)
            {
                livroParaDoar = livro;
                break;
            }
        }

        if (livroParaDoar != null)
        {
            doador.Livros.Remove(livroParaDoar);
            recebedor.AdicionarLivro(livroParaDoar);
            Console.WriteLine($"Livro '{livroParaDoar.Titulo}' doado de '{doador.Nome}' para '{recebedor.Nome}'.");
        }
        else
        {
            Console.WriteLine($"Erro: Livro com ISBN '{isbnLivro}' não encontrado para o doador '{doador.Nome}'.");
        }
    }

    public void ListarLeitorEspecifico(string cpf)
    {
        Leitor leitor = BuscarLeitorPorCpf(cpf);
        if (leitor != null)
        {
            Console.WriteLine("\n--- Detalhes do Leitor ---");
            leitor.ExibirDetalhes();
            Console.WriteLine("--------------------------");
        }
        else
        {
            Console.WriteLine($"Erro: Leitor com CPF '{cpf}' não encontrado.");
        }
    }

    public void PesquisarLivro(string isbn)
    {
        bool encontrado = false;
        foreach (var leitor in leitores)
        {
            Livro livroEncontrado = null!;
            foreach (var livro in leitor.Livros)
            {
                if (livro.Isbn == isbn)
                {
                    livroEncontrado = livro;
                    break;
                }
            }

            if (livroEncontrado != null)
            {
                Console.WriteLine($"\nLivro encontrado! Pertence ao leitor:");
                leitor.ExibirDetalhes();
                Console.WriteLine("Detalhes do Livro:");
                livroEncontrado.ExibirDetalhes();
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine($"Livro com ISBN '{isbn}' não encontrado em nenhuma biblioteca de leitor.");
        }
    }
}
