// See https://aka.ms/new-console-template for more information

using Snake;

Coord gridDimensions = new Coord(20, 50);
Coord snakePos = new Coord(10, 10);
Random rand = new Random();
Coord applePos = new Coord(rand.Next(1, gridDimensions.X-1), rand.Next(1, gridDimensions.Y-1));
int frameDelay = 100;
Direction movementDirection = Direction.Down;
int score = 0;

List<Coord> snakePosHistory = new List<Coord>();
int tailLength = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine($"Score: {score}");
    snakePos.ApplyMovementDirection(movementDirection);
    for (int x = 0; x < gridDimensions.X; x++)
    {
        for (int y = 0; y < gridDimensions.Y; y++)
        {
            Coord currentCoord = new Coord(x, y);
        
            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                Console.Write("\u25a0");
            else if (applePos.Equals(currentCoord))
                Console.Write("a");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    if (snakePos.Equals(applePos))
    {
        tailLength++;
        score++;
        applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));        
    } else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimensions.X - 1 ||
               snakePos.Y == gridDimensions.Y - 1 || snakePosHistory.Contains(snakePos))
    {
        score = 0;
        tailLength = 1;
        snakePos = new Coord(10, 1);
        snakePosHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }
    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
    if (snakePosHistory.Count > tailLength)
        snakePosHistory.RemoveAt(0);
    
    DateTime time = DateTime.Now;
    while ((DateTime.Now - time).TotalMilliseconds < frameDelay)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
            }
        }
    }
}