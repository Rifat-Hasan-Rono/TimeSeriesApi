using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesApi.Interface
{
    public interface IReadingRepository
    {
        Task<IEnumerable<dynamic>> GetParam();
        Task<IEnumerable<dynamic>> TimeSeriesData(int buildingId, int objectId, int dataFieldId, DateTime from, DateTime to);
    }
}
