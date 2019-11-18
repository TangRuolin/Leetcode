using System;
using System.Collections.Generic;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x = 43261596;
            uint y = reverseBits(x);
            Console.WriteLine(y);
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
        #region 颠倒二进制符号数
        static public uint reverseBits(uint n)
        {

           
        }
        #endregion
    }
}
