using System;
using SCICT.NLP.Persian;

namespace Indexer1
{
    class PersianNormalizer
    {

        public int Normalize(char[] input, int len)
        {
            PersianCharFilter filter = new PersianCharFilter();
            String str = filter.FilterString((new String(input)));
            str.CopyTo(0, input, 0, str.Length);
            return str.Length;
        }

        protected int Delete(char[] s, int pos, int len)
        {
            if (pos < len)
                Array.Copy(s, pos + 1, s, pos, len - pos - 1);

            return len - 1;
        }
    }
}
