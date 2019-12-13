using System;
using System.Collections.Generic;
using System.Linq;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[4] { 0,1,2,-3 };
            int re = ThreeSumClosest(nums,1);
            Console.ReadKey();
        }
        #region 求两数和
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return null;
        }
        #endregion

        #region 32位有符号整数反转
        static public int Revere(int x)
        {
            float max = MathF.Pow(2,31) - 1;
            float min = 0 - MathF.Pow(2, 31);
            if (x > max || x < min || x == 0) return 0;
            char[] xCharList = x.ToString().ToCharArray();
            int length = xCharList.Length;
            if (xCharList[0] == '-')
            {
              
                for (int i = 1; i <= length / 2; i++)
                {
                    char temp = xCharList[i];
                    xCharList[i] = xCharList[length - i];
                    xCharList[length - i] = temp;
                }
            }
            else
            {
                for(int i = 0; i < length / 2; i++)
                {
                  
                    char temp = xCharList[i];
                    xCharList[i] = xCharList[length - 1 - i];
                    xCharList[length - 1 - i] = temp;
                 
                }
            }
            string result = "";
            for(int i = 0; i < xCharList.Length; i++)
            {
                result = result + xCharList[i];
            }
            try
            {
                return Int32.Parse(result); 
            }catch(Exception ex)
            {
                return 0;
            }
                
            
        }
        #endregion

        #region 寻找无重复字符的最长子串
        public static int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            List<char> resultChar = new List<char>();
            char[] sChar = s.ToCharArray();
            for(int i = 0; i < sChar.Length; i++)
            {
                if (!resultChar.Contains(sChar[i]))
                {
                    resultChar.Add(sChar[i]);
                    if(maxLength < resultChar.Count)
                    {
                        maxLength = resultChar.Count;
                    }
                    continue;
                }
                for(int j = 0; j < resultChar.Count; j++)
                {
                    if (resultChar[j] != sChar[i])
                    {
                        resultChar.RemoveAt(j);
                        j -= 1;
                    }
                    else
                    {
                        resultChar.RemoveAt(j);
                        break;
                    }
                }
                resultChar.Add(sChar[i]);
            }
            return maxLength;
        }
        #endregion

        #region 求有序数组的中位数
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> add = nums1.ToList();
            add.AddRange(nums2.ToList());
            add.Sort();
            int index = add.Count / 2;
            if(add.Count % 2 == 0)
            {
                return ((double)add[index] + (double)add[index - 1]) / 2;
            }
            return add[index];

        }
        #endregion

        #region Z字形变换
        public static string Convert(string s, int numRows)
        {
            string result = "";
            char[] sChar = s.ToCharArray();
            int length = sChar.Length / numRows;
            if (s == null) return result;
            if (numRows <= 1) return s;
            List<char>[] sRe = new List<char>[numRows];
            
            for (int i = 0; i < sChar.Length; i++)
            {
                int ans = i / (numRows-1);
                int currentRow = i % (numRows-1);
                if(ans %2 == 0)
                {
                    if(sRe[currentRow] == null)
                    {
                        sRe[currentRow] = new List<char>();
                    }
                    sRe[currentRow].Add(sChar[i]);
                }
                else
                {
                    if (sRe[numRows - 1 - currentRow] == null) sRe[numRows - 1 - currentRow] = new List<char>();
                    sRe[numRows - 1 - currentRow].Add(sChar[i]);
                }
            }
            for(int i = 0; i < sRe.Length; i++)
            {
                if (sRe[i] == null) continue;
                for(int j = 0; j < sRe[i].Count; j++)
                {
                    result += sRe[i][j];
                }
            }
            return result;
        }
        #endregion

        #region  回文数
        static public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            char[] xChars = x.ToString().ToCharArray();
            for(int i = 0; i < xChars.Length/2; i++)
            {
                if (xChars[i] != xChars[xChars.Length - 1 - i]) return false;
            }
            return true;
        }
        #endregion

        #region 两数相加
        public class ListNode
        {
             public int val;
             public ListNode next;
             public ListNode(int x) { val = x; }
         }
        static public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode cursor = result;
            int carry = 0;
            while(l1 != null || l2 != null || carry > 0)
            {
                int l1val = l1 != null ? l1.val : 0;
                int l2val = l2 != null ? l2.val : 0;
                int samVal = l1val + l2val + carry;
                carry = samVal / 10;
                ListNode l = new ListNode(samVal %10);
                cursor.next = l;
                cursor = l;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;

            }
            return result.next;
        }
        #endregion

        #region 罗马数字转数字
        public static int RomanToInt(string s)
        {
            char[] sChar = s.ToCharArray();
            int lastNum = 0;
            int num = 0;
            int reslut = 0;
            for (int i = 0; i < sChar.Length; i++)
            {
                switch (sChar[i])
                {
                    case 'I':
                        num = 1;
                        break;
                    case 'V':
                        num = 5;
                        break;
                    case 'X':
                        num = 10;
                        break;
                    case 'L':
                        num = 50;
                        break;
                    case 'C':
                        num = 100;
                        break;
                    case 'D':
                        num = 500;
                        break;
                    case 'M':
                        num = 1000;
                        break;
                    default:
                        break;
                }
                if (num <= lastNum || lastNum==0) reslut += num;
                else reslut = reslut + num - lastNum * 2;
                lastNum = num;
            }
            return reslut;
        }
        #endregion

        #region 数字转罗马数字
        public string IntToRoman(int num)
        {
            int[] value = new int[13] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] sChar = new string[13] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string result = "";
            for (int i = 0; i < value.Length; i++)
            {
                while(num >= value[i])
                {
                    result += sChar[i];
                    num -= value[i];
                }
            }
            return result;
        }
        #endregion

        #region 最长公共前缀
        public static string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            if (strs.Length == 0) return result;
            for(int i = 0; i < strs[0].Length; i++)
            {
                string comparison = strs[0].Substring(i,1);
                for(int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].Length <= i || strs[j].Substring(i,1) != comparison)
                    {
                        return result;
                    }
                }
                result += comparison;
            }
            return result;
        }
        #endregion

        #region 三数之和
        public static  IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> numsList = nums.ToList();
            numsList.Sort();
            if (numsList.Count < 3) return result;
            for (int i = 0; i < numsList.Count - 2; i++)
            {
                if (i > 0 && numsList[i] == numsList[i - 1]) continue;
                int sum = numsList[i];
                int min = i + 1, max = numsList.Count - 1;
                while (min < max)
                {
                    while (numsList[min] + numsList[max] > (-sum) && min < max) max--;
                    while (numsList[min] + numsList[max] < (-sum) && min < max) min++;
                    if (numsList[min] + numsList[max] == (-sum) && min < max)
                    {
                        List<int> resultSon = new List<int>();
                        resultSon.Add(numsList[i]);
                        resultSon.Add(numsList[min]);
                        resultSon.Add(numsList[max]);
                        result.Add(resultSon);
                        max--;
                        min++;
                        while (min < max && numsList[min] == numsList[min - 1])
                        {
                            min++;
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region 盛最多水的容器
        public static int MaxArea(int[] height)
        {
            int min = 0, max = height.Length - 1;
            int result = (height[min] > height[max] ? height[max] : height[min]) * (max - min);
            while (min < max)
            {
                if (height[min] > height[max])
                {
                    max--;
                }
                else
                {
                    min++;
                }
                int newResult = (height[min] > height[max] ? height[max] : height[min]) * (max - min);
                if(result < newResult)
                {
                    result = newResult;
                }
            }
         
            return result;
        }
        #endregion

        #region 最接近的三数之和
        public static int ThreeSumClosest(int[] nums, int target)
        {
            List<int> numList = nums.ToList();
            numList.Sort();
            int num = 0;
            int numDis = -1;
            if (numList.Count < 3) return 0;
            if (numList.Count == 3) return numList[0] + numList[1] + numList[2];
            for (int i = 0; i < numList.Count - 2; i++)
            {
                //if (i > 0 && numList[i] == numList[i - 1]) continue;
                int min = i + 1, max = numList.Count - 1;
                while (max - min > 0)
                {
                    int newNum = numList[i] + numList[min] + numList[max];
                    int newNumDis = Math.Abs(target - newNum);
                    if(numDis<0||newNumDis < numDis)
                    {
                        numDis = newNumDis;
                        num = newNum;
                    }
                    if (newNumDis == 0) return num;
                    else
                    {
                        if (newNum > 0) max--;
                        else if (newNum < 0) min--;
                    }
                }
            }
            return num;
        }
        #endregion
    }
}
