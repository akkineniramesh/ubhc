using System;
public class SnakesnLadders
{
    const int numberofboards = 101;
    const int boardsize = 101;
    int pos = 1, turnsofdice = 0, turnsofgame = 0;
    int[] states = new int[101];
    int numberofdiceturns = 100000;
    int[] ladderStart = { 8, 19, 21, 28, 36, 43, 50, 54, 61, 62, 66 };
    int[] ladderEnd = { 26, 38, 82, 53, 57, 77, 91, 88, 99, 96, 87 };
    int[] snakeStart = { 98, 93, 83, 69, 68, 64, 59, 52, 48, 46 };
    int[] snakeEnd = { 13, 37, 22, 33, 2, 24, 18, 11, 9, 15 };
    int[] ladderHit = new int[12];
    int[] snakeHit = new int[11];
    int[] lIndex = new int[101];
    int[] sIndex = new int[101];
    int numberofgames = 0;
    int turnsofdiceforagame = 0;
    double turnsasmoney = 0;
    double basispoint = 100;
    double turnsasmoneytakeninx = 0;
    double interest = 0.006;

    double gameturnmultiple = 1;
    double gametotalmultiple = 1;
    int[,] boardstates = new int[numberofboards, boardsize];
    int[,] boardlIndex = new int[numberofboards, boardsize];
    int[,] boardsIndex = new int[numberofboards, boardsize];
    int[,] boardladderHit = new int[numberofboards, 12];
    int[,] boardsnakeHit = new int[numberofboards, 11];
    int[] boardpos = new int[numberofboards];
    int[] boardturnsofdiceforagame = new int[numberofboards];
    int[] boardturnsofgame = new int[numberofboards];
    //float boardgameturnmultiple[101];
    //float boardgametotalmultiple[101];
    double[,] boardgameturnmultiple = new double[numberofboards, 31];
    double[,] boardgametotalmultiple = new double[numberofboards, 31];
    double[] commonboardgametotalmultipleleft = new double[31];
    double[] commonboardgametotalmultipleadded = new double[31];
    double[] commonboardgametotalmultipletakenin = new double[101];
    int snakesshuffled = 0;
    int laddersshuffled = 0;



    Random r = new Random();
    String args;

    public static void Main(string[] args)
    {
        int dice;
        for (dice = 0; dice <= 6; dice = dice + 1) Console.Write(dice);
        int dice1;
        dice1 = 10;
        while (dice1 >= 1)
        {
            Console.Write(dice1);
            dice1 = dice1 - 1;
        }
        int[] ndice = new int[10];
        for (dice1 = 0; dice1 < 10; ++dice1)
        {
            ndice[dice1] = dice1 * 2;
            Console.Write(ndice[dice1]);
        }
        if (dice1 > dice) Console.Write("{0:G} {1:G}", dice1, dice);
        Console.Write("{0:G} \n", multiply(5, 3));
        SnakesnLadders sal = new SnakesnLadders();
        //sal.runGames();
        //sal.boardrunGames();
        sal.commonboardrunGames();
        Console.WriteLine("hello ramesh");
    }
    public static int multiply(int m1, int m2)
    {
        Console.Write("{0:G} {1:G} \n", m1, m2);
        return m1 * m2;
    }
    void runGame()
    {
        pos = 1;
        for (int i = 1; i < 101; i++)
        {
            states[i] = 0;
            lIndex[i] = 0;
            sIndex[i] = 0;
        }
        for (int i = 1; i < 12; i++) ladderHit[i] = 0;
        for (int i = 1; i < 11; i++) snakeHit[i] = 0;
        //getSnakesLadders(args);
        //System.out.println("turnsasmoneyatstart=" + turnsasmoney);
        fillLadders();
        fillSnakes();
        //fillLaddersrand();
        //fillSnakesrand();
        while (turnsofdice < numberofdiceturns)
        {
            Dice();
            TurnsofDice();
            if (pos > 100) numberofGames();
            SnakesLadders();
        }

    }
    void Dice()
    {
        int d = r.Next(0, 6) + 1;
        //System.out.println("dice="+d);
        pos = pos + d;
        //System.out.println("position"+pos);
        //return p;
    }
    void TurnsofDice()
    {
        turnsofdice++;
        turnsofdiceforagame++;
    }
    void SnakesLadders()
    {
        if (states[pos] != 0)
        {
            if (lIndex[pos] != 0) ladderHit[lIndex[pos]]++;
            if (sIndex[pos] != 0) snakeHit[sIndex[pos]]++;
            //if(pos>states[pos])printf("snakehit %d",pos);
            //if(pos<states[pos])printf("ladderhit %d",pos);
            pos = states[pos];
        }
        //return pos;
    }

    void numberofGames()
    {
        pos = pos - 100;
        //System.out.println("turnsofgame="+turnsofgame);
        //System.out.println("position="+pos);
        turnsofgame++;
        //turnsasmoney = turnsasmoney*(((10000 - basispoint) / 10000) + (basispoint / (turnsofdiceforagame * 350)));
        logmultiple();
        turnsofdiceforagame = 0;
        //if(turnsofgame%35==0)numberofdiceturns=numberofdiceturns+100;
    }
    void fillLadders()
    {
        for (int i = 0; i < 11; i++)
        {
            //if (lIndex[ladderStart[i]] != 0)
            //{
            states[ladderStart[i]] = ladderEnd[i];
            lIndex[ladderStart[i]] = i + 1;
            //}
        }
    }
    void fillSnakes()
    {
        for (int i = 0; i < 10; i++)
        {
            //if (sIndex[snakeStart[i]] != 0)
            //{
            states[snakeStart[i]] = snakeEnd[i];
            sIndex[snakeStart[i]] = i + 1;
            //}
        }
    }
    void logmultiple()
    {
        gameturnmultiple = (((10000 - basispoint) / 10000) * (turnsasmoneytakeninx + 1))
        - turnsasmoneytakeninx * (1 + interest) +
        ((basispoint / (turnsofdiceforagame * 350))) * (turnsasmoneytakeninx + 1);
        //gameturnmultiple = ((10000 - basispoint) / 10000) + ((basispoint / (turnsofdiceforagame * 350)));
        //printf(" gameturnmultiple %f ", gameturnmultiple);
        gametotalmultiple = gametotalmultiple * gameturnmultiple;
        gameturnmultiple = 1;
        //loggameturnmultiple = log(((10000 - basispoint) / 10000) + ((basispoint / (turnsofdiceforagame * 350))));
        //printf(" loggameturnmultiple %e ", loggameturnmultiple);
        //loggametotalmultiple = loggametotalmultiple + loggameturnmultiple;
        //loggameturnmultiple = 0;
        //printf(" loggametotalmultiple %e ", loggametotalmultiple);
    }
    void printGameStats()
    {
        //printf("turnsofdice= %d \n", turnsofdice);
        //printf("turnsofgame= %d \n", turnsofgame);
        //printf("numberofdiceturns= %d \n", numberofdiceturns);
        //printf("turnsofdiceindistance= %f \n" , turnsofdice*3.5);
        //printf("turnsasmoney= %f \n", turnsasmoney);
        //System.out.println("numberofdiceturnsindistance="+(long)(numberofdiceturns*3.5));
        //printf(" loggametotalmultiple %e ", loggametotalmultiple);
        //printf(" gametotalmultiple %f \n", gametotalmultiple);
        Console.Write(" {0:G} \n", gametotalmultiple);
        //printf("pos= %d", pos);
        for (int i = 1; i <= 11; i++)
            Console.Write("LadderHit{0:G} {1:G} ", i, ladderHit[i]);
        for (int i = 1; i <= 10; i++)
            Console.Write("SnakeHit{0:G} {1:G}", i, snakeHit[i]);
    }
    void runGames()
    {
        for (int i = 0; i < 3; i++)
        {
            turnsasmoneytakeninx = i;
            //printf(" turnsasmoneytakeninx %f ", turnsasmoneytakeninx);
            Console.Write("{0:G}", turnsasmoneytakeninx);
            runGame();
            printGameStats();
            turnsofdice = 0;
            turnsofgame = 0;
        }
    }
    void fillLaddersrand()
    {
        for (int i = 0; i < 11; i++)
        {
            if (r.Next(0, 6) > 2)
            {
                states[ladderStart[i]] = ladderEnd[i];
                lIndex[ladderStart[i]] = i + 1;
            }
        }
    }
    void fillSnakesrand()
    {
        for (int i = 0; i < 10; i++)
        {
            if (r.Next(0, 6) > 2)
            {
                states[snakeStart[i]] = snakeEnd[i];
                sIndex[snakeStart[i]] = i + 1;
            }
        }
    }
    void boardrunGame()
    {
        gameturnmultiple = 1;
        turnsasmoneytakeninx = 0;
        for (int h = 1; h < 101; h++)
        {
            boardpos[h] = 1;
            boardturnsofdiceforagame[h] = 0;
            boardturnsofgame[h] = 0;
            //boardgameturnmultiple[h] = 1;
            //boardgametotalmultiple[h] = 1;
            //commonboardgametotalmultipletakenin[h] = 0;
            for (int i = 1; i < 31; i++)
            {
                //boardgameturnmultiple[h][i] = 1;
                boardgametotalmultiple[h, i] = 0.01;
                //if (h<2)commonboardgametotalmultipleleft[i] = 1;
                //if (h<2)commonboardgametotalmultipleadded[i] = 1;
            }

            for (int i = 1; i < 101; i++)
            {
                boardstates[h, i] = 0;
                boardlIndex[h, i] = 0;
                boardsIndex[h, i] = 0;
            }

            for (int i = 1; i < 12; i++) boardladderHit[h, i] = 0;
            for (int i = 1; i < 11; i++) boardsnakeHit[h, i] = 0;
            boardfillLaddersrand(h);
            boardfillSnakesrand(h);
        }
        while (turnsofdice < numberofdiceturns)
        {
            boardDice();
            boardTurnsofDice();
            for (int h = 1; h < 101; h++)
            {
                if (boardpos[h] > 100) boardnumberofGames1(h);
            }
            boardSnakesLadders();
            //boardshuffleSnakesrand();
            //boardshuffleLaddersrand();
        }
        //commonboardlogtotalmultiple();
    }
    void boardfillLaddersrand(int h)
    {
        for (int i = 0; i < 11; i++)
        {
            if (r.Next(0, 6) > 2)
            {
                boardstates[h, ladderStart[i]] = ladderEnd[i];
                boardlIndex[h, ladderStart[i]] = i + 1;
            }
        }
    }
    void boardfillSnakesrand(int h)
    {
        for (int i = 0; i < 10; i++)
        {
            if (r.Next(0, 6) > 2)
            {
                boardstates[h, snakeStart[i]] = snakeEnd[i];
                boardsIndex[h, snakeStart[i]] = i + 1;
            }
        }
    }
    void boardDice()
    {
        int d = r.Next(0, 6) + 1;
        for (int h = 1; h < numberofboards; h++)
        {
            boardpos[h] = boardpos[h] + d;
            //printf(" %d", pos);
        }
    }
    void boardTurnsofDice()
    {
        ++turnsofdice;
        for (int h = 1; h < numberofboards; h++)
        {
            boardturnsofdiceforagame[h]++;
        }
    }
    void boardSnakesLadders()
    {
        for (int h = 1; h < numberofboards; h++)
        {
            if (boardstates[h, boardpos[h]] != 0)
            {
                if (boardlIndex[h, boardpos[h]] != 0) boardladderHit[h, boardlIndex[h, boardpos[h]]]++;
                if (boardsIndex[h, boardpos[h]] != 0) boardsnakeHit[h, boardsIndex[h, boardpos[h]]]++;
                //if(pos>states[pos])printf("snakehit %d",pos);
                //if(pos<states[pos])printf("ladderhit %d",pos);
                boardpos[h] = boardstates[h, boardpos[h]];
            }
        }
    }
    void boardlogmultiple(int h)
    {
        for (int i = 1; i < 11; i++)
        {
            turnsasmoneytakeninx = i - 1;
            gameturnmultiple = ((10000 - basispoint) / 10000) * (turnsasmoneytakeninx + 1)
                - turnsasmoneytakeninx * (1 + interest)
                + ((basispoint / (boardturnsofdiceforagame[h] * 350))) * (turnsasmoneytakeninx + 1);
            boardgametotalmultiple[h, i] = boardgametotalmultiple[h, i] * gameturnmultiple;
            gameturnmultiple = 1;
        }
        //boardgameturnmultiple[h] = ((10000 - basispoint) / 10000)*(turnsasmoneytakeninx + 1)
        //- turnsasmoneytakeninx*(1 + interest)
        //+ ((basispoint / (boardturnsofdiceforagame[h] * 350)))*(turnsasmoneytakeninx + 1);
        //boardgametotalmultiple[h] = boardgametotalmultiple[h] * boardgameturnmultiple[h];
        //boardgameturnmultiple[h] = 1;
    }
    void boardnumberofGames1(int h)
    {
        boardpos[h] = boardpos[h] - 100;
        //System.out.println("turnsofgame="+turnsofgame);
        //System.out.println("position="+pos);
        boardturnsofgame[h]++;
        //turnsasmoney = turnsasmoney*(((10000 - basispoint) / 10000) + (basispoint / (turnsofdiceforagame * 350)));
        boardlogmultiple(h);
        //commonboardlogmultiple(h);
        //prefcommonboardlogmultiple(h);
        //prefcommonboardlogmultiple1(h);
        boardturnsofdiceforagame[h] = 0;
        //if(turnsofgame%35==0)numberofdiceturns=numberofdiceturns+100;
    }
    void boardprintGameStats()
    {
        for (int h = 1; h < 101; h++)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" {0:G} ", boardgametotalmultiple[h, i]);
            }
            Console.Write("\n");
            //}
            //for (int h = 1; h < 101; h++)
            //{
            //for (int i = 1; i <= 11; i++)
            //	Console.Write("{0:G}{1:G} \n", i, boardladderHit[h,i]);
            //for (int i = 1; i <= 10; i++)
            //	Console.Write("{0:G}{1:G} \n", i, boardsnakeHit[h,i]);
        }
    }
    void boardrunGames()
    {
        for (int i = 0; i < 3; i++)
        {
            turnsasmoneytakeninx = i;
            //printf(" turnsasmoneytakeninx %f ", turnsasmoneytakeninx);
            Console.Write("{0:G}", turnsasmoneytakeninx);
            boardrunGame();
            boardprintGameStats();
            turnsofdice = 0;
            turnsofgame = 0;
        }
    }
    void commonboardlogmultiple(int h)
    {
        for (int i = 1; i < 11; i++)
        {
            commonboardgametotalmultipleadded[i] = commonboardgametotalmultipleadded[i] - boardgametotalmultiple[h,i];
            turnsasmoneytakeninx = i - 1;
            gameturnmultiple = ((10000 - basispoint) / 10000) * (turnsasmoneytakeninx + 1)
                - turnsasmoneytakeninx * (1 + interest)
                + (basispoint / (boardturnsofdiceforagame[h] * 350)) * (turnsasmoneytakeninx + 1);
            boardgametotalmultiple[h,i] = boardgametotalmultiple[h,i] * gameturnmultiple;
            commonboardallocatemultiple(h, i);
            //commonboardgametotalmultiple[i] = commonboardgametotalmultiple[i] + boardgametotalmultiple[h][i];
            //boardgametotalmultiple[h][i] = commonboardgametotalmultiple[i] / 10000;
            //commonboardgametotalmultiple[i] = commonboardgametotalmultiple[i] - boardgametotalmultiple[h][i];
            gameturnmultiple = 1;
        }
    }
    void commonboardprintGameStats()
    {
        for (int i = 1; i < 11; i++)
        {
            Console.Write("{0:G} ", commonboardgametotalmultipleadded[i]);
        }
        Console.Write("\n");
        for (int i = 1; i < 11; i++)
        {
            Console.Write("{0:G} ", commonboardgametotalmultipleleft[i]);
        }
        Console.Write("\n");
        //printf("snakes shuffled %d ", snakesshuffled);
        //printf("ladders shuffled %d \n", laddersshuffled);
        for (int h = 1; h < 101; h++)
        {
            Console.Write("{0:G} ", boardgametotalmultiple[h,1]);
        }
        Console.Write("\n");
    }
    void commonboardrunGames()
    {
        for (int i = 0; i < 3; i++)
        {
            commonboardrunGame();
            turnsofdice = 0;
            commonboardprintGameStats();
            //prefcommonboardprintGameStats1();
        }
    }
    void commonboardrunGame()
    {
        gameturnmultiple = 1;
        turnsasmoneytakeninx = 0;
        for (int h = 1; h < 101; h++)
        {
            boardpos[h] = 1;
            boardturnsofdiceforagame[h] = 0;
            boardturnsofgame[h] = 0;
            //boardgameturnmultiple[h] = 1;
            //boardgametotalmultiple[h] = 1;
            //commonboardgametotalmultipletakenin[h] = 0;
            for (int i = 1; i < 31; i++)
            {
                //boardgameturnmultiple[h][i] = 1;
                boardgametotalmultiple[h,i] = 0.01;
                if (h < 2) commonboardgametotalmultipleleft[i] = 1;
                if (h < 2) commonboardgametotalmultipleadded[i] = 1;
            }

            for (int i = 1; i < 101; i++)
            {
                boardstates[h,i] = 0;
                boardlIndex[h,i] = 0;
                boardsIndex[h,i] = 0;
            }

            for (int i = 1; i < 12; i++) boardladderHit[h,i] = 0;
            for (int i = 1; i < 11; i++) boardsnakeHit[h,i] = 0;
            boardfillLaddersrand(h);
            boardfillSnakesrand(h);
        }
        while (turnsofdice < numberofdiceturns)
        {
            boardDice();
            boardTurnsofDice();
            for (int h = 1; h < 101; h++)
            {
                if (boardpos[h] > 100) commonboardnumberofGames(h);
            }
            boardSnakesLadders();
            boardshuffleSnakesLaddersrand();
        }
        //commonboardlogtotalmultiple();
    }
    void commonboardnumberofGames(int h)
    {
        boardpos[h] = boardpos[h] - 100;
        //System.out.println("turnsofgame="+turnsofgame);
        //System.out.println("position="+pos);
        boardturnsofgame[h]++;
        //turnsasmoney = turnsasmoney*(((10000 - basispoint) / 10000) + (basispoint / (turnsofdiceforagame * 350)));
        //boardlogmultiple(h);
        commonboardlogmultiple(h);
        //prefcommonboardlogmultiple(h);
        //prefcommonboardlogmultiple1(h);
        boardturnsofdiceforagame[h] = 0;
        //if(turnsofgame%35==0)numberofdiceturns=numberofdiceturns+100;
    }
    void boardshuffleSnakesLaddersrand()
    {
        for (int h = 1; h < 101; h++)
        {
            if ((h * 1) == r.Next(0, 101))
            {
                //printf("shuffling snakes %d ", h);
                snakesshuffled++;
                laddersshuffled++;
                for (int i = 1; i < 101; i++)
                {
                    boardstates[h,i] = 0;
                    boardlIndex[h,i] = 0;
                    boardsIndex[h,i] = 0;
                }
                boardfillSnakesrand(h);
                boardfillLaddersrand(h);
            }
        }
    }
    void commonboardlogtotalmultiple()
    {
        for (int i = 1; i < 11; i++)
        {
            //for(int h=1;h<101;h++)
            //{
            //commonboardgametotalmultipleadded[i]=commonboardgametotalmultipleadded[i]+boardgametotalmultiple[h][i];
            //}
            commonboardgametotalmultipleadded[i] = commonboardgametotalmultipleadded[i] + commonboardgametotalmultipleleft[i];
        }
    }
    void commonboardallocatemultiple(int h, int i)
    {
        //if (boardgametotalmultiple[h][i] > (commonboardgametotalmultipleleft[i]))
        if (boardgametotalmultiple[h,i] > (commonboardgametotalmultipleadded[i] / 3))
        {
            commonboardgametotalmultipleleft[i] = commonboardgametotalmultipleleft[i] + (boardgametotalmultiple[h,i] / 10);
            boardgametotalmultiple[h,i] = boardgametotalmultiple[h,i] * 0.9;
        }
        else if (boardgametotalmultiple[h,i] > (commonboardgametotalmultipleadded[i] / 50)
            && boardgametotalmultiple[h,i] < commonboardgametotalmultipleleft[i] * 4)
        {
            commonboardgametotalmultipleleft[i] = commonboardgametotalmultipleleft[i] - (boardgametotalmultiple[h,i] / 4);
            boardgametotalmultiple[h,i] = boardgametotalmultiple[h,i] * 1.25;
        }
        else if (boardgametotalmultiple[h,i] < (commonboardgametotalmultipleadded[i] / 3000))
        {
            commonboardgametotalmultipleleft[i] = commonboardgametotalmultipleleft[i] + boardgametotalmultiple[h,i];
            boardgametotalmultiple[h,i] = commonboardgametotalmultipleleft[i] / 1000;
            commonboardgametotalmultipleleft[i] = commonboardgametotalmultipleleft[i] - boardgametotalmultiple[h,i];
        }
        commonboardgametotalmultipleadded[i] = commonboardgametotalmultipleadded[i] + boardgametotalmultiple[h,i];
    }

}
/*
#define numberofboards 101
#define boardsize 101
#define numberofparts 101
int multiply(int m1, int m2);
int Dice(int pos);
int pos = 1, turnsofdice = 0, turnsofgame = 0;
int states[101];
long numberofdiceturns = 100000;
void runGame(), TurnsofDice(), fillLadders(), fillSnakes(), numberofGames(), printGameStats(), logmultiple(), runGames();
void fillSnakesrand(), fillLaddersrand(), printGameStatsrand();
void boardrunGame(), boardrunGames(), boardfillLaddersrand(int h), boardfillSnakesrand(int h), boardDice();
void boardTurnsofDice(), boardnumberofGames1(int b), boardlogmultiple(int c), boardprintGameStats();
void boardSnakesLadders(), boardshuffleSnakesLaddersrand();
void commonboardrunGame();
void commonboardlogmultiple(int c), commonboardprintGameStats(), commonboardrunGames(), commonboardnumberofGames(int b);
void commonboardlogtotalmultiple(), commonboardallocatemultiple(int c, int d);
void prefcommonboardlogmultiple1(int c), prefcommonboardprintGameStats1(), prefcommonboardallocatemultiple1(int c, int d);
void prefcommonboardallocatemultiple2(int c, int d), prefboardrunGames1(), prefcommonboardrunGames1();
void prefcommonboardlogwholemultiple1(), prefcommonboardallocatemultiple3(int c);
void prefcommonboardlogmultiple2(int c), boardnumberofGames2(int b), prefcommonboardlogtotalmultiple();
void prefcommonboardprintGameStats2(), prefcommonboardrunGames2(), prefboardrunGames2();
void prefboardfillLaddersrand(int h), prefboardfillSnakesrand(int h);
void prefboardshuffleSnakesrand(), prefboardshuffleLaddersrand();
void prefcommonboardlogwholemultiple0();
void prefcommonboardlogwholemultiple2();
void prefcommonboardprintGameStats3();
void prefboardshuffleSnakesLaddersrand();
//struct gamestate *gamestatestruct();
int SnakesLadders();
int ladderStart[] = { 8,19,21,28,36,43,50,54,61,62,66 };
int ladderEnd[] = { 26,38,82,53,57,77,91,88,99,96,87 };
int snakeStart[] = { 98,93,83,69,68,64,59,52,48,46 };
int snakeEnd[] = { 13,37,22,33,2,24,18,11,9,15 };
int ladderHit[12];
int snakeHit[11];
int lIndex[101];
int sIndex[101];
int boardstates[numberofboards][boardsize];
int boardlIndex[numberofboards][boardsize];
int boardsIndex[numberofboards][boardsize];
int boardladderHit[numberofboards][12];
int boardsnakeHit[numberofboards][11];
int boardpos[numberofboards];
int boardturnsofdiceforagame[numberofboards];
int boardturnsofgame[numberofboards];
//float boardgameturnmultiple[101];
//float boardgametotalmultiple[101];
float boardgameturnmultiple[101][31];
float boardgametotalmultiple[101][31];
float commonboardgametotalmultipleleft[31];
float commonboardgametotalmultipleadded[31];
float commonboardgametotalmultipletakenin[101];
float logprefwholemultiple = 0;
float logprefwholemultipletaken = 0;
float logprefwholemultipleadded = 1;
float logprefwholemultipleleft = 1;
float prefboardgametotalmultiple[numberofboards];
int snakesshuffled = 0;
int laddersshuffled = 0;
int turnsofdiceforagame = 0;
float turnsasmoney = 100;
float turnsasmoneytakeninx = 0;
float interest = 0.006;
float prefinterest = 0.0045;
float basispoint = 100;
float gameturnmultiple = 1;
float gametotalmultiple = 1;
float logprefgamewholemultiple = 1;
double loggameturnmultiple = 0;
double loggametotalmultiple = 0;
struct gamestate
{
	float logprefgamewholemultiple;
	float logprefwholemultipletaken;
	float logprefwholemultipleadded;
	float logprefwholemultipleleft;
	float gameprefinterest;
	int numberofgameboards;
	int gameboardsize;
	int gamenumberofparts;
	int boardpos[numberofboards];
	int boardturnsofdiceforagame[numberofboards];
	int boardturnsofgame[numberofboards];
	int boardstates[numberofboards][boardsize];
	int boardlIndex[numberofboards][boardsize];
	int boardsIndex[numberofboards][boardsize];
	int boardladderHit[numberofboards][12];
	int boardsnakeHit[numberofboards][11];
	float prefboardgametotalmultiple[numberofboards];
};
struct gamestate prefgamestate, p;
struct gamestate *gamestatestruct();
void writegamestate(struct gamestate *p1);
//char *writegamestatestr(struct gamestate *p1);
void writegamestatestr(struct gamestate *p1);
void printtime();
*/
