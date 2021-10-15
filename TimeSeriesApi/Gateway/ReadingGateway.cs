using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesApi.Gateway
{
    public class ReadingGateway
    {
        private static readonly string ConnectionString = @"Data Source=DESKTOP-JOALEOP\SQLEXPRESS; Initial Catalog=s3assessment;  Persist Security Info=True; User ID=sa; Password=12345678";

        public static async Task<List<dynamic>> GetParam()
        {
            string query = @"SELECT Id,Name FROM Building ";
            query += @"SELECT Id,Name FROM Object ";
            query += @"SELECT Id,Name FROM DataField ";
            using IDbConnection con = new SqlConnection(ConnectionString);
            List<dynamic> buildings = new List<dynamic>();
            List<dynamic> objects = new List<dynamic>();
            List<dynamic> dataFields = new List<dynamic>();
            using (var multi = await con.QueryMultipleAsync(query, null))
            {
                buildings = multi.Read<dynamic>().ToList();
                objects = multi.Read<dynamic>().ToList();
                dataFields = multi.Read<dynamic>().ToList();
            }
            return new List<dynamic>() { buildings, objects, dataFields };
        }

        public static async Task<object[]> TimeSeriesData(int buildingId, int objectId, int dataFieldId, DateTime from, DateTime to)
        {
            string query = @"Select DATEDIFF_BIG(ms, DATEFROMPARTS(1970, 1, 1), Timestamp) 'Timestamp',Value From Reading Where ";
            if (buildingId > 0) query += "BuildingId=" + buildingId + " And ";
            if (objectId > 0) query += "ObjectId=" + objectId + " And ";
            if (dataFieldId > 0) query += "DataFieldId=" + dataFieldId + " And ";
            query += "Timestamp between '" + from + "' And '" + to + "' Order By Timestamp";
            using IDbConnection con = new SqlConnection(ConnectionString);
            return (await con.QueryAsync(query, new DynamicParameters())).
                Select(d => new object[] { d.Timestamp, d.Value }).ToArray();
        }
    }
}
