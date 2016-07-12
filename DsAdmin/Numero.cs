using System;
using System.Data;
using System.Data.SqlClient;

namespace DsAdmin
{
    public class Numero
    {
        private DAO neo;

        private bool sessaoInterna = false;

        public Numero()
        {
            sessaoInterna = true;
            neo = new DAO();
        }

        public Numero(DAO conexao)
        {
            neo = conexao;
        }

        public void Incluir(Int32 cod_numero_num, String des_numero_num)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_IncluirNumero");
            _Command.Parameters.AddWithValue("@cod_numero_num", cod_numero_num == 0 ? Convert.DBNull : cod_numero_num);
            _Command.Parameters.AddWithValue("@des_numero_num", des_numero_num == null ? Convert.DBNull : des_numero_num);
            neo.ExecutaNonQuery(_Command);

            if (sessaoInterna)
            {
                neo.Commit();
                neo.Fechar();
            }
        }

        public void Alterar(Int32 cod_numero_num, String des_numero_num)
        {
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_AlterarNumero");
            _Command.Parameters.AddWithValue("@cod_numero_num", cod_numero_num == 0 ? Convert.DBNull : cod_numero_num);
            _Command.Parameters.AddWithValue("@des_numero_num", des_numero_num == null ? Convert.DBNull : des_numero_num);
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
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarNumero");
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_numero");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_numero"].DefaultView;
        }

        public DataView ListarPorFiltro(Int32 cod_numero_num, String des_numero_num)
        {
            DataSet lRetorno;
            SqlCommand _Command = (SqlCommand)neo.InicializaProcedure("usp_rau_ListarNumeroPorFiltro");
            _Command.Parameters.AddWithValue("@cod_numero_num", cod_numero_num == 0 ? Convert.DBNull : cod_numero_num);
            _Command.Parameters.AddWithValue("@des_numero_num", des_numero_num == null ? Convert.DBNull : des_numero_num);
            lRetorno = neo.ConsultaQueryDataSet(_Command, "tb_rau_numero");

            if (sessaoInterna)
            {
                neo.Fechar();
            }

            return lRetorno.Tables["tb_rau_numero"].DefaultView;
        }
    }
}