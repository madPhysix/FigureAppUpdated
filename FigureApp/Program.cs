using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FigureApp
{
    internal class Program
    {
        static List<Figure> listOfFigures = new List<Figure>();
        static void Main(string[] args)
        {
            
            string fileName = "figure.txt";

            while (true)
            {
                Console.WriteLine("\n1)show all figures\n" +
                                  "2)create a figure\n" +
                                  "3)change figure\n" +
                                  "4)save to file\n" +
                                  "5)read from file\n" +
                                  "0)exit");
                bool parsedChoice = int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        {
                            ShowAllFigures(fileName);
                            break;
                        }
                    case 2:
                        {
                            ChangeFigure();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Choose what you want to change: \n 1)Move the figure \n 2)Rotate the figure \n 3)Scale the figure \n");
                            int whatToDo = HelperClass.ParseStringToInt(Console.ReadLine());
                            Console.WriteLine("Choose the index of element you want to change(begins from zero):");
                            int index = HelperClass.ParseStringToInt(Console.ReadLine());
                            switch (whatToDo)
                            {
                                case 1:
                                    Console.WriteLine("Now define how much you want to move by X and Y");
                                    listOfFigures[index].MoveFigure(HelperClass.ParseStringToInt(Console.ReadLine()), HelperClass.ParseStringToInt(Console.ReadLine()));
                                    break;
                                case 2:
                                    Console.WriteLine("Define how many degrees you want to rotate it");
                                    listOfFigures[index].RotateFigure(HelperClass.ParseStringToInt(Console.ReadLine()));
                                    break;
                                case 3:
                                    Console.WriteLine("Define how many times you want to scale your figure");
                                    listOfFigures[index].Scale(HelperClass.ParseStringToInt(Console.ReadLine()));
                                    break;
                            }
                            break;
                        }
                    case 4:
                        {
                            TextWriter textWriter = new StreamWriter("saverr");
                            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                            serializer.Serialize(textWriter, listOfFigures);
                            textWriter.Close();

                            break;
                        }
                    case 5:
                        {
                            TextReader readToWrite = new StreamReader("saverr");
                            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                            listOfFigures = (List<Figure>)serializer.Deserialize(readToWrite, listOfFigures.GetType());
                            readToWrite.Close();
                            break;
                        }
                    default:
                        {
                            if (parsedChoice)
                            {
                                if (choice == 0)
                                {
                                    Console.WriteLine("Ended!");
                                    Environment.Exit(0);
                                    return;
                                }
                                Console.WriteLine("Enter numbers according to menu!");
                            }
                            else
                            {
                                Console.WriteLine("duz emelli bir wey yaz!");
                            }
                            break;
                        }
                }
            }
        }

        static void ShowAllFigures(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
                Console.Write("Program has been configured.\n" +
                              "Restart it please.");
                Environment.Exit(0);
            }
            using (StreamWriter strwrtr = new StreamWriter(fileName))
            {
                if (listOfFigures.Count == 0) Console.WriteLine("There are no figures, try to create one.");

                else
                {
                    int i = 0;
                    foreach (var p in listOfFigures)
                    {
                        strwrtr.WriteLine($"Figure[{i}]: {p.GetType().Name} has area of {p.Area} and perimeter of {p.Perimeter}.");
                        i++;
                    }
                }
            }

            using (StreamReader strrdr = new StreamReader(fileName))
            {
                string info = strrdr.ReadToEnd();
                Console.Write(info);
            }
        }

        static void ChangeFigure()
        {
            Console.WriteLine("Please, choose the figure you want to create:\n" +
                                    "1)Circle\n" +
                                    "2)Rectangle(square)\n" +
                                    "3)Triangle\n");
            int figureChoice = HelperClass.ParseStringToInt(Console.ReadLine());
            bool isChoiceCorrect = false;
            while (isChoiceCorrect == false)
            {
                switch (figureChoice)
                {
                    case 1:
                        Console.WriteLine("Please, enter the coordinates of the center, and any other point of your circle: ");

                        List<Point> pointsOfCircle = CreatePoints(2);
                        Circle circle = new Circle(pointsOfCircle);
                        listOfFigures.Add(circle);

                        isChoiceCorrect = true;
                        break;

                    case 2:
                        Console.WriteLine("Please, enter the coordinates of your rectangle point by point: ");

                        List<Point> pointsOfRectangle = CreatePoints(4);

                        Rectangle rectangle = new Rectangle(pointsOfRectangle);
                        listOfFigures.Add(rectangle);

                        isChoiceCorrect = true;
                        break;

                    case 3:
                        Console.WriteLine("Please, enter the coordinates of your triangle point by point: ");

                        List<Point> pointsOfTriangle = CreatePoints(3);

                        Triangle triangle = new Triangle(pointsOfTriangle);
                        listOfFigures.Add(triangle);

                        isChoiceCorrect = true;
                        break;

                    default:
                        Console.WriteLine("There are no such thing as this -_-");
                        break;
                }
            }
        }

        static List<Point> CreatePoints(int countOfPoints) 
        {
            List<Point> pointsOfCircle = new List<Point>();
            for (int i = 0; i < countOfPoints; i++)
            {
                Point newPoint = new Point(HelperClass.ParseStringToInt(Console.ReadLine()), HelperClass.ParseStringToInt(Console.ReadLine()));
                pointsOfCircle.Add(newPoint);  
            }
            return pointsOfCircle;
        }
    }
}
