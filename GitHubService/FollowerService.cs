using GitHubDomain;
using GitHubDomain.Interfaces;
using GitHubService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubService
{
    public class FollowerService : IFollowerService
    {
        private IFollowerRepository _followerRepository;
        private int _queryCounter = 0;
        private int _queryDepth;
        public FollowerService(IFollowerRepository followerRepository)
        {
            _followerRepository = followerRepository ?? throw new ArgumentNullException("followerRepository");
        }

        public List<Follower> GetFollowers(string id, int queryDepth)
        {
            _queryDepth = queryDepth;
            var followers = this.SearchFollowers(id);
            _queryCounter += 1;
            GetFollowersRecursively(followers);
            return followers;
        }

        private List<Follower> SearchFollowers(string id)
        {
           return _followerRepository.GetFollowers(id);
        }

        private void GetFollowersRecursively(List<Follower> followers)
        {
            while (_queryCounter < _queryDepth)
            {
                foreach (var f in followers)
                {
                    f.Followers = this.SearchFollowers(f.Login);
                }
                _queryCounter += 1;
                var nextFollowers = followers.SelectMany(x => x.Followers).ToList();
                GetFollowersRecursively(nextFollowers);
            }
        }
    }
}
