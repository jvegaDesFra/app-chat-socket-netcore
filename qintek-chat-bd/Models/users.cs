using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace qintek_chat_bd.Models
{
    public class users
    {
        [Key]
        public int UserID { get; set; }

        public int id { get; set; }

        [StringLength(500)]
        public string name { get; set; }
        [StringLength(500)]
        public string nick { get; set; }
        public DateTimeOffset dateLogged { get; set; }
        [StringLength(500)]
        public string connectionId { get; set; }

        public int? messages { get; set; }
    }
}
