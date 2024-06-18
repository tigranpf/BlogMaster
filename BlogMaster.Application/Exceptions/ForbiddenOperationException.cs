using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.Exceptions
{
    public class ForbiddenOperationException : Exception
    {
        public string User { get; }
        public string UseCase { get; }

        public ForbiddenOperationException(string useCase, string user) :
            base("User: " + user + " doesen't have right to execute: " + useCase + ".")
        {
            User = user;
            UseCase = useCase;
        }
    }
}
