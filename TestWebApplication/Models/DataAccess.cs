using System.Data;
using System.Data.SqlClient;

namespace TestWebApplication.Models
{
    public class DataAccess
    {
        /// <summary>
        /// Получает все данные из определённой БД из определённой таблицы.
        /// </summary>
        /// <param name="sqlServer">Сервер, на котором расположена БД</param>
        /// <returns>Все строки из таблицы.</returns>
        public static DataSet GetAllData(string sqlServer)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(@"Data Source=ТЕРМИНАТОР-Д\SQLEXPRESS2012;Initial Catalog=PostDB;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MailAddress;", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }
}