﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Infrastructure.Authentication
{
    public interface IPermissionService
    {
        Task<HashSet<string>> GetPermissionsAsync(Guid userId);
    }
}