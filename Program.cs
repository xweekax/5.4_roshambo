using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Threading;

namespace LAb5._2_Rock_Paper_Scissors
{
    enum GenerateRoShamBo
    {
        Rock,
        Paper,
        Scissors
    }
    
    abstract class Player
    {
        public GenerateRoShamBo TheOption { get; set; }

        public virtual GenerateRoShamBo RoShamBo()
        {
            return GenerateRoShamBo.Rock;
        }
    }

    class HumanPlayer : Player
    {
        public override GenerateRoShamBo RoShamBo() //pass in a char or string
        {
            Console.Write("\nRock, Paper or Scissors? (R/P/S): ");
            string userInput = Console.ReadLine();
            userInput.ToLower();

            if (userInput == "r")
            {
                base.TheOption = GenerateRoShamBo.Rock;
                return GenerateRoShamBo.Rock;
            }
            else if (userInput == "p")
            {
                base.TheOption = GenerateRoShamBo.Paper;
                return GenerateRoShamBo.Paper;
            }
            else if (userInput == "s")
            {
                base.TheOption = GenerateRoShamBo.Scissors;
                return GenerateRoShamBo.Scissors;
            }
            else
            {
                return RoShamBo();
            }
        }
    }

    class RockPlayer : Player
    {
        public override GenerateRoShamBo RoShamBo()
        {
            base.TheOption = GenerateRoShamBo.Rock;
            return GenerateRoShamBo.Rock;
        }
    }

    class OtherPlayer : Player
    {
        private static Random rand = new Random();

        public override GenerateRoShamBo RoShamBo()
        {
            int randHand = rand.Next(3);
            GenerateRoShamBo randomHand = (GenerateRoShamBo)randHand;
            base.TheOption = randomHand;
            return randomHand;
        }

    }

    class Program
    {

        static void Main()
        {
            bool quit = false;

            Console.Write("What is the name you would like? ");
            string name = Console.ReadLine();

            Console.Write("\nWho would you like to play against, Kyle or Karen? (1/2): ");
            string oponant = Console.ReadLine();
            int oponant1 = int.Parse(oponant);

            Player computerPlayer;
            HumanPlayer human = new HumanPlayer();

            theGoods();

            void theGoods()
            {
                while (oponant1 != 1 && oponant1 != 2)
                { 
                        Console.WriteLine("\nInvalid input - please enter 1 or 2");
                        Console.Write("\nWho would you like to play against, Kyle or Karen? (1/2): ");
                        string oponant = Console.ReadLine();
                        oponant1 = int.Parse(oponant);                    
                }
                if (oponant1 == 1) //oponant 1 is kyle who always throws rock
                {
                    human.RoShamBo();
                    computerPlayer = new RockPlayer();
                    computerPlayer.RoShamBo();
                    Console.WriteLine($"Kyle chose: {computerPlayer.TheOption} you have chosen: {human.TheOption}");
                    rpsMath();
                }
                else if (oponant1 == 2) //Karen who is random
                {
                    human.RoShamBo();
                    computerPlayer = new OtherPlayer();
                    computerPlayer.RoShamBo();
                    Console.WriteLine($"Karen chose: {computerPlayer.TheOption} you have chosen: {human.TheOption}");
                    rpsMath();
                }
                Console.Write("\nWould you like to continue?: (y/n)");
                string userContinue = Console.ReadLine();

                if (userContinue == "n")
                {
                    quit = true;
                }
                else if (userContinue == "y")
                {
                    theGoods();
                }
            }
            void rpsMath()
            {
                if ((computerPlayer.TheOption == GenerateRoShamBo.Rock && human.TheOption == GenerateRoShamBo.Rock)
                    || (computerPlayer.TheOption == GenerateRoShamBo.Paper && human.TheOption == GenerateRoShamBo.Paper)
                    || (computerPlayer.TheOption == GenerateRoShamBo.Scissors && human.TheOption == GenerateRoShamBo.Scissors))
                {
                    Console.WriteLine("Its a draw\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Rock && human.TheOption == GenerateRoShamBo.Paper)
                {
                    Console.WriteLine($"{human.TheOption} beats {computerPlayer.TheOption} You Win!\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Scissors && human.TheOption == GenerateRoShamBo.Paper)
                {
                    Console.WriteLine($"{human.TheOption} is cut by {computerPlayer.TheOption} You Lose!\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Paper && human.TheOption == GenerateRoShamBo.Rock)
                {
                    Console.WriteLine($"{human.TheOption} is covered by {computerPlayer.TheOption} You Lose!\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Scissors && human.TheOption == GenerateRoShamBo.Rock)
                {
                    Console.WriteLine($"{human.TheOption} crushes {computerPlayer.TheOption} You Win!\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Rock && human.TheOption == GenerateRoShamBo.Scissors)
                {
                    Console.WriteLine($"{human.TheOption} is crushed by {computerPlayer.TheOption} You Lose!\n");
                }
                else if (computerPlayer.TheOption == GenerateRoShamBo.Paper && human.TheOption == GenerateRoShamBo.Scissors)
                {
                    Console.WriteLine($"{human.TheOption} cuts {computerPlayer.TheOption} You Win!\n");
                }
                else
                {
                    Console.WriteLine("it broke!");
                }
            }
        }          
            
    }
}
