﻿using System;
using System.Collections.Generic;
using System.Text;
using AIMLbot;
using System.IO;

namespace ConsoleBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string settingsPath = Path.Combine(Environment.CurrentDirectory, Path.Combine("config", "Settings.xml"));

            Bot myBot = new Bot();
            myBot.loadSettings(settingsPath);
            User myUser = new User("consoleUser", myBot);
            myBot.isAcceptingUserInput = false;
            myBot.loadAIMLFromFiles();
            myBot.isAcceptingUserInput = true;
            while (true)
            {
                Console.Write("You: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    Request r = new Request(input, myUser, myBot);
                    Result res = myBot.Chat(r);
                    Console.WriteLine("Bot: " + res.Output);
                }
            }
        }
    }
}
