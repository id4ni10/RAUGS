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
                     Id = item["cod_licitacao_lic"].ToInt32(),
                     dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                     cod_cliente_cli = item["cod_cliente_cli"].ToInt32(),
                     cod_tipo_licitacao_tli = item["cod_tipo_licitacao_tli"].ToInt32(),
                     num_valor_lic = item["num_valor_lic"].ToDecimal(),
                     tip_status_lic = item["tip_status_lic"].ToBoolean()
                 }).ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            DropDownListNumero();
            DropDownListCliente();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Licitacao licitacao)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Licitacao().Incluir(licitacao.dat_licitacao_lic, licitacao.cod_cliente_cli,
                    licitacao.cod_tipo_licitacao_tli, licitacao.num_mes_lic, licitacao.num_valor_lic,
                    licitacao.tip_status_lic, licitacao.cod_numero_num, ref retorno);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Licitacao", "Create"));
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
                        num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
                        tip_status_lic = (bool)item["tip_status_lic"]
                    }).First());
        }

        public ActionResult Edit(int Id)
        {
            DropDownListNumero();
            DropDownListCliente();

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
                        num_valor_lic = Convert.ToDecimal(item["num_valor_lic"]),
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
                    licitacao.num_mes_lic, licitacao.num_valor_lic, licitacao.tip_status_lic,
                    licitacao.cod_numero_num, licitacao.Id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
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
                        Id = Convert.ToInt32(item["cod_licitacao_lic"]),
                        dat_licitacao_lic = item["dat_licitacao_lic"].ToDateTime(),
                        cod_cliente_cli = Convert.ToInt32(item["cod_cliente_cli"]),
                        cod_tipo_licitacao_tli = Convert.ToInt32(item["cod_tipo_licitacao_tli"]),
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
    }
}