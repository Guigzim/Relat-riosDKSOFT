using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace RelatóriosDKSOFT
{
    public class DbExecuter
    {
        
        public DataTable getData(string query)
        {
            using (DbConnection con = new DbConnection())
            {

                FbCommand command = new FbCommand(query, con.conexao);
                DataTable tableLoad = new DataTable();
                tableLoad.Load(command.ExecuteReader());
                return tableLoad;
            }

        }
    }
}
