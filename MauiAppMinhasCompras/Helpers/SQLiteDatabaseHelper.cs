﻿using MauiAppMinhasCompras.Models;
using SQLite;
using System.Diagnostics;

namespace MauiAppMinhasCompras.Helpers
{
    public class CategoriaTotal
    {
        public string Categoria { get; set; }
        public decimal Total { get; set; }
    }

    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'" + " OR categoria LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }

        public Task<List<CategoriaTotal>> GetTotalPorCategoria() 
        {
            string sql = @"
                SELECT categoria, SUM(preco * quantidade) AS Total
                FROM Produto
                GROUP BY categoria
            ";

            return _conn.QueryAsync<CategoriaTotal>(sql);
        }
    }
}
