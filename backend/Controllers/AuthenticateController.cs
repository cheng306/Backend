﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using backend.Models;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Authenticate")]
    public class AuthenticateController : Controller
    {
        readonly AppDatabase database;

        public AuthenticateController(AppDatabase database)
        {
            this.database = database;
        }

        [HttpPost("register")]
        public JwtResponse Register([FromBody] User user)
        {
            //get the token
            var jwt = new JwtSecurityToken();
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //add user to database
            database.Users.Add(user);
            database.SaveChanges();

            //return to frontend
            return new JwtResponse() {
                Token = encodedJwt
                ,FirstName = user.FirstName
                ,LastName = user.LastName
                ,UserName = user.UserName
            };
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginData loginData)
        {
            //get the login user
            var loginUser = database.Users.SingleOrDefault(user => user.UserName == loginData.UserName && user.Password == loginData.Password);

            if (loginUser == null)
            {
                return NotFound("Invalid Username or password");
            }
            else
            {
                //get the token
                var jwt = new JwtSecurityToken();
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                //get the response to frontend
                var response = new JwtResponse(){
                    Token = encodedJwt
                    ,FirstName = loginUser.FirstName
                    ,LastName = loginUser.LastName
                    ,UserName = loginUser.UserName  
                };

                return Ok(response);

            }
                

            
            //return Ok(CreateJwtPacket(user));
        }
    }
}