using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Contato
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Contato()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Contato(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(String des_nome_con, String des_cgc_con, String des_cpf_cnpj_con, String des_telefone_residencial_con, String des_endereco_con, String des_cep_con, String des_inscricao_estadual_con, String des_bairro_con, String des_cidade_con, String des_estado_con, String des_telefone_comercial_con, String des_email_con, String des_telefone_celular_con, ref Int32 cod_contato_con)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirContato");
            _Command.Parameters.AddWithValue("@des_nome_con", des_nome_con == null ? Convert.DBNull : des_nome_con);
            _Command.Parameters.AddWithValue("@des_cgc_con", des_cgc_con == null ? Convert.DBNull : des_cgc_con);
            _Command.Parameters.AddWithValue("@des_cpf_cnpj_con", des_cpf_cnpj_con == null ? Convert.DBNull : des_cpf_cnpj_con);
            _Command.Parameters.AddWithValue("@des_telefone_residencial_con", des_telefone_residencial_con == null ? Convert.DBNull : des_telefone_residencial_con);
            _Command.Parameters.AddWithValue("@des_endereco_con", des_endereco_con == null ? Convert.DBNull : des_endereco_con);
            _Command.Parameters.AddWithValue("@des_cep_con", des_cep_con == null ? Convert.DBNull : des_cep_con);
            _Command.Parameters.AddWithValue("@des_inscricao_estadual_con", des_inscricao_estadual_con == null ? Convert.DBNull : des_inscricao_estadual_con);
            _Command.Parameters.AddWithValue("@des_bairro_con", des_bairro_con == null ? Convert.DBNull : des_bairro_con);
            _Command.Parameters.AddWithValue("@des_cidade_con", des_cidade_con == null ? Convert.DBNull : des_cidade_con);
            _Command.Parameters.AddWithValue("@des_estado_con", des_estado_con == null ? Convert.DBNull : des_estado_con);
            _Command.Parameters.AddWithValue("@des_telefone_comercial_con", des_telefone_comercial_con == null ? Convert.DBNull : des_telefone_comercial_con);
            _Command.Parameters.AddWithValue("@des_email_con", des_email_con == null ? Convert.DBNull : des_email_con);
            _Command.Parameters.AddWithValue("@des_telefone_celular_con", des_telefone_celular_con == null ? Convert.DBNull : des_telefone_celular_con);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_contato_con", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_contato_con = (Int32)_Command.Parameters["cod_contato_con"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(String des_nome_con, String des_cgc_con, String des_cpf_cnpj_con, String des_telefone_residencial_con, String des_endereco_con, String des_cep_con, String des_inscricao_estadual_con, String des_bairro_con, String des_cidade_con, String des_estado_con, String des_telefone_comercial_con, String des_email_con, String des_telefone_celular_con, Int32 cod_contato_con)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarContato");
            _Command.Parameters.AddWithValue("@des_nome_con", des_nome_con == null ? Convert.DBNull : des_nome_con);
            _Command.Parameters.AddWithValue("@des_cgc_con", des_cgc_con == null ? Convert.DBNull : des_cgc_con);
            _Command.Parameters.AddWithValue("@des_cpf_cnpj_con", des_cpf_cnpj_con == null ? Convert.DBNull : des_cpf_cnpj_con);
            _Command.Parameters.AddWithValue("@des_telefone_residencial_con", des_telefone_residencial_con == null ? Convert.DBNull : des_telefone_residencial_con);
            _Command.Parameters.AddWithValue("@des_endereco_con", des_endereco_con == null ? Convert.DBNull : des_endereco_con);
            _Command.Parameters.AddWithValue("@des_cep_con", des_cep_con == null ? Convert.DBNull : des_cep_con);
            _Command.Parameters.AddWithValue("@des_inscricao_estadual_con", des_inscricao_estadual_con == null ? Convert.DBNull : des_inscricao_estadual_con);
            _Command.Parameters.AddWithValue("@des_bairro_con", des_bairro_con == null ? Convert.DBNull : des_bairro_con);
            _Command.Parameters.AddWithValue("@des_cidade_con", des_cidade_con == null ? Convert.DBNull : des_cidade_con);
            _Command.Parameters.AddWithValue("@des_estado_con", des_estado_con == null ? Convert.DBNull : des_estado_con);
            _Command.Parameters.AddWithValue("@des_telefone_comercial_con", des_telefone_comercial_con == null ? Convert.DBNull : des_telefone_comercial_con);
            _Command.Parameters.AddWithValue("@des_email_con", des_email_con == null ? Convert.DBNull : des_email_con);
            _Command.Parameters.AddWithValue("@cod_contato_con", cod_contato_con == 0 ? Convert.DBNull : cod_contato_con);
            _Command.Parameters.AddWithValue("@des_telefone_celular_con", des_telefone_celular_con == null ? Convert.DBNull : des_telefone_celular_con);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public DataView Consultar(Int32 cod_contato_con)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ConsultarContato");
            _Command.Parameters.AddWithValue("@cod_contato_con", cod_contato_con == 0 ? Convert.DBNull : cod_contato_con);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contato"].DefaultView;
        }

        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarContato");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contato"].DefaultView;
        }

        public DataView ListarPorFiltro(String des_nome_con, String des_cgc_con, String des_cpf_cnpj_con, String des_telefone_residencial_con, String des_endereco_con, String des_cep_con, String des_inscricao_estadual_con, String des_bairro_con, String des_cidade_con, String des_estado_con, String des_telefone_comercial_con, String des_email_con, Int32 cod_contato_con)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarContatoPorFiltro");
            _Command.Parameters.AddWithValue("@des_nome_con", des_nome_con == null ? Convert.DBNull : des_nome_con);
            _Command.Parameters.AddWithValue("@des_cgc_con", des_cgc_con == null ? Convert.DBNull : des_cgc_con);
            _Command.Parameters.AddWithValue("@des_cpf_cnpj_con", des_cpf_cnpj_con == null ? Convert.DBNull : des_cpf_cnpj_con);
            _Command.Parameters.AddWithValue("@des_telefone_residencial_con", des_telefone_residencial_con == null ? Convert.DBNull : des_telefone_residencial_con);
            _Command.Parameters.AddWithValue("@des_endereco_con", des_endereco_con == null ? Convert.DBNull : des_endereco_con);
            _Command.Parameters.AddWithValue("@des_cep_con", des_cep_con == null ? Convert.DBNull : des_cep_con);
            _Command.Parameters.AddWithValue("@des_inscricao_estadual_con", des_inscricao_estadual_con == null ? Convert.DBNull : des_inscricao_estadual_con);
            _Command.Parameters.AddWithValue("@des_bairro_con", des_bairro_con == null ? Convert.DBNull : des_bairro_con);
            _Command.Parameters.AddWithValue("@des_cidade_con", des_cidade_con == null ? Convert.DBNull : des_cidade_con);
            _Command.Parameters.AddWithValue("@des_estado_con", des_estado_con == null ? Convert.DBNull : des_estado_con);
            _Command.Parameters.AddWithValue("@des_telefone_comercial_con", des_telefone_comercial_con == null ? Convert.DBNull : des_telefone_comercial_con);
            _Command.Parameters.AddWithValue("@des_email_con", des_email_con == null ? Convert.DBNull : des_email_con);
            _Command.Parameters.AddWithValue("@cod_contato_con", cod_contato_con == 0 ? Convert.DBNull : cod_contato_con);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_contato");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_contato"].DefaultView;
        }

        public void Excluir(Int32 cod_contato_con)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ExcluirContato");
            _Command.Parameters.AddWithValue("@cod_contato_con", cod_contato_con == 0 ? Convert.DBNull : cod_contato_con);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }
    }
}