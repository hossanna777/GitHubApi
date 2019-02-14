using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubDomain
{
    public class GitHubConfig
    {
        public string BaseURL { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string ClientId { get; set; }
        public int QueryDepth { get; set; } = 3;//default
    }
}
