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
    public class PatientServiceTests
    {
        [Test]
        public void CreatePatient_ShouldCreatePatient()
        {
            //Arrange
            string firstName = "Bob";
            string lastName = "Kerman";
            string socialSecurityNumber = "41233";
            string sex = "Male";
            string status = "Critical";
            DateTime dateOfBirth = DateTime.Now;
            string extraInfo = "Bob";

            Mock<IPatientRepository> patientRepositoryMock = new Mock<IPatientRepository>();
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

            PatientService patientService = new PatientService(patientRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Patient patient =  patientService.CreatePatient(firstName, lastName, socialSecurityNumber, sex, status, dateOfBirth, extraInfo);

            //Assert
            Assert.That(firstName, Is.EqualTo(patient.FirstName));
            Assert.That(lastName, Is.EqualTo(patient.LastName));
            Assert.That(socialSecurityNumber, Is.EqualTo(patient.SocialSecurityNumber));
            Assert.That(sex, Is.EqualTo(patient.Sex));
            Assert.That(status, Is.EqualTo(patient.Status));
            Assert.That(dateOfBirth, Is.EqualTo(patient.DateOfBirth));
            Assert.That(extraInfo, Is.EqualTo(patient.ExtraInfo));

            patientRepositoryMock.Verify(x => x.CreatePatient(It.IsAny<Patient>()), Times.Once);
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
