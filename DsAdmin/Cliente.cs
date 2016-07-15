using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Cliente
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Cliente()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Cliente(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(String des_cliente_cli, ref Int32 cod_cliente_cli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirCliente");
            _Command.Parameters.AddWithValue("@des_cliente_cli", des_cliente_cli == null ? Convert.DBNull : des_cliente_cli);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_cliente_cli", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_cliente_cli = (Int32)_Command.Parameters["@cod_cliente_cli"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(String des_cliente_cli, Int32 cod_cliente_cli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarCliente");
            _Command.Parameters.AddWithValue("@des_cliente_cli", des_cliente_cli == null ? Convert.DBNull : des_cliente_cli);
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_cliente_cli)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarCliente");
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_cliente");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_cliente"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarCliente");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_cliente");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_cliente"].DefaultView;
        }

        public DataView ListarPorFiltro(String des_cliente_cli, Int32 cod_cliente_cli)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarClientePorFiltro");
            _Command.Parameters.AddWithValue("@des_cliente_cli", des_cliente_cli == null ? Convert.DBNull : des_cliente_cli);
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_cliente");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_cliente"].DefaultView;
        }

        public void Excluir(Int32 cod_cliente_cli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirCliente");
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}