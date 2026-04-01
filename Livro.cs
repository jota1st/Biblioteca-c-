// Alunos: Túlio Thauã Dutra e José Pedro

namespace Biblioteca;

using System;

public class Livro
{
    public string Titulo;
    public string Autor;
    public string Isbn;

    public Livro(string titulo, string autor, string isbn)
    {
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Título: {Titulo}, Autor: {Autor}, ISBN: {Isbn}");
    }
}
