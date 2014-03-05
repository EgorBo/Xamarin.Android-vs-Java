using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ContactListXamarin
{
    public class TestExecuter
    {
        public const int TestsCount = 5;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public string Run(ITest test)
        {
            var timeSpans = new List<long>(TestsCount);
            for (int i = 0; i < TestsCount; i++)
            {
                _stopwatch.Restart();
                test.Run();
                _stopwatch.Stop();
                timeSpans.Add(_stopwatch.ElapsedMilliseconds);
            }
            long first = timeSpans.First();
            long max = timeSpans.Max();
            long min = timeSpans.Min();
			long avg = (timeSpans.Sum() - max - min)/(timeSpans.Count - 2);
            return string.Format("First: {0}, Fastest: {1}, Slowest: {2}, Average: {3}", first, min, max, avg);
        }
    }
}