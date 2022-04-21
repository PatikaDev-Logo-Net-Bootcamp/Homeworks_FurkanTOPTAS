using System;
using Xunit;

namespace ApartmanYonetimOtomasyonu.Test
{
    public class AuthenticationControl
    {
        //[Fact]
        //public void Test1()
        //{

        //}

        [Theory]
        [InlineData("toptasfurkan")]
        [InlineData("superadmin")]
        public void Be_able_login(string username)
        {
            // Arrange
            Authentication sut = new Authentication();

            //Act
            bool result = sut.Login(username);

            //Assert
            Assert.True(result);


        }

        [Theory]
        [InlineData("")]
        [InlineData("asdasdasdasdasdasdzxczxczxzcadasdas")]
        public void Cannot_Login(string username)
        {
            //Arrange
            Authentication sut = new Authentication();

            //Act
            void act() => sut.Login(username);

            //Assert
            Assert.Throws<InvalidOperationException>(act);
            //Assert.True(act);
        }


    }
}
