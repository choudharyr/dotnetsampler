using static DotNetSampler.Sampler;

namespace DotNetSampler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sPath = Sampler.RelativeToCommonBase("/home/daniel/memes", "/home/daniel/work");
            Console.WriteLine(sPath);

            var path = new List<PointInTime>()
            {
                new PointInTime(0, 0, 1625151600),
                new PointInTime(3, 4, 1625155200),
                new PointInTime(6, 8, 1625158800)
            };

            double timeSeconds = 1800; // 30 minutes after the first timestamp
            double speed = Sampler.SpeedAtTime(timeSeconds, path.ToArray());

            Console.WriteLine($"Instantaneous speed at {timeSeconds} seconds: {speed} units per second");


            string input = "example";
            var stringList = new List<string> { "samples", "simple", "examine", "ample", "temple" };

            string mostSimilar = Sampler.ClosestWord(input, stringList.ToArray());
            Console.WriteLine($"The most similar string to '{input}' is '{mostSimilar}'.");
        }
    }
}
