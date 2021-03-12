using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{[Table("Iletisim")]
    public class Iletisim
    {[Key]
        public int IletisimId { get; set; }
        [Required, StringLength(300, ErrorMessage = "300 Karekter olmalıdır.")]
        public string Adres { get; set; }
        [Required, StringLength(300, ErrorMessage = "300 Karekter olmalıdır.")]
        public string Telefon { get; set; }
        
        public string Fax { get; set; }
       
        public string Whatsapp{ get; set; }
     
        public string Facebook { get; set; }
       
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}