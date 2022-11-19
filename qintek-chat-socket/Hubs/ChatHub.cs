using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace qintek_chat_socket.Hubs
{
    public class ChatHub : Hub
    {

        public List<UserLogged> lsUsers = new List<UserLogged>();


        /// <summary>
        /// Al conectarse se envian al usuario logeado todos los usuarios conectados al momento
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            string logeado = "";

            Clients.All.SendAsync("UserList", qintek_chat_bd.Methods.users.GetUser(0));

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
          //  qintek_chat_bd.Methods.users.RemoveUser(Context.ConnectionId);
           // Clients.All.SendAsync("UserList", qintek_chat_bd.Methods.users.GetUser(0));

            string desconectado = Context.ConnectionId;
            return base.OnDisconnectedAsync(exception);

        }

        public async Task GetUnreadMessageByGrop(int userLogeado, int userChat)
        {

            qintek_chat_bd.Models.groups group = qintek_chat_bd.Methods.groups.setGroup(userLogeado, userChat);

            var result = qintek_chat_bd.Methods.users.GetUnreadMessageByGroup(userLogeado, group.grupo);

            await Clients.Client(result.cnnID).SendAsync("GetUnreadMessages", result);

        }
        // cuando se agrega el usuario, se envian a todos los usuarios conectados que existe un nuevo inicio de sesion
        public async Task AddUser(int userId, string name, string nick)
        {
            var agregado = qintek_chat_bd.Methods.users.AddUser(userId, name, nick, Context.ConnectionId);

            

            if (agregado != null)
            {
                var usersLogeados = qintek_chat_bd.Methods.users.GetUser(userId);

                foreach (var user in usersLogeados)
                {
                    qintek_chat_bd.Models.groups group = qintek_chat_bd.Methods.groups.setGroup(userId, user.id);
                    await Groups.AddToGroupAsync(Context.ConnectionId, group.grupo.ToString());
                    await Clients.Client(agregado.connectionId).SendAsync("NewUser", qintek_chat_bd.Methods.users.GetUserByID(userId));

                }

               

                
            }

        }



        public async Task JoinGroup(int userIdA, int userIdB)
        {

            qintek_chat_bd.Models.groups group = qintek_chat_bd.Methods.groups.setGroup(userIdA, userIdB);

          //  await Groups.AddToGroupAsync(Context.ConnectionId, group.grupo.ToString());

            await Clients.Client(Context.ConnectionId).SendAsync("GetGroup", group.grupo.ToString());

            await Clients.Client(Context.ConnectionId).SendAsync("GetMessages", qintek_chat_bd.Methods.messages.getMessages(group.grupo));

        }

        public async Task LeaveGroup(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("LeftUser", $"{userName} salió del canal");
        }

        public async Task SendMessage(string group, int userID, string message)
        {
            qintek_chat_bd.Models.messages ms = qintek_chat_bd.Methods.messages.addMessage(new Guid(group), userID, message);
            qintek_chat_bd.Methods.users.UpdateMessageUnread(userID, new Guid(group));

            await Clients.Group(group).SendAsync("NewMessage", ms);
        }
    }

    //public record NewMessage(string UserName, string Message, string GroupName);

    public class NewMessage
    {
        public string UserName;
        public string Message;
        public string GroupName;
    }

    public class UserLogged
    {
        public int idUser;
        public string name;
    }
}
