using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Demo.Helpers.DB.Queries;
using Demo.Helpers.DB;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using Demo.Config;
using Demo.Helpers.Utils;
using System.Data;

namespace DemoBackendAutomation.StepDefinitions
{
    [Binding]
    public sealed class GetStepDefinitions
    {

        [Given(@"I have a endpoint /get - Positive")]
        public static async Task GivenIHaveAEndpointGetAsyncPositive()
        {
            IConfiguration configuration = AppConfig.GetConfig();

            //Sample interaction with petstore API
            var client = new RestClient("http://petstore.swagger.io");
            var request = new RestRequest("v2/store/inventory");
            var response = client.ExecuteGet(request);
            Console.WriteLine(response.StatusCode);
            Assert.True(response.StatusDescription.Equals(configuration["StatusOK"]));

        }

        [Given(@"I have a endpoint /get - Negative")]
        public static async Task GivenIHaveAEndpointGetAsyncNegative()
        {
            IConfiguration configuration = AppConfig.GetConfig();

            //Sample interaction with petstore API
            var client = new RestClient("http://petstore.swagger.io");
            var request = new RestRequest("v2/store/inventory");
            var response = client.ExecuteGet(request);
            Console.WriteLine(response.StatusCode);
            Assert.True(response.StatusDescription.Contains(configuration["Status401Unauthorized"]));

        }


        [Then(@"I verify in the Database - Positive")]
        public static async Task ThenIVerifyInfoInTheDatabasePositive()
        {
            IConfiguration configuration = AppConfig.GetConfig();
            
            
            DBManager dbMan = new DBManager();
            DataTable tableResponse = dbMan.ExecuteQuery(DBCommons.SelectSettingGroupByName.StringFormat(configuration["TableName"]));
            int countLines = tableResponse.Rows.Count;
            Assert.True(countLines > 0, $" "+ configuration["TableName"] + ", is not part of the Table Demo, Expected 1 Got {countLines}");
            dbMan.CloseConnection();

        }

        [Then(@"I verify data in the Database - Negative")]
        public static async Task ThenIVerifyInfoInTheDatabaseNegative()
        {
            IConfiguration configuration = AppConfig.GetConfig();

            DBManager dbMan = new DBManager();
            DataTable tableResponse = dbMan.ExecuteQuery(DBCommons.SelectSettingGroupByName.StringFormat(configuration["TableName"]));
            int countLines = tableResponse.Rows.Count;
            Assert.True(countLines > 1, $" "+ configuration["TableName"] + ", is not part of the Table Demo, Expected 0 Got {countLines}");
            dbMan.CloseConnection();

        }
    }
}