using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appVentas.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace appVentas.Controllers
{
    public class MongoDBController : Controller
    {

        static MongoClient cliente = new MongoClient("mongodb://localhost:27017");

        static MongoServer servidor = cliente.GetServer();

        static MongoDatabase dbventas = servidor.GetDatabase("ventas");

        static MongoCollection clientes = dbventas.GetCollection<Cliente>("cliente");

        IEnumerable<Cliente> listado() 
        {
            return clientes.AsQueryable<Cliente>().ToList();
        }

        // GET: MongoDB
        public ActionResult Index()
        {
            return View(listado());
        }

       
        public ActionResult Create()
        {

            return View(new Cliente());
        
        }

        [HttpPost]
        public ActionResult Create(Cliente reg)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Ingrese los datos del cliente");
                return View(reg);

            }


            clientes.Insert<Cliente>(reg);
            ViewBag.mensaje = "Cliente agregado";
            return View(reg);
        
        

        }

        public ActionResult Details(String id)
        {

            Cliente reg = clientes.FindOneByIdAs<Cliente>(new ObjectId(id));
            return View(reg);
        
        }

    }
}