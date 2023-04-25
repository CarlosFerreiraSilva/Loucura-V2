using CoderCarrer.Domain;
using CoderCarrer.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class VagaDAO
    {
        MySqlConnection conexao;
        public VagaDAO()
        {
            conexao = ConexaoBD.GetConexao();

        }

        public bool sincronizarInserindoVagas(IExtratorVaga pvagas) {


            List<Vaga> lista = pvagas.getVagas();
            foreach (var item in lista)
            {
                string Mysql = "insert into vaga (data_vaga, descricao_vaga, empresa, salario, titulo, url, dataColeta) values (@data_vaga, @descricao_vaga, @empresa, @salario, @titulo, @url, @dataColeta);";
                int qtdInserida = conexao.Execute(Mysql, item);

            }
            return false;
        }





    }
}