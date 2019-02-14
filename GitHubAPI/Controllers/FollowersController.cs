using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using GitHubDomain;
using GitHubService.Interfaces;

namespace GitHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly IConfiguration _config;       
        private readonly IFollowerService _followerService;
        public FollowersController(IConfiguration config, IFollowerService followerService)
        {
            _config = config;
            _followerService = followerService;         
        }
        [HttpGet]
        [Route("{id}/{queryDepth}")]
        public ActionResult<List<Follower>> Get(string id, int queryDepth)
        {
            return  _followerService.GetFollowers(id, queryDepth);
        }
    }
}