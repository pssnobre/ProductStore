using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductStore.Repository
{
    public class ProdutoRepository : AbstractRepository<Produto, int>
    {
        public override void Delete(Produto entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE tblProduto Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE tblProduto Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override List<Produto> GetAll()
        {
            //string sql = "Select Id, Nome, Descricao, Ativo, Perecivel, CategoriaID FROM tblProduto ORDER BY Nome";
            string sql =
                "SELECT t.Id, t.Nome, t.Descricao, t.Ativo, t.Perecivel, t.CategoriaID, c.Id, c.Nome  as CategoriaNome, c.Descricao, c.Ativo FROM tblProduto as t INNER JOIN tblCategoriaProduto as c ON t.CategoriaID = c.id; ";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Produto> list = new List<Produto>();
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Produto();
                            p.Id = (int)reader["Id"];
                            p.Nome = reader["Nome"].ToString();
                            p.Descricao = reader["Descricao"].ToString();
                            p.Ativo = bool.Parse(reader["Ativo"].ToString());
                            p.Perecivel = bool.Parse(reader["Perecivel"].ToString());
                            p.CategoriaID = (int)reader["CategoriaID"];
                            p.CategoriaNome = reader["CategoriaNome"].ToString();
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        public override Produto GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Descricao, Ativo, Perecivel, CategoriaID FROM tblProduto WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Produto();
                                p.Id = (int)reader["Id"];
                                p.Nome = reader["Nome"].ToString();
                                p.Descricao = reader["Descricao"].ToString();
                                p.Ativo = bool.Parse(reader["Ativo"].ToString());
                                p.Perecivel = bool.Parse(reader["Perecivel"].ToString());
                                p.CategoriaID = (int)reader["CategoriaID"];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        public override void Save(Produto entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO tblProduto (Nome, Descricao, Ativo, Perecivel, CategoriaID) VALUES (@Nome, @Descricao, @Ativo, @Perecivel, @CategoriaID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@Ativo", entity.Ativo);
                cmd.Parameters.AddWithValue("@Perecivel", entity.Perecivel);
                cmd.Parameters.AddWithValue("@CategoriaID", entity.CategoriaID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(Produto entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE tblProduto SET Nome=@Nome, Descricao=@Descricao, Ativo=@Ativo, Perecivel=@Perecivel, CategoriaID=@CategoriaID Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@Ativo", entity.Ativo);
                cmd.Parameters.AddWithValue("@Perecivel", entity.Perecivel);
                cmd.Parameters.AddWithValue("@CategoriaID", entity.CategoriaID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}