using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    
    public class ClienteController : Controller
    {
        private readonly ClienteApplication _clienteApplication;
        private readonly ICLienteRepository _clienteRepository;
       
        public ClienteController(ClienteApplication clienteApplication , ICLienteRepository clienteRepository)
        {
            _clienteApplication = clienteApplication;
            _clienteRepository = clienteRepository;

           
        }

        
        public ActionResult Index()
        {
            var cliente = _clienteApplication.GetAll();
            var clienteViewModel1 = Mapper.Map<IEnumerable<Cliente> , IEnumerable<ClienteViewModel>>(_clienteApplication.GetAll());
            //var clienteViewModel = new ClienteViewModel();
            List<ClienteViewModel> clienteViewModel = new List<ClienteViewModel>() {
                new ClienteViewModel {Id = 1, Nome = "Ricardo Santos " , Email = "ri.santos@hotmail.com "} ,
                new ClienteViewModel {Id = 2, Nome = "Bruna Olivia " , Email = "oliviaaguiar@hotmail.com "} ,
                new ClienteViewModel {Id = 3, Nome = "Dalmira de Souza Santos " , Email = "dalmira@uol.com.br"}

            };
            return View(clienteViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]   //
        public ActionResult Create(ClienteViewModel cliente)
        {
           if(ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                //_clienteRepository.Salvar(clienteDomain);
                //_clienteApplication.Salvar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
