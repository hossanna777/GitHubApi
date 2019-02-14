# GitHubAPI Followers

REST based endpoint that loads a given GitHub users followers and their followers followers 

## Built With

* Visual Studio 2017 - C# .NET Core 2.1 

## Instructions
Start VS project GitHubApi. Hit endpoint https://localhost:44336/api/followers/{github_id}/{queryDepth} with your favorite REST endpoint browser tool
* **github_id (string)**- GitHub user id whose followers you want to load.  
* **queryDepth (integer)** - Depth of follower levels you want to return.
* **access_token** - In the root of the GitHubAPI project, inside of the appsettings.json file, enter this access token (b416658-04253fdb-3fe215d22bd31-591aa4f7-e320) WITHOUT the dashes, in the GitHubApi->access_token section (the default value is ADD OAuth ACCESS TOKEN HERE).

## Versioning

1.0

## Authors

* **Bill Adams** - CenturyLink Code Challange

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


