
internal class Program
{
    static Random R = new();
    static int[] oddSum = { 3, 5, 7, 9, 11 };
    static int[] evenSum = { 2, 4, 6, 8, 10, 12 };
    static int myPoint = 0;
    static int pcPoint = 0;
    static void sayHello()
    {
        Console.WriteLine(
            "\tBOBSTONES\n" +
            "\tCREATIVE COMPUTING\n" +
            "\tMORRISTOWN, NEW JERSEY" +
            "\n\n\n" +
            "    THIS IS A NUMBER GAME CALLED BOBSTONES.  THE OBJECT OF\n" +
            "BOBSTONES IS TO GUESS THREE THINGS ABOUT THE ROLL OF A PAIR\n" +
            "OF DICE.  ON EACH TURN, THE COMPUTER SIMULATES THE ROLL OF\n" +
            "THE DICE.  THEN, YOU OR THE COMPUTER (YOUR OPPONENT) GUESS\n" +
            "\n" +
            "                                                     SCORE\n" +
            " 1. IF THE SUM OF THE DICE IS ODD OR EVEN           1 POINT\n" +
            " 2. THE SUM OF THE DICE                             2 POINTS\n" +
            " 3. THE NUMBER ON EACH OF THE TWO DICE              3 POINTS\n" +
            "\n" +
            "    THE WINNER IS THE FIRST PLAYER TO SCORE 11 POINTS.  IF A\n" +
            "TIE RESULTS, THE WINNER IS THE FIRST PLAYER TO BREAK THE TIE.\n" +
            "    GOOD LUCK !"
            );
    }
    static string OoE()
    {
        while (true)
        {
            Console.Write("IS THE SUM ODD OR EVEN? ");
            switch (Console.ReadLine())
            {
                case "ODD":
                    return "ODD";
                case "EVEN":
                    return "EVEN";
                default:
                    Console.WriteLine("/// TYPE THE WORD 'ODD' OR THE WORD 'EVEN'.");
                    break;
            }
        }
    }
    static int NowSum()
    {
        while (true)
        {
            Console.Write("NOW, GUESS THE SUM ");
            try
            {
                int sum = Convert.ToInt32(Console.ReadLine());
                if (sum >= 2 && sum < 13)
                {
                    return sum;
                }
                else
                {
                    Console.WriteLine("INCORRECT INPUT");
                }
            }
            catch
            {
                Console.WriteLine("INCORRECT INPUT");
            }
        }
    }
    static (int, int) WTN()
    {
        while (true)
        {
            Console.Write("WHAT ARE THE TWO NUMBERS WHICH PRODUCED ");
            string ansver = Console.ReadLine();
            string[] strings = ansver.Split(new char[] { ',', '.', ' ' });
            if (strings.Length == 2)
            {
                try
                {
                    return (Convert.ToInt32(strings[0]), Convert.ToInt32(strings[1]));
                }
                catch
                {
                    Console.WriteLine("/// THE NUMBERS MUST BE BETWEEN 1 AND 6.");
                }
            }
            else
            {
                Console.WriteLine("/// THE NUMBERS MUST BE BETWEEN 1 AND 6.");
            }
        }
    }
    static bool RoW()
    {
        while (true)
        {
            Console.Write("AM I RIGHT OR WRONG ");
            switch (Console.ReadLine())
            {
                case "RIGHT":
                    return true;
                case "WRONG":
                    return false;
                default:
                    Console.WriteLine("/// TYPE THE WORD 'RIGHT' OR THE WORD 'WRONG'.");
                    break;
            }
        }
    }
    static bool YoN()
    {
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "YES":
                    return true;
                case "NO":
                    return false;
                default:
                    Console.WriteLine("/// TYPE THE WORD 'YES' OR THE WORD 'NO'.");
                    break;
            }
        }
    }
    static (int, int) Random()
    {
        return (R.Next(1, 7), R.Next(1, 7));
    }
    static string HowStart()
    {
        while (true)
        {
            Console.Write("\nYOU FIRST OR ME ");
            switch (Console.ReadLine())
            {
                case "YOU":
                    Console.WriteLine();
                    return "PC";
                case "ME":
                    Console.WriteLine();
                    return "ME";
                default:
                    Console.WriteLine("/// TYPE THE WORD 'YOU' OR THE WORD 'ME'.");
                    break;
            }
        }
    }
    static bool loop = true;
    static void printPoint()
    {
        if (myPoint < 11 && pcPoint < 11)
        {
            Console.WriteLine($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
        }
        else if (myPoint >= 11)
        {
            Console.WriteLine($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
            Console.Write("YOU WIN! ANOTHER GAME ");
            bool ansver = YoN();
            if (ansver == true)
            {
                myPoint = 0;
                pcPoint = 0;
                StartGame(HowStart());
            }
            else
            {
                loop = false;
                Console.WriteLine("SEE YOU LATER.");
            }
        }
        else if(pcPoint >= 11)
        {
            Console.WriteLine($"\nTHE SCORE IS ME {pcPoint} - YOU {myPoint}.\n");
            Console.Write("I WIN! ANOTHER GAME ");
            bool ansver = YoN();
            if (ansver == true)
            {
                myPoint = 0;
                pcPoint = 0;
                StartGame(HowStart());
            }
            else
            {
                loop = false;
                Console.WriteLine("SEE YOU LATER.");
            }

        }
       
    }
    static void StartGame(string _who)
    {
        string who = _who;

            while (loop)
            {
                int D1, D2;
                (D1, D2) = Random();
                if (who == "ME")
                {

                    Console.WriteLine("YOUR TURN.");
                    string ansver = OoE();
                    if ((ansver == "ODD" && (D1 + D2) % 2 != 0) ||
                        (ansver == "EVEN" && (D1 + D2) % 2 == 0))
                    {
                        Console.WriteLine("YOU ARE CORRECT.");
                        myPoint += 1;
                    }
                    else
                    {
                        who = "PC";
                        Console.WriteLine($"SORRY, THE SUM IS {D1 + D2}");
                        printPoint();
                        continue;
                    }
                    if (D1 + D2 == NowSum())
                    {
                        myPoint += 1;
                        Console.WriteLine("YOU ARE CORRECT.");
                    }
                    else
                    {
                        who = "PC";
                        Console.WriteLine($"SORRY, THE SUM IS {D1 + D2}");
                        printPoint();
                        continue;
                    }
                    int D1A, D2A;
                    (D1A, D2A) = WTN();
                    if ((D1A, D2A) == (D1, D2) || (D1A, D2A) == (D2, D1))
                    {
                        myPoint += 1;
                        Console.WriteLine("YOU ARE CORRECT.\n");
                        who = "PC";
                        printPoint();
                        continue;
                    }
                    else
                    {
                        who = "PC";
                        Console.WriteLine($"SORRY, THE NUMBERS ARE {D1} AND {D2} .");
                        printPoint();
                        continue;
                    }

                }
                else if (who == "PC")
                {
                    Console.WriteLine("MY TURN.\n" +
                        $"*** ON THIS ROLL OF THE DICE, THE TWO NUMBERS ARE {D1} AND {D2} .\n" +
                        $"*** THE SUM IS {D1 + D2}");
                    int OoE = R.Next(1, 3);
                    if (OoE == 1)
                    {
                        Console.WriteLine("MY GUESS IS THAT THE SUM IS ODD.");
                    }
                    else
                    {
                        Console.WriteLine("MY GUESS IS THAT THE SUM IS EVEN.");
                    }
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    int sum;
                    if (OoE == 1)
                    {
                        sum = oddSum[R.Next(0, 5)];
                    }
                    else
                    {
                        sum = evenSum[R.Next(0, 6)];
                    }
                    Console.WriteLine($"MY GUESS OF THE SUM IS {sum}");
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    if (sum > 6)
                    {
                        D1 = R.Next(1, 7);
                        D2 = sum - D1;
                    }
                    else
                    {
                        D1 = R.Next(1, sum);
                        D2 = sum - D1;
                    }
                    Console.WriteLine($"MY GUESS IS THAT THE NUMBERS ARE {D1} AND {D2} ");
                    if (!RoW())
                    {
                        who = "ME";
                        printPoint();
                        continue;
                    }
                    pcPoint += 1;
                    who = "ME";
                    printPoint();
                }
            }
    }
    private static void Main(string[] args)
    {
        sayHello();

        StartGame(HowStart());
    }
}