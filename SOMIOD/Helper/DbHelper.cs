﻿using SOMIOD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOMIOD.Helper
{
    public class DbHelper
    {
        public static List<Application> GetApplications()
        {
            var applications = new List<Application>();
            using (var dbcon = new DbConnection())
            {
                var db = dbcon.Open();
                var cmd = new SqlCommand("SELECT * FROM Application", db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    applications.Add(new Application(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2)));
                }
            }
            return applications;
        }
        public static void CreateApplication(string name)
        {
            using (var dbcon = new DbConnection())
            {
                var db = dbcon.Open();
                var cmd = new SqlCommand("INSERT INTO Application (Name, CreationDate) VALUES (@name, @creationDate)", db);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        private class DbConnection : IDisposable
        {
            private string _connStr = Properties.Settings.Default.connStr;
            
            private SqlConnection conn = null;
            public DbConnection()
            {
                conn = new SqlConnection(_connStr);
            }
            public SqlConnection Open()
            {
                conn.Open();
                return conn;
            }

            public void Dispose()
            {
                conn.Close();
            }
        }
    }
}