﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class ModoPagoDao:Obrigatorio<ModoPago>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ModoPagoDao()
        {
            objConexaoDB = ConexaoDB.SaberEstado();
        }
        public void Create(ModoPago objModoPago)
        {
            string create = "insert into modoPag values('" + objModoPago.Nome + "','" + objModoPago.Outros + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objModoPago.Estado = 1000; 
            }
            finally
            {
                objConexaoDB.GetSqlConnection().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void Delete(ModoPago objModoPago)
        {
            string delete = "delete from modoPag where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexaoDB.GetSqlConnection().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool Find(ModoPago objModoPago)
        {
            bool temRegistros;
            string find = "select*from modoPag where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objModoPago.Nome = reader[1].ToString();
                    objModoPago.Outros = reader[2].ToString();

                    objModoPago.Estado = 99;
                }
                else
                {
                    objModoPago.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetSqlConnection().Close();
                objConexaoDB.CloseDB();
            }

            return temRegistros;
        }

        public List<ModoPago> FindAll()
        {
            List<ModoPago> listaModoPagos = new List<ModoPago>();
            string find = "select*from modoPag";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ModoPago objModoPago = new ModoPago();
                    objModoPago.NumPago = Convert.ToInt32(reader[0].ToString());
                    objModoPago.Nome = reader[1].ToString();
                    objModoPago.Outros = reader[2].ToString();

                    listaModoPagos.Add(objModoPago);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetSqlConnection().Close();
                objConexaoDB.CloseDB();
            }

            return listaModoPagos;
        }

        public void Update(ModoPago objModoPago)
        {
            string update = "update modoPag set  nome='" + objModoPago.Nome + "',outrosDetalhes='" + objModoPago.Outros + "' where numPag='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexaoDB.GetSqlConnection().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
