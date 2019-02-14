using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubDomain
{
   public class Follower
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Avatar_Url { get; set; }
        public string Gravatar_Id { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public string Followers_Url { get; set; }
        public string Gists_Url { get; set; }
        public string Starred_Url { get; set; }
        public string Subscriptions_Url { get; set; }
        public string Organizations_Url { get; set; }
        public string Events_Url { get; set; }
        public string Received_Events_Url { get; set; }
        public string Type { get; set; }
        public bool Site_Admin { get; set; }
        public List<Follower> Followers { get; set; }
    }
}
