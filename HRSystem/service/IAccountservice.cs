﻿using HRSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.service
{
    public interface IAccountservice
    {
        Task<IdentityResult> CreateAccount(signupmodel signup);
        Task<SignInResult> signin(signinmodel si);
        Task<IdentityResult> addrole(rolemodel rolemodel);
        List<Applicationuser> getusers();
        Task<List<userroles>> getroles(string userid);
        Task updateuserrole(List<userroles> liuserrole);
        Task Logout();
    }
}
  