using System.Diagnostics;

namespace PerfSurf.Counters
{
    public class PerfCounterWrapper
    {
        private readonly PerformanceCounter _counter;

        public string Name { get; set; }

        public float Value
        {
            get { return _counter.NextValue(); }
        }

        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            Name = name;
            _counter= new PerformanceCounter(category, counter, instance, readOnly: true);
        }
    }
}