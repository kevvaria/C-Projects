using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace HTMLScrapper
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            // variable declaration
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            List<string> list = new List<string>();

            // obtain the URL from user input
            Console.WriteLine("Welcome to HTML scrapping using the HTMLAgilityPack library." +
                "Please be ethically mindful using this code.");
            Console.Write("Please enter the URL you would like to scrap: ");
            string url = Console.ReadLine();
            
            // Load the URL, parse HTML for all available href links
            doc = web.Load(url);            
            list = getLinks(doc);

            // print the list of links obtained
            printList(list);
        }

        /*
         * Method Name: getLinks
         * Parameter: HTML document
         * Return: list of links
         * Purpose: parse links from the HTML document and store in a list
         */
        static List<string> getLinks(HtmlDocument doc)
        {
            List<string> tempList = new List<string>();
            foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                var attribute = link.Attributes["href"];
                tempList.Add(attribute.Value);
            }
            return tempList;
        }

        /*
         * Method Name: printList
         * Parameter: list of links
         * Purpose: print each list item one by one
         */
        static void printList(List<string> list)
        {
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem);
            }
        }
    }
}
