﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaster.Application.UseCases
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }

    }
}

