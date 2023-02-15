using MediQuick.Data.Contracts;
using MediQuick.Data.Enums;
using MediQuick.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Tests
{
    public class RoleServiceTests
    {
        [Test]
        public void GetAllRoles_ShouldReturnCorrectly()
        {
            //Arange
            List<Role> roles = new List<Role>();

            Mock<IRoleRepository> roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.GetAllRoles()).Returns(roles);

            RoleService roleService = new RoleService(roleRepository.Object);

            //Act
            List<Role> resultRoles = roleService.GetAllRoles();

            //Assert
            Assert.That(roles, Is.EqualTo(resultRoles));
        }

        [Test]
        public void GetSpecificRoles_ShouldReturnCorrectRoles()
        {
            //Arange
            List<RoleType> roleTypes = new List<RoleType>() { RoleType.Admin, RoleType.HospitalEmployee};
            List<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Name = RoleType.Admin.ToString()
                } ,
                new Role()
                {
                    Name = RoleType.HospitalAdmin.ToString()
                },
                new Role()
                {
                    Name = RoleType.HospitalEmployee.ToString()
                },
                new Role()
                {
                    Name = RoleType.AmbulanceDriver.ToString()
                }
            };

            List<Role> wantedRoles = roles
                .Where(x => roleTypes
                .Select(y => y.ToString())
                .Contains(x.Name))
                .ToList();

            Mock<IRoleRepository> roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.GetAllRoles()).Returns(roles);

            RoleService roleService = new RoleService(roleRepository.Object);

            //Act
            List<Role> resultRole = roleService.GetSpecificRoles(roleTypes);

            //Assert
            Assert.That(wantedRoles, Is.EquivalentTo(resultRole));
        }

        [Test]
        public void GetRoleById_ShouldReturnCorrectRole()
        {
            //Arrange
            int roleId = 1;
            Role role = new Role() { Id = roleId };

            Mock<IRoleRepository> roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.GetRoleById(roleId)).Returns(role);

            RoleService roleService = new RoleService(roleRepository.Object);

            //Act
            Role resultRole = roleService.GetRoleById(roleId);

            //Assert
            Assert.That(resultRole, Is.EqualTo(role));  
        }

        [Test]
        public void GetRoleByName_ShouldReturnCorrectRole()
        {
            //Arrange
            string name = "Admin";
            Role role = new Role() { Name = name };

            Mock<IRoleRepository> roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.GetRoleByName(name)).Returns(role);

            RoleService roleService = new RoleService(roleRepository.Object);

            //Act
            Role resultRole = roleService.GetRoleByName(name);

            //Assert
            Assert.That(resultRole, Is.EqualTo(role));
        }
    }
}
