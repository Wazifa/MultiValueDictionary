using System;
using System.Collections.Generic;
using System.Linq;

namespace Spreetail
{
    public class Dictionary
    {
        Dictionary<string, List<string>> dictionary;

        public Dictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public void Command(string word)
        {
            List<string> userInput = word.Split(" ").ToList();
            string command = userInput[0].ToLower();
            userInput.RemoveAt(0);

            switch(command)
            {
                case "add" :
                    Add(userInput);
                    break;

                case "keys":
                    Keys();
                    break;

                case "members":
                    Members(userInput);
                    break;

                case "remove":
                    Remove(userInput);
                    break;

                case "removeall":
                    RemoveAll(userInput);
                    break;

                case "clear":
                    Clear();
                    break;

                case "keyexists":
                    KeyExists(userInput);
                    break;

                case "memberexists":
                    MemberExists(userInput);
                    break;

                case "allmembers":
                    AllMembers();
                    break;

                case "items":
                    Items();
                    break;
            }
        }

        public void Add(List<string> values)
        { 
            string key = values[0];

            if (dictionary.ContainsKey(key))
            {

                if (dictionary[key].Contains(values[1]))
                {
                    Console.WriteLine("ERROR, member already exists for key");
                    return;
                }
                
                dictionary[key].Add(values[1]);
                
            }
            else
            {
                values.RemoveAt(0);
                dictionary.Add(key, values.ToList());
            }

            Console.WriteLine(") Added");
        }

        public void Keys()
        {
            if(dictionary.Count == 0)
            {
                Console.WriteLine("empty set");
                return;
            }
            int iteration = 1;

            foreach(var item in dictionary)
            {
                Console.WriteLine(iteration + ")" + " " + item.Key);
                iteration++;
            }
        }

        public void Remove(List<string> values)
        {
            if (! dictionary.ContainsKey(values[0]))
            {
                Console.WriteLine("ERROR, key does not exist");
            }
            else
            {
                var items = dictionary[values[0]];
                if(!items.Contains(values[1]))
                {
                    Console.WriteLine("ERROR, member does not exist");
                }
                else
                {
                    dictionary[values[0]].Remove(values[1]);
                    if (dictionary[values[0]].Count == 0) dictionary.Remove(values[0]);

                    Console.WriteLine(") Removed");
                }
            }
        }

        public void Members(List<string> values)
        {
            if (!dictionary.ContainsKey(values[0]))
            {
                Console.WriteLine("ERROR, key does not exist");
                return;
            }
            int iteration = 1;

            List<string> members = dictionary[values[0]];
            
            foreach (var value in members)
            {
                Console.WriteLine(iteration + ")" + " " + value);
                iteration++;
            }

        }

        public void RemoveAll(List<string> values)
        {
            if(!dictionary.ContainsKey(values[0]))
            {
                Console.WriteLine("ERROR, key does not exist");
                return;
            }

            dictionary.Remove(values[0]);
            Console.WriteLine("Removed");
        }

        public void Clear()
        {
            dictionary.Clear();
            Console.WriteLine("Cleared");
        }

        public void KeyExists(List<string> values)
        {
            if (dictionary.ContainsKey(values[0]))
                Console.WriteLine(") true");

            else Console.WriteLine(") false");
        }

        public void MemberExists(List<string> values)
        {
            if (dictionary.ContainsKey(values[0]))
            {
                List<string> members = dictionary[values[0]];

                if (members.Contains(values[1])) Console.WriteLine(") true");
                else Console.WriteLine(") false");
            }
        }

        public void AllMembers()
        {
            if(dictionary.Count == 0)
            {
                Console.WriteLine("empty set");
                return;
            }
            int iteration = 1;
            foreach(var list in dictionary)
            {
                foreach(string item in list.Value)
                {
                    Console.WriteLine(iteration + ")" + " " + item);
                    iteration++;
                }
            }
        }

        public void Items()
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("empty set");
                return;
            }
            int iteration = 1;
            foreach (var list in dictionary)
            {
                foreach (string item in list.Value)
                {
                    Console.WriteLine(iteration + ")" + " " + list.Key + " " + item);
                    iteration++;
                }
            }
        }
    }
}
