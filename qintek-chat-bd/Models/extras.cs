using System;
using System.Collections.Generic;
using System.Text;

namespace qintek_chat_bd.Models
{
    public class resultUnread
    {
        public int userId { get; set; }
        public int userIdTo { get; set; }
        public int unread { get; set; }
        public string cnnID { get; set; }
    }
}
