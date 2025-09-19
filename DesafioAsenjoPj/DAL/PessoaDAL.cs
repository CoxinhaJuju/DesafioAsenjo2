using DesafioAsenjoPj.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioAsenjoPj.DAL
{
    internal class PessoaDAL
    {
        private static string strConexao =
@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + Application.StartupPath + @"\CrudPessoas.accdb;";
       
       
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            string caminhoBanco = Application.StartupPath + @"\CrudPessoas.accdb";
            try { conn.Open(); }
            catch (Exception) { Erro.setMsg("Erro ao conectar ao banco!  /  " + caminhoBanco); }
            
        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void inseriUmaPessoa(Pessoa p)
        {
            string aux = "INSERT INTO Pessoa(nome, telefone, email, cep, estado, cidade, bairro, rua, numero, complemento) " +
                         "VALUES (@nome, @telefone, @email, @cep, @estado, @cidade, @bairro, @rua, @numero, @complemento)";
            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@nome", p.getNome());
            strSQL.Parameters.AddWithValue("@telefone", p.getTelefone());
            strSQL.Parameters.AddWithValue("@email", p.getEmail());
            strSQL.Parameters.AddWithValue("@cep", p.getCep());
            strSQL.Parameters.AddWithValue("@estado", p.getEstado());
            strSQL.Parameters.AddWithValue("@cidade", p.getCidade());
            strSQL.Parameters.AddWithValue("@bairro", p.getBairro());
            strSQL.Parameters.AddWithValue("@rua", p.getRua());
            strSQL.Parameters.AddWithValue("@numero", p.getNumero());
            strSQL.Parameters.AddWithValue("@complemento", p.getComplemento());

            try { strSQL.ExecuteNonQuery(); }
            catch (Exception) { Erro.setMsg("Erro ao inserir pessoa!"); }
        }

        public static void excluiUmaPessoa(Pessoa p)
        {
            string aux = "DELETE FROM Pessoa WHERE id = @id";
            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@id", p.getId());
            strSQL.ExecuteNonQuery();
        }

        public static void atualizaUmaPessoa(Pessoa p)
        {
            string aux = @"UPDATE Pessoa SET nome=@nome, telefone=@telefone, email=@email, cep=@cep,
                           estado=@estado, cidade=@cidade, bairro=@bairro, rua=@rua, numero=@numero, complemento=@complemento
                           WHERE id=@id";
            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@id", p.getId());
            strSQL.Parameters.AddWithValue("@nome", p.getNome());
            strSQL.Parameters.AddWithValue("@telefone", p.getTelefone());
            strSQL.Parameters.AddWithValue("@email", p.getEmail());
            strSQL.Parameters.AddWithValue("@cep", p.getCep());
            strSQL.Parameters.AddWithValue("@estado", p.getEstado());
            strSQL.Parameters.AddWithValue("@cidade", p.getCidade());
            strSQL.Parameters.AddWithValue("@bairro", p.getBairro());
            strSQL.Parameters.AddWithValue("@rua", p.getRua());
            strSQL.Parameters.AddWithValue("@numero", p.getNumero());
            strSQL.Parameters.AddWithValue("@complemento", p.getComplemento());
            strSQL.ExecuteNonQuery();
        }

        public static void consultaUmaPessoa(Pessoa p)
        {
            string aux = "SELECT * FROM Pessoa WHERE id=@id";
            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@id", p.getId());
            result = strSQL.ExecuteReader();

            if (result.Read())
            {
                p.setNome(result.GetString(1));
                p.setTelefone(result.GetString(2));
                p.setEmail(result.GetString(3));
                p.setCep(result.GetString(4));
                p.setEstado(result.GetString(5));
                p.setCidade(result.GetString(6));
                p.setBairro(result.GetString(7));
                p.setRua(result.GetString(8));
                p.setNumero(result.GetString(9));
                p.setComplemento(result.GetString(10));
            }
            else
            {
                Erro.setMsg("Pessoa não encontrada!");
            }
            result.Close();
        }
    }
}
