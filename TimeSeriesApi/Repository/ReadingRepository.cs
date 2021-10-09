using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesApi.Gateway;
using TimeSeriesApi.Interface;

namespace TimeSeriesApi.Repository
{
    public class ReadingRepository : IReadingRepository
    {
        public async Task<IEnumerable<dynamic>> GetParam()
        {
            return await ReadingGateway.GetParam();
        }

        public async Task<IEnumerable<dynamic>> TimeSeriesData(int buildingId, int objectId, int dataFieldId, DateTime from, DateTime to)
        {
            return await ReadingGateway.TimeSeriesData(buildingId, objectId, dataFieldId, from, to);
        }
    }
}
