using System;
using System.Collections.Generic;
using System.Text;

namespace ML1.LeetCode
{
    class PLengthOfLongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            var maxLen = 0;
            var noRepeatList = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!noRepeatList.ContainsKey(c))
                {
                    noRepeatList.Add(c, i);
                }
                else
                {
                    var len = i - noRepeatList[c];
                    if (len > maxLen)
                    {
                        maxLen = len;
                    }
                }
            }
            return maxLen;
        }
    }
}
