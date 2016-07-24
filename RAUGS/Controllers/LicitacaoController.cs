using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;  Remover este coment?rio caso deseje refer?nciar o usu?rio logado

namespace RAUGS.Controllers
{
    [Authorize]
    public class LicitacaoController : Controller
    {
        public ActionResult Index(Models.LicitacaoSearch search)
        {
            DropDownListNumero();
            DropDownListCliente();
            DropDownListTipoLicitacao();

            var data =
                (from item in
                    new DsAdmin.Licitacao()
                    .ListarPorFiltro(search.dat_licitacao_lic, search.cod_cliente_cli, search.num_mes_lic, search.cod_tipo_licitacao_tli, search.cod_numero_num)
                    .Table.AsEnumerable()
                 select new Models.LicitacaoView
                 {
                     Id = item["cod_licitacao_lic"].ToInt32(),
                     dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                     des_cliente_cli = item["des_cliente_cli"].ToString(),
                     des_tipo_licitacao_tli = item["des_tipo_licitacao_tli"].ToString(),
                     num_valor_lic = item["num_valor_lic"].ToString(),
                     tip_status_lic = item["tip_status_lic"].ToBoolean(),
                     num_mes_lic = item["num_mes_lic"].ToInt32(),
                     des_numero_num = item["des_numero_num"].ToString()
                 }).ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            DropDownListNumero();
            DropDownListCliente();
            DropDownListTipoLicitacao();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Licitacao licitacao)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Licitacao().Incluir(licitacao.dat_licitacao_lic, licitacao.cod_cliente_cli,
                    licitacao.cod_tipo_licitacao_tli, licitacao.num_mes_lic, licitacao.num_valor_lic.ToDecimal(),
                    licitacao.tip_status_lic, licitacao.cod_numero_num, ref retorno);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult Details(int Id)
        {
            return View(
                (from item in
                    new DsAdmin.Licitacao().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Licitacao
                    {
                        Id = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        num_valor_lic = item["num_valor_lic"].ToString(),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        public ActionResult Edit(int Id)
        {
            DropDownListNumero();
            DropDownListCliente();
            DropDownListTipoLicitacao();

            return View(
                (from item in
                    new DsAdmin.Licitacao().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Licitacao
                    {
                        Id = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        num_mes_lic = Convert.ToInt32(item["num_mes_lic"]),
                        num_valor_lic = item["num_valor_lic"].ToString(),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        [HttpPost]
        public ActionResult Edit(int Id, Models.Licitacao licitacao)
        {
            try
            {
                new DsAdmin.Licitacao().Alterar(licitacao.dat_licitacao_lic,
                    licitacao.cod_cliente_cli, licitacao.cod_tipo_licitacao_tli,
                    licitacao.num_mes_lic, licitacao.num_valor_lic.ToDecimal(), licitacao.tip_status_lic,
                    licitacao.cod_numero_num, licitacao.Id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult Delete(int Id)
        {
            return View(
                (from item in
                    new DsAdmin.Licitacao().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Licitacao
                    {
                        Id = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        num_valor_lic = item["num_valor_lic"].ToString(),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        [HttpPost]
        public ActionResult Delete(int Id, Models.Licitacao licitacao)
        {
            try
            {
                new DsAdmin.Licitacao().Excluir(Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Contratos(int Id)
        {
            var data =
                (from item in
                    new DsAdmin.Contrato().ListarPorLicitacao(Id).Table.AsEnumerable()
                 select new Models.ContratoView
                 {
                     Id = item["cod_contrato_ctr"].ToInt32(),
                     dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                     dat_fim_ctr = item["dat_inicio_ctr"].ToDateTime(),
                     num_valor_ctr = item["num_valor_ctr"].ToDecimal(),
                     des_tipo_contrato_tcr = item["des_tipo_contrato_tcr"].ToString()
                 }).ToList();

            var model = new Models.ContratoPublicacao { cod_licitacao_lic = Id, Contratos = data };

            return View(model);
        }

        public void DropDownListCliente()
        {
            var data =
                (from item in
                    new DsAdmin.Cliente().Listar().Table.AsEnumerable()
                 select new SelectListItem
                 {
                     Text = item["des_cliente_cli"].ToString(),
                     Value = item["cod_cliente_cli"].ToString()
                 }).ToList();

            data.Insert(0, new SelectListItem { Text = "Selecione", Value = "" });

            ViewBag.Clientes = data;
        }

        public void DropDownListNumero()
        {
            var data =
                (from item in
                    new DsAdmin.Numero().Listar().Table.AsEnumerable()
                 select new SelectListItem
                 {
                     Text = item["des_numero_num"].ToString(),
                     Value = item["cod_numero_num"].ToString()
                 }).ToList();

            data.Insert(0, new SelectListItem { Text = "Selecione", Value = "" });

            ViewBag.Numeros = data;
        }

        public void DropDownListTipoLicitacao()
        {
            var data =
                (from item in
                    new DsAdmin.TipoLicitacao().Listar().Table.AsEnumerable()
                 select new SelectListItem
                 {
                     Text = item["des_tipo_licitacao_tli"].ToString(),
                     Value = item["cod_tipo_licitacao_tli"].ToString()
                 }).ToList();

            data.Insert(0, new SelectListItem { Text = "Selecione", Value = "" });

            ViewBag.TipoLicitacao = data;
        }
    }
}