// Alunos: Túlio Thauã Dutra e José Pedro

namespace Biblioteca;

using System;
using System.Collections.Generic;

public class Leitor
{
    public string Nome;
    public string Cpf;
    public List<Livro> Livros;

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Livros = new List<Livro>();
    }

    public void AdicionarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void RemoverLivro(string isbn)
    {
        Livro livroParaRemover = null!;
        foreach (var livro in Livros)
        {
            if (livro.Isbn == isbn)
            {
                livroParaRemover = livro;
                break;
            }
        }
        if (livroParaRemover != null)
        {
            Livros.Remove(livroParaRemover);
        }
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Nome: {Nome}, CPF: {Cpf}");
        if (Livros.Count > 0)
        {
            Console.WriteLine("Livros:");
            foreach (var livro in Livros)
            {
                livro.ExibirDetalhes();
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro cadastrado para este leitor.");
        }
    }
}
