using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericArrayLibrary
{
    public static class SequenceExtensions
    {
        public static IEnumerable SequenceFindMissing(this int[] sequence)
        {
            return sequence.Zip(sequence.Skip(1), (a, b) => Enumerable.Range(a + 1, (b - a) - 1))
                .SelectMany(s => s);
        }

        public static bool IsSequenceBroken(this int[] sequence)
        {
            return sequence.Zip(sequence.Skip(1), (a, b) => b - a)
                .Any(v => v != 1);
        }
    }
}
