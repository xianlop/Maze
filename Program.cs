namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Abstract.Generate generate = new Abstract.Generate();
            generate.Start();
            Console.ReadKey(true);
        }
    }
}