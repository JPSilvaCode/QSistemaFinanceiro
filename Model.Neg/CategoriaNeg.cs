﻿using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class CategoriaNeg
    {
        private CategoriaDao objCategoriaDao;
        private ProdutoDao objProdutoDao;

        public CategoriaNeg()
        {
            objCategoriaDao = new Dao.CategoriaDao();
            objProdutoDao = new ProdutoDao();
        }

        public void Create(Categoria objCategoria)
        {
            bool verificacao = true;


            string codigo = objCategoria.IdCategoria;
            if (string.IsNullOrEmpty(codigo))
            {
                objCategoria.Estado = 10;
                return;
            }
            else
            {
                codigo = objCategoria.IdCategoria.Trim();
                verificacao = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificacao)
                {
                    objCategoria.Estado = 1;
                    return;
                }
            }


            string nome = objCategoria.Nome;
            if (nome == null)
            {
                objCategoria.Estado = 20;
                return;
            }
            else
            {
                nome = objCategoria.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 30;
                if (!verificacao)
                {
                    objCategoria.Estado = 2;
                    return;
                }
            }


            string descricao = objCategoria.Descricao;
            if (descricao == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descricao = objCategoria.Descricao.Trim();
                verificacao = descricao.Length > 0 && descricao.Length <= 50;
                if (!verificacao)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }


            Categoria objCategoriaAux = new Categoria();
            objCategoriaAux.IdCategoria = objCategoria.IdCategoria;
            verificacao = !objCategoriaDao.Find(objCategoriaAux);
            if (!verificacao)
            {
                objCategoria.Estado = 4;
                return;
            }

            //se tudo tiver ok ele salva
            objCategoria.Estado = 99;
            objCategoriaDao.Create(objCategoria);
            return;

        }

        public void Update(Categoria objCategoria)
        {
            bool verificacion = true;


            string nome = objCategoria.Nome;
            if (nome == null)
            {
                objCategoria.Estado = 20;
                return;
            }
            else
            {
                nome = objCategoria.Nome.Trim();
                verificacion = nome.Length > 0 && nome.Length <= 30;
                if (!verificacion)
                {
                    objCategoria.Estado = 2;
                    return;
                }
            }


            string descricao = objCategoria.Descricao;
            if (descricao == null)
            {
                objCategoria.Estado = 30;
                return;
            }
            else
            {
                descricao = objCategoria.Descricao.Trim();
                verificacion = descricao.Length > 0 && descricao.Length <= 50;
                if (!verificacion)
                {
                    objCategoria.Estado = 3;
                    return;
                }
            }


            //se tudo tiver certo ele atualiza
            objCategoria.Estado = 99;
            objCategoriaDao.Update(objCategoria);
            return;
        }


        public void Delete(Categoria objCategoria)
        {
            bool verificacao = true;


            Categoria objCategoriaAux = new Categoria();
            objCategoriaAux.IdCategoria = objCategoria.IdCategoria;
            verificacao = objCategoriaDao.Find(objCategoriaAux);
            if (!verificacao)
            {
                objCategoria.Estado = 33;
                return;
            }

            //verificação depois se tem produto associado
            Produto objProduto = new Produto();
            objProduto.Categoria = objCategoria.IdCategoria;
            verificacao = !objProdutoDao.FindProdutoPorCategoriaId(objProduto);
            if (!verificacao)
            {
                objCategoria.Estado = 34;
                return;
            }

            //se tudo tiver ok delete
            objCategoria.Estado = 99;
            objCategoriaDao.Delete(objCategoria);
            return;


        }

        public bool Find(Categoria objCategoria)
        {
            return objCategoriaDao.Find(objCategoria);
        }

        public List<Categoria> FindAll()
        {
            return objCategoriaDao.FindAll();
        }
    }
}
