using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Licitacao
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Licitacao()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Licitacao(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(DateTime? dat_licitacao_lic, Int32 cod_cliente_cli, Int32 cod_tipo_licitacao_tli, Int32 num_mes_lic, Decimal num_valor_lic, Boolean? tip_status_lic, Int32 cod_numero_num, ref Int32 cod_licitacao_lic)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirLicitacao");
            _Command.Parameters.AddWithValue("@dat_licitacao_lic", !dat_licitacao_lic.HasValue ? Convert.DBNull : dat_licitacao_lic);
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            _Command.Parameters.AddWithValue("@num_mes_lic", num_mes_lic == 0 ? Convert.DBNull : num_mes_lic);
            _Command.Parameters.AddWithValue("@num_valor_lic", num_valor_lic == 0 ? Convert.DBNull : num_valor_lic);
            _Command.Parameters.AddWithValue("@tip_status_lic", !tip_status_lic.HasValue ? Convert.DBNull : tip_status_lic);
            _Command.Parameters.AddWithValue("@cod_numero_num", cod_numero_num == 0 ? Convert.DBNull : cod_numero_num);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_licitacao_lic", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_licitacao_lic = (Int32)_Command.Parameters["@cod_licitacao_lic"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(DateTime? dat_licitacao_lic, Int32 cod_cliente_cli, Int32 cod_tipo_licitacao_tli, Int32 num_mes_lic, Decimal num_valor_lic, Boolean? tip_status_lic, Int32 cod_numero_num, Int32 cod_licitacao_lic)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarLicitacao");
            _Command.Parameters.AddWithValue("@dat_licitacao_lic", !dat_licitacao_lic.HasValue ? Convert.DBNull : dat_licitacao_lic);
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            _Command.Parameters.AddWithValue("@num_mes_lic", num_mes_lic == 0 ? Convert.DBNull : num_mes_lic);
            _Command.Parameters.AddWithValue("@num_valor_lic", num_valor_lic == 0 ? Convert.DBNull : num_valor_lic);
            _Command.Parameters.AddWithValue("@tip_status_lic", !tip_status_lic.HasValue ? Convert.DBNull : tip_status_lic);
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            _Command.Parameters.AddWithValue("@cod_numero_num", cod_numero_num == 0 ? Convert.DBNull : cod_numero_num);

            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_licitacao_lic)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarLicitacao");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_licitacao"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarLicitacao");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_licitacao"].DefaultView;
        }

        public DataView ListarPorFiltro(DateTime? dat_licitacao_lic, Int32 cod_cliente_cli, Int32 cod_tipo_licitacao_tli, Int32 num_mes_lic, Decimal num_valor_lic, Boolean? tip_status_lic, Int32 cod_licitacao_lic)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarLicitacaoPorFiltro");
            _Command.Parameters.AddWithValue("@dat_licitacao_lic", !dat_licitacao_lic.HasValue ? Convert.DBNull : dat_licitacao_lic);
            _Command.Parameters.AddWithValue("@cod_cliente_cli", cod_cliente_cli == 0 ? Convert.DBNull : cod_cliente_cli);
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            _Command.Parameters.AddWithValue("@num_mes_lic", num_mes_lic == 0 ? Convert.DBNull : num_mes_lic);
            _Command.Parameters.AddWithValue("@num_valor_lic", num_valor_lic == 0 ? Convert.DBNull : num_valor_lic);
            _Command.Parameters.AddWithValue("@tip_status_lic", !tip_status_lic.HasValue ? Convert.DBNull : tip_status_lic);
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_licitacao"].DefaultView;
        }

        public void Excluir(Int32 cod_licitacao_lic)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirLicitacao");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}