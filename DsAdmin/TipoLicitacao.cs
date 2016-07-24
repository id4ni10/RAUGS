using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class TipoLicitacao
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public TipoLicitacao()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public TipoLicitacao(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(String des_tipo_licitacao_tli, ref Int32 cod_tipo_licitacao_tli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirTipoLicitacao");
            _Command.Parameters.AddWithValue("@des_tipo_licitacao_tli", des_tipo_licitacao_tli == null ? Convert.DBNull : des_tipo_licitacao_tli);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_tipo_licitacao_tli", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_tipo_licitacao_tli = (Int32)_Command.Parameters["@cod_tipo_licitacao_tli"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(String des_tipo_licitacao_tli, Int32 cod_tipo_licitacao_tli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarTipoLicitacao");
            _Command.Parameters.AddWithValue("@des_tipo_licitacao_tli", des_tipo_licitacao_tli == null ? Convert.DBNull : des_tipo_licitacao_tli);
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_tipo_licitacao_tli)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarTipoLicitacao");
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_licitacao"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarTipoLicitacao");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_licitacao"].DefaultView;
        }

        public DataView ListarPorFiltro(String des_tipo_licitacao_tli, Int32 cod_tipo_licitacao_tli)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarTipoLicitacaoPorFiltro");
            _Command.Parameters.AddWithValue("@des_tipo_licitacao_tli", des_tipo_licitacao_tli == null ? Convert.DBNull : des_tipo_licitacao_tli);
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_tipo_licitacao");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_tipo_licitacao"].DefaultView;
        }

        public void Excluir(Int32 cod_tipo_licitacao_tli)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirTipoLicitacao");
            _Command.Parameters.AddWithValue("@cod_tipo_licitacao_tli", cod_tipo_licitacao_tli == 0 ? Convert.DBNull : cod_tipo_licitacao_tli);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}