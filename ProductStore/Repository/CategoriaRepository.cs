using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProductStore.Models;

namespace ProductStore.Repository
{
    public class CategoriaRepository : AbstractRepository<Categoria, int>
    {
        public override void Delete(Categoria entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE tblCategoriaProduto Where Id=@Id";
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
                string sql = "DELETE tblCategoriaProduto Where Id=@Id";
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

        public override List<Categoria> GetAll()
        {
            string sql = "Select Id, Nome, Descricao, Ativo FROM tblCategoriaProduto ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Categoria> list = new List<Categoria>();
                Categoria p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Categoria();
                            p.Id = (int)reader["Id"];
                            p.Nome = reader["Nome"].ToString();
                            p.Descricao = reader["Descricao"].ToString();
                            p.Ativo = bool.Parse(reader["Ativo"].ToString());
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

        public override Categoria GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Descricao, Ativo FROM tblCategoriaProduto WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Categoria p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Categoria();
                                p.Id = (int)reader["Id"];
                                p.Nome = reader["Nome"].ToString();
                                p.Descricao = reader["Descricao"].ToString();
                                p.Ativo = bool.Parse(reader["Ativo"].ToString());
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

        public override void Save(Categoria entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO tblCategoriaProduto (Nome, Descricao, Ativo, Perecivel, CategoriaID) VALUES (@Nome, @Descricao, @Ativo, @Perecivel, @CategoriaID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@Ativo", entity.Ativo);
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

        public override void Update(Categoria entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE tblCategoriaProduto SET Nome=@Nome, Descricao=@Descricao, Ativo=@Ativo Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
                cmd.Parameters.AddWithValue("@Ativo", entity.Ativo);
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