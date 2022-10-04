using CreditSuisse.Data.Context;
using CreditSuisse.Data.Interfaces.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CreditSuisseContext _context;

        public RepositoryBase(CreditSuisseContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var type = typeof(T);
                var tabela = GetTableName(type);

                using var tbl = _context.SqlConnection();

                var query = $@"SELECT * FROM {tabela}";

                var result = await tbl.QueryAsync<T>(query);

                return result;

                // TODO: Após criar o contexto, descomentar
                //var collection = _context.GetDataBase().GetCollection<T>(tabela);

                //return await collection.Find(m => true).ToListAsync();
            }
            catch (Exception ex)
            {
                var t = ex;
            }

            return null;
        }

        public async Task<T> GetById(int id)
        {
            var type = typeof(T);
            var tabela = GetTableName(type);

            using var tbl = _context.SqlConnection();

            var query = $@"SELECT * FROM {tabela} WHERE ID = {id}";

            var result = await tbl.QueryAsync<T>(query);

            return result?.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetByName(string name)
        {
            var type = typeof(T);
            var tabela = GetTableName(type);
            
            //var collection = _context.GetDataBase().GetCollection<T>(tabela);

            //var nomeCampo = $"Nome{type.Name}";

            //var filter = Builders<T>.Filter.Regex(nomeCampo, BsonRegularExpression.Create(new Regex(name, RegexOptions.IgnoreCase)));

            //return await collection.Find(filter).ToListAsync();
            return null;
        }

        #region Utils
        private static string GetTableName(Type type)
        {
            dynamic tableAttr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
            var name = string.Empty;

            if (tableAttr != null)
                name = tableAttr.Name;

            return name;
        }
        #endregion
    }
}
