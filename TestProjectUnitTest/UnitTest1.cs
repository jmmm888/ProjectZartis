using TestProject.BusinessLayer;
using TestProject.Models;

namespace TestProjectUnitTest;

public class UnitTest1
{

    [Theory]
    [InlineData(5, 5)]
    [InlineData(9, 7)]
    [InlineData(10, 9)]
    [InlineData(7, 7)]
    public void CanLandOnPlatform(int x, int y)
    {
        Coordinate topLefCoordinate = new Coordinate { X = 5, Y = 5 };
        Coordinate topRigthCoordinate = new Coordinate { X = 15, Y = 5 };
        Coordinate bottomLefCoordinate = new Coordinate { X = 5, Y = 15 };
        Coordinate bottomRigthCoordinate = new Coordinate { X = 15, Y = 15 };

        Factory.StarConfigurations(topLefCoordinate, topRigthCoordinate, bottomLefCoordinate, bottomRigthCoordinate);

        var result = Factory.Play(new Coordinate { X = x, Y = y });

        Assert.Equal(Constants.LandingResultsOptions[1], result);
    }

    [Theory]
    [InlineData(16, 5)]
    [InlineData(20, 3)]
    [InlineData(3, 9)]
    public void CantLandOnPlatform(int x, int y)
    {
        Coordinate topLefCoordinate = new Coordinate { X = 5, Y = 5 };
        Coordinate topRigthCoordinate = new Coordinate { X = 15, Y = 5 };
        Coordinate bottomLefCoordinate = new Coordinate { X = 5, Y = 15 };
        Coordinate bottomRigthCoordinate = new Coordinate { X = 15, Y = 15 };

        Factory.StarConfigurations(topLefCoordinate, topRigthCoordinate, bottomLefCoordinate, bottomRigthCoordinate);

        var result = Factory.Play(new Coordinate { X = x, Y = y });

        Assert.Equal(Constants.LandingResultsOptions[-1], result);
    }

    [Theory]
    [InlineData(7, 7)]
    [InlineData(11, 7)]
    [InlineData(5, 12)]
    public void CanLandSecondTimeOnPlatform(int x, int y)
    {
        Coordinate topLefCoordinate = new Coordinate { X = 5, Y = 5 };
        Coordinate topRigthCoordinate = new Coordinate { X = 15, Y = 5 };
        Coordinate bottomLefCoordinate = new Coordinate { X = 5, Y = 15 };
        Coordinate bottomRigthCoordinate = new Coordinate { X = 15, Y = 15 };

        Factory.StarConfigurations(topLefCoordinate, topRigthCoordinate, bottomLefCoordinate, bottomRigthCoordinate);

        // firstLand
        Factory.Play(new Coordinate { X = 9, Y = 10 });

        var result = Factory.Play(new Coordinate { X = x, Y = y });

        Assert.Equal(Constants.LandingResultsOptions[1], result);
    }

    [Theory]
    [InlineData(8, 7)]
    [InlineData(10, 7)]
    [InlineData(11, 11)]
    public void CantLandSecondTimeOnPlatform(int x, int y)
    {
        Coordinate topLefCoordinate = new Coordinate { X = 5, Y = 5 };
        Coordinate topRigthCoordinate = new Coordinate { X = 15, Y = 5 };
        Coordinate bottomLefCoordinate = new Coordinate { X = 5, Y = 15 };
        Coordinate bottomRigthCoordinate = new Coordinate { X = 15, Y = 15 };

        Factory.StarConfigurations(topLefCoordinate, topRigthCoordinate, bottomLefCoordinate, bottomRigthCoordinate);

        // firstLand
        Factory.Play(new Coordinate { X = 9, Y = 10 });

        var result = Factory.Play(new Coordinate { X = x, Y = y });

        Assert.Equal(Constants.LandingResultsOptions[0], result);
    }
}
