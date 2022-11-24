using System;
using System.Collections.Generic;

namespace Longest_Valid_Parentheses
{
  class Program
  {
    static void Main(string[] args)
    {
      string str = "())((()))";
      Solution s = new Solution();
      var answer = s.LongestValidParentheses_(str);
      Console.Write(answer);
    }
  }

  /// <summary>
  /// O(N) Runtime
  /// O(N) Space
  /// </summary>
  public class Solution
  {
    public int LongestValidParentheses(string s)
    {
      Stack<int> stack = new Stack<int>();
      int max = 0;
      stack.Push(-1);
      for (int i = 0; i < s.Length; i++)
      {
        if (s[i] == '(')
        {
          stack.Push(i);
        }
        else
        {
          stack.Pop();
          if (stack.Count == 0)
          {
            stack.Push(i);
          }
          else
          {
            max = Math.Max(max, i - stack.Peek());
          }
        }
      }

      return max;
    }

    /*
     * There are only three cases for a string:
        '(' are more than ')'
        '(' are less than ')'
        '(' and ')' are the same
        Now, when you scan from left to right, you can only find the correct maxLength for cases 2 and 3, because if it is case 1, where '(' are more than ')' (e.g., "((()"), then left is always greater than right and maxLength does not have the chance to be updated.

        Similarly, when you scan from right to left, you can only find the maxLength for cases 1 and 3.

        Therefore, a two-pass scan covers all the cases and is guaranteed to find the correct maxLength
     */

    public int LongestValidParentheses_(string s)
    {
      int l = 0;
      int r = 0;
      int max = 0;
      for (int i = 0; i < s.Length; i++)
      {
        if (s[i] == '(') l++;
        else r++;

        if (l == r) max = Math.Max(max, 2 * r);
        if (r > l)
        {
          l = 0; r = 0;
        }
      }

      l = 0; r = 0;
      for (int i = s.Length - 1; i >= 0; i--)
      {
        if (s[i] == '(') l++;
        else r++;

        if (l == r) max = Math.Max(max, 2 * l);
        if (l > r)
        {
          l = 0; r = 0;
        }
      }

      return max;
    }
  }
}
