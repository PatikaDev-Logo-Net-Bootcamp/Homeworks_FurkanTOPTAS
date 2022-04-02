using System;
using Xunit;
using XUnitSample;

namespace First.App.Tests
{
    public class AuthenticationShould
    {
        [Theory]
        [InlineData("samet")]
        [InlineData("sametkayikci61")]
        public void Be_able_login(string username)
        {
            //Arrange
            Authentication sut = new Authentication();

            //Act
            bool result = sut.Login(username);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("sam")]
        [InlineData("ee")]
        public void Cannot_Login(string username)
        {
            //Arrange
            Authentication sut = new Authentication();

            //Act
            void act() => sut.Login(username);

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

    }
}
