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
            DateTime[] returnDate = new DateTime[100]; 
            double[] lateFees = new double[100];       

            int lastIndex = 0; 

            

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

            while (exit == false)
            {



                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7.View Most Popular Books ");
                Console.Write("8. Search Books by Category");
                Console.WriteLine("10. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:



                        Console.Write("Category: ");
                        categories[lastIndex] = Console.ReadLine();

                        Console.Write("Title: ");
                        titles[lastIndex] = Console.ReadLine();

                        Console.Write("Author: ");
                        authors[lastIndex] = Console.ReadLine();

                        Console.Write("ISBN: ");
                        isbns[lastIndex] = Console.ReadLine();

                        available[lastIndex] = true;
                        borrowers[lastIndex] = "";
                        borrowCount[lastIndex] = 0;
                        lateFees[lastIndex] = 0;
                        lastIndex++;
                        Console.WriteLine("Book added");
                        break;

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
                                    Console.WriteLine("ISBN: " + isbns[i]);
                                    Console.WriteLine("Available: " + available[i]);
                                    Console.WriteLine("Borrower: " + borrowers[i]);


                                }
                            }
                        }

                                    break;

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
                    
                    case 6:


                        Console.Write("Enter first borrower name:");
                        string firstBorrower = Console.ReadLine();


                        Console.Write("Enter second borrower name:");
                        string secondBorrower = Console.ReadLine();


                        bool firstBorrowerFound = false;
                        int firstBorrowerIndex = 0;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (firstBorrower == borrowers[i])
                            {
                                firstBorrowerIndex = i; // مكان / رقم تواجد الشخص الاول


                                firstBorrowerFound = true;
                                break;

                            }
                        }
                        if (firstBorrowerFound == false)
                        {
                            Console.WriteLine("current borrower name not found");
                        }
                        else
                        {
                            bool secondBorrowerFound = false;
                            int secondBorrowerIndex = 0;
                            for (int i = 0; i < 100; i++)
                            {
                                if (secondBorrower == borrowers[i])
                                {
                                    secondBorrowerIndex = i; 

                                    secondBorrowerFound = true;
                                    break; 

                                }
                            }
                            if (secondBorrowerFound == false)
                            {
                                Console.WriteLine("New borrower name not found");
                            }
                            else
                            {

                                string temp = "";

                                temp = borrowers[firstBorrowerIndex];

                                borrowers[firstBorrowerIndex] = borrowers[secondBorrowerIndex];

                                borrowers[secondBorrowerIndex] = temp;

                            }
                        }







                        break;





                    case 7:
                    
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine("-----------------------------");
                        exit = true;
                    
                    break;
                    case 8:












                        break;









                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}






