namespace libraybook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] titles = new string[100];
            string[] authors = new string[100];
            string[] isbns = new string[100];
            bool[] available = new bool[100];
            string[] borrowers = new string[100];

            int lastIndex = -1; // Initialize lastIndex to -1 since no books are added yet

            lastIndex++;// Increment to 0 for the first book

            titles[lastIndex] = "MATH";
            authors[lastIndex] = "HASNA ";
            isbns[lastIndex] = "111";
            available[lastIndex] = true;
            borrowers[lastIndex] = "---     ----";

            lastIndex++;
            titles[lastIndex] = "Algorithms";
            authors[lastIndex] = "HOOR";
            isbns[lastIndex] = "222";
            available[lastIndex] = true;
            borrowers[lastIndex] = "-----    -----";


            lastIndex++;
            titles[lastIndex] = " Sciences";
            authors[lastIndex] = "NOOR ";
            isbns[lastIndex] = "333";
            available[lastIndex] = true;
            borrowers[lastIndex] = "-----    -----";






            while (true)
            {
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7. Exit");
                Console.Write("Choose option: ");
                Console.WriteLine("--------------------------------------");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Title: ");
                        titles[lastIndex] = Console.ReadLine();

                        Console.Write("Author: ");
                        authors[lastIndex] = Console.ReadLine();

                        Console.Write("ISBN: ");
                        isbns[lastIndex] = Console.ReadLine();

                        available[lastIndex] = true;
                        borrowers[lastIndex] = "";

                        Console.WriteLine("Book added");
                        break;

                    case 2:
                         if (choice == 2)
                        {
                            Console.Write("Enter ISBN: ");
                            string isbn = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (isbns[i] == isbn)
                                {
                                    found = true;

                                    if (available[i])
                                    {
                                        Console.Write("Borrower name: ");
                                        borrowers[i] = Console.ReadLine();
                                        available[i] = false;
                                        Console.WriteLine("Book borrowed successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book already borrowed");
                                    }

                                    break;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Book not found");
                            }
                        }

                        break;



                    case 3:

                        if (choice == 3)
                        {
                            Console.Write("Enter ISBN: ");
                            string isbn = Console.ReadLine();

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (isbns[i] == isbn)
                                {
                                    available[i] = true;
                                    borrowers[i] = "";
                                    Console.WriteLine("Book returned");

                                }
                            }
                        }
                                    break;
                                











                }
            }
        }
    }
}






