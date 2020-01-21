using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "23";
            string a = GetPermutation(3, 2);
            Console.WriteLine("最终结果："+a);
           
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

        #region 在排序数组中查找元素的第一个和最后一个位置
        public static int[] SearchRange(int[] nums, int target)
        {
            int min = 0, max = nums.Length-1;
            int mid;
            int resultMin = -1, resultMax = -1;
            if(nums.Length == 0) return new int[] { resultMin, resultMax };
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (nums[mid] > target) max = mid - 1;
                else if (nums[mid] < target) min = mid + 1;
                else
                {
                    int midx;
                    int maxx = mid;
                    while (min <= maxx)
                    {
                        midx = (min + maxx) / 2;

                        if ( (nums[midx] == target && midx == 0)||(nums[midx] == target && midx > 0 && nums[midx - 1] < target))
                        {
                            resultMin = midx;
                            break;
                        }
                        else if (nums[midx] < target) min = midx + 1;
                        else
                        {
                            maxx = midx - 1;
                        }
                    }
                    while(mid <= max)
                    {
                        midx = (mid + max) / 2;
                        if ((nums[midx] == target && midx == nums.Length-1) || (nums[midx] == target && midx < nums.Length - 1&&nums[midx + 1] > target))
                        {
                            resultMax = midx;
                            break;
                        }
                        else if (nums[midx] > target) max = midx - 1;
                        else
                        {
                            mid = midx + 1;
                        }
                    }
                    break;
                }
            }
            return new int[] { resultMin, resultMax };
        }
        #endregion

        #region 搜索插入数据
        public int SearchInsert(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    if (i == 0) return 0;
                    if (nums[i - 1] <= target)
                    {
                        return i;
                    }
                }
            }
            return nums.Length;
        }
        #endregion

        #region 外观数列
        public static string CountAndSay(int n)
        {
            string result = "1";
            if (n == 1) return result;
            int num = 2;
            while(num <= n)
            {
                char[] reChar = result.ToArray();
                int count = 0;
                char number = reChar[0];
                result = "";
                for(int i = 0; i < reChar.Length; i++)
                {
                    if(reChar[i] == number)
                    {
                        count++;
                    }
                    else
                    {
                        result += count.ToString() + number.ToString();
                        number = reChar[i];
                        count = 1;
                    }
                }
                result = result + count.ToString() + number;

                num++;
            }
            return result;
        }
        #endregion

        #region 读取xml方法
        /// <summary>
        /// 从xml文件中获取对应tag的值（int类型）
        /// </summary>
        /// <param name="tag"></param>标签名字
        /// <param name="defaultValue"></param>默认值
        /// <returns></returns>
        static int GetXmlNodeInt(string tag, int defaultValue)
        {
            XmlDocument xml_file = new XmlDocument();
            xml_file.LoadXml("具体的地址");
            var val = xml_file.GetElementsByTagName(tag);
            if (val == null || val.Count <= 0) return defaultValue;
            int outValue;
            if(int.TryParse(val[0].InnerText,out outValue))
            {
                return outValue;
            }
            return defaultValue;
        }
        /// <summary>
        /// 从xml文件中读取对于tag的值（string类型）
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static string GetXmlNodeString(string tag,string defaultValue)
        {
            XmlDocument xml_file = new XmlDocument();
            xml_file.LoadXml("具体的地址");
            var val = xml_file.GetElementsByTagName(tag);
            if(val == null || val.Count <= 0)
            {
                return defaultValue;
            }
            return val[0].InnerText;
        }
        #endregion

        #region 组合总和（没解决）
        //public IList<IList<int>> CombinationSum(int[] candidates, int target)
        //{

        //}
        #endregion

        #region 最大子序和(时间复杂度为O(n))
        public static int MaxSubArray(int[] nums)
        {
            int result = nums[0];
            int sum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(sum > 0)
                {
                    sum += nums[i];
                }
                else
                {
                    sum = nums[i];
                }
                if (sum > result)
                {
                    result = sum;
                }
            }
            return result;
        }
        #endregion

        #region 跳跃游戏
        public static bool CanJump(int[] nums)
        {
            int last = nums.Length-1;
            for(int i = nums.Length - 2; i >= 0; i--)
            {
                if (last - i <= nums[i]) last = i;
            }
           
            return last == 0;
        }
        #endregion

        #region 螺旋矩阵
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
            if (matrix.Length == 0) return result;
            int r1 = 0, r2 = matrix[0].Length-1, c1 = 0, c2 = matrix.Length-1;
            while (r1 <= r2 && c1 <= c2)
            {
                for (int i = r1; i <= r2; i++) result.Add(matrix[c1][i]);
                for (int i = c1+1; i <= c2; i++) result.Add(matrix[i][r2]);
                if(c1 != c2)
                    for (int i = r2 - 1; i >= r1; i--) result.Add(matrix[c2][i]);
                if(r1!=r2)
                    for (int i = c2 - 1; i > c1; i--) result.Add(matrix[i][r1]);
                r1++;
                r2--;
                c1++;
                c2--;
            }
            return result;
        }
        #endregion

        #region 合并区间
        public int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            if (intervals.Length == 0) return result.ToArray();
            for(int i = 0; i < intervals.Length-1; i++)
            {
                for(int j = i + 1; j < intervals.Length; j++)
                {
                    if (intervals[i][0] > intervals[j][0])
                    {
                        int[] temp = intervals[i];
                        intervals[i] = intervals[j];
                        intervals[j] = temp;
                    }
                }
            }
           // bool[] tag = new bool[intervals.Length];
            int[] n = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
               if(n[1] >= intervals[i][0])
                {
                    if (n[0] > intervals[i ][0]) n[0] = intervals[i][0];
                    if (n[1] < intervals[i][1]) n[1] = intervals[i][1];
                }
                else
                {
                    result.Add(n);
                    n = intervals[i];
                }
            }
            result.Add(n);
            return result.ToArray();
        }
        #endregion

        #region 最后一个单词的长度
        public static int LengthOfLastWord(string s)
        {
            char[] sChar = s.ToCharArray();
            int n = 0;
            for(int i = sChar.Length - 1; i >= 0; i--)
            {
                if (sChar[i] == ' ')
                {
                    if (n != 0) return n;
                    continue;
                }
                n++;
            }
            return n;
        }
        #endregion

        #region 螺旋矩阵2
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            if (n == 0)
            {
                return result;
            } 
            int r1 = 0, r2 = n - 1, c1 = 0, c2 = n - 1;
            int number = 1;
            while(r2 >= r1 && c2 >= c1)
            {
                for(int i = r1;i<=r2;i++)
                {
                    if (result[c1] == null) result[c1] = new int[n];
                    result[c1][i] = number;
                    number++;
                }
                for(int i = c1 + 1; i <= c2; i++)
                {
                    if (result[i] == null) result[i] = new int[n];
                    result[i][r2] = number;
                    number++;
                }
                if (c1 != c2)
                {
                    for(int i = r2 - 1; i >= r1; i--)
                    {
                        result[c2][i] = number;
                        number++;
                    }
                }
                if(r1 != r2)
                {
                    for(int i = c2 - 1; i > c1; i--)
                    {
                        result[i][r1] = number;
                        number++;
                    }
                }
                r1++;
                r2--;
                c1++;
                c2--;
            }
            return result;
        }
        #endregion

        #region 全排列 
        public static IList<IList<int>> resultPermute;
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<int> num = new List<int>();
            PermuteLoop(num,nums.ToList());
            return resultPermute;
        }
        public static void PermuteLoop(IList<int> nums,List<int> choose)
        {
            if (choose.Count == 0)
            {
                if(resultPermute == null)
                {
                    resultPermute = new List<IList<int>>();
                }
                IList<int> result = new List<int>();
                foreach(int i in nums)
                {
                    result.Add(i);
                }
                resultPermute.Add(result);
            }
            for(int i = 0; i < choose.Count; i++)
            {
                nums.Add(choose[i]);
                int num = choose[i];
                choose.RemoveAt(i);
                PermuteLoop(nums,choose);
                choose.Insert(i,num);
                nums.Remove(choose[i]);
            }
        }
        #endregion

        #region 全排列2
        static IList<IList<int>> resultPermuteUnique = new List<IList<int>>();
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<int> num = new List<int>();
            PermuteUniqueLoop(num,nums.ToList());
            return resultPermuteUnique;
        }
        public static void PermuteUniqueLoop(IList<int> num,List<int> choose)
        {
            if(choose.Count == 0)
            {
                IList<int> result = new List<int>();
                foreach(int i in num)
                {
                    result.Add(i);
                }
                resultPermuteUnique.Add(result);
            }
            List<int> hasAddList = new List<int>();
            for(int i = 0; i < choose.Count; i++)
            {
                bool hasAdd = false;
                foreach (int n in hasAddList)
                {
                    if(choose[i] == n)
                    {
                        hasAdd = true;
                        break;
                    }
                }
                if (hasAdd) continue;
                num.Add(choose[i]);
                int temp = choose[i];
                choose.RemoveAt(i);
                PermuteUniqueLoop(num, choose);
                choose.Insert(i,temp);
                num.RemoveAt(num.Count-1);
                hasAddList.Add(choose[i]);
            }
        }
        #endregion

        #region 旋转图像
        public void Rotate(int[][] matrix)
        {
            if (matrix.Length == 0) return;
            for(int i = 0; i < matrix.Length-1; i++)
            {
                for(int j = i+1; j < matrix.Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            int middle = matrix.Length / 2;
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < middle; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix.Length - j - 1];
                    matrix[i][matrix.Length - j - 1] = temp;
                }
            }
        }
        #endregion

        #region 字母异位词分组
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            for(int i = 0; i < strs.Length; i++)
            {
                char[] a = strs[i].ToCharArray();
                Array.Sort(a);
                string key = string.Join("",a);
                if (map.ContainsKey(key))
                {
                    map[key].Add(strs[i]);
                    continue;
                }
                IList<string> list = new List<string>();
                list.Add(strs[i]);
                map.Add(key, list);
            }
            foreach(var i in map)
            {
                result.Add(i.Value);
            }
            return result;
        }

        #endregion

        #region 找出第k个排列
        public static string permutationResult = null;
        public static int index = 0;

        public static string GetPermutation(int n, int k)
        {
            if (k == 0) return permutationResult;
            int[] number = new int[n];
            int everyGroupNum = 1;
            for(int i = 0; i < n; i++)
            {
                number[i] = i + 1;
                if(i != 0)
                    everyGroupNum *= i;
            }
            if (k == 1) return string.Join("",number);
            int startGroup = (k / everyGroupNum) + 1; 
            index = k % everyGroupNum;
            if (everyGroupNum == 1)
            {
                index = 1;
                startGroup--;
            }
            if(index == 0)
            {
                index = everyGroupNum;
                startGroup--;
            }
            List<int> result = new List<int>();
            result.Add(startGroup);
            List<int> residue = number.ToList();
            residue.Remove(startGroup);
            GetPermutationLoop(result, residue);
            return permutationResult;

        }
        public static void GetPermutationLoop(List<int> result,List<int> residue)
        {
            if(residue.Count == 0)
            {
                if(index == 1)
                {
                    permutationResult = string.Join("", result.ToArray());
                }
                else
                {
                    index--;
                }
                return;
            }
            for(int i = 0; i < residue.Count; i++)
            {
                result.Add(residue[i]);
                int temp = residue[i];
                residue.RemoveAt(i);
                GetPermutationLoop(result, residue);
                if (permutationResult != null)
                {
                    return;
                }
                result.RemoveAt(result.Count-1);
                residue.Insert(i, temp);
            }

        }
        #endregion

        #region 插入区间 
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            bool hasAdd = false;
            int[] resultItem = null;
            for(int i = 0; i < intervals.Length; i++)
            {
                if(resultItem == null)
                {
                    resultItem = new int[2];
                    resultItem[0] = intervals[i][0];
                    resultItem[1] = intervals[i][1];
                    if (resultItem[0] > newInterval[1])
                    {
                        if (!hasAdd)
                        {
                            result.Add(newInterval);
                            hasAdd = true;
                        }
                        result.Add(resultItem);
                        resultItem = null;
                        continue;
                    }
                    if(resultItem[1] < newInterval[0])
                    {
                        result.Add(resultItem);
                        resultItem = null;
                        continue;
                    }
                    hasAdd = true;
                    resultItem[0] = resultItem[0] < newInterval[0] ? resultItem[0] : newInterval[0];
                    resultItem[1] = resultItem[1] > newInterval[1] ? resultItem[1] : newInterval[1];
                }
                else
                {
                    if(resultItem[1] >= intervals[i][0])
                    {
                        resultItem[1] = resultItem[1] > intervals[i][1] ? resultItem[1] : intervals[i][1];
                    }
                    else
                    {
                        result.Add(resultItem);
                        resultItem = new int[2];
                        resultItem[0] = intervals[i][0];
                        resultItem[1] = intervals[i][1];
                    }
                }
               
            }
            if(resultItem!= null)
            {
                result.Add(resultItem);
            }
            if (!hasAdd)
            {
                result.Add(newInterval);
            }
            return result.ToArray();
        }
        #endregion

        #region 不同路径
        public int UniquePaths(int m, int n)
        {

        }
        #endregion
    }
}
