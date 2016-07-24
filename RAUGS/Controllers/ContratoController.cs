using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;  Remover este coment?rio caso deseje refer?nciar o usu?rio logado

namespace RAUGS.Controllers
{
    [Authorize]
    public class ContratoController : Controller
    {
        public ActionResult Create(Int32 Id)
        {
            DropDownListTipoContrato();

            return View(new Models.Contrato { cod_licitacao_lic = Id });
        }

        [HttpPost]
        public ActionResult Create(Int32 Id, Models.Contrato contrato)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Contrato().Incluir(contrato.dat_inicio_ctr, contrato.dat_fim_ctr,
                    contrato.num_valor_ctr.ToDecimal(), contrato.cod_tipo_contrato_tcr, Id, ref retorno);

                return RedirectToAction("Index", new { Id = Id });
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
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        cod_licitacao_lic = item["cod_licitacao_lic"].ToInt32(),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        num_valor_ctr = item["num_valor_ctr"].ToString(),
                        cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                    }).First());
        }

        public ActionResult Edit(int Id)
        {
            DropDownListTipoContrato();

            return View(
                (from item in
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        dat_fim_ctr = item["dat_fim_ctr"].ToDateTime(),
                        cod_licitacao_lic = item["cod_licitacao_lic"].ToInt32(),
                        num_valor_ctr = item["num_valor_ctr"].ToString(),
                        cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                    }).First());
        }

        [HttpPost]
        public ActionResult Edit(int Id, Models.Contrato contrato)
        {
            try
            {
                new DsAdmin.Contrato().Alterar(contrato.dat_inicio_ctr, contrato.dat_fim_ctr, 
                    contrato.num_valor_ctr.ToDecimal(), contrato.cod_tipo_contrato_tcr, contrato.Id);

                return RedirectToAction("Index", new { Id = Id });
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
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        num_valor_ctr = item["num_valor_ctr"].ToString(),
                        cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                    }).First());
        }

        [HttpPost]
        public ActionResult Delete(int Id, Models.Contrato contrato)
        {
            try
            {
                new DsAdmin.Contrato().Excluir(Id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public void DropDownListTipoContrato()
        {
            var data =
                (from item in
                    new DsAdmin.TipoContrato().Listar().Table.AsEnumerable()
                 select new SelectListItem
                 {
                     Text = item["des_tipo_contrato_tcr"].ToString(),
                     Value = item["cod_tipo_contrato_tcr"].ToString()
                 }).ToList();

            data.Insert(0, new SelectListItem { Text = "Selecione", Value = "" });

            ViewBag.TipoContrato = data;
        }
    }
}