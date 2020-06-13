﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace marathon
{

    ///---- ПОДКЛЮЧЕНИЕ БД ---- \\\
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=marathonskills2016");// подключение к серверу 
        public void openConnection()// функция, открывающая соединение
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()// функция, закрывающая соединение
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()// функция, возвращающая соединение
        {
            return connection;
        }

    }
}
