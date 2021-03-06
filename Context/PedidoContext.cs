﻿using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source= DESKTOP-LOT7QKV\SQLEXPRESS2; Initial Catalog=Db_Pedidos; user id=sa; password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
