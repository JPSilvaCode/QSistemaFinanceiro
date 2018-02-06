﻿using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class ModoPagoNeg
    {
        private ModoPagoDao objModoPagoDao;
        

        public ModoPagoNeg()
        {
            objModoPagoDao = new ModoPagoDao();
           
        }

        public void create(ModoPago objModoPago)
        {
            bool verificacao = true;
            
            string nome = objModoPago.Nome;
            if (nome == null)
            {
                objModoPago.Estado = 20;
            }else
            {
                nome = objModoPago.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length < 30;
                if (!verificacao)
                {
                    objModoPago.Estado = 2;
                    return;
                }
            }                      

            string outro = objModoPago.Outros.ToString().Trim();
            verificacao = outro.Length > 0 && outro.Length < 50;
            if (!verificacao)
            {
                objModoPago.Estado = 3;
                return;
            }
         

            ModoPago objModoPagoAux = new ModoPago();
            objModoPagoAux.NumPago = objModoPago.NumPago;
            verificacao = !objModoPagoDao.Find(objModoPagoAux);
            if (!verificacao)
            {
                objModoPago.Estado = 4;
                return;
            }
          


            //tudo correto então salva
            objModoPago.Estado = 99;
            objModoPagoDao.Create(objModoPago);
            return;

        }

        public void update(ModoPago objModoPago)
        {
            bool verificacao = true;
            

            
            string nome = objModoPago.Nome;
            if (nome == null)
            {
                objModoPago.Estado = 20;
            }
            else
            {
                nome = objModoPago.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length < 30;
                if (!verificacao)
                {
                    objModoPago.Estado = 2;
                    return;
                }
            }
           

            string outro = objModoPago.Outros.Trim();
            verificacao = outro.Length > 0 && outro.Length < 50;
            if (!verificacao)
            {
                objModoPago.Estado = 3;
                return;
            }
           

            //Tudo correto
            objModoPago.Estado = 99;
            objModoPagoDao.Update(objModoPago);
            return;

        }

        public void delete(ModoPago objModoPago)
        {
            bool verificacion = true;
            
            //Verificar Se o modo de pag existe
            ModoPago objModoPagoAux = new ModoPago();
            objModoPagoAux.NumPago = objModoPago.NumPago;
            verificacion = objModoPagoDao.Find(objModoPagoAux);
            if (!verificacion)
            {
                objModoPago.Estado = 33;
                return;
            }
            


            // **---- verificar se tem fatura relacionada a ele
            //POR DEPOIS O CÓDIGO AQUI
            

            objModoPago.Estado = 99;
            objModoPagoDao.Delete(objModoPago);
            return;
        }

        public bool find(ModoPago objModoPago)
        {
            return objModoPagoDao.Find(objModoPago);
        }
        public List<ModoPago> findAll()
        {
            return objModoPagoDao.FindAll();
        }

    }
}
