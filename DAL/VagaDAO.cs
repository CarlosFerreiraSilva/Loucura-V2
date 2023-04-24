using CoderCarrer.Domain;
using CoderCarrer.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class VagaDAO
    {
        SqlConnection _conexao;
        public VagaDAO()
        {
            _conexao = ConexaoBD.getConexao();

        }

        public bool sincronizarInserindoVagas(IExtratorVaga pvagas) {

            foreach (var item in pvagas.getVagas())
            {
                string sql = "insert  (NOME,SOBRENOME) values (@NOME,@SOBRENOME)";
                int qtdInserida = _conexao.Execute(sql, item);

            }

          
          
            return false;
        
        }





    }
}