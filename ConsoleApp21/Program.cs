using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf_Go
{
    class Program
    {
        static void Main(string[] args)
        {


            string yesNo;
            bool go = true;
            Console.Write("----Welkome to The Golf----\n" +
                "Do you want to play enter y/n: ");
            yesNo = Console.ReadLine();



            if (yesNo.Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("You step on to the course\n" +
                    "It is 320 meters to the cup\n" +
                    "You have 5 swings to get to it\n" +
                    "If you ever get further away from the cup the when you started,\n" +
                    "you will be considerd to be outside of the course.");
                Loop();
            }
            else
            {
                go = false;
            }

            
        }

        static int Loop()
        {
            int loopNumber = 0;

            string yesNo = Console.ReadLine();
            bool go = true;
            double distanceToHole = 320;
            double distanceRemaining = distanceToHole;
            List<double> swings = new List<double>();

            do
            {               
                double angle = Angle();
                double velocity = Velosity();
                double ballDistance = CalcDis(angle, velocity);
                distanceRemaining = distanceRemaining - ballDistance;
                distanceRemaining = Math.Abs(distanceRemaining);
                distanceRemaining = Math.Round(distanceRemaining, 1);
                swings.Add(distanceRemaining);

                Console.WriteLine("Your swings: " + swings.Count);

               
                if (distanceRemaining <= 0.1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Left distance to cup: " + distanceRemaining);
                    Console.WriteLine("Your distance is: " + ballDistance + "\n---You won!---\n");
                                     
                    go = false;
                }
                else if (distanceRemaining > distanceToHole)
                {
                    Console.WriteLine("To Long - Game over\n");
                    go = false;//eto znachit cikle zakonchilsya
                }
                else if (swings.Count > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your distance is: " + ballDistance);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Left distance to cup: " + distanceRemaining);
                    Console.WriteLine("You don't have more swings\n");
                    go = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your distance is: " + ballDistance);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Left distance to cup: " + distanceRemaining);
                }
            }
            while (go);

            PrintList(swings);
            

            Console.Write("Do you want to play again? Enter y/n: \n");// ? na povtor, doljen bit posle loopa!
            

            yesNo = Console.ReadLine();
            Console.WriteLine("Destance to The cup is 320 meter");
            go = false;
            if (yesNo.Equals("y"))
            {

                Loop();
            }


            return loopNumber;

        }
        static void PrintList(List<double> swings)
        {
            Console.WriteLine("--- History---");

            foreach (double item in swings)//pokazivaet iz Lista i to chto v nytri  cykla
            {               
                Console.WriteLine("Your swing: " + item);
                //for (int i = 0; item < 4; i++)
                //{
                //    if (i == 4)
                //        break;
                //    Console.WriteLine(i);
                //}
            }
        }
        static double Angle()
        {

            bool stay = true;
            int creativeNumber = 0;
            
            do
            {
                try
                {
                    Console.Write("\nInput Angle: ");
                    double angle = Convert.ToDouble(Console.ReadLine());

                    if (angle < 0.1 || angle > 89.9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Angle must be within 0.1 to 89.9, please try again.");
                    }
                    else
                    {
                        return angle;
                    }
                }
                catch (FormatException)
                {                    
                    Console.WriteLine("Not right number");
                    Console.WriteLine();
                }
            }
            while (stay);
            return creativeNumber;

        }
        static double Velosity()
        {
            bool stay = true;
            int creativeNumber = 0;

            do
            {
                try
                {
                    Console.Write("Input Velocity: ");
                    double velocity = Convert.ToDouble(Console.ReadLine());

                    if (velocity < 0.1 || velocity > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Velocity must be within 0.1 to 100, please try again.");
                    }
                    else
                    {
                        return velocity;
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Not right number");
                    Console.WriteLine();
                }
            }
            while (stay);
            return creativeNumber;
        }
        static double CalcDis(double angle, double velocity)
        {
            double GRAVITY = 9.8;


            return Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * ((Math.PI / 180) * angle));
        }
    }
}