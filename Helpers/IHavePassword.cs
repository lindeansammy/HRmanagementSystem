﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTeamProject.Helpers
{
    public interface IHavePassword
    {
        System.Security.SecureString Password { get; }
    }
}
