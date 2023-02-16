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
    public class AmbulanceServiceTests
    {
        [Test]
        public void GetAmbulanceByUserId_ShouldWorkCorrectly()
        {
            //Arrange
            int userId = 3;
            Ambulance ambulance = new Ambulance(); 

            Mock<IAmbulanceRepository> ambulanceRepositoryMock = new Mock<IAmbulanceRepository>();
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<IPatientService> patientServiceMock = new Mock<IPatientService>();
            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            AmbulanceService ambulanceService =
                new AmbulanceService(ambulanceRepositoryMock.Object, locationRepositoryMock.Object, hospitalRepositoryMock.Object,
                                     patientServiceMock.Object, patientRepositoryMock.Object, unitOfWorkMock.Object);

            ambulanceRepositoryMock.Setup(x => x.GetByUserId(userId)).Returns(ambulance);

            //Act
            Ambulance result = ambulanceService.GetAmbulanceByUserId(userId);

            //Assert
            Assert.That(ambulance, Is.EqualTo(result));
        }

        [Test]
        public void GetAmbulanceById_ShouldWorkCorrectly()
        {
            //Arrange
            int id = 3;
            Ambulance ambulance = new Ambulance();

            Mock<IAmbulanceRepository> ambulanceRepositoryMock = new Mock<IAmbulanceRepository>();
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<IPatientService> patientServiceMock = new Mock<IPatientService>();
            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            AmbulanceService ambulanceService =
                new AmbulanceService(ambulanceRepositoryMock.Object, locationRepositoryMock.Object, hospitalRepositoryMock.Object,
                                     patientServiceMock.Object, patientRepositoryMock.Object, unitOfWorkMock.Object);

            ambulanceRepositoryMock.Setup(x => x.GetById(id)).Returns(ambulance);

            //Act
            Ambulance result = ambulanceService.GetAmbulanceById(id);

            //Assert
            Assert.That(ambulance, Is.EqualTo(result));
        }

        [Test]
        public void GetAllAmbulancesFromHospital_ShouldWorkCorrectly()
        {
            //Arrange
            int hospitalId = 3;
            List<Ambulance> ambulances = new List<Ambulance>() { new Ambulance(), new Ambulance() };

            Mock<IAmbulanceRepository> ambulanceRepositoryMock = new Mock<IAmbulanceRepository>();
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<IPatientService> patientServiceMock = new Mock<IPatientService>();
            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            AmbulanceService ambulanceService =
                new AmbulanceService(ambulanceRepositoryMock.Object, locationRepositoryMock.Object, hospitalRepositoryMock.Object,
                                     patientServiceMock.Object, patientRepositoryMock.Object, unitOfWorkMock.Object);

            ambulanceRepositoryMock.Setup(x => x.GetAllAmbulancesFromHospital(hospitalId)).Returns(ambulances);

            //Act
            List<Ambulance> result = ambulanceService.GetAllAmbulancesFromHospital(hospitalId);

            //Assert
            Assert.That(ambulances, Is.EqualTo(result));
        }

        [Test]
        public void UpdateAmbulanceLocation_ShouldWorkCorrectly()
        {
            //Arrange
            Ambulance ambulance = new Ambulance() { Location = new Location()};
            Decimal latitude = 3;
            Decimal longitude = 4;


            Mock<IAmbulanceRepository> ambulanceRepositoryMock = new Mock<IAmbulanceRepository>();
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<IPatientService> patientServiceMock = new Mock<IPatientService>();
            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            AmbulanceService ambulanceService =
                new AmbulanceService(ambulanceRepositoryMock.Object, locationRepositoryMock.Object, hospitalRepositoryMock.Object,
                                     patientServiceMock.Object, patientRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            ambulanceService.UpdateAmbulanceLocation(ambulance, latitude, longitude);

            //Assert
            Assert.That(latitude, Is.EqualTo(ambulance.Location.Latitude));
            Assert.That(longitude, Is.EqualTo(ambulance.Location.Longitude));
        }

        [Test]
        public void RemoveAmbulancePatient_ShouldWorkCorrectly()
        {
            //Arrange
            int ambulanceId = 3;
            int patientId = 2;
            Ambulance ambulance = new Ambulance()
            {
                PatientId = patientId
            };

            Mock<IAmbulanceRepository> ambulanceRepositoryMock = new Mock<IAmbulanceRepository>();
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<IHospitalRepository> hospitalRepositoryMock = new Mock<IHospitalRepository>();
            Mock<IPatientService> patientServiceMock = new Mock<IPatientService>();
            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            AmbulanceService ambulanceService =
                new AmbulanceService(ambulanceRepositoryMock.Object, locationRepositoryMock.Object, hospitalRepositoryMock.Object,
                                     patientServiceMock.Object, patientRepositoryMock.Object, unitOfWorkMock.Object);

            ambulanceRepositoryMock.Setup(x => x.GetById(ambulanceId)).Returns(ambulance);

            //Act
            ambulanceService.RemoveAmbulancePatient(ambulanceId);

            Assert.IsNull(ambulance.PatientId);
            unitOfWorkMock.Verify(x => x.Commit(), Times.Exactly(2));
            patientRepositoryMock.Verify(x => x.DeletePatientById(patientId), Times.Exactly(1));
        }
    }
}
