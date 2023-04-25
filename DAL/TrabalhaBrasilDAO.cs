using CoderCarrer.Domain;
using CoderCarrer.Models;
using Dapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class TrabalhaBrasilDAO
    {
        MySqlConnection conexao;
        public TrabalhaBrasilDAO()
        {
            conexao = ConexaoBD.GetConexao();
            if (conexao.State!= System.Data.ConnectionState.Open)
            {
                conexao.Open();
            }

        }
        public List<Vaga> getVagasDB()
        {

            var queryEmpresa = "select distinct empresa from vagas ";
            List<Vaga> empresas = (List<Vaga>)conexao.Query<Vaga>(queryEmpresa);

            List<Vaga> todos = new List<Vaga>();
            foreach (var item in empresas)
            {
                var select = "select * from vagas where empresa ='"+item.empresa+"'";
                List<Vaga> vagasempresa = (List<Vaga>)conexao.Query<Vaga>(select);
                var ultimaVagaColetada = vagasempresa.OrderByDescending(x => x.id_vaga).LastOrDefault();
                var selectEmpresaUltima = "select * from vagas where empresa ='" + item.empresa + "' and dataColeta='"+ultimaVagaColetada.dataColeta+"'";
                List<Vaga> listaVagaEmpresaAtual = (List<Vaga>)conexao.Query<Vaga>(selectEmpresaUltima);

                todos.AddRange(listaVagaEmpresaAtual);
            }



            return todos;
        }
        public void InserirVagasnoBanco()
        {
            string query = "insert into vaga (data_vaga, descricao_vaga, empresa, salario, titulo, url, dataColeta) values (@data_vaga, @descricao_vaga, @empresa, @salario, @titulo, @url, @dataColeta);"; 
            var inserir = conexao.Execute(query);
            this.conexao.Close();
        }
        

     


    }
}
;