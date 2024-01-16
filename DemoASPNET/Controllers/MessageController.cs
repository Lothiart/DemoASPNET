using DemoASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace DemoASPNET.Controllers
{
    public class MessageController : Controller
    {
        
        static List<Message> Messages = new List<Message>
        {

            new Message(){Id=1, Emetteur="A", Contenu="C"},
            new Message(){Id=2, Emetteur="B",Contenu="C"}
        };
        //static List<Message> MessRech;
        private readonly ILogger<HomeController> _logger;
        public MessageController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            message.Id = Messages.Max(m => m.Id) + 1;
            message.Date = DateTime.Now; 
            Messages.Add(message);
            return RedirectToAction("CreateMessage");
        }

        public IActionResult CreateMessageContrainte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMessageContrainte(Message message)
        {
            if (!ModelState.IsValid)
            {
                return View(message);

            }
            message.Id = Messages.Max(m => m.Id) + 1;
            
            message.Date = DateTime.Now;
            Messages.Add(message);
            return RedirectToAction("CreateMessageContrainte");
        }

        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            Message message = Messages.FirstOrDefault(m => m.Id == id);

            return View(message);
        }
        public ActionResult ReadMessages()
        {

            return View(Messages);
        }
        public ActionResult UpdateMessage(Message message)
        {
            Messages.FirstOrDefault(m => m.Id == message.Id).Date = DateTime.Now;
            Messages.FirstOrDefault(m => m.Id == message.Id).Emetteur = message.Emetteur;
            Messages.FirstOrDefault(m => m.Id == message.Id).Contenu = message.Contenu;
            return View();
        }
        public ActionResult DeleteMessage(int Id)
        {
            
            Messages.Remove(Messages.FirstOrDefault(m => m.Id == Id));

            return RedirectToAction("ReadMessages");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> SearchAjax(string emetteur)
        {
            var messages = Messages.Find(m => m.Emetteur == emetteur);

            return PartialView("_displayMessages", messages);
            //return RedirectToRoute("Detail/" + pet.Id);
        }
        public ActionResult RechercheMessage()
        {
            return View(Messages);
        }
        public ActionResult Recherche(string emetteur)
        {

            //foreach (Message mess in Messages)
            //{
            //    if (mess.Emetteur.Contains(emetteur))
            //    {
            //        MessRech.Add(mess);
            //    }

            //}
            var MessRech = (emetteur == null) ? Messages : Messages.Where(item => item.Emetteur.Contains(emetteur)).ToList();   


           return PartialView("_ReadMessagesPartial", MessRech);
        }
        public ActionResult IsUnique(string emetteur) {
            bool res = false;
            var mes = Messages.FirstOrDefault(e=>e.Emetteur==emetteur);
            if (mes == null)
            {
                res = true;
            }
            return Json(mes);
        }
    }
}
