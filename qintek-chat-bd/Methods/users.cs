using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qintek_chat_bd.Methods
{
    public class users
    {
        public static bool RemoveUser(string connectionID)
        {
            bool resultado = false;
            try
            {
                using (var context = new LibraryContext())
                {
                    Models.users existUser = context.users.Where(x => x.connectionId == connectionID).FirstOrDefault();
                    if (existUser != null)
                    {
                        context.users.Remove(existUser);
                        context.SaveChanges();
                    }


                    // context.Database.EnsureCreated();

                    resultado = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public static Models.users GetUserByID(int idUserLogeado)
        {
            Models.users response = new Models.users();

            using (var context = new LibraryContext())
            {
                response = context.users.Where(x => x.id == idUserLogeado).FirstOrDefault();
            }

            return response;
        }
        public static List<Models.users> GetUser(int idUserLogeado)
        {
            List<Models.users> response = new List<Models.users>();

            using (var context = new LibraryContext())
            {
                response = context.users.Where(x => x.id != idUserLogeado).ToList();
            }

            return response;
        }
        public static void markReaded(int userid, Guid group)
        {
            try
            {
                using (var context = new LibraryContext())
                {



                    var messageUnread = context.messages.Where(x => x.group == group && x.userID == userid && x.readed == false).ToList();

                    messageUnread.ForEach(x => x.readed = true);
                    context.SaveChanges();
                


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Models.resultUnread GetUnreadMessageByGroup(int userid, Guid group)
        {
            Models.resultUnread resultado = new Models.resultUnread();
            try
            {
                using (var context = new LibraryContext())
                {

                    var toUser = context.groups.Where(x => x.grupo == group).FirstOrDefault();
                    var userIDTo = 0;
                    if (toUser.userID_A == userid)
                    {
                        userIDTo = toUser.userID_B;
                    }
                    else if (toUser.userID_B == userid)
                    {
                        userIDTo = toUser.userID_A;
                    }
                    var messageUnread = context.messages.Where(x => x.group == group && x.userID == userid && x.readed == false).ToList();
                    var user = context.users.Where(x => x.id == userid).FirstOrDefault();

                    resultado.userId = userid;
                    resultado.unread = messageUnread.Count;
                    //resultado.cnnID = user.connectionId;

            
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public static bool UpdateMessageUnread(int userid, Guid group)
        {
            bool resultado = false;
            try
            {
                using (var context = new LibraryContext())
                {
                   
                    var toUser = context.groups.Where(x => x.grupo == group).FirstOrDefault();
                    var userIDTo = 0;
                    if(toUser.userID_A == userid)
                    {
                        userIDTo = toUser.userID_B;
                    } else if(toUser.userID_B == userid)
                    {
                        userIDTo = toUser.userID_A;
                    }
                    var messageUnread = context.messages.Where(x => x.group == group && x.userID == userid).ToList();
                    Models.users existUser = context.users.Where(x => x.id == userid).FirstOrDefault();
                    if (!(existUser == null))
                    {

                        existUser.messages = messageUnread.Count;
                        context.SaveChanges();
                    }


                    resultado = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public static Models.users AddUser(int id, string name, string nick, string connectionID)
        {
            Models.users resultado = null;
            try
            {
                using (var context = new LibraryContext())
                {
                    Models.users existUser = context.users.Where(x => x.id == id).FirstOrDefault();
                    if (existUser == null)
                    {
                        Models.users userAdd = new Models.users();
                        userAdd.id = id;
                        userAdd.name = name;
                        userAdd.nick = nick;
                        userAdd.dateLogged = DateTime.Now;
                        userAdd.connectionId = connectionID;
                        userAdd.messages = 0;
                        context.users.Add(userAdd);
                        context.SaveChanges();
                        resultado = userAdd;
                    } else
                    {
                        existUser.connectionId = connectionID;
                        context.SaveChanges();
                        resultado = existUser;
                    }
                 


                    // context.Database.EnsureCreated();

                    
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
    }
}
