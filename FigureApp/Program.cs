﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FigureApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Figure> ListOfFigures = new List<Figure>();
            string saver = "";
            int choice;
            



            Console.WriteLine("Be aware that, if you want this program to work, first add figures you want to add,\n" +
                "and only then you can modify figures you already have!");



            while (true)
            {
                Console.WriteLine("\n1)show all figures\n" +
                                  "2)create a figure\n" +
                                  "3)change figure\n" +
                                  "4)save to file\n" +
                                  "5)read from file\n" +
                                  "0)exit");
                bool parsed = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
            {
               
                case 1:
                    {
                            StreamReader reader = new StreamReader("figure.txt");
                            string line = "";
                            
                            
                                line += reader.ReadToEnd();
                                reader.Close();
                            
                            Console.Write(line);
                        break;
                    }
                case 2:
                    {
                            
                            Console.WriteLine("Please, choose the figure you want to create:\n" +
                                "1)Circle\n" +
                                "2)Rectangle(square)\n" +
                                "3)Triangle\n");
                            int underChoice = Convert.ToInt32(Console.ReadLine());
                            bool flag = false;
                            while (flag == false)
                            {
                                switch (underChoice)
                                {
                                    
                                    case 1:
                                        Console.WriteLine("Please, enter the coordinates of the center, and any other point of your circle: ");

                                        Point point1 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point2 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfCircle = new List<Point> { point1, point2 };
                                        
                                        
                                        Circle circle = new Circle(pointsOfCircle);
                                        circle.FindCenter();
                                        circle.FindArea();
                                        circle.FindPerimeter();
                                        saver += $"The area of this circle is {circle.Area} and the perimeter is {circle.Perimeter} \n";
                                        flag = true;
                                        ListOfFigures.Add(circle);
                                        
                                        
                                        break;

                                    case 2:
                                        Console.WriteLine("Please, enter the coordinates of your rectangle point by point: ");

                                        Point point11 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point12 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point13 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point14 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfRectangle = new List<Point> { point11, point12, point13, point14 };
                                      
                                        Rectangle rectangle = new Rectangle(pointsOfRectangle);
                                        
                                        
                                        rectangle.FindCenter();
                                        rectangle.FindArea();
                                        rectangle.FindPerimeter();
                                        saver += $"The area of rectangle is: {rectangle.Area} and Perimeter of rectangle is: {rectangle.Perimeter}\n";
                                        flag = true;
                                        ListOfFigures.Add(rectangle);
                                        break;
                                        

                                    case 3:
                                        Point point21 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point22 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point23 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfTriangle = new List<Point> { point21, point22, point23 };
                                       
                                        Triangle triangle = new Triangle(pointsOfTriangle);
                                        triangle.DefineSides(pointsOfTriangle);
                                        triangle.FindCenter();
                                        triangle.FindArea();
                                        triangle.FindPerimeter();
                                        saver += $"The area of triangle is: {triangle.Area} and Perimeter of triangle is: {triangle.Perimeter}\n"; 
                                        ListOfFigures.Add(triangle);
                                        flag = true;
                                        break;
                                    default:
                                        Console.WriteLine("There are no such thing as this -_-");
                                        break;
                                }
                            }
                        break;
                    }
                case 3:
                    {
                            Console.WriteLine("Choose what you want to change: \n 1)Move the figure \n 2)Rotate the figure \n 3)Scale the figure \n 4) Delete the Figure");
                            int whatToDo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Choose the index of element you want to change(begins from zero):");
                            int index = Convert.ToInt32(Console.ReadLine());
                            switch (whatToDo)
                            {
                                case 1:
                                    Console.WriteLine("Now define how much you want to move by X and Y");
                                    ListOfFigures[index].MoveFigure(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 2:
                                    Console.WriteLine("Define how many degrees you want to rotate it");
                                    ListOfFigures[index].RotateFigure(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 3:
                                    Console.WriteLine("Define how many times you want to scale your figure");
                                    ListOfFigures[index].Scale(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 4:
                                    Console.WriteLine("I'm deleting this figure");
                                    ListOfFigures.RemoveAt(index);
                                    saver = "";
                                    StreamWriter deleteAll = new StreamWriter("figure.txt",false);
                                    deleteAll.Write("");
                                    deleteAll.Close();
                                    foreach(Figure p in ListOfFigures)
                                    {
                                        saver = $"The area of {p.GetType()} is {p.Area} and Perimeter of {p.GetType()} is {p.Perimeter}";
                                    }
                                    break;
                            }


                        break;
                    }
                case 4:
                    {
                            TextWriter textWriter = new StreamWriter("saverr");
                            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                            serializer.Serialize(textWriter, ListOfFigures);


                            break;
                    }
                    #region bst   
                    /*  case 5:
                    {
                        xwriter.Close();
                       StreamReader fileReader = new StreamReader("pointsaver.txt");
                       string readed = "";

                       while (readed != null)
                       {
                           readed = fileReader.ReadLine();

                           if (readed != null)
                           {
                               var splitter = readed.Split(' ');
                               switch (splitter[0])
                               {
                                   case "circle":
                                       {
                                           int i = 1;
                                           List<Point> pointsOfCircle = new List<Point>();

                                           while (i < splitter.Length - 1)
                                           {
                                               Point readedPoints = new Point(Convert.ToDouble(splitter[i]), Convert.ToDouble(splitter[i + 1]));
                                               pointsOfCircle.Add(readedPoints);
                                               i += 2;
                                           }
                                           Circle circle = new Circle(pointsOfCircle);
                                           ListOfFigures.Add(circle);
                                           circle.FindArea();
                                           circle.FindCenter();
                                           circle.FindPerimeter();
                                           break;
                                       }
                                   case "rectangle":
                                       {
                                           int i = 1;
                                           List<Point> pointsOfRectangle = new List<Point>();

                                           while (i < splitter.Length - 1)
                                           {
                                               Point readedPoints = new Point(Convert.ToDouble(splitter[i]), Convert.ToDouble(splitter[i + 1]));
                                               pointsOfRectangle.Add(readedPoints);
                                               i += 2;
                                           }
                                           Rectangle rectangle = new Rectangle(pointsOfRectangle);
                                           ListOfFigures.Add(rectangle);
                                           rectangle.FindArea();
                                           rectangle.FindCenter();
                                           rectangle.FindPerimeter();
                                           break;
                                       }
                                   case "triangle":
                                       {
                                           int i = 1;
                                           List<Point> pointsOfTriangle = new List<Point>();

                                           while (i < splitter.Length - 1)
                                           {
                                               Point readedPoints = new Point(Convert.ToDouble(splitter[i]), Convert.ToDouble(splitter[i + 1]));
                                               pointsOfTriangle.Add(readedPoints);
                                               i += 2;
                                           }
                                           Triangle triangle = new Triangle(pointsOfTriangle);
                                           ListOfFigures.Add(triangle);
                                           triangle.DefineSides(pointsOfTriangle);
                                           triangle.FindArea();
                                           triangle.FindCenter();
                                           triangle.FindPerimeter();
                                           break;
                                       }

                                       default:
                                       {
                                           Console.WriteLine("There are no figures :(");
                                           break;
                                       }
                               }
                           }
                           }
                       fileReader.Close();
                       break;
                   } */
                    #endregion


                    case 5:
                        {
                            TextReader textReader = new StreamReader("saverr");
                            Newtonsoft.Json.JsonSerializer deserializer = new Newtonsoft.Json.JsonSerializer();
                            deserializer.Deserialize(textReader);



                            break;
                        }
                    default:
                    {
                        if(parsed)
                        {
                            if(choice == 0)
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
    }
}
