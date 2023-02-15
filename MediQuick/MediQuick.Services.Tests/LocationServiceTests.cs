using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Tests
{
    public class LocationServiceTests
    {
        [Test]
        public void CreateLocation_ShouldCreateLocation()
        {
            //Arrange
            Location location = new Location();

            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            LocationService locationService = new LocationService(locationRepositoryMock.Object, unitOfWorkMock.Object);

            locationService.CreateLocation(location);

            locationRepositoryMock.Verify(x => x.AddLocation(location), Times.Once);
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
