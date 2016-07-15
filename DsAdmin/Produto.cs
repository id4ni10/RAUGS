using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Produto
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Produto()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Produto(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(String des_produto_pro, ref Int32 cod_produto_pro)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirProduto");
            _Command.Parameters.AddWithValue("@des_produto_pro", des_produto_pro == null ? Convert.DBNull : des_produto_pro);

            SqlParameter retorno = new SqlParameter();
            retorno = _Command.Parameters.Add("@cod_produto_pro", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            neo.ExecutaNonQuery(_Command);
            cod_produto_pro = (Int32)_Command.Parameters["@cod_produto_pro"].Value;

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(Int32 cod_produto_pro, String des_produto_pro)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarProduto");
            _Command.Parameters.AddWithValue("@cod_produto_pro", cod_produto_pro == 0 ? Convert.DBNull : cod_produto_pro);
            _Command.Parameters.AddWithValue("@des_produto_pro", des_produto_pro == null ? Convert.DBNull : des_produto_pro);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }


        public DataView Listar()
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarProduto");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_produto");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_produto"].DefaultView;
        }

        public DataView ListarPorFiltro(Int32 cod_produto_pro, String des_produto_pro)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarProdutoPorFiltro");
            _Command.Parameters.AddWithValue("@cod_produto_pro", cod_produto_pro == 0 ? Convert.DBNull : cod_produto_pro);
            _Command.Parameters.AddWithValue("@des_produto_pro", des_produto_pro == null ? Convert.DBNull : des_produto_pro);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_produto");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_produto"].DefaultView;
        }
    }
}