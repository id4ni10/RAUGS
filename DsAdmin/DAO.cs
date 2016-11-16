using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class DAO
    {
        private SqlConnection conn = new SqlConnection("Application Name=RAUGS;Data Source=xxxxx;Initial Catalog=xxxx;User ID=xxx;Password='xxxx';");

        private SqlTransaction transaction;

        public DAO()
        {
            conn.Open();
            transaction = conn.BeginTransaction();
        }

        public DbCommand InicializaProcedure(string procedure)
        {
            DbCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Transaction = transaction;

            return cmd;
        }

        public DataSet ConsultaQueryDataSet(DbCommand comando, string tabela)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)comando);
            da.Fill(ds);
            ds.Tables[0].TableName = tabela;
            return ds;
        }

        public int ExecutaNonQuery(DbCommand commando)
        {
            try
            {
                return commando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void Fechar()
        {
            conn.Close();
        }

        public void Commit()
        {
            if (transaction.Connection != null)
            {
                transaction.Commit();
            }
        }

        public bool IsClosed
        {
            get { return conn.State == ConnectionState.Closed; }
        }

        public void Rollback()
        {
            if (transaction.Connection != null)
            {
                transaction.Rollback();
            }
        }
    }
}
