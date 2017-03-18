using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using CommunitySite.Models.Repository;
using Xunit;

namespace CommunitySiteTests
{
    public class CommunitySiteTests
    {
         
        [Fact]
        public void CanChangeNewsTitle()
        {
            //Arrange
            News t = new News { Title = "Dog News", Date = new DateTime(2017, 1, 2), Story = "blah blah blah" };

            //Act
            t.Title = "Dog News Test";

            //Assert
            Assert.Equal("Dog News Test", t.Title);
        }

        [Fact]
        public void CanChangeNewsDate()
        {
            //Arrange
            News t = new News { Title = "Dog News", Date = new DateTime(2017,1,2), Story = "blah blah blah" };

            //Act
            DateTime newDate = new DateTime(2017, 12, 3);
            t.Date = newDate;

            //Assert
            Assert.Equal(newDate, t.Date);
        }

        [Fact]
        public void CanChangeNewsStory()
        {
            //Arrange
            News t = new News { Title = "Dog News", Date = new DateTime(2017, 1, 2), Story = "blah blah blah" };

            //Act
            t.Story = "and more blah";

            //Assert
            Assert.Equal("and more blah", t.Story);
        }

        [Fact]
        public void CanAddNewsAuthor()
        {
            //Arrange
            News t = new News { Title = "Dog News", Date = new DateTime(2017, 1, 2), Story = "blah blah blah" };

            //Act
            t.Author = "Harry Potter";

            //Assert
            Assert.Equal("Harry Potter", t.Author);
        }


      
        

    }
}
