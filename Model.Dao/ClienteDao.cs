using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClienteDao : Obrigatorio<Cliente>
    {
        private ConexaoDB conexaoDB;
        private SqlCommand sqlCommand;

        public ClienteDao()
        {
            conexaoDB = ConexaoDB.SaberEstado();
        }

        public void Create(Cliente objCliente)
        {
            string create = "insert into cliente(nome, endereco, telefone, cpf) VALUES ('" + objCliente.Nome + "', '" + objCliente.Endereco + "' , '" + objCliente.Telefone + "', '" + objCliente.CPF + "' )";
            try
            {
                sqlCommand = new SqlCommand(create, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }
        }

        public void Delete(Cliente objCliente)
        {
            string delete = "delete from cliente where idCliente = '" + objCliente.IdCliente + "' ";
            try
            {
                sqlCommand = new SqlCommand(delete, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }
        }

        public bool Find(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select * from cliente where idCliente  = '" + objCliente.IdCliente + "' ";
            try
            {
                sqlCommand = new SqlCommand(find, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();
                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }

            return temRegistros;
        }

        public List<Cliente> FindAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select * from cliente order by nome";

            try
            {
                sqlCommand = new SqlCommand(findAll, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente
                    {
                        IdCliente = Convert.ToInt64(reader[0].ToString()),
                        Nome = reader[1].ToString(),
                        Endereco = reader[2].ToString(),
                        Telefone = reader[3].ToString(),
                        CPF = reader[4].ToString()
                    };
                    listaClientes.Add(objCliente);
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }

            return listaClientes;
        }

        public void Update(Cliente objCliente)
        {
            string update = "update cliente set nome='" + objCliente.Nome + "', endereco ='" + objCliente.Endereco + "', telefone='" + objCliente.Telefone + "', cpf='" + objCliente.CPF + "' where idCliente='" + objCliente.IdCliente + "'";
            try
            {
                sqlCommand = new SqlCommand(update, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCliente.Estado = 1;

            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }
        }

        public bool FindClientePorcpf(Cliente objCliente)
        {
            bool temRegistros;
            string find = "select*from cliente where cpf='" + objCliente.CPF + "'";
            try
            {
                sqlCommand = new SqlCommand(find, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();

                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }
            return temRegistros;
        }

        public List<Cliente> FindAllCliente(Cliente objCLiente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select* from cliente where nome like '%" + objCLiente.Nome + "%' or cpf like '%" + objCLiente.CPF + "%' or idCliente like '%" + objCLiente.IdCliente + "%' ";
            try
            {

                sqlCommand = new SqlCommand(findAll, conexaoDB.GetSqlConnection());
                conexaoDB.GetSqlConnection().Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();

                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.CPF = reader[4].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexaoDB.GetSqlConnection().Close();
                conexaoDB.CloseDB();
            }

            return listaClientes;

        }
    }
}
