using System;
using System.Collections.Immutable;
using System.ComponentModel;

class Program // This program showcases all of the functions 
{
    static void Main (string[] args)
    {
        var dictionaryProject = new Dictionary<string, List<int>>() // This is the dictionary that powers this program, thanks to Rujumba Garfabusa for the idea of having multiple values on one key.
        {
          {"Dolphins", [1, 15]}, 
          {"Buccaneers", [7, 8]},
          {"Jaguars", [12, 3]},  
        };

        var sortedDictionaryProject = dictionaryProject.OrderBy(kv => kv.Key); // This is the sorted dictionary that displays when you view it, it can be sorted ascended and decended.

        
        bool escapeNumber = false; // This value is to stop the loop
        
        while (escapeNumber == false) {
            Console.WriteLine("");
            Console.WriteLine("Please type in these options:");
            Console.WriteLine("Add, Append, View, Sort, Delete, Quit");
            string? caseString = Console.ReadLine();
            string? inputString;
            int inputNumber;
            int inputNumber2;
            Console.WriteLine("");
   
            switch(caseString) // Six values, Add, Append, View, Sort, Delete, Quit
            {
                case "Add":
                    

                    try
                    {
                        Console.WriteLine("What is the team you are planning to add?");
                        inputString = Console.ReadLine();
                        Console.WriteLine("How many wins does the team have?");
                        inputNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How many losses does the team have?");
                        inputNumber2 = Convert.ToInt32(Console.ReadLine());
                        
                        
                        if (inputString != null) // These if statement is used to prevent a warning, and appear all along the program
                        {
                            dictionaryProject.Add(inputString, [inputNumber, inputNumber2]);
                            Console.WriteLine("You have added team " + inputString + " with " + inputNumber + " wins, and " + inputNumber2 + " losses.");
                        }
                        
                    }
                    catch(ArgumentNullException) // This is for catching any errors that occur in the program
                    {
                        Console.WriteLine("The values or key is null");
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("The values that you put is not an integer.");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("An error has occurred");
                    }
                    
                    break;
                case "Delete":
                    Console.WriteLine("What is the team you are planning to delete"); // This deletes a value off the program.
                    inputString = Console.ReadLine();
                    if (inputString != null && dictionaryProject.ContainsKey(inputString))
                    {
                        dictionaryProject.Remove(inputString);
                        Console.WriteLine("Team " + inputString + " deleted.");
                    }
                    
                    break;
                
                case "View":
                    foreach(KeyValuePair <string, List<int>> kv in sortedDictionaryProject) // This code is a modified version of the code from the textbook.
                    {
                        Console.WriteLine (kv.Key + ",  " + kv.Value[0] + " Wins, and " + kv.Value[1] + " Losses.");
                    }
                         
                    break;
                
                case "Append":
                
                    try
                    {
                        Console.WriteLine("What is the team you are picking:");
                        foreach (string previewString in dictionaryProject.Keys) Console.WriteLine(previewString + " "); // Similar to the Viewer, execept without any wins or looses.
                        Console.WriteLine("----------------------");
                        inputString = Console.ReadLine();
                    
                        if (inputString != null)
                        {
                              if (dictionaryProject.ContainsKey(inputString)) // This if statement is to remove any errors that involve the wrong variable.
                            {
    
                                 Console.WriteLine("How many wins does the team have?");
                                 inputNumber = Convert.ToInt32(Console.ReadLine());
                                 Console.WriteLine("How many losses does the team have?");
                                 inputNumber2 = Convert.ToInt32(Console.ReadLine());
                    
                        
                                 dictionaryProject[inputString][0] = inputNumber;
                                 dictionaryProject[inputString][1] = inputNumber2;

                                 Console.WriteLine("The win lose ratio of team " + inputString + " is now " + inputNumber + " Wins and " + inputNumber2 + " Losses.");
                            }
            
                        } 
                        else
                        {
                            Console.WriteLine("Value of " + inputString + " is not found in the team list");
                        }
                    }
                    catch(ArgumentNullException)
                    {
                        Console.WriteLine("The values or key is null");
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("The values that you put is not an integer.");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("An error has occurred");
                    }
                    
                    
                    
                    break;
                     
                case "Quit":
                    escapeNumber = true; // Simply quits the program
                    Console.WriteLine("Goodbye.");
                    break;
                case "Sort":
                    Console.WriteLine("Please type in these options:");
                    Console.WriteLine("Ascending, Decending");
                    caseString = Console.ReadLine();
                    switch(caseString)
                    {
                        case"Ascending":
                                 sortedDictionaryProject = dictionaryProject.OrderBy(kv => kv.Key); // The sorting systems are using LINQ, allowing for ordering of the teams.
                                 break;
                        case"Decending":
                                 sortedDictionaryProject = dictionaryProject.OrderByDescending(kv => kv.Key);
                                 break;
                    }
                    break;
            }
        }   
    }
}

// This is the end.