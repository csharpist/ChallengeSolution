using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseLibrary.Abstract;
using DatabaseLibrary.Conrete.Dto;
using DatabaseLibrary.Conrete.Entities;
using DatabaseLibrary.Infrastructure;

namespace WebApp.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<UserDto> Get()
        {
            return _userRepository.Users.ProjectTo<UserDto>();
        }

        public UserDto Get(int id)
        {
            return Mapper.Map<User, UserDto>(_userRepository.Users.Single(_ => _.Id == id));
        }

        public async Task Post([FromBody]UserDto user)
        {
            await _userRepository.SaveUserAsync(Mapper.Map<UserDto, User>(user));
        }

        public async Task Put([FromBody]UserDto user)
        {
            await _userRepository.SaveUserAsync(Mapper.Map<UserDto, User>(user));
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        protected override void Dispose(bool disposing)
        {
            _userRepository?.Dispose();
            base.Dispose(disposing);
        }
    }
}