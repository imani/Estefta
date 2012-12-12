using System;

namespace Indexer1
{
    class PersianNormalizer
    {

        public String Normalize(String input, int len)
        {
            String str = SCICT.NLP.Utility.StringUtil.RefineAndFilterPersianWord(input);
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
