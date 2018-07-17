﻿namespace Airport.WebApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.WebApi.Controllers;

    using AirportEf.BLL.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Moq;

    using Xunit;

    // The same Tests applicable for each of 8 Controllers in API, so I tested 1 because logic is the same
    public class PilotsApiControllerTests
    {
        private Mock<IPilotService> _pilotServiceMock;
        private PilotsController controller;

        public PilotsApiControllerTests()
        {
            _pilotServiceMock = new Mock<IPilotService>();
            controller = new PilotsController(_pilotServiceMock.Object);
        }

        #region Get

        [Fact] // +
        public async Task Get_ReturnsAOkObjectResult_With2PilotDtoObjects()
        {
            // Arrange
            _pilotServiceMock.Setup(repo => repo.GetAllEntitiesAsync())
                                                        .Returns(Task.FromResult(GetTestPilots().AsEnumerable()));

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<PilotDto>>(viewResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact] // +
        public async Task Get_ReturnsANoContentResult_WithNoObjects()
        {
            // Arrange
            _pilotServiceMock.Setup(repo => repo.GetAllEntitiesAsync()).Returns(Task.FromResult(Enumerable.Empty<PilotDto>()));

            // Act
            var result = await controller.Get();

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result.Result);
        }

        #endregion

        #region Get by Id

        [Fact]
        public async Task GetPilotTest_ReturnsNotFound_WhenPilotDoesNorExists()
        {
            // Arrange
            var mockId = 203;
            _pilotServiceMock.Setup(repo => repo.GetEntityByIdAsync(mockId)).Returns(Task.FromResult<PilotDto>(null));

            // Act
            var result = await controller.GetById(mockId);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetPilotTest_ReturnsPilot_WhenPilotExists()
        {
            // Arrange
            var mockId = 2;
            var mockPilot = GetTestPilots()[1];
            _pilotServiceMock.Setup(repo => repo.GetEntityByIdAsync(mockId))
                                                    .Returns(Task.FromResult(mockPilot));

            // Act
            var result = await controller.GetById(mockId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<PilotDto>(actionResult.Value);
            Assert.Equal(mockPilot.Name, model.Name);
            Assert.Equal(mockPilot.Id, model.Id);
            Assert.Equal(mockPilot, actionResult.Value);
            // TODO: Check content type: application/json
        }


        #endregion

        #region Create

        [Fact] // +
        public async Task CreatePilot_ReturnsCreatedAtActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var pilotRequest = new PilotRequest()
            {
                Name = "Sanya",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
            };
            _pilotServiceMock.Setup(repo => repo.CreateEntityAsync(pilotRequest))
                                                        .Returns(Task.FromResult(GetTestPilots()[0]))
                                                        .Verifiable();

            // Act
            var result = await controller.Create(pilotRequest);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);

            Assert.Null(createdAtActionResult.ControllerName);
            Assert.Equal("GetById", createdAtActionResult.ActionName);
            Assert.Equal(GetTestPilots().First().Id, createdAtActionResult.RouteValues["id"]);
            var model = Assert.IsAssignableFrom<PilotDto>(createdAtActionResult.Value);
            _pilotServiceMock.Verify();
        }

        [Fact] // +
        public async Task CreatePilot_ReturnsBadRequestObjectResult_WhenModelStateIsInValid()
        {
            // Arrange
            // Test for model validation on Common Project with Fluent Validation Tests
            var pilotRequest = new PilotRequest()
            {
                // Name = "Sanya", // Doesn't check validity anyway =)
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
            };
            controller.ModelState.AddModelError("Name", "Please specify a valid Name");

            // Act
            var result = await controller.Create(pilotRequest);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestObjectResult.Value);
            Assert.Equal(new SerializableError(controller.ModelState), badRequestObjectResult.Value);
        }

        [Fact] // +
        public async Task CreatePilot_ReturnsBadRequestObjectResult_WhenModelIsValidButWasNotCreated()
        {
            // Arrange
            var pilotRequest = new PilotRequest()
                                   {
                                       Name = "Sanya", 
                                       FamilyName = "Morkva",
                                       DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                                       Experience = new TimeSpan(5000, 00, 00, 00),
                                   };
            _pilotServiceMock.Setup(repo => repo.CreateEntityAsync(pilotRequest))
                                                         .Returns(Task.FromResult<PilotDto>(null))
                                                         .Verifiable();

            // Act
            var result = await controller.Create(pilotRequest);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);
            Assert.True(statusCodeResult.StatusCode == 500);
        }

        #endregion

        #region Update

        [Fact] // +
        public async Task UpdatePilot_ReturnsNoContent_WhenModelStateIsValidAndValidatedAtBLL()
        {
            // Arrange
            var mockId = 2;
            var pilotRequest = new PilotRequest()
            {
                Name = "Updated",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
            };
            _pilotServiceMock.Setup(repo => repo.UpdateEntityByIdAsync(pilotRequest, mockId))
                                                        .Returns(Task.FromResult(true))
                                                        .Verifiable();

            // Act
            var result = await controller.Update(mockId, pilotRequest);

            // Assert
            var contentResult = Assert.IsType<NoContentResult>(result.Result);
            _pilotServiceMock.Verify();
        }

        [Fact] // +
        public async Task UpdatePilot_ReturnsNoContent_WhenModelStateIsInValid()
        {
            // Arrange
            var mockId = 2;
            var pilotRequest = new PilotRequest()
            {
                Name = "Updated",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(2003, 12, 22, 17, 30, 0), // Doesn't check validity anyway =)
                Experience = new TimeSpan(5000, 00, 00, 00),
            };
            controller.ModelState.AddModelError("DateOfBirth", "Please specify a valid Date Of Birth");

            // Act
            var result = await controller.Update(mockId, pilotRequest);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestObjectResult.Value);
            Assert.Equal(new SerializableError(controller.ModelState), badRequestObjectResult.Value);
        }

        [Fact] // +
        public async Task UpdatePilotTest_ReturnsStatusCode500_WhenPilotExistsButWasNotUpdated()
        {
            // Arrange
            var mockId = 2;
            var pilotRequest = new PilotRequest()
                                   {
                                       Name = "Sanya", 
                                       FamilyName = "Morkva",
                                       DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                                       Experience = new TimeSpan(5000, 00, 00, 00),
                                   };
            _pilotServiceMock.Setup(repo => repo.UpdateEntityByIdAsync(pilotRequest, mockId))
                                                        .Returns(Task.FromResult(false));

            // Act
            var result = await controller.Update(mockId, pilotRequest);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);
            Assert.True(statusCodeResult.StatusCode == 500);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task DeletePilotTest_ReturnsStatusCode500_WhenPilotExistsButWasNotDeleted()
        {
            // Arrange
            var mockId = 203;
             _pilotServiceMock.Setup(repo => repo.DeleteEntityByIdAsync(mockId)).Returns(Task.FromResult(false));

            // _pilotServiceMock.Setup(repo => repo.DeleteEntityByIdAsync(mockId)).Throws(new HttpStatusCodeException(HttpStatusCode.NotFound));
            // TODO: Can't test because error catches in Middleware, not controller

            // Act
            var result = await controller.Delete(mockId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);
            Assert.True(statusCodeResult.StatusCode == 500);
        }

        [Fact]
        public async Task DeletePilotTest_ReturnsNoContent_WhenPilotExists()
        {
            // Arrange
            var mockId = 2;
            _pilotServiceMock.Setup(repo => repo.DeleteEntityByIdAsync(mockId)).Returns(Task.FromResult(true));

            // Act
            var result = await controller.Delete(mockId);

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

        #endregion

        // Mock Data
        private List<PilotDto> GetTestPilots()
        {
            var pilots = new List<PilotDto>
                             {
                                 new PilotDto()
                                     {
                                         Id = 1,
                                         Name = "Qwerty",
                                         FamilyName = "Qwerty",
                                         DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                                         Experience = new TimeSpan(1600, 00, 00, 00),
                                     },
                                 new PilotDto()
                                     {
                                         Id = 2,
                                         Name = "Ostap",
                                         FamilyName = "Bober",
                                         DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                                         Experience = new TimeSpan(3600, 00, 00, 00),
                                     }
                             };
            return pilots;
        }
    }
}