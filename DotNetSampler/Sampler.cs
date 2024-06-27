using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSampler
{
    public class Sampler
    {

        // ---- 2.
        /*
          Write a function that accepts two Paths and returns the portion of the first Path that is not
          common with the second, which is to say portion of the first path starting from where the two
          paths diverged.

          For example, RelativeToCommonBase("/home/daniel/memes", "/home/daniel/work") should
          produce "/home/daniel".

        ADDED BY RAHUL - Example is incorrect, the expected output in this case is "work"
        */
        public static String RelativeToCommonBase(String path1, String path2)
        {
            if (path1 == null) {
                throw new ArgumentException("The first path cannot be null.", nameof(path1));
            }

            if (path2 == null) {
                throw new ArgumentException("The second path cannot be null.", nameof(path2));
            }

            var fullPath1 = Path.GetFullPath(path1);
            var fullPath2 = Path.GetFullPath(path2);

            var path1Segments = fullPath1.Split(Path.DirectorySeparatorChar);
            var path2Segments = fullPath2.Split(Path.DirectorySeparatorChar);

            int minLength = Math.Min(path1Segments.Length, path2Segments.Length);
            int commonSegmentsLength = 0;

            for (int i = 0; i < minLength; i++) {
                if (!path1Segments[i].Equals(path2Segments[i], StringComparison.OrdinalIgnoreCase))
                    break;

                commonSegmentsLength = i + 1;
            }

            if(commonSegmentsLength == 0) { // nothing common
                return fullPath1;
            }

            if(commonSegmentsLength == path2Segments.Length) {
                return string.Empty;    // nothing uncommon
            }

            var unCommonSegments = path1Segments.Skip(commonSegmentsLength).ToArray();

            var outputPath = Path.Combine(unCommonSegments);

            return outputPath;
        }

        // ---- 2.
        /*
          Write a function that accepts a string as the first parameter, and a
          list of strings as the second parameter, and returns a string from the
          list that is "most like" the first string. The choice of algorithm 
          is yours.
        */
        public static String ClosestWord(String word, String[] possibilities)
        {
            if (string.IsNullOrEmpty(word) || possibilities == null || possibilities.Count() == 0) {
                throw new ArgumentException("Input string and string list cannot be null or empty.");
            }

            string mostLikedString = null;
            int minDistance = int.MaxValue;

            foreach (var str in possibilities) {
                int distance = StringSimilarity.LevenshteinDistance(word, str);
                if (distance < minDistance) {
                    minDistance = distance;
                    mostLikedString = str;
                }
            }

            return mostLikedString;
        }

        // ----3.
        /*
          Pretend there is a vehicle traveling along a path. The path is represented
          by a list of x, y points and a unix timestamp at that point 
          (the PointIntime struct).  The vehicle travels
          in straight lines between those points and passes through each point at
          the corresponding timestamp. Given this list of points and timestamps,
          and a time seconds (relative to the first timestamp), write a function
          that returns the instantaneous speed of the fake vehicle at that timestamp.
        */
        public struct PointInTime
        {
            public PointInTime(double x, double y, double timestamp)
            {
                X = x;
                Y = y;
                Timestamp = timestamp;
            }

            public double X { get; }
            public double Y { get; }
            public double Timestamp { get; }

            public override string ToString() => $"({X}, {Y}, {Timestamp})";
        }

        public static double SpeedAtTime(double atTime, PointInTime[] path)
        {
            if (path == null || path.Length < 2) {
                throw new ArgumentException("At least 2 points are needed to calculate the instantaneous speed");
            }

            double targetTime = path[0].Timestamp + atTime;

            for (int i = 0; i < path.Length - 1; i++) {
                var point1 = path[i];
                var point2 = path[i + 1];

                if (targetTime >= point1.Timestamp && targetTime <= point2.Timestamp) {
                    // Calculate distance using the Euclidean distance formula
                    double distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));

                    // Calculate time difference between the two points
                    double timeDifference = point2.Timestamp - point1.Timestamp;

                    // Calculate speed
                    double speed = distance / timeDifference;

                    return speed;
                }
            }

            throw new ArgumentException("The relative time is not in the range of the provided timestamps.");
        }
    }
}
