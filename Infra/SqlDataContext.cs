using ApiMaisEventos.Models;
using APIMaisEventos.Inerfaces.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection;
using System.Threading.Tasks;

namespace APIMaisEventos.Infra
{
    public class SqlDataContext : ISqlDataContext
    {
        private string connectionString;
        private readonly IAppSettingsManager _appSettingsManager;
        public SqlDataContext(IAppSettingsManager appSettingsManager) 
        {
            _appSettingsManager = appSettingsManager;
            connectionString = _appSettingsManager.GetValue("DBConnection");
        }

        public async Task<bool> NonQueryToSql(string proc, Dictionary<string, object> Parameters = null)
        {
            //Abrir conexão no banco
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                // Criamos o comando de execução no banco
                using (SqlCommand cmd = new SqlCommand(proc, conexao))
                {

                    cmd.Parameters.Clear();
                    foreach (KeyValuePair<string, object> kvp in Parameters)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    int linhasafetadas = cmd.ExecuteNonQuery();
                    if (linhasafetadas == 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public async Task<IEnumerable<T>> SelectListFromSql <T>(string ProcedureName, Dictionary<string, object> Parameters = null) 
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();


                using (SqlCommand cmd = new SqlCommand(ProcedureName, conexao))
                {

                    if (Parameters != null)
                    {
                        cmd.Parameters.Clear();
                        foreach (KeyValuePair<string, object> kvp in Parameters)
                        {
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<T> result;
                    //ler todos os itens da consulta
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        result = DataReaderMapToList<T>(reader);
                    }

                    if (result != null)
                        return result;

                    else
                        return default;

                }
            }
        }

        public async Task<T> SelectSingleOrDefaultFromSql<T>(string ProcedureName, Dictionary<string, object> Parameters = null)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

            

                using (SqlCommand cmd = new SqlCommand(ProcedureName, conexao))
                {

                    if (Parameters != null)
                    {
                        cmd.Parameters.Clear();
                        foreach (KeyValuePair<string, object> kvp in Parameters)
                        {
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }
                    T result;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ler todos os itens da consulta
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            result = DataReaderMapSingle<T>(reader);
                        }



                        if (result != null)
                            return result;

                        else
                            return default;
                    }
                    catch (Exception ex)
                    { }

                }
            }
            return default;
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static T DataReaderMapSingle<T>(IDataReader dr)
        {
            T obj = default(T);
            dr.Read();
            obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            return obj;
        }

    }
}
