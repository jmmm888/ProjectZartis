using TestProject.BusinessLayer;
using TestProject.Models;

Console.WriteLine("Start Application");

//Console.WriteLine("\nChoose your landing configuration:");
//Console.WriteLine("\nTop Left Coordinate: ");
//var topLefCoordinateAux = Console.ReadLine();

//Console.WriteLine("\nTop Rigth Coordinate: ");
//var topRigthCoordinateAux = Console.ReadLine();

//Console.WriteLine("\nBottom Left Coordinate: ");
//var bottomLefCoordinateAux = Console.ReadLine();

//Console.WriteLine("\nBottom Rigth Coordinate: ");
//var bottomRigthCoordinateAux = Console.ReadLine();

//Coordinate topLefCoordinate = new Coordinate { X = Convert.ToInt32(topLefCoordinateAux.Split(",")[0]), Y = Convert.ToInt32(topLefCoordinateAux.Split(",")[1]) };
//Coordinate topRigthCoordinate = new Coordinate { X = Convert.ToInt32(topRigthCoordinateAux.Split(",")[0]), Y = Convert.ToInt32(topRigthCoordinateAux.Split(",")[1]) };
//Coordinate bottomLefCoordinate = new Coordinate { X = Convert.ToInt32(bottomLefCoordinateAux.Split(",")[0]), Y = Convert.ToInt32(bottomLefCoordinateAux.Split(",")[1]) };
//Coordinate bottomRigthCoordinate = new Coordinate { X = Convert.ToInt32(bottomRigthCoordinateAux.Split(",")[0]), Y = Convert.ToInt32(bottomRigthCoordinateAux.Split(",")[1]) };

Coordinate topLefCoordinate = new Coordinate { X = 5, Y = 5 };
Coordinate topRigthCoordinate = new Coordinate { X = 15, Y = 5 };
Coordinate bottomLefCoordinate = new Coordinate { X = 5, Y = 15 };
Coordinate bottomRigthCoordinate = new Coordinate { X = 15, Y = 15 };

Factory.StarConfigurations(topLefCoordinate, topRigthCoordinate, bottomLefCoordinate, bottomRigthCoordinate);

Console.WriteLine("\n\nDone ");

Console.WriteLine("\nPlay: ");
var playAux = Console.ReadLine();

Coordinate play = new Coordinate { X = Convert.ToInt32(playAux.Split(",")[0]), Y = Convert.ToInt32(playAux.Split(",")[1]) };

var result = Factory.Play(play);
Console.WriteLine("\nResult: " + result);


Console.WriteLine("\nPlay 2: ");
var playAux1 = Console.ReadLine();

Coordinate play1 = new Coordinate { X = Convert.ToInt32(playAux1.Split(",")[0]), Y = Convert.ToInt32(playAux1.Split(",")[1]) };

var result1 = Factory.Play(play1);
Console.WriteLine("\nResult 1: " + result1);


Console.WriteLine("\nPlay 3: ");
var playAux2 = Console.ReadLine();


Coordinate play2 = new Coordinate { X = Convert.ToInt32(playAux2.Split(",")[0]), Y = Convert.ToInt32(playAux2.Split(",")[1]) };

var result2 = Factory.Play(play2);
Console.WriteLine("\nResult 2: " + result2);

Console.ReadLine();
