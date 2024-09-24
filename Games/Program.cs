namespace Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tasks tasks = new("games.csv");
            tasks.Task1();
            tasks.Task2();
            tasks.Task3();
            tasks.Task4();
            tasks.Task5();
            tasks.Task6();
            tasks.Task7();
            tasks.Task8();
        }
    }
}
