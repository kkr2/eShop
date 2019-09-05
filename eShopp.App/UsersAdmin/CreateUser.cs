﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace eShop.App.UsersAdmin
{
    public class CreateUser
    {
        private UserManager<IdentityUser> _userManager;

        public CreateUser(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public class Request
        {
            public string UserName { get; set; }
        }


        public async Task<bool> Do(Request request)
        {
            var managerUser = new IdentityUser()
            {
                UserName = request.UserName
            };

             await _userManager.CreateAsync(managerUser, "password");

            
            var managerClaim = new Claim("Role", "Manager");

            
           await _userManager.AddClaimAsync(managerUser, managerClaim);

            return true;
        }


    }
}
