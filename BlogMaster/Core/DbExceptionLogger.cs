using BlogMaster.Application;
using BlogMaster.DataAccess;
using BlogMaster.Domain;

namespace BlogMaster.API.Core
{
    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly BMContext _context;

        public DbExceptionLogger(BMContext context)
        {
            _context = context;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
