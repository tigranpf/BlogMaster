using BlogMaster.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly BMContext _context;

        protected EfUseCase(BMContext context)
        {
            _context = context;
        }

        protected BMContext Context => _context;
    }
}
