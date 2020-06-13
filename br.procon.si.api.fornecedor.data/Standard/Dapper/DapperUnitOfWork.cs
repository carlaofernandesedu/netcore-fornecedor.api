using System;
using System.Collections.Generic;
using Dapper; 
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.data.Standard.Dapper
{
    
    public class DapperUnitOfWork : IUnitOfWork 
    {
        private readonly string _connectionString;
        private SqlTransaction _transaction { get; set; }
        private SqlConnection _connection { get; set; }
        private bool _disposed;
        private bool _ehtransaction { get; set; }
        private int _commandTimeout;

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public DapperUnitOfWork(IDataSettings configuration)
        {
             _connectionString = configuration.DefaultConnection;
             _commandTimeout = configuration.commandTimeout.HasValue ? configuration.commandTimeout.Value : 300;
        }

        
        public void SetCommandTimeout(int commandTimeout)
        {
            _commandTimeout = commandTimeout;
        }


        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }
        #region "transacoes"
        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public void BeginTransaction()
        {
            _connection = new SqlConnection(this._connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _ehtransaction = true;
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                // _transaction.Rollback();
                throw;
            }
            finally
            {
                _ehtransaction = false;
                if (_transaction != null)
                    _transaction.Dispose();

                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }

                _transaction = null;
                _connection = null;

            }
        }
        #endregion

        #region "Operações Sincronas"
        public IEnumerable<T> List<T>(string query, DynamicParameters parameters) where T : new()
        {
            if (_ehtransaction == false || _transaction == null)
            {
                return GetWithoutTransaction<T>(query, parameters);
            }
            else
            {
                return GetWithTransaction<T>(query, parameters);
            }
        }

        public T Get<T>(string query, DynamicParameters parameters) where T : new()
        {
            return List<T>(query, parameters).FirstOrDefault();
        }

        private IEnumerable<T> GetWithTransaction<T>(string query, DynamicParameters parameters) where T : new()
        {
            return _connection.Query<T>(sql: query, param: parameters , transaction: _transaction, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
        }

        private IEnumerable<T> GetWithoutTransaction<T>(string query, DynamicParameters parameters) where T : new()
        {
            using (IDbConnection conn = new SqlConnection(this._connectionString))
            {
                return conn.Query<T>(sql: query, param: parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }

        public int Execute(string query, DynamicParameters parameters)
        {
            if (_ehtransaction == false || _transaction == null)
            {
                using (IDbConnection conn = new SqlConnection(this._connectionString))
                {
                    return conn.Execute(sql: query, param: parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                return _connection.Execute(sql: query, param: parameters, transaction: _transaction, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion

        #region "Operações Assincronas"

        public async Task<IEnumerable<T>> ListAsync<T>(string query, DynamicParameters parameters) where T : new()
        {
            if (_ehtransaction == false || _transaction == null)
            {
                return await GetWithoutTransactionAsync<T>(query, parameters);
            }
            else
            {
                return await GetWithTransactionAsync<T>(query, parameters);
            }
        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters parameters) where T : new()
        {
            T result = await _connection.QuerySingleAsync<T>(sql: query, param: parameters , transaction: _transaction, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
            return result;
        }

        private async Task<IEnumerable<T>> GetWithTransactionAsync<T>(string query, DynamicParameters parameters) where T : new()
        {
            return await _connection.QueryAsync<T>(sql: query, param: parameters , transaction: _transaction, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
        }

        private async Task<IEnumerable<T>> GetWithoutTransactionAsync<T>(string query, DynamicParameters parameters) where T : new()
        {
            using (IDbConnection conn = new SqlConnection(this._connectionString))
            {
                return await conn.QueryAsync<T>(sql: query, param: parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> ExecuteAsync(string query, DynamicParameters parameters)
        {
            if (_ehtransaction == false || _transaction == null)
            {
                using (IDbConnection conn = new SqlConnection(this._connectionString))
                {
                    return await conn.ExecuteAsync(sql: query, param: parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                return await _connection.ExecuteAsync(sql: query, param: parameters, transaction: _transaction, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            _ehtransaction = false;
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        if (_connection.State == ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DapperUnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}

    
