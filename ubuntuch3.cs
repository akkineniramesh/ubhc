using System;
public class SnakesnLadders
{
    int pos=1,turnsofdice=0,turnsofgame=0;
	int[] states=new int[101];
    int numberofdiceturns = 100000;
	int[] ladderStart={8,19,21,28,36,43,50,54,61,62,66};
	int[] ladderEnd = {26,38,82,53,57,77,91,88,99,96,87};
	int[] snakeStart= {98,93,83,69,68,64,59,52,48,46};
	int[] snakeEnd =  {13,37,22,33,2,24,18,11,9,15};
	int[] ladderHit=new int[12];
	int[] snakeHit= new int[11];
	int[] lIndex= new int[101];
	int[] sIndex= new int[101];
	int numberofgames=0;
	int turnsofdiceforagame=0;
	double turnsasmoney=0;
	double basispoint=100;
    double turnsasmoneytakeninx = 0;
    double interest = 0.006;

    double gameturnmultiple = 1;
    double gametotalmultiple = 1;

	Random r= new Random();
	String args;
	
    public static void Main(string[] args)
    {
        int dice;
	    for (dice = 0; dice <= 6; dice = dice + 1)Console.Write(dice);
        int dice1;
	    dice1 = 10;
	    while (dice1 >= 1)
	    {
		    Console.Write(dice1);
		    dice1 = dice1 - 1;
	    }
        int[] ndice =new int[10];
	    for (dice1 = 0; dice1<10; ++dice1)
	    {
		    ndice[dice1] = dice1 * 2;
		    Console.Write(ndice[dice1]);
	    }
        if (dice1 > dice)Console.Write("{0:G} {1:G}",dice1, dice);
        Console.Write("{0:G} \n",multiply(5, 3));
        SnakesnLadders sal=new SnakesnLadders();
        sal.runGames();
        Console.WriteLine("hello ramesh");
    }
    public static int multiply(int m1, int m2)
    {
	    Console.Write("{0:G} {1:G} \n",m1, m2);
	    return m1*m2;
    }
    void runGame()
	{
		for (int i = 1; i<101; i++)
	    {
		    states[i] = 0;
		    lIndex[i] = 0;
		    sIndex[i] = 0;
	    }
	    for (int i = 1; i < 12; i++)ladderHit[i] = 0;
	    for (int i = 1; i < 11; i++)snakeHit[i] = 0;
	//getSnakesLadders(args);
	//System.out.println("turnsasmoneyatstart=" + turnsasmoney);
	    fillLadders();
	    fillSnakes();
	    //fillLaddersrand();
	    //fillSnakesrand();
	    while (turnsofdice<numberofdiceturns)
	    {
            Dice();
		    TurnsofDice();
		    if (pos>100)numberofGames();
		    SnakesLadders();
	    }
        
	}
    void Dice()
	{
		int d=r.Next(0,6);
		//System.out.println("dice="+d);
		pos=pos+d+1;
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
		    if (lIndex[pos] != 0)ladderHit[lIndex[pos]]++;
		    if (sIndex[pos] != 0)snakeHit[sIndex[pos]]++;
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
        for (int i = 0; i<11; i++)
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
        for (int i = 0; i<10; i++)
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
        gameturnmultiple = (((10000 - basispoint) / 10000)*(turnsasmoneytakeninx + 1))- turnsasmoneytakeninx*(1 + interest)+ ((basispoint / (turnsofdiceforagame * 350)))*(turnsasmoneytakeninx + 1);
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
        //for (int i = 1; i <= 11; i++)
        //Console.Write("LadderHit{0:G} {1:G} ",i, ladderHit[i]);
        //for (int i = 1; i <= 10; i++)
        //Console.Write("SnakeHit{0:G} {1:G}", i, snakeHit[i]);
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