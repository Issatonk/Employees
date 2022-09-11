using AutoFixture;
using Employees.Core;
using Employees.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employees.BusinessLogic.Tests
{
    public class ProgLangServiceTests
    {
        private readonly Mock<IProgLangRepository> _progLangRepositoryMock;

        private readonly ProgLangService _service;

        
        public ProgLangServiceTests()
        {
            _progLangRepositoryMock = new Mock<IProgLangRepository>();
            _service = new ProgLangService(_progLangRepositoryMock.Object);
        }

        [Fact]
        public void Create_ProgLangIsValid_ShouldCreateNewProgLang()
        {
            //arrange
            Fixture fixture = new Fixture();

            var progLang = fixture.Create<ProgLang>();
            //act
            var result = _service.Create(progLang);

            //assert

            _progLangRepositoryMock.Verify(x => x.Add(progLang), Times.Once);
        }
        [Fact]
        public void Create_ProgLangIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            ProgLang progLang = null;
            //act
            var result = _service.Create(progLang);

            //assert

            _progLangRepositoryMock.Verify(x => x.Add(progLang), Times.Never);
            Assert.ThrowsAsync<ArgumentNullException>(()=>_service.Create(progLang));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_ProgLangIsInvalid_ShouldThrowArgumentException(string name)
        {
            //arrange
            var progLang = new ProgLang { Name = name};
            //act
            var result = _service.Create(progLang);

            //assert

            _progLangRepositoryMock.Verify(x => x.Add(progLang), Times.Never);
            Assert.ThrowsAsync<ArgumentException>(() => _service.Create(progLang));
        }
    }
}
