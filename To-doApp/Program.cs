using System;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            while (true)
            {
                Console.Write("Enter 'add', 'show', 'remove', 'edit', or 'end': ");
                var userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "add")
                {
                    AddTask(list);
                }
                else if (userInput == "show")
                {
                    ShowDetails(list);
                }

                else if (userInput == "remove")
                {
                    RemoveTask(list);
                }
                else if (userInput == "edit")
                {
                    EditTask(list);
                }
                else if (userInput == "end")
                {
                    Console.WriteLine("\nEnded..\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input..");
                }
            }
        }

        static public void ShowDetails(List<string> list)
        {
            Console.WriteLine("\n");
            var i = 1;
            if (list.Count() == 0)
            {
                Console.WriteLine("List is empty..");
            }
            else
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{i}.{item}");
                    i++;
                }
            }
            Console.WriteLine("\n");
        }

        static public void AddTask(List<string> list)
        {
            Console.Write("Enter To-do to add : ");
            var todoInput = Console.ReadLine().Trim().ToLower();

            list.Add(todoInput);

            Console.WriteLine($"\n{todoInput} added in todo list\n");
        }

        static public void RemoveTask(List<string> list)
        {
            var inputIsNumber = true;

            if (list.Count() == 0)
            {
                Console.WriteLine("\nlist is empty..\n");
                inputIsNumber = false;
            }

            while (inputIsNumber)
            {
                Console.WriteLine("\n");
                ShowDetails(list);
                Console.WriteLine("\n");

                Console.Write("Enter To-do number to remove : ");
                var numberInput = Console.ReadLine().Trim().ToLower();
                int removeInput;

                if (int.TryParse(numberInput, out removeInput))
                {
                    if (removeInput > list.Count())
                    {
                        Console.WriteLine($"\nRange is incorrect in the todo app there is only {list.Count()} item..\n");

                        inputIsNumber = true;
                        break;
                    }

                    Console.WriteLine($"\n{list.ElementAt(removeInput - 1)} removed from todo list..\n");

                    list.RemoveAt(removeInput - 1);
                    inputIsNumber = false;
                }
                else
                {
                    Console.WriteLine("\nWrong input please enter a Number...\n");
                    inputIsNumber = true;
                }
            }
        }

        static public void EditTask(List<string> list)
        {
            var inputIsNumber = true;

            if (list.Count() == 0)
            {
                Console.WriteLine("\nlist is empty..\n");
                inputIsNumber = false;
            }

            while (inputIsNumber)
            {
                Console.WriteLine("\n");
                ShowDetails(list);
                Console.WriteLine("\n");

                Console.Write("Enter To-do number to edit or done : ");
                var numberEdit = Console.ReadLine().Trim().ToLower();
                int editInput;

                if (int.TryParse(numberEdit, out editInput))
                {
                    if (editInput > list.Count())
                    {
                        Console.WriteLine($"\nRange is incorrect in the todo app there is only {list.Count()} item..\n");

                        inputIsNumber = true;
                        break;
                    }

                    var removedItem = list.ElementAt(editInput - 1);

                    Console.Write("Enter new to-do : ");
                    var newTodo = Console.ReadLine().Trim().ToLower();

                    list.RemoveAt(editInput - 1);
                    list.Insert(editInput - 1, newTodo);

                    Console.WriteLine($"\n{removedItem} removed and {newTodo} added in the to-do list..\n");

                    inputIsNumber = false;
                }
                else if (numberEdit == "done")
                {
                    Console.WriteLine("\nExited from the edit mode....\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nWrong input please enter a Number...\n");
                    inputIsNumber = true;
                }
            }
        }
    }
}
