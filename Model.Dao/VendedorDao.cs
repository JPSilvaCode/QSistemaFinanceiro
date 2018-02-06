﻿using System;
using System.Collections.Generic;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class VendedorDao : Obrigatorio<Vendedor>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public VendedorDao()
        {
            objConexaoDB = ConexaoDB.SaberEstado();
        }
        public void Create(Vendedor objVendedor)
        {
            string create = "insert into vendedor values('" + objVendedor.IdVendedor + "','" + objVendedor.Nome + "','" + objVendedor.Cpf + "','" + objVendedor.Telefone + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
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
        }

        public void Delete(Vendedor objVendedor)
        {
            string delete = "delete from vendedor where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
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
        }

        public bool Find(Vendedor objVendedor)
        {
            bool temRegistros;
            string find = "select*from vendedor where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objVendedor.Nome = reader[1].ToString();
                    objVendedor.Cpf = reader[2].ToString();
                    objVendedor.Telefone = reader[3].ToString();
                    objVendedor.Estado = 99;
                }
                else
                {
                    objVendedor.Estado = 1;
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

        public List<Vendedor> FindAll()
        {
            List<Vendedor> listaVendedores = new List<Vendedor>();
            string find = "select*from vendedor order by nome asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Vendedor objVendedor = new Vendedor();
                    objVendedor.IdVendedor = reader[0].ToString();
                    objVendedor.Nome = reader[1].ToString();
                    objVendedor.Cpf = reader[2].ToString();
                    objVendedor.Telefone = reader[3].ToString();
                    listaVendedores.Add(objVendedor);
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

            return listaVendedores;
        }

        public void Update(Vendedor objVendedor)
        {
            string update = "update vendedor set  nome='" + objVendedor.Nome + "',cpf='" + objVendedor.Cpf + "',telefone='" + objVendedor.Telefone + "' where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.GetSqlConnection());
                objConexaoDB.GetSqlConnection().Open();
                comando.ExecuteNonQuery();
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
        }
    }
}
