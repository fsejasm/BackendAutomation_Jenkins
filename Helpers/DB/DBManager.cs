// <copyright file="DBManager.cs" company="Demo AF">
//     Test All rights reserved.
// </copyright>

namespace Demo.Helpers.DB
{
    using Demo.Config;
    using Demo.Helpers.DB.Queries;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Singleton DB Manager Class to provide reusable methods to connect and manage Databases from Automation Framework
    /// </summary>
    public sealed class DBManager
    {
        public string dataSource { get; set; }
        public string catalog { get; set; }
        public string credentials { get; set; }
        private SqlConnection connection;
        private string connectionStringOptions = "PersistSecurityInfo=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
        public Dictionary<string, List<string>> catalogMap { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DBManager" /> class.
        /// </summary>
        public DBManager()
        {
            IConfiguration configuration = AppConfig.GetConfig();
            dataSource = configuration["SQLServerDataSource"];
            catalog = configuration["SQLServerCatalog"];
            credentials = configuration["SQLServerConnectionCredentials"];
            string connectionString = $"Data Source = {dataSource}; Initial Catalog = {catalog}; {connectionStringOptions}; {credentials}";
            catalogMap = new Dictionary<string, List<string>>();
            connection = new SqlConnection(@connectionString);
            connection.Open();
        }

        /// <summary>
        /// This method should be called at the end of the execution of all tests in order to close the database connection
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();
        }
        /// <summary>
        /// This method executes a SQL Query on the database and returns a DataTable with the execution results
        /// </summary>
        /// <param name="sqlQuery">Standard SQL query string</param>
        /// <param name="logQuery">Used to log the query on application logs, true by default</param>
        /// <returns>a DataTable with the query results</returns>
        public DataTable ExecuteQuery(string sqlQuery, bool logQuery = true)
        {
            DataTable response = new DataTable();
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                if (logQuery)
                {
                    Log.Information($"Execute Query: {sqlQuery}");
                }
                using (SqlDataReader queryResponse = command.ExecuteReader()) response.Load(queryResponse);
            }
            return response;
        }
    }
}
