using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using Dapper;

namespace ConsoleApplication5.TestDataFolder
{
    public class ExcelDataAccess
    {

        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static JrnData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [Sheet1$] where key='{0}'", keyName);
                var value = connection.Query<JrnData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

    }
}
