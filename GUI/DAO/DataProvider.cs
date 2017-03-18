﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; //Ctrl +R + E

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }

        private string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        public DataTable ExcuteQuery(String query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                // code trong using sẽ được giải phóng vùng nhớ sau khi kết thúc khối lệnh trong using kể cả trường hợp khối lệnh bị lỗi vẫn được giải phóng.
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
                return data;
            }
        }

        public int ExcuteNoneQuery(String query , object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(conn)) 
            {
                // code trong using sẽ được giải phóng vùng nhớ sau khi kết thúc khối lệnh trong using kể cả trường hợp khối lệnh bị lỗi vẫn được giải phóng.
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item,parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
                return data;
            }         
        }

        public object ExcuteScalar(String query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                // code trong using sẽ được giải phóng vùng nhớ sau khi kết thúc khối lệnh trong using kể cả trường hợp khối lệnh bị lỗi vẫn được giải phóng.
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
                return data;
            }
        }
    }
}
