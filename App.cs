using System;
using System.Collections.Generic;
using console_library2.Models;

namespace console_library2
{
  public class App
  {
    public List<string> Messages { get; set; } = new List<string>();
    public Library Library { get; set; } = new Library();
    public App()
    {
    }

    public void Run()
    {
      bool RunLibrary = true;
      Console.Clear();
      Messages.Add(@"Welcome to:
   ___                      _          __ _ _                            ____  
  / __\___  _ __  ___  ___ | | ___    / /(_) |__  _ __ __ _ _ __ _   _  |___ \ 
 / /  / _ \| '_ \/ __|/ _ \| |/ _ \  / / | | '_ \| '__/ _` | '__| | | |   __) |
/ /__| (_) | | | \__ \ (_) | |  __/ / /__| | |_) | | | (_| | |  | |_| |  / __/ 
\____/\___/|_| |_|___/\___/|_|\___| \____/_|_.__/|_|  \__,_|_|   \__, | |_____|
                                                                 |___/         
            ");
      while (RunLibrary == true)
      {
        Print();
        System.Console.WriteLine("What would you like to do?");
        System.Console.WriteLine("[v]iew Library, E[x]it Library");
        string option = Console.ReadLine().ToLower();
        switch (option)
        {
          case "v":
          case "view":
            Messages.Add(Library.ViewLibrary());
            break;
          case "q":
          case "quit":
          case "x":
          case "exit":
            RunLibrary = false;
            break;
        }
      }
    }

    private void Print()
    {
      foreach (string m in Messages)
      {
        System.Console.WriteLine(m);
      }
      Messages.Clear();
    }
  }
}