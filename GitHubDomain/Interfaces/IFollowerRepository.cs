using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubDomain.Interfaces
{
    public interface IFollowerRepository
    {
        List<Follower> GetFollowers(string id);
    }
}
