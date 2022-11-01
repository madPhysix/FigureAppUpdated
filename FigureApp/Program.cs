using Newtonsoft.Json;
using System;
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
            int choice;
            



            


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

                            if(!File.Exists("figure.txt"))
                                { File.Create("figure.txt");
                                                             }
                            using (StreamWriter strwrtr = new StreamWriter("figure.txt"))
                            {
                                if (ListOfFigures.Count == 0) Console.WriteLine("There are no figures, try to create one.");

                                else 
                                {
                                    int i = 0;
                                     foreach(var p in ListOfFigures)
                                    {
                                        strwrtr.WriteLine($"Figure[{i}]: {p.GetType().Name} has area of {p.Area} and perimeter of {p.Perimeter}.");
                                        i++;
                                    }
                                }
                            }

                            using (StreamReader strrdr = new StreamReader("figure.txt"))
                            {
                                string info = strrdr.ReadToEnd();
                                Console.Write(info);
                            }

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
                            Console.WriteLine("Choose what you want to change: \n 1)Move the figure \n 2)Rotate the figure \n 3)Scale the figure \n");
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
                               
                            }


                        break;
                    }
                case 4:
                    {
                            TextWriter textWriter = new StreamWriter("saverr");
                            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Objects });
                            serializer.Serialize(textWriter, ListOfFigures);
                            textWriter.Close();

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
                            TextReader readToWrite = new StreamReader("saverr");
                            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                            ListOfFigures = (List<Figure>)serializer.Deserialize(readToWrite, ListOfFigures.GetType());
                            readToWrite.Close();
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
