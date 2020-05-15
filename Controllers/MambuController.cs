using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bugs.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

namespace _4Bugs.Controllers
{
    public class MambuController : Controller
    {
        const string baseUrl = "https://razerhackathon.sandbox.mambu.com/api/";

        [HttpPost]
        public string GetBranchID(int id, IFormCollection collection)
        {
            var client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(Helper.MAMBU_LOGIN, Helper.MAMBU_PASSWORD);
            var request = new RestRequest("/branches/" + Helper.MAMBU_LOGIN, Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content; // {"message":" created."}

            return content;
        }
    }
}