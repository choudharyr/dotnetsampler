namespace DotNetSampler.Tests
{
    public class SamplerTests
    {
        [Fact]
        public void RelativeToCommonBase_ShouldReturnEmptyString_WhenPathsAreIdentical()
        {
            string path1 = "/home/daniel/memes";
            string path2 = "/home/daniel/memes";

            var result = Sampler.RelativeToCommonBase(path1, path2);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void RelativeToCommonBase_ShouldReturnUncommonPathSegment()
        {
            string path1 = "/home/daniel/memes";
            string path2 = "/home/daniel/work";

            var result = Sampler.RelativeToCommonBase(path1, path2);

            Assert.Equal("memes", result);
        }

        [Fact]
        public void ClosestWord_ShouldReturnMostSimilarWord()
        {
            string word = "example";
            string[] possibilities = { "samples", "simple", "examine", "ample", "temple" };

            var result = Sampler.ClosestWord(word, possibilities);

            Assert.Equal("examine", result);
        }

        [Fact]
        public void SpeedAtTime_ShouldReturnCorrectSpeed()
        {
            var path = new[]
            {
                new Sampler.PointInTime(0, 0, 1625151600),
                new Sampler.PointInTime(3, 4, 1625155200),
                new Sampler.PointInTime(6, 8, 1625158800)
            };
            double atTime = 1800; // 30 minutes after the first timestamp

            var result = Sampler.SpeedAtTime(atTime, path);

            Assert.Equal(0.00138889, result, 5);
        }

        [Fact]
        public void SpeedAtTime_ShouldThrowException_WhenPathHasLessThanTwoPoints()
        {
            var path = new[]
            {
                new Sampler.PointInTime(0, 0, 1625151600)
            };
            double atTime = 1800;

            Assert.Throws<ArgumentException>(() => Sampler.SpeedAtTime(atTime, path));
        }

        [Fact]
        public void ClosestWord_ShouldThrowException_WhenInputIsNullOrEmpty()
        {
            string word = null;
            string[] possibilities = { "samples", "simple", "examine", "ample", "temple" };

            Assert.Throws<ArgumentException>(() => Sampler.ClosestWord(word, possibilities));
        }
    }
}