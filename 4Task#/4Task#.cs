using System;

class Program
{
    static Random random = new Random();

    static bool Unpredictable(int roundNumber, bool[] selfChoices, bool[] enemyChoices)
    {
        return random.Next(2) == 1;
    }

    static bool Reciprocity(int roundNumber, bool[] selfChoices, bool[] enemyChoices)
    {
        if (roundNumber < 2 || !enemyChoices[roundNumber - 2])
        {
            return false;
        }
        return true;
    }

    static bool Mastery(int roundNumber, bool[] selfChoices, bool[] enemyChoices)
    {
        if (roundNumber == 1)
        {
            return true;
        }

        int selfBetrayals = 0, enemyBetrayals = 0;
        for (int i = 0; i < roundNumber; i++)
        {
            if (!selfChoices[i])
            {
                selfBetrayals++;
            }
            if (!enemyChoices[i])
            {
                enemyBetrayals++;
            }
        }

        if (selfBetrayals > enemyBetrayals)
        {
            return false;
        }

        return true;
    }

    static void Game(Func<int, bool[], bool[], bool> tact1, Func<int, bool[], bool[], bool> tact2, ref int player1Score, ref int player2Score)
    {
        int rounds = random.Next(100) + 100;

        bool[] player1Moves = new bool[rounds];
        bool[] player2Moves = new bool[rounds];

        for (int i = 1; i <= rounds; i++)
        {
            bool decision1 = tact1(i, player1Moves, player2Moves);
            bool decision2 = tact2(i, player2Moves, player1Moves);

            player1Moves[i - 1] = decision1;
            player2Moves[i - 1] = decision2;

            if (decision1 && decision2)
            {
                player1Score += 24;
                player2Score += 24;
            }
            else if (decision1 && !decision2)
            {
                player1Score += 0;
                player2Score += 20;
            }
            else if (!decision1 && decision2)
            {
                player1Score += 20;
                player2Score += 0;
            }
            else
            {
                player1Score += 4;
                player2Score += 4;
            }
        }
    }

    static void Main(string[] args)
    {
        int unpredScore = 0, recipScore = 0, mastScore = 0;

        Game(Unpredictable, Reciprocity, ref unpredScore, ref recipScore);
        Game(Unpredictable, Mastery, ref unpredScore, ref mastScore);
        Game(Reciprocity, Mastery, ref recipScore, ref mastScore);

        Console.WriteLine("Счёт игрока с тактикой unpredictable: " + unpredScore);
        Console.WriteLine("Счёт игрока с тактикой reciprocity: " + recipScore);
        Console.WriteLine("Счёт игрока с тактикой mastery: " + mastScore);
    }
}
