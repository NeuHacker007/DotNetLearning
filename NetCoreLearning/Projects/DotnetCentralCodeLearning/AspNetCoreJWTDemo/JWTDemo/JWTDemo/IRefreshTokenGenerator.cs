﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo
{
    public interface IRefreshTokenGenerator
    {
        string GenerateToken();
    }
}
