using ProjetoAPI.Context;
using ProjetoAPI.Domains;
using ProjetoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext ctx;
        public ProdutoRepository()
        {
            ctx = new PedidoContext();
        }
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona objeto do tipo produto ao dbset do contexto
                ctx.Produtos.Add(produto);
                //ctx.Set<Produto>().Add(produto);
                //ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Salva as alterações no contexto
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return ctx.Produtos.FirstOrDefault(c => c.Id == id); top 1
                return ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se produto existe
                //Caso não existe gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera sua propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera Produto no contexto
                ctx.Produtos.Update(produtoTemp);
                //Salva o contexto
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //Remove o produto do dbSet
                ctx.Produtos.Remove(produtoTemp);
                //Salva as alteráções do contexto
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO : Incluir erro na tabela de Log
                throw new Exception(ex.Message);
            }
        }
    }
}
