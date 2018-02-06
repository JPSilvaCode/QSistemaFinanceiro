using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class ClienteNeg
    {
        private ClienteDao objClienteDao;

        public ClienteNeg()
        {
            objClienteDao = new ClienteDao();

        }

        public void Create(Cliente objCliente)
        {
            bool verificacao = true;

            //inicio da validação do Nome
            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }
            }
            //end validar nome

            //inicio da validação do cpf
            string cpf = objCliente.CPF;
            if (cpf == null)
            {
                objCliente.Estado = 50;
                return;
            }
            else
            {
                cpf = objCliente.CPF.Trim();
                verificacao = cpf.Length <= 12 && cpf.Length > 10;
                if (!verificacao)
                {
                    objCliente.Estado = 250;
                    return;
                }
            }
            //fim da validãção do cpf

            //begin validar endereco retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 15 && telefone.Length > 7;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone

            //begin verificar duplicidade retorna estado=8
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = !objClienteDao.Find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 8;
                return;
            }
            //end validar duplicidade

            //begin verificar duplicidade cpf retorna estado=8
            Cliente objCliente1 = new Cliente();
            objCliente1.CPF = objCliente.CPF;
            verificacao = !objClienteDao.FindClientePorcpf(objCliente1);
            if (!verificacao)
            {
                objCliente.Estado = 9;
                return;
            }


            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.Create(objCliente);
            return;
        }      

        public void Update(Cliente objCliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objCliente.IdCliente.ToString();
            long id = 0;
            if (codigo == null)
            {
                objCliente.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.IdCliente);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999;


                    if (!verificacao)
                    {
                        objCliente.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objCliente.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar nome retorna estado=2
            string nome = objCliente.Nome;
            if (nome == null)
            {
                objCliente.Estado = 20;
                return;
            }
            else
            {
                nome = objCliente.Nome.Trim();
                verificacao = nome.Length <= 30 && nome.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 2;
                    return;
                }

            }
            //end validar nome




            //inicio da validação do cpf
            string cpf = objCliente.CPF;
            if (cpf == null)
            {
                objCliente.Estado = 50;
                return;
            }
            else
            {
                cpf = objCliente.CPF.Trim();
                verificacao = cpf.Length <= 12 && cpf.Length > 10;
                if (!verificacao)
                {
                    objCliente.Estado = 250;
                    return;
                }

            }

            //fim da validãção do cpf



            //begin validar endereço retorna estado=6
            string endereco = objCliente.Endereco;
            if (endereco == null)
            {
                objCliente.Estado = 60;
                return;
            }
            else
            {
                endereco = objCliente.Endereco.Trim();
                verificacao = endereco.Length <= 50 && endereco.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 6;
                    return;
                }

            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telefone = objCliente.Telefone;
            if (telefone == null)
            {
                objCliente.Estado = 70;
                return;
            }
            else
            {
                telefone = objCliente.Telefone.Trim();
                verificacao = telefone.Length <= 30 && telefone.Length > 0;
                if (!verificacao)
                {
                    objCliente.Estado = 7;
                    return;
                }

            }
            //end validar telefone



            //se nao tem erro
            objCliente.Estado = 99;
            objClienteDao.Update(objCliente);
            return;
        }

        public void Delete(Cliente objCliente)
        {
            bool verificacao = true;
            //verificando se existe
            Cliente objClienteAux = new Cliente();
            objClienteAux.IdCliente = objCliente.IdCliente;
            verificacao = objClienteDao.Find(objClienteAux);
            if (!verificacao)
            {
                objCliente.Estado = 33;
                return;
            }


            objCliente.Estado = 99;
            objClienteDao.Delete(objCliente);
            return;
        }

        public bool Find(Cliente objCliente)
        {
            return objClienteDao.Find(objCliente);
        }

        public List<Cliente> FindAll()
        {
            return objClienteDao.FindAll();
        }

        public List<Cliente> FindAllClientes(Cliente objCLiente)
        {
            return objClienteDao.FindAllCliente(objCLiente);
        }
    }
}
