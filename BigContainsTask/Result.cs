using System;
using System.Collections.Generic;

namespace IntegrityVisionTest
{
    public class Result
    {
        public TimeSpan ResultTime { get; set; }
        public IList<string> ResultArray { get; set; }
	    public string FirstLongestWord { get; set; }
		public string SecondLongestWord { get; set; }
    }
}
