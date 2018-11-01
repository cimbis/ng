using Microsoft.EntityFrameworkCore;
using Ngtryout.DB;
using Ngtryout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ngtryout.Infrastructure
{
    public interface IDataRepository
    {
        Task<bool> AddDatapoint(IDatapoint data);
        Task<IEnumerable<IDatapoint>> GetAllDataPoints();
        Task<IDatapoint> GetDatapoint(string name);
        Task<bool> UpdateDatapoint(string id, string name, double value);
        Task<bool> DeleteDatapoint(string id);
    }

    public class DataRepository : IDataRepository
    {
        private readonly DataContext _ctx;

        public DataRepository(DataContext context)
        {
            _ctx = context;
        }

        public async Task<bool> AddDatapoint(IDatapoint data)
        {
            await _ctx.DataList.AddAsync(new DatapointEntity(data));
            var saved = await _ctx.SaveChangesAsync();
            return Convert.ToBoolean(saved);
        }

        public async Task<bool> DeleteDatapoint(string id)
        {
            var de = await _ctx.DataList
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            _ctx.DataList.Remove(de);

            var saved = await _ctx.SaveChangesAsync();
            return Convert.ToBoolean(saved);
        }

        public async Task<bool> UpdateDatapoint(
            string id,
            string name,
            double value)
        {
            var dp = await _ctx.DataList
                .Where(o => o.Id == id)
                .Select(o => new DatapointDomain(o.Name, o.RecordedAt, o.Value))
                .FirstOrDefaultAsync();

            dp.Name = name;
            dp.Value = value;

            var saved = await _ctx.SaveChangesAsync();
            return Convert.ToBoolean(saved);
        }

        public async Task<IEnumerable<IDatapoint>> GetAllDataPoints() =>
             await _ctx.DataList
                .Select(o => new DatapointDomain(o.Name, o.RecordedAt, o.Value))
                .ToListAsync();


        public async Task<IDatapoint> GetDatapoint(string id) =>
            await _ctx.DataList
            .Where(o => o.Id == id)
            .Select(o => new DatapointDomain(o.Name, o.RecordedAt, o.Value))
            .FirstOrDefaultAsync();
    }
}
