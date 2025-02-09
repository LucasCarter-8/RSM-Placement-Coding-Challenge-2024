using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            List<StreamingService> subscribedServices = new List<StreamingService>();

            do
            {
                Console.WriteLine("Enter options for manipulating graph: ");
                Console.WriteLine("1. Streaming Service");
                Console.WriteLine("2. Add a Film to a particular Streaming Service");
                Console.WriteLine("3. Remove a Film to a particular Streaming Service");
                Console.WriteLine("4. Set the rating of a particular Film");
              

                userInput = Console.ReadLine().Trim();
                if (userInput == "q" || userInput == string.Empty)
                {
                    break;
                }
                if (!int.TryParse(userInput, out int choice) || choice < 1)
                {
                    Console.WriteLine("Entered invalid option");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Details of Streaming Service in this format (Name Price):");
                        string[] serviceDetails = Console.ReadLine().Split(' ');

                        subscribedServices.Add(new StreamingService(serviceDetails[0], float.Parse(serviceDetails[1])));
                        Console.WriteLine("Added Service");
 
                        break;

                    case 2:
                        Console.WriteLine("Enter Details of Film in this format (Name Year Genre Runtime):");
                        string[] filmDetails = Console.ReadLine().Split(' ');
                        Film filmToAdd = new Film(filmDetails[0], int.Parse(filmDetails[1]), filmDetails[2], float.Parse(filmDetails[3]));
                        Console.WriteLine("Enter Name of Streaming Service to Film to: ");
                        StreamingService tempService = new StreamingService(Console.ReadLine(), 0);
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (service.ContainsFilm(filmToAdd))
                            {
                                Console.WriteLine("Film already exists on another Streaming Service");
                                break;
                            }
                        }
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (service.CompareTo(tempService) == 0)
                            {
                                service.AddFilm(filmToAdd);
                                Console.WriteLine("Film Added");
                                break;
                            }
                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter Details of Film in this format (Name Year):");
                        string[] filmDetailsToRemove = Console.ReadLine().Split(' ');

                        Console.WriteLine("Enter Name of Streaming Service to remove Film from: ");
                        StreamingService tempService2 = new StreamingService(Console.ReadLine(), 0);
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService2.CompareTo(service) == 0)
                            {
                                service.RemoveFilm(new Film(filmDetailsToRemove[0], int.Parse(filmDetailsToRemove[1]), "", 0));
                                Console.WriteLine("Remove Film");
                                break;
                            }
                        }
                        Console.WriteLine("Film isn't able to be removed");

                        break;
                    case 4:
                        Console.WriteLine("Enter Name of Streaming Service which has the Film: ");
                        StreamingService tempService3 = new StreamingService(Console.ReadLine(), 0);
                        Console.WriteLine("Enter Details of Film to rate in this format (Name Year):");
                        string[] filmDetailsToRate = Console.ReadLine().Split(' ');
                        Console.WriteLine("Enter Rating (1-5): ");
                        int rating = int.Parse(Console.ReadLine());
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService3.CompareTo(service) == 0)
                            {
                                service.SetFilmRating(new Film(filmDetailsToRate[0], int.Parse(filmDetailsToRate[1]), "", 0), rating);
                                
                            }
                        }
                        break;



                }
            } while (true);
        }

    }
}

