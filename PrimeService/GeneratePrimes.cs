using System;

public class GeneratePrimes
{
  ///<summary>
  ///產生一個包含質數的陣列
  ///</summary>
  ///
  /// <param name="maxValue">產生的最大值</param>
  public static int[] GeneratePrimeNumbers(int maxValue)
  {
    if (maxValue >= 2) // 僅在此時有意義
    {
      // 宣告
      int s = maxValue + 1; // 陣列大小
      bool[] f = new bool[s];
      int i;

      // 將陣列元素初始化為true.
      for (i = 0; i < s; i++)
        f[i] = true;

      // 去掉已知的非質數
      f[0] = f[1] = false;

      // sieve(篩選；過濾)
      int j;
      for (i = 2; i < Math.Sqrt(s) + 1; i++)
      {
        if (f[i])
        {
          for (j = 2 * i; j < s; j += i)
            f[j] = false;
        }
      }

      // 有多少個質數?
      int count = 0;
      for (i = 0; i < s; i++)
      {
        if (f[i])
          count++;
      }

      int[] primes = new int[count];

      // 把質數轉移到結果陣列中
      for (i = 0, j = 0; i < s; i++)
      {
        if (f[i]) // 若為質數
          primes[j++] = i;
      }

      return primes; // 回傳primes結果陣列
    }
    else // maxValue < 2
      return new int[0]; // 若輸入不合理的值，則回傳空陣列
  }
}