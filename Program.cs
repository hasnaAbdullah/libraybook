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

            string[] categories = new string[100];
            int[] borrowCount = new int[100];
            DateOnly[] returnDate = new DateOnly[100];
            double[] lateFees = new double[100];





            // Adding initial books to the system for testing
            // Each book data must use the same index

            int lastIndex = 0;
            lastIndex++;
            titles[lastIndex] = "MATH";
            authors[lastIndex] = "HASNA ";
            isbns[lastIndex] = "111";
            available[lastIndex] = true;
            borrowers[lastIndex] = "---     ----";
            categories[0] = "Math";
            borrowCount[0] = 5;
            lateFees[0] = 0;


           

            lastIndex++;
            titles[lastIndex] = "Algorithms";
            authors[lastIndex] = "HOOR";
            isbns[lastIndex] = "222";
            available[lastIndex] = true;
            borrowers[lastIndex] = "-----    -----";
            categories[1] = "Computer";
            borrowCount[1] = 2;
            lateFees[1] = 0;


            lastIndex++;
            titles[lastIndex] = " Sciences";
            authors[lastIndex] = "NOOR ";
            isbns[lastIndex] = "333";
            available[lastIndex] = false;
            borrowers[lastIndex] = "Noof";
            categories[2] = "Science";
            borrowCount[2] = 7;
            lateFees[2] = 0;



            bool exit = false;
            // Main loop to keep the system running until user exits
            while (exit == false)
            {
                // Display main menu options to the user
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7.View Most Popular Books ");
                Console.WriteLine("8. Search Books by Category");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Choose Opation");
                Console.WriteLine("--------------------------------------");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {




                    // CASE 1: Add a new book to the library
                    // Increases lastIndex and stores all book information
                    // New books are always available by default

                    case 1:
                        {
                            lastIndex++;

                            Console.Write("Title: ");
                            titles[lastIndex] = Console.ReadLine();

                            Console.Write("Author: ");
                            authors[lastIndex] = Console.ReadLine();

                            Console.Write("ISBN: ");
                            isbns[lastIndex] = Console.ReadLine();

                            Console.Write("Category: ");
                            categories[lastIndex] = Console.ReadLine();


                            available[lastIndex] = true;
                            borrowers[lastIndex] = "";
                            borrowCount[lastIndex] = 0;
                            lateFees[lastIndex] = 0;
                            exit = false;

                            Console.WriteLine("Book added");
                        }
                        break;




                    // CASE 2: Borrow a book by title
                    // User enters book title
                    // If more than one book has the same title, all are displayed
                    // User must choose the correct book using ISBN
                    // Borrow count increases and return date is set
                    case 2:

                        Console.Write("Enter ISBN: ");
                        string isbnInput = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (isbns[i] == isbnInput)
                            {
                                found = true;

                                if (available[i])
                                {
                                    Console.Write("Borrower name: ");
                                    borrowers[i] = Console.ReadLine();
                                    available[i] = false;
                                    borrowCount[i]++;
                                     DateOnly today = DateOnly.FromDateTime(DateTime.Today).AddDays(3);
                                    returnDate[i] = today;
                                    lastIndex++;
                                    Console.WriteLine("Book borrowed successfully");
                                    Console.WriteLine("Borrow count: " + borrowCount[i]);
                                    Console.WriteLine("Return date: " + returnDate[i].ToShortDateString());

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

                        break;


                    // CASE 3: Return a borrowed book
                    // User enters ISBN
                    // System checks if the book was borrowed
                    // If returned late, a late fee is calculated

                    case 3:

                        Console.Write("Enter ISBN: ");
                        string returnISBN = Console.ReadLine();

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (isbns[i] == returnISBN && available[i]) 
                            {
                                 DateOnly today = DateOnly.FromDateTime(DateTime.Today);

                                if (today > returnDate[i])
                                {
                                    int lateDays = (today.DayNumber -  returnDate[i].DayNumber); 
                                    lateFees[i] = lateDays * 0.5;
                                    Console.WriteLine("Late fee: " + lateFees[i]);
                                }
                                else
                                {
                                    Console.WriteLine("Book returned on time");
                                }

                                available[i] = true;
                                borrowers[i] = "";
                            }
                        }
                        break;

                    // CASE 4: Search for a book
                    // User can search by ISBN or Title
                    // Displays book information if found

                    case 4:
                         {
                            Console.Write("Enter ISBN or Title: ");
                            string search = Console.ReadLine();

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (isbns[i] == search || titles[i] == search)
                                {
                                    Console.WriteLine("Title: " + titles[i]);
                                    Console.WriteLine("Author: " + authors[i]);
                                    Console.WriteLine("Category " + categories[i]);
                                    Console.WriteLine("Available: " + available[i]);


                                }
                            }
                        }

                        break;
                    // CASE 5: List all available books
                    // Displays only books that are not currently borrowed

                    case 5:

                        {
                            Console.WriteLine("Available Books:");
                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (available[i])
                                {
                                    Console.WriteLine("Title: " + titles[i] + " Author: " + authors[i] + " ISBN: " + isbns[i]);
                                }
                            }
                        }

                        break;
                    // CASE 6: Transfer a book to another borrower
                    // If borrower has more than one book
                    // System displays all borrowed books
                    // User selects which book to transfer by ISBN

                    case 6:
                        {

                            Console.Write(" Current borrower:");
                            string from = Console.ReadLine();


                            Console.Write(" New borrower :");
                            string to = Console.ReadLine();




                            for (int i = 0; i <= lastIndex; i++)
                            {

                                if (borrowers[i].Equals(from))
                                {
                                    borrowers[i] = to;
                                }



                            }
                            Console.WriteLine(" Transfer completed ");

                        }
                        break;

                    // CASE 7: Display most popular books
                    // Books are sorted in descending order by borrow count
                    // Sorting keeps all book information together

                    case 7:


                        for (int i = 0; i <= lastIndex; i++)
                            for (int j = i + 1; j <= lastIndex; j++)
                                if (borrowCount[j] > borrowCount[i])
                                {
                                    int temp = borrowCount[i];
                                    borrowCount[i] = borrowCount[j];
                                    borrowCount[j] = temp;

                                    string t = titles[i];
                                    titles[i] = titles[j];
                                    titles[j] = t;
                                }

                        Console.WriteLine("Most Popular Books:");
                        for (int i = 0; i <= lastIndex; i++)
                            Console.WriteLine(titles[i] + " - Borrowed: " + borrowCount[i]);
                        break;

                    // CASE 8: Search books by category
                    // Displays all books under the selected category


                    case 8:
                        Console.Write("Enter category: ");
                        string cat = Console.ReadLine();
                        bool foundCat = false;

                        for (int i = 0; i <= lastIndex; i++)
                            if (categories[i].Equals(cat, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(titles[i] + " | Available: " + available[i]);
                                foundCat = true;
                            }

                        if (!foundCat)
                            Console.WriteLine("No books found in this category");
                        break;
                    // CASE 10: Exit the system
                    // Stops the program execution

                    case 10:
                        
                            exit = true;

                        
                        break;

                        Console.WriteLine("Press any key to continue..."); 
                        Console.ReadKey();
                        Console.Clear();
                        
                }
            }
        }
    }
}


















