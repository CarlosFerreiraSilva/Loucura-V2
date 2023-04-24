using CoderCarrer.Domain;
using CoderCarrer.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class TrabalhaBrasilDAO
    {
        SqlConnection _conexao;
        public TrabalhaBrasilDAO()
        {
            _conexao = ConexaoBD.getConexao();

        }
        public List<Vaga> getVagasDB()
        {

            var queryEmpresa = "select distinct empresa from vagas ";
            List<Vaga> empresas = (List<Vaga>)_conexao.Query<Vaga>(queryEmpresa);

            List<Vaga> todos = new List<Vaga>();
            foreach (var item in empresas)
            {
                var select = "select * from vagas where empresa ='"+item.empresa+"'";
                List<Vaga> vagasempresa = (List<Vaga>)_conexao.Query<Vaga>(select);
                var ultimaVagaColetada = vagasempresa.OrderByDescending(x => x.id_vaga).LastOrDefault();
                var selectEmpresaUltima = "select * from vagas where empresa ='" + item.empresa + "' and dataColeta='"+ultimaVagaColetada.dataColeta+"'";
                List<Vaga> listaVagaEmpresaAtual = (List<Vaga>)_conexao.Query<Vaga>(selectEmpresaUltima);

                todos.AddRange(listaVagaEmpresaAtual);
            }



            return todos;
        }

     


    }
}
;