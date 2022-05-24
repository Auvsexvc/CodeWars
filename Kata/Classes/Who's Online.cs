using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// You have a group chat application, but who is online!?
    /// You want to show your users which of their friends are online and available to chat!
    /// Given an input of an array of objects containing usernames, status and time since last activity (in mins), create a function to work out who is online, offline and away.
    /// If someone is online but their lastActivity was more than 10 minutes ago they are to be considered away.
    /// username will always be a string, status will always be either 'online' or 'offline' (UserStatus enum in C#) and lastActivity will always be number >= 0.
    /// Finally, if you have no friends in your chat application, the input will be an empty array []. In this case you should return an empty object {} (empty Dictionary in C#).
    /// </summary>

    internal class Who_s_Online
    {
        // Reference:
        public enum UserStatus
        {
            Online,
            Offline,
            Away
        }

        public class User
        {
            public string Username;
            public UserStatus Status;
            public int LastActivity;

            public User(string username, UserStatus status, int lastActivity)
            {
                Username = username;
                Status = status;
                LastActivity = lastActivity;
            }
        }

        public static Dictionary<UserStatus, IEnumerable<string>> WhosOnline(User[] friends)
        {
            if (!friends.Any())
                return new Dictionary<UserStatus, IEnumerable<string>>();

            friends.Select(friend => friend.Status == UserStatus.Online && friend.LastActivity > 10 ? friend.Status = UserStatus.Away : friend.Status).ToList();

            return friends.Select(f => f.Status).Distinct().ToDictionary(k => k, u => friends.Where(f => f.Status == u).Select(un => un.Username));
        }
    }
}