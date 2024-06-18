using BlogMaster.Application;
using BlogMaster.DataAccess;
using Newtonsoft.Json;

namespace BlogMaster.API.Core
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private readonly BMContext _context;

        public DbUseCaseLogger(BMContext context)
        {
            _context = context;
        }
        public void Log(UseCaseLog log)
        {
            Domain.UseCaseLog newLog = new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            };
            

            _context.UseCaseLogs.Add(newLog);
            _context.SaveChanges();
        }
    }
}
