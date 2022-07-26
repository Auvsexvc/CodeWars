using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class KataSocialNetwork
    {
        public interface ISocialNetwork
        {
            int MemberCount { get; }

            IMember AddMember(string firstName, string lastName, string city, string country);

            IEnumerable<IMember> FindMember(string search);

            IMember FindMemberById(int id);
        }

        public interface IMember
        {
            IEnumerable<IMember> Friends { get; }
            int Id { get; }
            IEnumerable<IMember> Pending { get; }
            IEnumerable<IPost> Posts { get; }
            IMemberProfile Profile { get; }

            void AddFriendRequest(IMember from);

            IPost AddPost(string message);

            void ConfirmFriend(IMember member);

            IEnumerable<IPost> GetFeed();

            IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null);

            void RemoveFriend(IMember member);

            void RemoveFriendRequest(IMember member);

            void RemovePost(int id);
        }

        public interface IMemberProfile
        {
            string City { get; set; }
            string Country { get; set; }
            string Firstname { get; set; }
            string Lastname { get; set; }
            int MemberId { get; set; }
        }

        public interface IPost
        {
            DateTime Date { get; set; }
            int Id { get; set; }
            int Likes { get; set; }
            IMember Member { get; set; }
            string Message { get; set; }
        }

        public static class IdGenerator
        {
            public static int GetId<T>()
            {
                return 0;
            }
        }

        public class SocialNetwork : ISocialNetwork
        {
            private readonly List<IMember> _memberList;

            public int MemberCount => _memberList.Count;

            public SocialNetwork()
            {
                _memberList = new List<IMember>();
            }

            public IMember AddMember(string firstName, string lastName, string city, string country)
            {
                IMember member = new Member(firstName, lastName, city, country);
                _memberList.Add(member);

                return member;
            }

            public IMember FindMemberById(int id) =>
                _memberList.SingleOrDefault(m => m.Id == id);

            public IEnumerable<IMember> FindMember(string search) =>
                _memberList.Where(m => m.Profile.Firstname.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || m.Profile.Lastname.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || m.Profile.City.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || m.Profile.Country.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        public class Member : IMember
        {
            private readonly List<IMember> _pending;
            private readonly List<IMember> _friends;
            private readonly List<IPost> _posts;

            public int Id { get; }
            public IMemberProfile Profile { get; }
            public IEnumerable<IMember> Friends => _friends;
            public IEnumerable<IMember> Pending => _pending;
            public IEnumerable<IPost> Posts => _posts;

            public Member(string firstName, string lastName, string city, string country)
            {
                Id = IdGenerator.GetId<IMember>();
                Profile = new MemberProfile()
                {
                    MemberId = Id,
                    City = city,
                    Country = country,
                    Firstname = firstName,
                    Lastname = lastName
                };

                _pending = new();
                _friends = new();
                _posts = new();
            }

            public void AddFriendRequest(IMember from)
            {
                if (!_friends.Contains(from) && !_pending.Contains(from) && from != this)
                {
                    _pending.Add(from);
                    from.AddFriendRequest(this);
                }
            }

            public void ConfirmFriend(IMember member)
            {
                if (!_friends.Contains(member) && _pending.Contains(member) && member != this)
                {
                    _friends.Add(member);
                    member.ConfirmFriend(this);
                    RemoveFriendRequest(member);
                }
            }

            public void RemoveFriendRequest(IMember member)
            {
                if (_pending.Contains(member) && member != this)
                {
                    _pending.Remove(member);
                    member.RemoveFriendRequest(this);
                }
            }

            public void RemoveFriend(IMember member)
            {
                if (_friends.Contains(member) && member != this)
                {
                    _friends.Remove(member);
                    member.RemoveFriend(this);
                }
            }

            public IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null)
            {
                List<IMember> friends = _friends;

                while (level > 1)
                {
                    friends = friends.Concat(friends.SelectMany(m => m.Friends.Except(friends))).ToList();
                    level--;
                }

                return friends.Where(m => m.Id != Id).Distinct();
            }

            public IPost AddPost(string message)
            {
                IPost newPost = new Post()
                {
                    Id = IdGenerator.GetId<IPost>(),
                    Member = this,
                    Message = message,
                    Date = DateTime.Now,
                    Likes = 0
                };

                _posts.Add(newPost);

                return newPost;
            }

            public void RemovePost(int id)
            {
                IPost post = _posts.Find(p => p.Id == id);

                if (post != null)
                {
                    _posts.Remove(post);
                }
            }

            public IEnumerable<IPost> GetFeed() =>
                _posts.Concat(GetFriends().Where(m => m.Id != Id).SelectMany(m => m.Posts)).OrderBy(p => p.Id);
        }

        public class MemberProfile : IMemberProfile
        {
            public int MemberId { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }

        public class Post : IPost
        {
            public int Id { get; set; }
            public IMember Member { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public int Likes { get; set; }
        }
    }
}