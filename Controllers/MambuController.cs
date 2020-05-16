﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bugs.Models.Mambu;
using _4Bugs.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;

namespace _4Bugs.Controllers
{
    public class MambuController : Controller
    {
        const string baseUrl = "https://razerhackathon.sandbox.mambu.com/api/";

        public static string GetBranchID()
        {
            var client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(Helper.MAMBU_LOGIN, Helper.MAMBU_PASSWORD);
            var request = new RestRequest("/branches/" + Helper.MAMBU_LOGIN, Method.GET);
            IRestResponse response = client.Execute(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return obj["encodedKey"];
        }
        public static string CreateMambuClient()
        {
            MambuClient mambuClientInfo = new MambuClient();

           /*Testing data
            *mambuClientInfo.client.firstName = "Blah";
            mambuClientInfo.client.lastName = "Blah";
            mambuClientInfo.idDocuments[0].validUntil = "2022-02-01";
            mambuClientInfo.idDocuments[0].documentId = "S9812345A";*/

            mambuClientInfo.idDocuments[0].identificationDocumentTemplateKey = "8a8e867271bd280c0171bf7e4ec71b01"; //Hardcode dis shiz so everyone can verify by NRIC
            mambuClientInfo.idDocuments[0].documentType = "NRIC/Passport Number";
            mambuClientInfo.idDocuments[0].issuingAuthority = "Immigration Authority of Singapore";
           


            mambuClientInfo.client.preferredLanguage = "ENGLISH";
            mambuClientInfo.client.notes = "ENGLISH";

            mambuClientInfo.client.assignedBranchKey = GetBranchID();


            var client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(Helper.MAMBU_LOGIN, Helper.MAMBU_PASSWORD);
            var request = new RestRequest("/clients/", Method.POST);

            request.AddJsonBody(mambuClientInfo);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return null;
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            String client_id = obj["client"]["encodedKey"];
            //Save Client ID to USER
            return client_id;
        }  
        public static string CreateSavingsAccount(string clinetKey)
        {
            savingsAccount accountDetails = new savingsAccount();
            accountDetails.overdraftInterestSettings.interestRate = 5; // Changeable field in the future
            accountDetails.interestSettings.interestRate = "1.25";

            var client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(Helper.MAMBU_LOGIN, Helper.MAMBU_PASSWORD);
            var request = new RestRequest("/savings/", Method.POST);

            request.AddJsonBody(accountDetails);


            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return null;
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            String accountID = obj["savingsAccount"]["encodedKey"];
            //Save to AccountID
            return accountID;
        }

    }
}