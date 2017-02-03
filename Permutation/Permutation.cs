using System.Collections.Generic;
using System.Linq;

namespace Permutation
{
    public class Permutation
    {
        public List<List<string>> GetResult(List<string> source)
        {
            this._count = source.Count;
            InitialIndexPermutation();

            while (_endFlag == false)
            {
                ResultAdd(source);
            }

            return _result;
        }

        private void ResultAdd(List<string> source)
        {
            _indexPermutation.Reverse();
            List<int> cloneIndex = Clone(_indexPermutation);
            _indexPermutation.Reverse();

            List<string> tmpResult = new List<string>();
            List<string> sourceData = Clone(source);
            for (int i = 0; i < this._count; i++)
            {
                tmpResult.Add(sourceData[cloneIndex[0]]);

                sourceData.RemoveAt(cloneIndex[0]);
                cloneIndex.RemoveAt(0);
            }

            _result.Add(tmpResult);

            _indexPermutation[1]++;
            CarryBit();
        }

        private List<T> Clone<T>(List<T> source)
        {
            List<T> clone = new List<T>();
            source.ForEach(i => clone.Add(i));
            return clone;
        }

        private void InitialIndexPermutation()
        {
            foreach (var i in Enumerable.Range(0, _count))
            {
                _indexPermutation.Add(0);
            }
        }

        private void CarryBit()
        {
            for (int i = 1; i < _indexPermutation.Count; i++)
            {
                if (_indexPermutation[i] > i)
                {
                    if (i == _indexPermutation.Count - 1)
                    {
                        _endFlag = true;
                        return;
                    }
                    _indexPermutation[i + 1]++;
                    _indexPermutation[i] = 0;
                }
            }
        }

        private List<List<string>> _result = new List<List<string>>();

        private int _count = 0;

        private List<int> _indexPermutation = new List<int>();

        private bool _endFlag = false;
    }

}
