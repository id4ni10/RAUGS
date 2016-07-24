using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Contrato
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Contrato()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Contrato(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(DateTime? dat_inicio_ctr, DateTime? dat_fim_ctr, Decimal num_valor_ctr, Int32 cod_tipo_contrato_tcr, Int32 cod_licitacao_lic, ref Int32 cod_contrato_ctr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirContrato");
            _Command.Parameters.AddWithValue("@dat_inicio_ctr", !dat_inicio_ctr.HasValue ? Convert.DBNull : dat_inicio_ctr);
            _Command.Parameters.AddWithValue("@dat_fim_ctr", !dat_fim_ctr.HasValue ? Convert.DBNull : dat_fim_ctr);
            _Command.Parameters.AddWithValue("@num_valor_ctr", num_valor_ctr == 0 ? Convert.DBNull : num_valor_ctr);
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_contrato_ctr", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_contrato_ctr = (Int32)_Command.Parameters["@cod_contrato_ctr"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(DateTime? dat_inicio_ctr, DateTime? dat_fim_ctr, Decimal num_valor_ctr, Int32 cod_tipo_contrato_tcr, Int32 cod_contrato_ctr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarContrato");
            _Command.Parameters.AddWithValue("@dat_inicio_ctr", !dat_inicio_ctr.HasValue ? Convert.DBNull : dat_inicio_ctr);
            _Command.Parameters.AddWithValue("@dat_fim_ctr", !dat_fim_ctr.HasValue ? Convert.DBNull : dat_fim_ctr);
            _Command.Parameters.AddWithValue("@num_valor_ctr", num_valor_ctr == 0 ? Convert.DBNull : num_valor_ctr);
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            _Command.Parameters.AddWithValue("@cod_contrato_ctr", cod_contrato_ctr == 0 ? Convert.DBNull : cod_contrato_ctr);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_contrato_ctr)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarContrato");
            _Command.Parameters.AddWithValue("@cod_contrato_ctr", cod_contrato_ctr == 0 ? Convert.DBNull : cod_contrato_ctr);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contrato"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarContrato");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contrato"].DefaultView;
        }

        public DataView ListarPorLicitacao(Int32 cod_licitacao_lic)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarContratoPorLicitacao");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contrato"].DefaultView;
        }

        public DataView ListarPorFiltro(DateTime? dat_inicio_ctr, DateTime? dat_fim_ctr, Decimal num_valor_ctr, Int32 cod_tipo_contrato_tcr, Int32 cod_contrato_ctr)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarContratoPorFiltro");
            _Command.Parameters.AddWithValue("@dat_inicio_ctr", !dat_inicio_ctr.HasValue ? Convert.DBNull : dat_inicio_ctr);
            _Command.Parameters.AddWithValue("@dat_fim_ctr", !dat_fim_ctr.HasValue ? Convert.DBNull : dat_fim_ctr);
            _Command.Parameters.AddWithValue("@num_valor_ctr", num_valor_ctr == 0 ? Convert.DBNull : num_valor_ctr);
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            _Command.Parameters.AddWithValue("@cod_contrato_ctr", cod_contrato_ctr == 0 ? Convert.DBNull : cod_contrato_ctr);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contrato"].DefaultView;
        }

        public void Excluir(Int32 cod_contrato_ctr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirContrato");
            _Command.Parameters.AddWithValue("@cod_contrato_ctr", cod_contrato_ctr == 0 ? Convert.DBNull : cod_contrato_ctr);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}