using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qintek_chat_bd.Methods
{
    public class groups
    {
        public static int getGroup(int idUserA, int idUserB)
        {
            var result = existGroupByUsers(idUserA, idUserB);

            return result == null ? 0 : result.groupID;
        }

        public static Models.groups existGroupByUsers(int idUserA, int idUserB)
        {
            Models.groups existUser = null;
            using (var context = new LibraryContext())
            {
                existUser = context.groups.Where(x => x.userID_A == idUserA && x.userID_B == idUserB).FirstOrDefault();
                if (existUser == null)
                {
                    existUser = context.groups.Where(x => x.userID_A == idUserB && x.userID_B == idUserA).FirstOrDefault();
                }
            }
            return existUser;
        }
        public static Models.groups setGroup(int idUserA, int idUserB)
        {
            var grupo_ = existGroupByUsers(idUserA, idUserB);
            using (var context = new LibraryContext())
            {
                if(grupo_ == null)
                {
                    Models.groups group = new Models.groups();
                    group.dateCreated = DateTime.Now;
                    group.grupo = Guid.NewGuid();
                    group.userID_A = idUserA;
                    group.userID_B = idUserB;
                    context.groups.Add(group);
                    context.SaveChanges();

                    grupo_ = group;
                } else
                {
                    return grupo_;
                }
               // Models.groups grupo = context.groups.Where(x => x.groupID == grupo_.groupID).FirstOrDefault();


            }

            return grupo_;
        }
    }
}
