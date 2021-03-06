﻿using System.Data;
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
            string conn = string.Format(@"Data Source={0};Initial Catalog=PostDB;Integrated Security=True", sqlServer);
            using (SqlConnection connection = new SqlConnection(conn))
            {//Пока загружаются только 10т. строк, т.к. иначе ограничение на максимальную строку JSON не даст загрузить данные. Нужна динамическая подгрузка?
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 10000 * FROM MailAddress;", connection))
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
