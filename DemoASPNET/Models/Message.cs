using System.ComponentModel.DataAnnotations;

namespace DemoASPNET.Models
{
    public class Message
    {

        public int Id { get; set; }

        [Required]
        
        public string Emetteur { get; set; }
        [StringLength(20)]
        public string Contenu { get; set; }

        public DateTime Date { get; set; }
        
       

       
    }
}
