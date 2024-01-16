using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoASPNET.Models
{
    public class Message
    {

        public int Id { get; set; }

        [Required]
        [Remote("Unique?","Message",ErrorMessage ="Error : emetteur inexistant")]
        public string Emetteur { get; set; }
        [StringLength(20,ErrorMessage ="Max 20 caractères")]
        public string Contenu { get; set; }

        public DateTime Date { get; set; }
        
       

       
    }
}
