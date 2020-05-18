using AutoMapper;
using CUPrototype.Config;
using CUPrototype.Profiles;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestCUPrototype.Config
{
    public class TestServiceProvider : IDisposable
    {
        public IMapper Mapper { get; private set; }
        public DatabaseContext Context { get; private set; }

        public TestServiceProvider()
        {
            Mapper = new MapperConfiguration(c => { c.AddProfile(new MapperProfiles()); }).CreateMapper();
            Context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("test").Options);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }
    }
}
