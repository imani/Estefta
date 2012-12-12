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
    }
}
