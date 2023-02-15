using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Tests
{
    public class HospitalServiceTests
    {
        [Test]
        public void GetAllHospitals_ShouldReturnHospitals()
        {
            //Arrange
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<ILocationService> locationServiceMock = new Mock<ILocationService>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            HospitalService hospitalService = new HospitalService(hospitalRepositoryMock.Object, locationServiceMock.Object, unitOfWorkMock.Object);

            List<Hospital> hospitals = new List<Hospital>() { new Hospital() };

            hospitalRepositoryMock.Setup(x => x.GetAllHospitals()).Returns(hospitals);

            //Act
            List<Hospital> resultHospitals = hospitalService.GetAllHospitals();

            //Assert
            Assert.That(hospitals, Is.EqualTo(resultHospitals));
        }

        [Test]
        public void CreateHospital_NullName_ShouldThrow()
        {
            //Arrange
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<ILocationService> locationServiceMock = new Mock<ILocationService>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            HospitalService hospitalService = new HospitalService(hospitalRepositoryMock.Object, locationServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() => hospitalService.CreateHospital(null, 4, 5));

            Assert.That("Name cannot be empty!", Is.EqualTo(exception.Message));
        }

        [Test]
        public void CreateHospital_ShouldCreateHospital()
        {
            //Arrange
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<ILocationService> locationServiceMock = new Mock<ILocationService>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            HospitalService hospitalService = new HospitalService(hospitalRepositoryMock.Object, locationServiceMock.Object, unitOfWorkMock.Object);

            //Act
            hospitalService.CreateHospital("Kanef", 4, 5);

            //Assert
            locationServiceMock.Verify(x => x.CreateLocation(It.IsAny<Location>()), Times.Once);
            hospitalRepositoryMock.Verify(x => x.AddHospital(It.IsAny<Hospital>()), Times.Once);
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void GetHospitalById_ShouldGiveHospital()
        {
            //Arrange
            int hospitalId = 3;
            Hospital hospital = new Hospital();

            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<ILocationService> locationServiceMock = new Mock<ILocationService>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            HospitalService hospitalService = new HospitalService(hospitalRepositoryMock.Object, locationServiceMock.Object, unitOfWorkMock.Object);

            hospitalRepositoryMock.Setup(x => x.GetHospitalById(hospitalId)).Returns(hospital);

            //Act
            Hospital resultHospital = hospitalService.GetHospitalById(hospitalId);

            //Assert

            Assert.That(hospital, Is.EqualTo(resultHospital));
        }
    }
}
