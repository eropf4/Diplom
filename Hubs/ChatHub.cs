using Diplom.DBContext;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Diplom.Auth.Common;
using Microsoft.AspNetCore.Authorization;
using Diplom.Controllers;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;
        private readonly ApplicationContext _applicationContext;

        public ChatHub(IDictionary<string, UserConnection> connections, IOptions<AuthOptions> authOptions, ApplicationContext context)
        {
            _botUser = "MyChat Bot";
            _connections = connections;
            _applicationContext = context;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} has left");
                SendUsersConnected(userConnection.Room);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            var auth = new AuthentificatorUser(_applicationContext);
            var user1 = auth.AuthenticatieUser(userConnection.User, userConnection.Room);
            var userId = user1.Id.ToString();

            var roomName = user1.ChatRooms.First().Name.ToString();

            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            _connections[Context.ConnectionId] = new UserConnection { Room = roomName, User = userId };

            await Clients.Group(roomName).SendAsync("ReceiveMessage", _botUser, $"{user1.NickName} has joined {roomName}");
            await SendUsersConnected(roomName);
        }

        public async Task SendMessage(string message)
        {

            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                var user = _applicationContext.Accounts.FirstOrDefault(x => userConnection.User == x.Id.ToString());
                var userName = user.NickName;
                await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", userName, message);

                var bdMessage = new Models.Message() { messageCreator = user, Text = message, Time = DateTime.Now };

                var room = _applicationContext.ChatRooms.Include(c => c.Messages).SingleOrDefault(x => x.Name == userConnection.Room);
                    room.Messages.Add(bdMessage);
                await _applicationContext.SaveChangesAsync();
            }
        }

        public Task SendUsersConnected(string room)
        {
            var usersIdList = _connections.Values
                .Where(c => c.Room == room)
                .Select(c => c.User).ToList();
            var userNames = _applicationContext.Accounts.Where(x => usersIdList.Contains(x.Id.ToString())).Select(x => x.NickName);

            return Clients.Group(room).SendAsync("UsersInRoom", userNames);
        }
    }

}
