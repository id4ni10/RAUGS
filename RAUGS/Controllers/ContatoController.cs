using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using RAUGS.Models;

namespace RAUGS.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        // GET: Contato
        public ActionResult Index(ContatoViewModel search)
        {
            var contatos = from contato in
                               new DsAdmin.Contato().ListarPorFiltro(search.Nome,
                               null, null, null, null, null, null, null,
                               search.Cidade, null, null, search.Email, 0).Table.AsEnumerable()
                           select new ContatoViewModel
                           {
                               Id = Convert.ToInt32(contato["cod_contato_con"]),
                               Nome = contato["des_nome_con"].ToString(),
                               Cidade = contato["des_cidade_con"].ToString(),
                               Email = contato["des_email_con"].ToString()
                           };

            return View(contatos.ToList());
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            var contatos = from contato in
                               new DsAdmin.Contato().ListarPorFiltro(null,
                               null, null, null, null, null, null, null,
                               null, null, null, null, id).Table.AsEnumerable()
                           select new ContatoModel
                           {
                               Id = id,
                               Nome = contato["des_nome_con"].ToString(),
                               Cidade = contato["des_cidade_con"].ToString(),
                               Email = contato["des_email_con"].ToString(),
                               Bairro = contato["des_bairro_con"].ToString(),
                               CEP = contato["des_cep_con"].ToString(),
                               CGC = contato["des_cgc_con"].ToString(),
                               CPF_CNPJ = contato["des_cpf_cnpj_con"].ToString(),
                               Endereco = contato["des_endereco_con"].ToString(),
                               Estado = contato["des_estado_con"].ToString(),
                               Inscricao_Estadual = contato["des_inscricao_estadual_con"].ToString(),
                               Telefone_Comercial = contato["des_telefone_comercial_con"].ToString(),
                               Telefone_Residencial = contato["des_telefone_residencial_con"].ToString(),
                               Telefone_Celular = contato["des_telefone_celular_con"].ToString()
                           };

            return View(contatos.First());
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(ContatoModel contato)
        {
            try
            {
                var retorno = 0;

                new DsAdmin.Contato().Incluir(contato.Nome, contato.CGC, contato.CPF_CNPJ,
                    contato.Telefone_Residencial, contato.Endereco, contato.CEP, contato.Inscricao_Estadual,
                    contato.Bairro, contato.Cidade, contato.Estado, contato.Telefone_Comercial, contato.Email, contato.Telefone_Celular,ref retorno);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            var contatos = from contato in
                               new DsAdmin.Contato().ListarPorFiltro(null,
                               null, null, null, null, null, null, null,
                               null, null, null, null, id).Table.AsEnumerable()
                           select new ContatoModel
                           {
                               Id = id,
                               Nome = contato["des_nome_con"].ToString(),
                               Cidade = contato["des_cidade_con"].ToString(),
                               Email = contato["des_email_con"].ToString(),
                               Bairro = contato["des_bairro_con"].ToString(),
                               CEP = contato["des_cep_con"].ToString(),
                               CGC = contato["des_cgc_con"].ToString(),
                               CPF_CNPJ = contato["des_cpf_cnpj_con"].ToString(),
                               Endereco = contato["des_endereco_con"].ToString(),
                               Estado = contato["des_estado_con"].ToString(),
                               Inscricao_Estadual = contato["des_inscricao_estadual_con"].ToString(),
                               Telefone_Comercial = contato["des_telefone_comercial_con"].ToString(),
                               Telefone_Residencial = contato["des_telefone_residencial_con"].ToString(),
                               Telefone_Celular = contato["des_telefone_celular_con"].ToString()
                           };

            return View(contatos.First());
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContatoModel contato)
        {
            try
            {
                new DsAdmin.Contato().Alterar(contato.Nome, contato.CGC, contato.CPF_CNPJ,
                    contato.Telefone_Residencial, contato.Endereco, contato.CEP, contato.Inscricao_Estadual,
                    contato.Bairro, contato.Cidade, contato.Estado, contato.Telefone_Comercial, contato.Email, contato.Telefone_Celular, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            var contatos = from contato in
                               new DsAdmin.Contato().ListarPorFiltro(null,
                               null, null, null, null, null, null, null,
                               null, null, null, null, id).Table.AsEnumerable()
                           select new ContatoModel
                           {
                               Id = id,
                               Nome = contato["des_nome_con"].ToString(),
                               Cidade = contato["des_cidade_con"].ToString(),
                               Email = contato["des_email_con"].ToString(),
                               Bairro = contato["des_bairro_con"].ToString(),
                               CEP = contato["des_cep_con"].ToString(),
                               CGC = contato["des_cgc_con"].ToString(),
                               CPF_CNPJ = contato["des_cpf_cnpj_con"].ToString(),
                               Endereco = contato["des_endereco_con"].ToString(),
                               Estado = contato["des_estado_con"].ToString(),
                               Inscricao_Estadual = contato["des_inscricao_estadual_con"].ToString(),
                               Telefone_Comercial = contato["des_telefone_comercial_con"].ToString(),
                               Telefone_Residencial = contato["des_telefone_residencial_con"].ToString(),
                               Telefone_Celular = contato["des_telefone_celular_con"].ToString()
                           };

            return View(contatos.First());
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                new DsAdmin.Contato().Excluir(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
