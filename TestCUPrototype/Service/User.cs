using CUPrototype.Controller;
using CUPrototype.DTO;
using CUPrototype.Service;
using CUPrototype.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestCUPrototype.Config;
using Xunit;

namespace TestCUPrototype.Service
{
    public class User : TestServiceProvider, IDisposable
    {
        private readonly IUserRepository _repository;
        private readonly UserController _controller;

        public User()
        {

            _repository = new UserRepository(Context);
            _controller = new UserController(_repository, Mapper);
        }

        [Fact]
        public void GetUserList()
        {
            // arrange
            Context.Users.Add(new CUPrototype.Models.User { Name = "Jung" });
            Context.Users.Add(new CUPrototype.Models.User { Name = "Kim" });
            Context.SaveChanges();

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
            var getUser = new CUPrototype.Models.User { Name = "Jung" };
            Context.Users.Add(getUser);
            Context.SaveChanges();

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
            var user = Assert.IsType<UserDto>(Mapper.Map<UserDto>(okResult.Value));
            Assert.Equal(insertUser.Name, user.Name);

        }

        [Fact]
        public void PutUser()
        {
            // arrange
            var sourceUser = new CUPrototype.Models.User { Name = "Jung" };
            Context.Users.Add(sourceUser);
            Context.SaveChanges();
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
            var sourceUser = new CUPrototype.Models.User { Name = "Jung" };
            Context.Users.Add(sourceUser);
            Context.SaveChanges();

            // act
            var response = _controller.DeleteUser(sourceUser.Id);

            // assert
            Assert.IsType<NoContentResult>(response);
        }
    }
}
