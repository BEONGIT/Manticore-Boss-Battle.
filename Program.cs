

using System.ComponentModel.Design;

Console.Title = "Hunting the Manticore";

int mantStation;
int round = 0;
int mantHealth=10;
int cityHealth = 15;
int cityRange;

do
{
    Console.WriteLine("Player 1, please place the Manticore. ");
    Console.Write("Pick a distance from the city 0-100 to station the Manticore? ");
    mantStation = Convert.ToInt32(Console.ReadLine());
}
while (mantStation < 0 || mantStation > 100);
Console.Clear();

bool CanonHit()
{
    bool hit;
    if (mantStation == cityRange)
    { hit = true; }
    else
    { hit = false; }
    return hit;
}

int CanonDamage()
{
    
    if (round % 3 == 0 && round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" 10 MIGHTY FIRE-ELECTRIC BLAST damage!!! ");
        Console.ResetColor();
        return 10;
    }
    else if (round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" 3 Fire Blast damage!! ");
        Console.ResetColor();
        return 3;
    }
    else if (round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" 5 Lightning Blast damage!!! ");
        Console.ResetColor();
        return 5;
    }
    else
    {
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine(" 1 normal damage!");
        Console.ResetColor();
        return 1;
    }
}

void CityShot()
{
    cityHealth--;
    if (cityRange == mantStation)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT!!!! ");
        Console.ResetColor();
    }
    else if (cityRange > mantStation)
    {
        Console.WriteLine("That round OVERSHOT the target. ");
    }
    else
    {
        Console.WriteLine("That round FELL SHORT of the target. ");
    }
}

void StatusUpdate()
{
    if (CanonHit())
    {
        mantHealth -= CanonDamage();
    }
}

Console.WriteLine("Player 2, it is your turn. ");

while (cityHealth > 0 && mantHealth > 0)

{
    round++;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {mantHealth}/10");
    Console.ResetColor();
    Console.ForegroundColor= ConsoleColor.Blue;
    Console.Write("The canon is expected to deal "); CanonDamage();
    Console.ResetColor();
    Console.Write("Enter desired canon range: ");
    cityRange = Convert.ToInt32(Console.ReadLine());
    CityShot();
    StatusUpdate();
    Console.WriteLine("_____________________________________________________________________________________________________________");
    
    if (cityHealth <= 0)
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("YOU LOSE");
        Console.WriteLine("The City of Consolas has been Destroyed! ");
        Console.ResetColor();
    }
    else if (mantHealth <= 0)
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("YOU WON!!!");
        Console.WriteLine("The City of Consolas has been Saved!! ");
        Console.ResetColor();
    }
}