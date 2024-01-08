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

        //public IActionResult CreateMessageContrainte()
        //{
        //    return View();
        //}
        //public ActionResult CreateMessageContrainte(Message message)
        //{
            
        //    message.Id = Messages.Max(m => m.Id) + 1;
        //    Messages.FirstOrDefault(m => m.Id == message.Id).Emetteur = message.Emetteur;
        //    message.Date = DateTime.Now;
        //    Messages.Add(message);
        //    return RedirectToAction("CreateMessageContrainte");
        //}

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
    }
}
