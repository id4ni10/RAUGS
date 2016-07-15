using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Aditivo
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Aditivo()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Aditivo(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(Int32 cod_licitacao_lic, String dat_inicio_adi, String dat_fim_adi, Decimal num_valor_adi, ref Int32 cod_aditivo_adi)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirAditivo");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            _Command.Parameters.AddWithValue("@dat_inicio_adi", dat_inicio_adi == null ? Convert.DBNull : dat_inicio_adi);
            _Command.Parameters.AddWithValue("@dat_fim_adi", dat_fim_adi == null ? Convert.DBNull : dat_fim_adi);
            _Command.Parameters.AddWithValue("@num_valor_adi", num_valor_adi == 0 ? Convert.DBNull : num_valor_adi);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_aditivo_adi", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_aditivo_adi = (Int32)_Command.Parameters["@cod_aditivo_adi"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(Int32 cod_licitacao_lic, String dat_inicio_adi, String dat_fim_adi, Decimal num_valor_adi, Int32 cod_aditivo_adi)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarAditivo");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            _Command.Parameters.AddWithValue("@dat_inicio_adi", dat_inicio_adi == null ? Convert.DBNull : dat_inicio_adi);
            _Command.Parameters.AddWithValue("@dat_fim_adi", dat_fim_adi == null ? Convert.DBNull : dat_fim_adi);
            _Command.Parameters.AddWithValue("@num_valor_adi", num_valor_adi == 0 ? Convert.DBNull : num_valor_adi);
            _Command.Parameters.AddWithValue("@cod_aditivo_adi", cod_aditivo_adi == 0 ? Convert.DBNull : cod_aditivo_adi);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_aditivo_adi)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarAditivo");
            _Command.Parameters.AddWithValue("@cod_aditivo_adi", cod_aditivo_adi == 0 ? Convert.DBNull : cod_aditivo_adi);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_aditivo");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_aditivo"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarAditivo");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_aditivo");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_aditivo"].DefaultView;
        }

        public DataView ListarPorFiltro(Int32 cod_licitacao_lic, String dat_inicio_adi, String dat_fim_adi, Decimal num_valor_adi, Int32 cod_aditivo_adi)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarAditivoPorFiltro");
            _Command.Parameters.AddWithValue("@cod_licitacao_lic", cod_licitacao_lic == 0 ? Convert.DBNull : cod_licitacao_lic);
            _Command.Parameters.AddWithValue("@dat_inicio_adi", dat_inicio_adi == null ? Convert.DBNull : dat_inicio_adi);
            _Command.Parameters.AddWithValue("@dat_fim_adi", dat_fim_adi == null ? Convert.DBNull : dat_fim_adi);
            _Command.Parameters.AddWithValue("@num_valor_adi", num_valor_adi == 0 ? Convert.DBNull : num_valor_adi);
            _Command.Parameters.AddWithValue("@cod_aditivo_adi", cod_aditivo_adi == 0 ? Convert.DBNull : cod_aditivo_adi);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_aditivo");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_aditivo"].DefaultView;
        }

        public void Excluir(Int32 cod_aditivo_adi)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirAditivo");
            _Command.Parameters.AddWithValue("@cod_aditivo_adi", cod_aditivo_adi == 0 ? Convert.DBNull : cod_aditivo_adi);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}