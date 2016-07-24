using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class TipoContrato
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public TipoContrato()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public TipoContrato(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(String des_tipo_contrato_tcr, ref Int32 cod_tipo_contrato_tcr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirTipoContrato");
            _Command.Parameters.AddWithValue("@des_tipo_contrato_tcr", des_tipo_contrato_tcr == null ? Convert.DBNull : des_tipo_contrato_tcr);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_tipo_contrato_tcr", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_tipo_contrato_tcr = (Int32)_Command.Parameters["cod_tipo_contrato_tcr"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(String des_tipo_contrato_tcr, Int32 cod_tipo_contrato_tcr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarTipoContrato");
            _Command.Parameters.AddWithValue("@des_tipo_contrato_tcr", des_tipo_contrato_tcr == null ? Convert.DBNull : des_tipo_contrato_tcr);
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_tipo_contrato_tcr)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarTipoContrato");
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_contrato"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarTipoContrato");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_contrato"].DefaultView;
        }

        public DataView ListarPorFiltro(String des_tipo_contrato_tcr, Int32 cod_tipo_contrato_tcr)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarTipoContratoPorFiltro");
            _Command.Parameters.AddWithValue("@des_tipo_contrato_tcr", des_tipo_contrato_tcr == null ? Convert.DBNull : des_tipo_contrato_tcr);
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_contrato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_contrato"].DefaultView;
        }

        public void Excluir(Int32 cod_tipo_contrato_tcr)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirTipoContrato");
            _Command.Parameters.AddWithValue("@cod_tipo_contrato_tcr", cod_tipo_contrato_tcr == 0 ? Convert.DBNull : cod_tipo_contrato_tcr);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}