using System;
using StoreModels;
using Xunit;

namespace StoreManagerTest
{
    /// <summary>
    /// 
    /// </summary>
    public class StroreFrontTest
    {

        [Fact]
        public void IsStroreFrontValidTest()
        {
            //Arrange
            StoreFront storeFront = new StoreFront() { 
                Name = "McDonald's"
            };
            //Act

            //Assert
        }
    }
}