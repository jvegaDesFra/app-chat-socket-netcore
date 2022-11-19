using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace qintek_chat_bd.Models
{
    public class groups
    {
        [Key]
        public int groupID { get; set; }

        public Guid grupo { get; set; }
        public int userID_A { get; set; }
        public int userID_B { get; set; }

        public DateTimeOffset dateCreated { get; set; }

    }

 
}
