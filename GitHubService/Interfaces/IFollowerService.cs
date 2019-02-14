using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubDomain;

namespace GitHubService.Interfaces
{
    public interface IFollowerService
    {     
        List<Follower> GetFollowers(string id, int queryDepth);
    }
}