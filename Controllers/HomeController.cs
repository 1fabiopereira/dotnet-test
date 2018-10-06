using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pos2909.db;
using Pos2909.db.Models;
using Newtonsoft.Json;

namespace Pos2909.Controllers
{
    public class HomeController : Controller
    {
        private AppDb db;

        public HomeController(AppDb appDb)
        {
            db = appDb;
        }

        /**
         * Renderiza a tela de listagem de usuários 
         */
        public async Task<IActionResult> Index()
        {
                await db.Connection.OpenAsync();
                var users = new User(db);
                var result = await users.ReadAllAsync();
                ViewData["size"] = (result.Count() != 0) ? result.Count() : 0;

                return View(result);
        }

        /**
         * Renderiza a tela de listagem adição de usuários 
         */
        public IActionResult Add ()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
