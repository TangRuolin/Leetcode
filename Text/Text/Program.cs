using System;
using System.Collections.Generic;
using System.Linq;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "23";
            int[] a = new int[3] { 1,3,2};
            NextPermutation(a);
            Console.ReadKey();
        }
        #region 题目中用到的节点（ListNode）
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        #endregion

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

        #region 最接近的三数之和（用排序加双指针）
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
                    int newNumDis = target - newNum;
                    if(numDis<0||Math.Abs(newNumDis) < numDis)
                    {
                        numDis = Math.Abs(newNumDis);
                        num = newNum;
                    }
                    if (newNumDis == 0) return num;
                    else if (newNumDis > 0) min++;
                    else if (newNumDis < 0) max--;
                }
            }
            return num;
        }
        #endregion

        #region 电话号码的字母组合(用回溯算法解决)
        static List<string> LetterCombinationsResult = new List<string>();
        public static IList<string> LetterCombinations(string digits)
        {
            string[] reTable = new string[10] {
                "","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"
            };
            if (string.IsNullOrEmpty(digits)) return LetterCombinationsResult;
            char[] d = digits.ToCharArray();
            LetterCom(d,reTable,0,"");
            return LetterCombinationsResult;
        }
       static void LetterCom(char[] digits,string[] reTable,int index,string resultString)
        {
            if(index >= digits.Length)
            {
                LetterCombinationsResult.Add(resultString);
                return;
            }
            int indexRe = digits[index]-48;
            char[] nowTable = reTable[indexRe].ToCharArray();
            for(int i = 0; i < nowTable.Length; i++)
            {
                resultString += nowTable[i];
                LetterCom(digits, reTable, index + 1, resultString);
                resultString = resultString.Substring(0,resultString.Length-1);
            }
        }
        #endregion

        #region 删除链表的倒数第N个节点
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n == 0) return head;
            if (head == null) return null;
            if (head.next == null) return null;

            int count = 0;
            ListNode node = head;
            ListNode node2 = null;
            while (node != null)
            {
                node = node.next;
                count++;
                if (count > n)
                {
                    node2 = node2 == null ? head : node2.next;
                }
                if (node == null)
                {
                    if (node2 == null) return head.next;
                    node2.next = node2.next.next;
                }
            }
            return head;
        }
        #endregion

        #region 有效括号
        public static bool IsValid(string s)
        {
            char[] sChar = s.ToCharArray();
            List<char> buffer = new List<char>();
            for(int i = 0; i < sChar.Length; i++)
            {
                if(sChar[i] == ']')
                {
                    if (buffer.Count>0 && buffer[buffer.Count - 1] == '[')
                    {
                        buffer.RemoveAt(buffer.Count-1);
                    }
                    else return false;
                }
                else if( sChar[i] == '}')
                {
                    if (buffer.Count > 0 && buffer[buffer.Count - 1] == '{')
                    {
                        buffer.RemoveAt(buffer.Count - 1);
                    }
                    else return false;
                }
                else if ( sChar[i] == ')')
                {
                    if (buffer.Count > 0 && buffer[buffer.Count - 1] == '(')
                    {
                        buffer.RemoveAt(buffer.Count - 1);
                    }
                    else return false;
                }
                else if(sChar[i] == '(' || sChar[i] == '{' || sChar[i] == '[')
                {
                    buffer.Add(sChar[i]);
                }
            }
            if (buffer.Count > 0) return false;
            return true;
        }
        #endregion

        #region 合并两个有序链表
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode cur = result;
            while(l1 != null && l2 != null)
            {
                if(l1.val <= l2.val)
                {
                    cur.next = l1;
                    cur = cur.next;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    cur = cur.next;
                    l2 = l2.next;
                }
            }
            if (l1 != null) cur.next = l1;
            if (l2 != null) cur.next = l2;
            return result.next;
        }
        #endregion

        #region 生成括号的对数
        static List<string> result = new List<string>();
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return result;
            string reString = "";
            List<char> buffer = new List<char>();
            int count = 0;
            GeneratePa(reString,buffer,n,count);
            return result;
        }
        static void GeneratePa(string reString,List<char> buffer,int n,int count)
        {
            if(count == n)
            {
                for(int i = 0; i < buffer.Count; i++)
                {
                    reString += ')';
                }
                result.Add(reString);
                return;
            }
           
            for(int i = 0; i < 2; i++)
            {
                if(i == 0)
                {
                    buffer.Add('(');
                    reString += '(';
                    count++;
                    GeneratePa(reString, buffer,n,count);
                    if (buffer.Count == 0) continue;
                    buffer.RemoveAt(buffer.Count-1);
                    reString = reString.Substring(0,reString.Length-1);
                    count--;
                }
                else
                {
                    if (buffer.Count == 0)
                    {
                        continue;
                    }
                    buffer.RemoveAt(buffer.Count - 1);
                    reString += ')';
                    GeneratePa(reString, buffer, n, count);
                    buffer.Add('(');
                }
                
            }
        }
        #endregion

        #region 合并k个排序链表(用到合并两个有序链表的方法)
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];
            ListNode[] newLists;
            if (lists.Length % 2 == 0)
            {
                newLists = new ListNode[lists.Length / 2];
            }
            else
            {
                newLists = new ListNode[lists.Length / 2 + 1];
                newLists[lists.Length / 2] = lists[lists.Length / 2];
            }
            for(int i = 0; i < lists.Length / 2; i++)
            {
                newLists[i] = MergeTwoLists(lists[i],lists[lists.Length-i-1]);
            }
            return MergeKLists(newLists);
        }
        #endregion

        #region 两两交换链表中的节点
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode result = new ListNode(0);
            ListNode cur = result;
            while(head != null && head != null)
            {

            }
            return result.next;
        }
        #endregion

        #region 删除排序数组中的重复项(双指针)
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            int start = 0;
            int end = 1;
            while(end < nums.Length)
            {
                if(nums[end] == nums[start])
                {
                    end++;
                }
                else
                {
                    start++;
                    nums[start] = nums[end];
                    end++;
                }
            }
            return start+1;
        }
        #endregion

        #region 移除元素
        public int RemoveElement(int[] nums, int val)
        {
            int newId = 0;
            int nowId = 0;
            while(nowId < nums.Length)
            {
                if (nums[nowId] == val) nowId++;
                else
                {
                    nums[newId] = nums[nowId];
                    newId++;
                    nowId++;
                }
            }
            return newId;
        }
        #endregion

        #region 搜索旋转排序数组
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;
            int min = 0, max = nums.Length-1;
            int mid;
            while(min <= max)
            {
                mid = (min + max) / 2;
                if (nums[mid] == target) return mid;
                if (nums[min] <= nums[mid])//前半部分有序
                {
                   if(nums[mid] >= target && nums[min] < target)
                    {
                        max = mid - 1 ;
                    }
                    else
                    {
                        min =mid+1;
                    }
                }
                else  //后半部分有序
                {
                    if(nums[mid]<target && nums[max] >= target)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid - 1 ;
                    }
                }
            }
            return -1;
        }
        #endregion

        #region 下一个排列
        public static void NextPermutation(int[] nums)
        {
            int temp;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    for(int j = 0; j < nums.Length/2; j++)
                    {
                        temp = nums[j];
                        nums[j] = nums[nums.Length - 1 - j];
                        nums[nums.Length - 1 - j] = temp;
                    }
                    return;
                }
                if (nums[i] > nums[i - 1])
                {
                    for(int j = i; j < (nums.Length + i)/2; j++)
                    {
                        temp = nums[j];
                        nums[j] = nums[nums.Length + i - j-1];
                        nums[nums.Length + i - j - 1] = temp;
                    } 
                    for(int j = i; j < nums.Length; j++)
                    {
                        if (nums[j] > nums[i - 1])
                        {
                            temp = nums[j];
                            nums[j] = nums[i - 1];
                            nums[i - 1] = temp;
                            break;
                        }
                    }
                    return;
                }
            }
            
        }
        #endregion
    }
}
