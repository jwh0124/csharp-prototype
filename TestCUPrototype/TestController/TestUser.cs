using AutoMapper;
using CUPrototype.Config;
using CUPrototype.Controller;
using CUPrototype.DTO;
using CUPrototype.Models;
using CUPrototype.Profiles;
using CUPrototype.Service;
using CUPrototype.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestCUPrototype.TestController
{
    public class TestUser : IDisposable
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IUserRepository _repository;
        private readonly UserController _controller;

        public TestUser()
        {
            _mapper = new MapperConfiguration(c => { c.AddProfile(new MapperProfiles()); }).CreateMapper();
            _context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("test").Options);
            _repository = new UserRepository(_context);
            _controller = new UserController(_repository, _mapper);
        }

        [Fact]
        public void GetUserList()
        {
            // arrange
            _context.Users.Add(new User { Name = "Jung" });
            _context.Users.Add(new User { Name = "Kim" });
            _context.SaveChanges();

            // act
            var response = _controller.GetUserList();

            // assert
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var userList = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(2, userList.Count);
        }


        [Fact]
        public void GetUserList_NotFound()
        {
            // act
            var response = _controller.GetUserList();

            // assert
            Assert.IsType<NotFoundResult>(response.Result);
        }


        [Fact]
        public void GetUser()
        {
            // arrange
            var getUser = new User { Name = "Jung" };
            _context.Users.Add(getUser);
            _context.SaveChanges();

            // act
            var response = _controller.GetUser(1);

            // assert
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var user = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(getUser.Name, user.Name);
        }

        [Fact]
        public void GetUser_NotFound()
        {
            // act
            var response = _controller.GetUser(1);

            // assert
            Assert.IsType<NotFoundResult>(response.Result);
            
        }

        [Fact]
        public void PostUser()
        {
            // arrange
            var insertUser = new UserDto { Name = "Jung" };

            // act
            var response = _controller.PostUser(insertUser);

            // assert
            var okResult = Assert.IsType<CreatedAtRouteResult>(response.Result);
            var user = Assert.IsType<UserDto>(_mapper.Map<UserDto>(okResult.Value));
            Assert.Equal(insertUser.Name, user.Name);

        }

        [Fact]
        public void PutUser()
        {
            // arrange
            var sourceUser = new User { Name = "Jung" };
            _context.Users.Add(sourceUser);
            _context.SaveChanges();
            var putUser = new UserDto { Name = "Kim" };

            // act
            var response = _controller.PutUser(sourceUser.Id, putUser);

            // assert
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public void DeleteUser()
        {
            // arrange
            var sourceUser = new User { Name = "Jung" };
            _context.Users.Add(sourceUser);
            _context.SaveChanges();

            // act
            var response = _controller.DeleteUser(sourceUser.Id);

            // assert
            Assert.IsType<NoContentResult>(response);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
