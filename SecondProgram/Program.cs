using System.Data;

namespace SecondProgram
{
    public class Program
    {
        public static void Main ()
        {
            // ExampleDailyChild.Program.Prog();
            // ExampleArrays.Program.Prog();
            // ExampleArrays.Example.Prog();
            // ExampleLists.Example.Prog();
            // ExampleLists.Program.Prog();
            // ExampleLists.ExampleProgram.Prog();
            // ExampleMethods.Example.Prog();
            Bradford.Program.Prog();
        }
    }
}

namespace ExampleDailyChild
{
    public class Program
    {
        public static void Prog()
        {
            Console.WriteLine("Daily Child");

            // do while loop
            bool finished = false;
            do
            {
                Console.Write("Please enter a day of the week: "); // ask user for day of week
#pragma warning disable CS8602
                /*
                * CS8602 warns Console.ReadLine() may return null value.
                * This is ok in this example: default switch block will catch this
                */
                string dayOfWeek = Console.ReadLine().ToLower();
#pragma warning restore CS8602

                switch (dayOfWeek) // Switch on dayOfWeek
                {
                    case "monday":
                        Console.WriteLine("Fair of face");
                        break;
                    case "tuesday":
                        Console.WriteLine("Full of grace");
                        break;
                    case "wednesday":
                        Console.WriteLine("Full of woe");
                        break;
                    case "thursday":
                        Console.WriteLine("Has far to go");
                        break;
                    case "friday":
                        Console.WriteLine("Loving and giving");
                        break;
                    case "saturday":
                        Console.WriteLine("Works hard for a living");
                        break;
                    case "sunday":
                        Console.WriteLine("Bonny and blithe, and good and gay");
                        break;
                    case "stop":
                        Console.WriteLine("All done");
                        finished = true;
                        break;
                    default: // if not valid day of week
                        Console.WriteLine("I don't know that one");
                        break;
                }
            } while (!finished);
        }
    }
}

namespace ExampleArrays
{
    public class Example
    {
        public static void Prog()
        {
            float[] myFloats =
            {
                1.2f, 2.4f, 3.6f, 6.7f, 42.3f, 31.3f,
                33.4f, 56.2f
            };

            for (int i = 0; i < myFloats.Length; i++)
            {
                Console.WriteLine("Value {0} = {1}", i, myFloats[i]);
            }

            foreach (float x in myFloats)
            {
                Console.WriteLine("Value is {0}", x);
            }
        }
    }

    public class Program
    {
        public static void Prog()
        {
            /*
             * - Create variables for the sales data
             * - Fill the variables with the sales data
             * - For each month of the year
             *     - Print the month to the screen
             *     - Subtract the sales values for the month two years ago from the value for the month last year.
             *     - If the result is greater than zero
             *         - Print "Sales increased by" and give the amount
             *     - Else
             *         - Print "Sales fell by" and give the amount
             */

            float[] pastSales = { // Can use as many months as needed, as long as there are at least 24 values (Needs at least 2 years of sales to compare) and an even number of values.
                894.83f,
                334.62f,
                1203.1f,
                1459.16f,
                1187.3f,
                635.07f,
                491.77f,
                345.6f,
                1161.71f,
                981.72f,
                686.64f,
                1166.3f,
                1425.66f,
                1247.92f,
                1421.22f,
                1359.86f,
                637.67f,
                404.23f,
                600.12f,
                1418.07f,
                194.05f,
                982.99f,
                108.59f,
                1414.48f
            };

            if (pastSales.Length < 24)
            {
                Console.WriteLine("There needs to be at least 24 values!");
                Environment.Exit(1);
            }

            if (pastSales.Length % 2 == 1)
            {
                Console.WriteLine("There needs to be an even number of values!");
                Environment.Exit(2);
            }

            for (int i = 0; i < pastSales.Length - 12; i++)
            {
                Console.WriteLine("{0}:", getMonthName((i % 12) + 1)); // Do (i % 12) + 1 to ensure even if more than 12 months, it works. I.e. 0 = 1, ... 11 = 12, 12 = 1, etc. This means it will work with infinite numbers of months

                float resultOriginal = pastSales[i];
                float resultYearAfter = pastSales[i + 12]; // Same month 1 year later (12 months later)

                float difference = (float)Math.Round(resultYearAfter - resultOriginal, 2); // Make sure is two decimals

                if (difference > 0)
                {
                    Console.WriteLine("Sales increased by {0}", getCurrencyString(difference));
                } else
                {
                    Console.WriteLine("Sales fell by {0}", getCurrencyString(difference * -1)); // Multiply by -1 to ensure is positive
                }

                Console.WriteLine();
            }
        }

        static string getCurrencyString(float value)
        {
            // Adds £ and ensures to 2 decimal places, not 1. I.e. 913.3 => £913.30, 108.35 => £108.35

            if (value*10 == (int)(value*10)) // if only 1 decimal place
            {
                return "£" + value + "0";
            } else
            {
                return "£" + value;
            }
        }

        static string getMonthName(int monthNum)
        {
            switch (monthNum)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
    }
}

namespace ExampleLists
{
    public class Example
    {
        public static void Prog()
        {
            List<float> myFloats = new List<float>();
            myFloats.AddRange(
                new float[]
                {
                    1.2f,
                    2.4f,
                    3.6f,
                    6.7f,
                    42.3f,
                    31.3f,
                    33.4f,
                    56.2f
                }
            );

            foreach (float x in myFloats)
            {
                Console.WriteLine("{0}", x);
            }
        }
    }

    public class Program
    {
        public static void Prog()
        {
            /*
             * - Create variables for the sales data
             * - Fill the variables with the sales data
             * - For each month of the year
             *     - Print the month to the screen
             *     - Subtract the sales values for the month two years ago from the value for the month last year.
             *     - If the result is greater than zero
             *         - Print "Sales increased by" and give the amount
             *     - Else
             *         - Print "Sales fell by" and give the amount
             */

            List<float> pastSales = new List<float>
            { // Can use as many months as needed, as long as there are at least 24 values (Needs at least 2 years of sales to compare) and an even number of values.
                894.83f,
                334.62f,
                1203.1f,
                1459.16f,
                1187.3f,
                635.07f,
                491.77f,
                345.6f,
                1161.71f,
                981.72f,
                686.64f,
                1166.3f,
                1425.66f,
                1247.92f,
                1421.22f,
                1359.86f,
                637.67f,
                404.23f,
                600.12f,
                1418.07f,
                194.05f,
                982.99f,
                108.59f,
                1414.48f
            };

            if (pastSales.Count < 24)
            {
                Console.WriteLine("There needs to be at least 24 values!");
                Environment.Exit(1);
            }

            if (pastSales.Count % 2 == 1)
            {
                Console.WriteLine("There needs to be an even number of values!");
                Environment.Exit(2);
            }

            for (int i = 0; i < pastSales.Count - 12; i++)
            {
                Console.WriteLine("{0}:", getMonthName((i % 12) + 1)); // Do (i % 12) + 1 to ensure even if more than 12 months, it works. I.e. 0 = 1, ... 11 = 12, 12 = 1, etc. This means it will work with infinite numbers of months

                float resultOriginal = pastSales[i];
                float resultYearAfter = pastSales[i + 12]; // Same month 1 year later (12 months later)

                float difference = (float)Math.Round(resultYearAfter - resultOriginal, 2); // Make sure is two decimals

                if (difference > 0)
                {
                    Console.WriteLine("Sales increased by {0}", getCurrencyString(difference));
                }
                else
                {
                    Console.WriteLine("Sales fell by {0}", getCurrencyString(difference * -1)); // Multiply by -1 to ensure is positive
                }

                Console.WriteLine();
            }
        }

        static string getCurrencyString(float value)
        {
            // Adds £ and ensures to 2 decimal places, not 1. I.e. 913.3 => £913.30, 108.35 => £108.35

            if (value * 10 == (int)(value * 10)) // if only 1 decimal place
            {
                return "£" + value + "0";
            }
            else
            {
                return "£" + value;
            }
        }

        static string getMonthName(int monthNum)
        {
            switch (monthNum)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
    }

    public class ExampleProgram
    {
        public static void Prog()
        {
            List<float> myFloats = new List<float>
            {
                1.2f, 2.4f, 3.6f, 6.7f, 42.3f, 31.3f,
                33.4f, 56.2f
            };

            for (int i = 0; i < myFloats.Count; i++)
            {
                Console.WriteLine("Value {0} = {1}", i, myFloats[i]);
            }

            foreach (float x in myFloats)
            {
                Console.WriteLine("Value is {0}", x);
            }

            for (int i = 0; i < myFloats.Count; i++)
            {
                Console.WriteLine("Value {0} = {1} the value of i was {0}", i, myFloats[i]);
            }

            bool numberExists = myFloats.Contains(2.4f);
            if (numberExists)
            {
                int itsIndex = myFloats.IndexOf(2.4f);
                Console.WriteLine("The value was {0} held at {1}", myFloats[itsIndex], itsIndex);
            }
        }
    }
}

namespace ExampleMethods
{
    public class Example
    {
        public static void Prog ()
        {
            float[] vector = { 1, 2, 3 };
            double length = VectorLength(vector);
            Console.WriteLine("Length of vector is {0}", length);

            List<float> myFloats = new List<float>
            {
                1.2f, 2.4f, 3.6f, 6.7f, 42.3f, 31.3f, 33.4f, 56.2f
            };

            Console.WriteLine(GetValueFromList(myFloats, 2.4f));
            Console.WriteLine(GetValueFromList(myFloats, 2.8f));
            Console.WriteLine(GetValueFromList(myFloats, 24.2f));
            Console.WriteLine(GetValueFromList(myFloats, 2.6f));

            //foreach (float x in myFloats)
            //{
            //    Console.WriteLine(x);
            //}
        }

        static double VectorLength(float[] vector)
        {
            double result;
            float lengthSquared = 0f;
            
            foreach (float x in vector)
            {
                lengthSquared += x * x;
            }

            result = Math.Sqrt(lengthSquared);
            return result;
        }

        static string GetValueFromList (List<float> floats, float target)
        {
            int targetIndex = floats.IndexOf(target);

            if (targetIndex != -1) // Index of target in list. If -1, target not found
            {
                return "The value was " + target + " held at " + targetIndex;
            }

            floats.Add(target); // If does not exist, add to list
            targetIndex = floats.Count - 1; // New elements will always be appended to end of list

            return target + " did not exist and was added at " + targetIndex;
        }
    }
}

namespace Bradford
{
    public class Program
    {
        public static void Prog()
        {
            List<int> daysAbsent = new List<int>();

            int instanceCount = 1;
            bool readyToBreak = false;

            do
            {
                Console.Write("Enter how many days absent in instance {0}: ", instanceCount);
                string userInput = Console.ReadLine().Trim();
                int intInput;

                if (userInput == "stop")
                {
                    readyToBreak = true;
                }
                else if (int.TryParse(userInput, out intInput))
                {
                    daysAbsent.Add(intInput);
                } else
                {
                    Console.WriteLine("Please enter a valid integer or \"stop\".");
                    continue;
                }

                instanceCount++;
            } while (!readyToBreak);

            int bradfordFactor = daysAbsent.Count * daysAbsent.Count * daysAbsent.Sum();

            Console.WriteLine("The Bradford Factor is {0}: {1}", bradfordFactor, GetConcernLevel(bradfordFactor));
        }

        static string GetConcernLevel (int factor)
        {
            if (factor >= 900)
            {
                return "Sufficient days for a manager to consider dismissal.";
            }

            if (factor >= 100)
            {
                return "Sufficient days for a manager to start a disciplinary action (oral warning, written warning, formal monitoring etc.)";
            }

            if (factor >= 45)
            {
                return "Sufficient days for a manager to show concern and advise on possible disciplinary of financial actions, should more absences occur during an identified period.";
            }

            return "No concern.";
        }
    }
}