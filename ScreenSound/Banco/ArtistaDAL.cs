using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{

    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();

        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "SELECT * FROM Artistas WHERE Ativo = 1";

        SqlCommand command = new SqlCommand(sql, connection);

        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            bool ativoArtista = Convert.ToBoolean(dataReader["Ativo"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);

            Artista artista = new Artista(nomeArtista, bioArtista) { Id = idArtista, Ativo = ativoArtista };

            lista.Add(artista);

        }

        return lista;

    }

    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio, Ativo)" +
            "VALUES (@nome, @perfilPadrao, @bio, @ativo)";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@ativo", true);

        int retorno = command.ExecuteNonQuery();
        if (retorno > 0) Console.WriteLine($"Linha afetadas: {retorno}");

    }

    public void Deletar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = $"UPDATE Artistas SET Ativo = 0 WHERE Id = @id";
        
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        if (retorno > 0) Console.WriteLine($"Linha afetadas: {retorno}");

    }

    public void Atualizar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";

        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        if (retorno > 0) Console.WriteLine($"Linha afetadas: {retorno}");

    }


}

