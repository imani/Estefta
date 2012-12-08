using System;
using SCICT.NLP.Persian;

namespace Indexer1
{
    class PersianNormalizer
    {

        public String Normalize(String input, int len)
        {
            PersianCharFilter filter = new PersianCharFilter();
            String str = filter.FilterString(input);
            return str;
        }

        protected int Delete(char[] s, int pos, int len)
        {
            if (pos < len)
                Array.Copy(s, pos + 1, s, pos, len - pos - 1);

            return len - 1;
        }
    }
}
