using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPOS.Data;
using WebPOS.Models;

namespace WebPOS.Controllers
{
    public interface ISystemLogService
    {
        Task<SystemLog> AddLog(string message, string userId);
    }

    public class SystemLogContoller : ISystemLogService
    {
        private readonly AppDbContext _db;
        public SystemLogContoller(AppDbContext db)
        {
            _db = db;
        }

        public async Task<SystemLog> AddLog(string message, string id)
        {

            var log = new SystemLog()
            {
                Details = message,
                UserId = id,
            };
            await _db.systemLogs.AddAsync(log);
            await _db.SaveChangesAsync();
            return log;
        }
    }
}
