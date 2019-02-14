using GitHubDomain;
using GitHubDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubData.Repository
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly GitHubConfig _config;
        public FollowerRepository(GitHubConfig config)
        {
            _config = config ?? throw new ArgumentNullException("config");
        }

        public List<Follower> GetFollowers(string id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"token {this._config.AccessToken}");
                client.DefaultRequestHeaders.Add("User-Agent", Guid.NewGuid().ToString());
                var response = client.GetAsync(this._config.BaseURL + $"users/{id}/followers").Result;
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var data = response.Content.ReadAsStringAsync().Result;
                        var followers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Follower>>(data);
                        return followers.Any() ? followers.Take(5).ToList() : new List<Follower>();
                    case HttpStatusCode.NotFound:
                        return new List<Follower>();
                    default:
                        throw new Exception($"An error occurred while trying to retrieve GitHub followers for {id}");

                }
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while trying to retrieve GitHub followers for {id}");
            }
        }

    }
}
