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

        [Test]
        public void GetUserByUsernameAndPassword_NullUsername_ShouldReturnNull()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);
            //Act

            User user = userService.GetUserByUsernameAndPassword(null, "Pass");

            //Assert
            Assert.Null(user);
        }

        [Test]
        public void GetUserByUsernameAndPassword_NullPassword_ShouldReturnNull()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);
            //Act

            User user = userService.GetUserByUsernameAndPassword("Name", null);

            //Assert
            Assert.Null(user);
        }

        [Test]
        public void GetUserByUsernameAndPassword_ShouldReturnCorrectUser()
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

            User? resultUser = userService.GetUserByUsernameAndPassword(username, password);

            //Assert

            userRepositoryMock.Verify(x => x.GetByUsernameAndPassword(username, hashedPassword), Times.Once());
            Assert.That(createdUser, Is.EqualTo(resultUser));
        }

        [Test]
        public void CreateUser_UsernameAlreadyExists_ShouldThrow()
        {
            //Arrange
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";
            int hospitalId = 3;
            List<int> rolesIds = new List<int>() { 3, 4 };

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.DoesUserExistByName(username)).Returns(true);

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => userService.CreateUser(username, password, hospitalId, rolesIds));

            Assert.That("User by that name already exists!", Is.EqualTo(exception.Message));
            userRepositoryMock.Verify(x => x.DoesUserExistByName(username), Times.Once());
        }

        [Test]
        public void CreateUser_EmptyRoles_ShoudThrow()
        {
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";
            int hospitalId = 3;
            List<int> rolesIds = new List<int>() { };

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.DoesUserExistByName(username)).Returns(false);

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => userService.CreateUser(username, password, hospitalId, rolesIds));

            Assert.That("Roles cannot be empty!", Is.EqualTo(exception.Message));
            userRepositoryMock.Verify(x => x.DoesUserExistByName(username), Times.Once());
        }

        [Test]
        public void CreateUser_NullRoles_ShoudThrow()
        {
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";
            int hospitalId = 3;
            List<int> rolesIds = null;

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.DoesUserExistByName(username)).Returns(false);

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => userService.CreateUser(username, password, hospitalId, rolesIds));

            Assert.That("Roles cannot be empty!", Is.EqualTo(exception.Message));
            userRepositoryMock.Verify(x => x.DoesUserExistByName(username), Times.Once());
        }

        [Test]
        public void CreateUser_InvalidRoles_ShouldThrow()
        {
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";
            int hospitalId = 3;
            List<int> rolesIds = new List<int>() { 3, 4 } ;

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.DoesUserExistByName(username)).Returns(false);
            userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>()));
            roleRepositoryMock.Setup(x => x.GetRoleById(3)).Returns(new Role() { Id = 3 });
            roleRepositoryMock.Setup(x => x.GetRoleById(2)).Returns(new Role() { Id = 2 });

            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act and Assert
            var exception = Assert.Throws<Exception>(() => userService.CreateUser(username, password, hospitalId, rolesIds));

            Assert.That("Role was not found!", Is.EqualTo(exception.Message));
            userRepositoryMock.Verify(x => x.DoesUserExistByName(username), Times.Once());
            userRepositoryMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void CreateUser_ShouldCreateUser()
        {
            string username = "Name";
            string password = "asd";
            string hashedPassword = "dsa";
            int hospitalId = 3;
            List<int> rolesIds = new List<int>() { 3, 2 };

            var userRepositoryMock = new Mock<IUserRepository>();
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var hashServiceMock = new Mock<IHashService>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            hashServiceMock.Setup(x => x.HashText(password)).Returns(hashedPassword);
            userRepositoryMock.Setup(x => x.DoesUserExistByName(username)).Returns(false);
            userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>()));
            roleRepositoryMock.Setup(x => x.GetRoleById(3)).Returns(new Role() { Id = 3});
            roleRepositoryMock.Setup(x => x.GetRoleById(2)).Returns(new Role() { Id = 2});


            UserService userService = new UserService(userRepositoryMock.Object, roleRepositoryMock.Object, hashServiceMock.Object, unitOfWorkMock.Object);

            //Act 
            User user = userService.CreateUser(username, password, hospitalId, rolesIds);

            //Assert
            userRepositoryMock.Verify(x => x.DoesUserExistByName(username), Times.Once());
            userRepositoryMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Exactly(2));
            userRepositoryMock.Verify(x => x.AddRoleToUser(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));

            Assert.That(username, Is.EqualTo(user.Name));
            Assert.That(hashedPassword, Is.EqualTo(user.Password));
            Assert.That(hospitalId, Is.EqualTo(user.HospitalId));
        }
    }
}