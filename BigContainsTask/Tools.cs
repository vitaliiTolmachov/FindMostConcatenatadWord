using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IntegrityVisionTest
{
    public class Tools
    {
        private List<string> _resultArr = new List<string>();
        private List<string> _inputArray = new List<string>();
        private Dictionary<string, string> _lookupArray = new Dictionary<string, string>();
        private int shortestWordLendth;

        public Result Run(IList<string> inputArray)
        {
            _inputArray = inputArray.ToList();
            _inputArray.Reverse();

            var timer = Stopwatch.StartNew();

            InitializeLookupArray();
            SearchConcatenationWord();
            _resultArr = _resultArr.OrderByDescending(x => x.Length).ToList();

            timer.Stop();

            return new Result()
            {
                ResultArray = _resultArr,
                ResultTime = timer.Elapsed
            };
        }

        /// <summary>
        /// Creates lookup array. Key is the first chars. Value is the word starts from key.
        /// </summary>
        public void InitializeLookupArray()
        {
            foreach (string word in _inputArray)
            {
                _lookupArray.Add(word, word);
            }
        }

        public void SearchConcatenationWord()
        {
            for (int i = 0; i < _inputArray.Count; i++)
            {
                FindWord(_inputArray[i], i);
            }
        }

        private void FindWord(string word, int index)
        {
            int currentWordLength = word.Length;
            for (var charIndex = shortestWordLendth; charIndex < currentWordLength; charIndex++)
            {
                var prefix = word.Substring(0, charIndex);
                var suffix = word.Substring(charIndex);

                //We are not interested in suffix wich is smaller than the smallest words
                if (suffix.Length < shortestWordLendth)
                    break;
                if (_lookupArray.ContainsKey(prefix))
                {
                    if (_lookupArray.ContainsKey(suffix))
                    {
                        //If word = prefix + sufix it's contactenated word we are looking for
                        _resultArr.Add(_inputArray[index]);
                        break;
                    }
                    //Let's find another part to concatenate with prefix
                    FindWord(suffix, index);
                }

            }
        }
    }
}
