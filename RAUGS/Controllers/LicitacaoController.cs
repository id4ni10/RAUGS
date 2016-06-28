using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;  Remover este coment?rio caso deseje refer?nciar o usu?rio logado

namespace RAUGS.Controllers
{
    public class LicitacaoController : Controller
    {
        public ActionResult Index()
        {
            var data =
                (from item in
                    new DsAdmin.Licitacao().Listar().Table.AsEnumerable()
                 select new Models.Licitacao
                 {
                     cod_licitacao_lic = Convert.ToInt32(item["cod_licitacao_lic"]),
                     dat_licitacao_lic = item["dat_licitacao_lic"].ToString(),
                     cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                     cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                     dat_inicio_contrato_lic = item["dat_inicio_contrato_lic"].ToString(),
                     num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
                     tip_status_lic = (bool)item["tip_status_lic"]
                 }).ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Licitacao licitacao)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Licitacao().Incluir(licitacao.dat_licitacao_lic, licitacao.cod_cliente_cli, licitacao.cod_tipo_licitacao_tli, licitacao.dat_inicio_contrato_lic, licitacao.dat_fim_contrato_lic, licitacao.num_mes_lic, licitacao.num_valor_lic, licitacao.tip_status_lic, ref retorno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
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
                        cod_licitacao_lic = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToString(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        dat_inicio_contrato_lic = item["dat_inicio_contrato_lic"].ToString(),
                        num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        public ActionResult Edit(int Id)
        {
            return View(
                (from item in
                    new DsAdmin.Licitacao().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Licitacao
                    {
                        cod_licitacao_lic = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToString(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        dat_inicio_contrato_lic = item["dat_inicio_contrato_lic"].ToString(),
                        dat_fim_contrato_lic = item["dat_fim_contrato_lic"].ToString(),
                        num_mes_lic = Convert.ToInt32(item["num_mes_lic"]),
                        num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        [HttpPost]
        public ActionResult Edit(int Id, Models.Licitacao licitacao)
        {
            try
            {
                new DsAdmin.Licitacao().Alterar(licitacao.dat_licitacao_lic, licitacao.cod_cliente_cli, licitacao.cod_tipo_licitacao_tli, licitacao.dat_inicio_contrato_lic, licitacao.dat_fim_contrato_lic, licitacao.num_mes_lic, licitacao.num_valor_lic, licitacao.tip_status_lic, licitacao.cod_licitacao_lic);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
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
                        cod_licitacao_lic = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToString(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
                        dat_inicio_contrato_lic = item["dat_inicio_contrato_lic"].ToString(),
                        num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
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
    }
}