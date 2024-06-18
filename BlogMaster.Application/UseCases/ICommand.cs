using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases
{
    public interface ICommand<TData> : IUseCase
    {
        public void Execute(TData data);
    }
}
