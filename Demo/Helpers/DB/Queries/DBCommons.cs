using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Helpers.DB.Queries
{
    class DBCommons
    {
        public static string mapCatalogSQLQuery = @"select tab.name as tableName,col.name as columnName
            from sys.tables as tab inner join sys.columns as col on tab.object_id = col.object_id
            order by tableName, col.column_id";


        public static string SelectSettingGroupByName =
            @"SELECT [Name]
                FROM [Demo].[dbo].[TableDemo]
                WHERE Name = '{0}'";
    }
}
