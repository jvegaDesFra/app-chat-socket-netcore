using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qintek_chat_bd.Methods
{
    public class messages
    {

        public static Models.messages addMessage(Guid group, int userID, string message)
        {
            Models.messages result = null;
            using (var context = new LibraryContext())
            {

                Models.messages message_ = new Models.messages();
                message_.group = group;
                message_.message = message;
                message_.userID = userID;
                message_.readed = false;

                context.messages.Add(message_);
                context.SaveChanges();

                result = message_;
            }

            return result;
        }

        public static List<Models.messages> getMessages(Guid group)
        {
            List<Models.messages> message = new List<Models.messages>();
            using (var context = new LibraryContext())
            {
                message = context.messages.Where(x=>x.group == group).ToList();



            }

            return message;
        }

    }
}
