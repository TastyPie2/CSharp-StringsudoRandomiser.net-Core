using System;
using System.Threading;

namespace stringRandomiser
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(isShutingDown).Start();
            while (true)
            {
                
                Random rnd = new Random();

                char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

                bool isvalid = false;

                Console.WriteLine("Enter string lenght");
                int output = 0;

                while (isvalid == false)
                {
                    try
                    {
                        output = Convert.ToInt32(Console.ReadLine());
                        isvalid = true;
                    }
                    catch
                    {
                        Console.WriteLine("input not valid. try again");
                        isvalid = false;
                    }
                }

                string randomString = "";
                for (int i = 0; i < output; i++)
                {
                    bool isCap = false;
                    if (rnd.Next(0, 10) < 5)
                    {
                        isCap = true;
                    }

                    bool isNum = false;
                    if (rnd.Next(0, 10) < 5)
                    {
                        isNum = true;
                    }

                    string charToAdd = Convert.ToString(chars[rnd.Next(0, chars.Length - 1)]);

                    if (isNum)
                    {
                        charToAdd = rnd.Next(0, 9).ToString();
                        isCap = false;
                    }

                    if (isCap)
                    {
                        charToAdd = charToAdd.ToUpper();
                    }

                    randomString = randomString + charToAdd;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(randomString);

                Console.ResetColor();
            }
        }
        static void isShutingDown()
        {
            while(true)
            {
                Thread.Sleep(1500);

                if(Environment.HasShutdownStarted)
                {
                    Environment.Exit(0);
                }
            }

        }

    }
}
