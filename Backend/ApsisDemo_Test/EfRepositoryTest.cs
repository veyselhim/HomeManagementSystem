using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.EntityFramework;
using Entity.Concrete;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace ApsisDemo.Core_Test
{
    public class EfRepositoryTest
    {
        private List<Apartment> _apartments = new List<Apartment>();
        private readonly IRepository<Apartment> _repository;

        public EfRepositoryTest()
        {
            _apartments.Add(new Apartment{Type = "2+1",Id = 1});
            _apartments.Add(new Apartment { Type = "3+1", Id = 2 });

            Mock<IRepository<Apartment>> repository = new Mock<IRepository<Apartment>>();
            repository.Setup(x => x.GetAllAsync()).ReturnsAsync(_apartments);
            repository.Setup(x => x.DeleteAsync(It.IsAny<Apartment>()));
                repository.Setup(x => x.GetByIdAsync(x => x.Id == It.IsAny<int>())).ReturnsAsync((int i) => _apartments.FirstOrDefault(x => x.Id == i));
            repository.Setup(x => x.AddAsync(It.IsAny<Apartment>())).Callback((Apartment apartment) =>
            {
                   _apartments.Add(apartment);
            });

            _repository = repository.Object;
        }

        [Fact]
        public async Task RepositoryGetAll_Returns_List_Apartment()
        {
            //arrange
           

            //action
            var actual = await _repository.GetAllAsync();

            //assert
            Assert.IsType<List<Apartment>>(actual);
        }

        [Fact]
        public async Task RepositoryAdd()
        {
            //arrange

            //action
            await _repository.AddAsync(new Apartment {Id = 1});
            //assert
             Assert.True(_apartments is {Count: > 0});
            
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public async Task RepositoryGetById_returns_List_Apartments(int id)
        {
            //arrange

            //action
            await _repository.GetByIdAsync(x=>x.Id==id);
            //assert
            Assert.True(_apartments is { Count: > 0 });

        }

        [Fact]
        public async Task RepositoryDelete()
        {
            //arrange
            Apartment apartment = new Apartment{Id = 2};
            
            
            //action
            await _repository.DeleteAsync(apartment);
            //assert
            Assert.NotNull(apartment);

        }
    }
}
