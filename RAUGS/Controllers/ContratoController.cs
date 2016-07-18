using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;  Remover este coment?rio caso deseje refer?nciar o usu?rio logado

namespace RAUGS.Controllers
{
    public class ContratoController : Controller
    {
        public ActionResult Index(Int32 Id)
        {
            var data =
                (from item in
                    new DsAdmin.Contrato().Listar().Table.AsEnumerable()
                 select new Models.Contrato
                 {
                     Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                     dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                     num_valor_ctr = Convert.ToDecimal(item["num_valor_ctr"]),
                     cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                 }).ToList();

            return View(data);
        }

        public ActionResult Create(Int32 Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Contrato contrato)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Contrato().Incluir(contrato.dat_inicio_ctr, contrato.dat_fim_ctr, 
                    contrato.num_valor_ctr, contrato.cod_tipo_contrato_tcr, ref retorno);

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
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        num_valor_ctr = Convert.ToDecimal(item["num_valor_ctr"]),
                        cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                    }).First());
        }

        public ActionResult Edit(int Id)
        {
            return View(
                (from item in
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        dat_fim_ctr = item["dat_fim_ctr"].ToDateTime(),
                        num_valor_ctr = Convert.ToDecimal(item["num_valor_ctr"]),
                        cod_tipo_contrato_tcr = Convert.ToInt32(item["cod_tipo_contrato_tcr"])
                    }).First());
        }

        [HttpPost]
        public ActionResult Edit(int Id, Models.Contrato contrato)
        {
            try
            {
                new DsAdmin.Contrato().Alterar(contrato.dat_inicio_ctr, contrato.dat_fim_ctr, contrato.num_valor_ctr, contrato.cod_tipo_contrato_tcr, contrato.Id);

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
                    new DsAdmin.Contrato().Consultar(Id).Table.AsEnumerable()
                 select
                    new Models.Contrato
                    {
                        Id = Convert.ToInt32(item["cod_contrato_ctr"]),
                        dat_inicio_ctr = item["dat_inicio_ctr"].ToDateTime(),
                        num_valor_ctr = Convert.ToDecimal(item["num_valor_ctr"]),
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
            catch
            {
                return View("Error");
            }
        }
    }
}