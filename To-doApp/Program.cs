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
                Console.Write("Enter add show remove edit or end: ");
                var userInput = Console.ReadLine().Trim();

                if (userInput == "add")
                {
                    Console.Write("Enter To-do to add : ");
                    var todoInput = Console.ReadLine().Trim();

                    list.Add(todoInput);

                    Console.WriteLine("\n");
                    Console.WriteLine($"{todoInput} added in todo list");
                    Console.WriteLine("\n");
                }
                else if (userInput == "show")
                {
                    Console.WriteLine("\n");
                    ShowDetails(list);
                    Console.WriteLine("\n");
                }
                else if (userInput == "end")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Ended..");
                    Console.WriteLine("\n");
                    break;
                }
                else if (userInput == "remove")
                {
                    var correct = true;

                    if (list.Count() == 0)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("list is empty..");
                        Console.WriteLine("\n");
                        correct = false;
                    }

                    while (correct)
                    {
                        Console.WriteLine("\n");
                        ShowDetails(list);
                        Console.WriteLine("\n");

                        Console.Write("Enter To-do number to remove : ");
                        var numberInput = Console.ReadLine().Trim();
                        int removeInput;

                        if (int.TryParse(numberInput, out removeInput))
                        {
                            if (removeInput + 1 > list.Count())
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine($"Range is incorrect in the todo app there is only {list.Count()} item..");
                                Console.WriteLine("\n");

                                correct = true;
                                break;
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine($"{list.ElementAt(removeInput - 1)} removed from todo list..");
                            Console.WriteLine("\n");

                            list.RemoveAt(removeInput - 1);
                            correct = false;
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Wrong input please enter a Number...");
                            Console.WriteLine("\n");
                            correct = true;
                        }
                    }
                }
                else if (userInput == "edit")
                {
                    var correct = true;

                    if (list.Count() == 0)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("list is empty..");
                        Console.WriteLine("\n");
                        correct = false;
                    }

                    while (correct)
                    {
                        Console.WriteLine("\n");
                        ShowDetails(list);
                        Console.WriteLine("\n");

                        Console.Write("Enter To-do number to edit or done : ");
                        var numberEdit = Console.ReadLine().Trim();
                        int editInput;


                        if (int.TryParse(numberEdit, out editInput))
                        {
                            if (editInput + 1 > list.Count())
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine($"Range is incorrect in the todo app there is only {list.Count()} item..");
                                Console.WriteLine("\n");

                                correct = true;
                                break;
                            }

                            var removedItem = list.ElementAt(editInput - 1);

                            Console.Write("Enter new to-do : ");
                            var newTodo = Console.ReadLine().Trim();

                            list.RemoveAt(editInput - 1);
                            list.Insert(editInput - 1, newTodo);

                            Console.WriteLine("\n");
                            Console.WriteLine($"{removedItem} removed and {newTodo} added in the to-do list..");
                            Console.WriteLine("\n");

                            correct = false;
                        }
                        else if (numberEdit == "done")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Exited from the edit mode....");
                            Console.WriteLine("\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Wrong input please enter a Number...");
                            Console.WriteLine("\n");
                            correct = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input..");
                }
            }
        }
        static public void ShowDetails(List<string> list)
        {
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
        }
    }
}
