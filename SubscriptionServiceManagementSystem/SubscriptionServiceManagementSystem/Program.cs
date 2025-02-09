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
            StreamingService tempService;
            bool foundCopy = false;
            do
            {
                Console.WriteLine("Enter options for Management System: ");
                Console.WriteLine("1. Add Subscribed Streaming Service");
                Console.WriteLine("2. Add a Film to a particular Streaming Service");
                Console.WriteLine("3. Remove a Film from a particular Streaming Service");
                Console.WriteLine("4. Set the rating of a particular Film");
                Console.WriteLine("5. Add a TV Show to a particular Streaming Service");
                Console.WriteLine("6. Remove a TV show from a particular Streaming Service");
                Console.WriteLine("7. Set the rating of a particular TV Show");
                Console.WriteLine("8. Print Available Shows and Films on a Streaming Service: ");


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
                        Console.WriteLine("Enter Name of Streaming Service to add Film to: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);

                        //Checks for if the film is already on another streaming service
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (service.ContainsFilm(filmToAdd))
                            {
                                Console.WriteLine("Film already exists on another Streaming Service");
                                foundCopy = true;
                                break;
                            }
                        }

                        if(!foundCopy)
                        {
                            //Finds the service to add the film to 
                            foreach (StreamingService service in subscribedServices)
                            {
                                if (service.CompareTo(tempService) == 0)
                                {
                                    service.AddFilm(filmToAdd);
                                    break;
                                }
                            }
                        }

                        //Sets the bool to false so that it can check if anotehr duplicate is found later
                        foundCopy = false;

                        break;

                    case 3:
                        Console.WriteLine("Enter Details of Film in this format (Name Year):");
                        string[] filmDetailsToRemove = Console.ReadLine().Split(' ');

                        Console.WriteLine("Enter Name of Streaming Service to remove Film from: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);

                        //Loops through each service and removes the film from the one specified by the user
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService.CompareTo(service) == 0)
                            {
                                service.RemoveFilm(new Film(filmDetailsToRemove[0], int.Parse(filmDetailsToRemove[1]), "", 0));
                                Console.WriteLine("Remove Film");
                                break;
                            }
                        }
                     
                        break;
                    case 4:
                        Console.WriteLine("Enter Name of Streaming Service which has the Film: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);
                        Console.WriteLine("Enter Details of Film to rate in this format (Name Year):");
                        string[] filmDetailsToRate = Console.ReadLine().Split(' ');
                        Console.WriteLine("Enter Rating (1-5): ");
                        int rating = int.Parse(Console.ReadLine());
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService.CompareTo(service) == 0)
                            {
                                service.SetFilmRating(new Film(filmDetailsToRate[0], int.Parse(filmDetailsToRate[1]), "", 0), rating);
                                
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Details of TV show in this format (Name Genre SeasonCount):");
                        string[] showDetails = Console.ReadLine().Split(' ');
                        TVShow showToAdd = new TVShow(showDetails[0], showDetails[1]);

                        //For loop for adding seasons to the show thats about to be added to the streaming service
                        for(int i = 0; i< int.Parse(showDetails[2]); i++)
                        {
                            Console.WriteLine($"Enter Details for the Season in this format (Number Year EpisodeCount): ");
                            string[] seasonDetails = Console.ReadLine().Split(' ');
                            showToAdd.AddSeason(new Season(int.Parse(seasonDetails[0]), int.Parse(seasonDetails[1]), int.Parse(seasonDetails[2])));
                        }

                        Console.WriteLine("Enter Name of Streaming Service to add TV show to: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);

                        foreach (StreamingService service in subscribedServices)
                        {
                            //ContainsSeason checks the show to be added with each show currently on each service
                            //If the show to be added has the same name as another show and has at least one season from that other show
                            //Then the show isn't added to the service as the seasons are exclusive to different streaming services
                            if (service.ContainsSeason(showToAdd))
                            { 
                                Console.WriteLine("One of those seasons already exists on another Streaming Service");
                                foundCopy = true;
                                break;
                            }
                        }

                        if (!foundCopy)
                        {
                            foreach (StreamingService service in subscribedServices)
                            {
                                if (service.CompareTo(tempService) == 0)
                                {
                                    service.AddShow(showToAdd);
                                    break;
                                }
                            }
                        }
                        foundCopy = false;

                        break;
                    case 6:
                        Console.WriteLine("Enter Name of TV show: ");
                        string showDetailsToRemove = Console.ReadLine();

                        Console.WriteLine("Enter Name of Streaming Service to remove TV show from: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);

                        foreach (StreamingService service in subscribedServices)
                        {
                            if (service.CompareTo(tempService) == 0)
                            {
                                service.RemoveShow(new TVShow(showDetailsToRemove, ""));
                                Console.WriteLine("TV show Removed");
                                break;
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name of Streaming Service which has the TV show: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);
                        Console.WriteLine("Enter Name of TV show to rate: ");
                        string showToRate = Console.ReadLine();
                        Console.WriteLine("Enter Rating (1-5): ");
                        int tvRating = int.Parse(Console.ReadLine());
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService.CompareTo(service) == 0)
                            {
                                service.SetShowRating(new TVShow(showToRate, ""), tvRating);

                            }
                        }
                        break;
                    case 8:
                        //Added a print option so that each show and film can be displayed for each streaming service
                        Console.WriteLine("Enter Name of Streaming Service: ");
                        tempService = new StreamingService(Console.ReadLine(), 0);
                        foreach (StreamingService service in subscribedServices)
                        {
                            if (tempService.CompareTo(service) == 0)
                            {
                               service.PrintAvailableFilms();
                               service.PrintAvailableShows();

                            }
                        }
                        break;


                }
            } while (true);
        }

    }
}

