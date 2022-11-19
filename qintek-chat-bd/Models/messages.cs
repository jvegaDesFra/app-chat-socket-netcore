using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace qintek_chat_bd.Models
{
    public class messages
    {
        [Key]
        public int messageID { get; set; }
        public string message { get; set; }
        public int userID { get; set; }
        public Guid group { get; set; }

        public bool readed { get; set; }
    }
}
