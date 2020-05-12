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
        IMapper _mapper;
        DatabaseContext _context;
        IUserRepository _repository;
        UserController _controller;

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
            var response = _controller.getListUser();

            // assert
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var userList = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(2, userList.Count);
        }


        [Fact]
        public void GetUserList_NotFound()
        {
            // act
            var response = _controller.getListUser();

            // assert
            Assert.IsType<NotFoundResult>(response.Result);
        }


        [Fact]
        public void GetUser()
        {
            // arrange
            var insertUser = new User { Name = "Jung" };
            _context.Users.Add(insertUser);
            _context.SaveChanges();

            // act
            var response = _controller.getUser(1);

            // assert
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var userList = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(insertUser.Name, userList.Name);
        }

        [Fact]
        public void GetUser_NotFound()
        {
            // act
            var response = _controller.getUser(1);

            // assert
            Assert.IsType<NotFoundResult>(response.Result);
            
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
