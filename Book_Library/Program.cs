using System;
using System.Collections.Generic;


namespace Book_Library
{
    class Program
    {
        static List<IBook> Library = new List<IBook>();

        static void Main(string[] args)
        {
            int choice = -1;

            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add Book");
                Console.WriteLine("2 - Find Book");
                Console.WriteLine("3 - Borrow Book");
                Console.WriteLine("4 - Return Book");

                Console.WriteLine("Choose your option from the menu: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        throw new FormatException("Invalid input");
                    }

                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Program is Done..");
                            break;
                        case 1:
                            AddBook();
                            break;
                        case 2:
                            FindBook();
                            break;
                        case 3:
                            BorrowBook();
                            break;
                        case 4:
                            ReturnBook();
                            break;
                        default:
                            Console.WriteLine("This operation is not supported, please try again.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexpected error occurred: {e.Message}");
                }
            } while (choice != 0);
        }

        //method to add books
        static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Book Type: (Audiobook, Ebook, Hardcover");
            Console.WriteLine("Please Enter the Book Type: ");
            string booktype = Console.ReadLine();
            Console.WriteLine("Please Enter the Book Title: ");
            string booktitle = Console.ReadLine();

            IBook book;

            if (booktype.Equals("Ebook"))
            {
                book = new Ebook(booktitle);
            }
            else if (booktype.Equals("Hardcover"))
            {
                book = new HardCover(booktitle);
            }
            else if (booktype.Equals("Audiobook"))
            {
                book = new Audiobook(booktitle);
            }
            else
            {
                Console.WriteLine("Invalid Book Type. Book not Added.");
                return;
            }

            Library.Add(book);
            string location = book.GetLocation();
            Console.WriteLine($"Book '{booktitle}' of '{booktype}' has been added to the {location}.");

        }

        //method to find a book
        static void FindBook()
        {
            Console.Clear();
            Console.WriteLine("Please Enter a Book title:");
            string booktitle = Console.ReadLine();

            // iterates in the library lists to look for a specific title
            foreach (var book in Library)
            {
                if (book is HardCover hc && hc.Booktitle == booktitle ||
                    book is Ebook eb && eb.Booktitle == booktitle ||
                    book is Audiobook ab && ab.Booktitle == booktitle)
                {
                    //Prints the status of the book and its location
                    string status = book.IsBorrowed ? "borrowed" : "available";
                    string location = book.GetLocation();
                    Console.WriteLine($"The book {booktitle} is {status} and is in the {location}.");
                    return;
                }
            }

            Console.WriteLine($"The book {booktitle} does not exist in the Library or the Web.");
        }

        //method to borrow a book
        static void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("Enter book title:");
            string booktitle = Console.ReadLine();

            //Iterates in to the library lists to match a specific title of the book that the client will borrow
            foreach (var book in Library)
            {
                if (book is HardCover hc && hc.Booktitle == booktitle ||
                    book is Ebook eb && eb.Booktitle == booktitle ||
                    book is Audiobook ab && ab.Booktitle == booktitle)
                {
                    //marked the book as borrowed
                    book.MarkAsBorrowed();
                    //updates its location
                    Console.WriteLine($"The book '{booktitle}' has been borrowed and its location is now on the'{book.GetLocation()}'.");
                    return;
                }
            }

            Console.WriteLine($"The book {booktitle} does not exist in the library.");
        }

        //method to return a book 
        static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("Enter book title:");
            string booktitle = Console.ReadLine();

            // iterates through the library lists and marks the book as returned and update its location.
            foreach (var book in Library)
            {
                if (book is HardCover hc && hc.Booktitle == booktitle ||
                    book is Ebook eb && eb.Booktitle == booktitle ||
                    book is Audiobook ab && ab.Booktitle == booktitle)
                {
                    book.MarkAsReturned();
                    string location = book.GetLocation();
                    Console.WriteLine($"The book {booktitle} has been returned to the {location}.");
                    return;
                }
            }

            Console.WriteLine($"The book {booktitle} does not exist in the library or in the Web.");
        }
    }
    }
