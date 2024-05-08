﻿using Moq;
using ParkingZoneApp.Models;
using ParkingZoneApp.Repositories;
using ParkingZoneApp.Services;
using System.Text.Json;

namespace ReservationTests.Services
{
    public class ReservationServiceTests
    {
        private readonly Mock<IReservationRepository> _repository;
        private readonly IReservationService _service;
        private readonly Reservation _ReservationTest;
        private readonly int Id = 1;

        public ReservationServiceTests()
        {
            _repository = new Mock<IReservationRepository>();
            _service = new ReservationService(_repository.Object);
            _ReservationTest = new() { };
        }
        [Fact]
        public void GivenReservationModel_WhenInsertIsCalled_ThenRepositoryInsertIsCalled()
        {
            //Arrange
            _repository.Setup(x => x.Insert(_ReservationTest));

            //Act
            _service.Insert(_ReservationTest);

            //Assert
            _repository.Verify(x => x.Insert(_ReservationTest), Times.Once);
        }

        [Fact]
        public void GivenReservationModel_WhenUpdateIsCalled_ThenRepositoryUptadeIsCalled()
        {
            //Arrange
            _repository.Setup(x => x.Update(_ReservationTest));

            //Act
            _service.Update(_ReservationTest);

            //Assert
            _repository.Verify(x => x.Update(_ReservationTest), Times.Once);
        }

        [Fact]
        public void GivenParkingSlotsModel_WhenDeleteIsCalled_ThenRepositoryDeleteIsCalled()
        {
            //Arrange
            _repository.Setup(x => x.Delete(_ReservationTest));

            //Act
            _service.Delete(_ReservationTest);

            //Assert
            _repository.Verify(x => x.Delete(_ReservationTest), Times.Once);
        }

        [Fact]
        public void GivenNothing_WhenGetAllIsCalled_ThenRepositoryGetAllIsCalled()
        {
            //Arrange
            var reservations = new List<Reservation>();
            _repository.Setup(x => x.GetAll()).Returns(reservations);

            //Act
            var result = _service.GetAll();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Reservation>>(result);
            _repository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void GivenReservationId_WhenGetByIdIsCalled_ThenRepositoryGetByIdIsCalled()
        {
            //Arrange
            _repository.Setup(x => x.GetById(Id)).Returns(_ReservationTest);

            //Act
            var result = _service.GetById(Id);

            //Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Reservation>(result);
            _repository.Verify(x => x.GetById(Id), Times.Once);
            Assert.Equal(JsonSerializer.Serialize(_ReservationTest), JsonSerializer.Serialize(model));
        }
    }
}
