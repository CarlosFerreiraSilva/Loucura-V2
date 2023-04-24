using System.Data.SqlClient;

namespace CoderCarrer.DAL
{
    public class ConexaoBD
    {
        private static SqlConnection Banco;
        public static SqlConnection getConexao()
        {
            if (Banco == null)
            {
                Banco = new SqlConnection(@"Server=.\SENAI2022; Database=ListasDB; User id =sa; Password=senai.123;");
            }

            return Banco;
        }
    }
}
