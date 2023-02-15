using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using Moq;

namespace MediQuick.Services.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void LoginUser_NullUsername_ShouldThrow()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);
            //Act and Assert

            var exception = Assert.Throws<ArgumentException>(() => userService.LoginUser(null, "Pass"));

            Assert.That("The username cannot be empty!", Is.EqualTo(exception.Message));
        }

        [Test]
        public void LoginUser_NullPassword_ShouldThrow()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => userService.LoginUser("Name", null));

            Assert.That("The password cannot be empty!", Is.EqualTo(exception.Message));
        }

        [Test]
        public void LoginUser_NullUser_ShouldThrow()
        {
            //Arrange
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert

            var exception = Assert.Throws<ArgumentException>(() => userService.LoginUser(username, password));

            Assert.That("Wrong username or password!", Is.EqualTo(exception.Message));
            userRepositoryMock.Verify(x => x.GetByUsernameAndPassword(username, hashedPassword), Times.Once());
        }

        [Test]
        public void LoginUser_ShouldSucceed()
        {
            //Arrange
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            User createdUser = new User();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.GetByUsernameAndPassword(username, hashedPassword)).Returns(createdUser);

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act

            userService.LoginUser(username, password);

            //Assert

            userRepositoryMock.Verify(x => x.GetByUsernameAndPassword(username, hashedPassword), Times.Once());
        }
    }
}