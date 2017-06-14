using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;

namespace RelatóriosDKSOFT
{
    public class DbConnection : IDisposable
    {
        public FbConnection conexao;
        public DbConnection()
        {
            conexao = new FbConnection(ConfigurationManager.ConnectionStrings["DKSOFT"].ToString());
            try
            {
                conexao.Open();
            }
            catch (Exception)
            {

                throw new Exception("Erro de conexão com o banco de dados. Verifique sua conexão de rede.");
            }
        }
        public void Dispose()
        {
            conexao.Close();

        }
       

    }
}
