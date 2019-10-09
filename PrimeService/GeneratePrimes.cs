﻿using System;

public class PrimeGenerator
{
  private static int s;
  private static bool[] f;
  private static int[] primes;

  ///<summary>
  ///產生一個包含質數的陣列
  ///</summary>
  ///
  /// <param name="maxValue">產生的最大值</param>
  public static int[] GeneratePrimeNumbers(int maxValue)
  {
    if (maxValue < 2)
    {
      return new int[0];
    }
    else
    {
      InitializeSieve(maxValue);
      Sieve();
      LoadPrimes();
      return primes;
    }
  }

  private static void LoadPrimes()
  {
    int i;
    int j;

    // 有多少個質數?
    int count = 0;
    for (i = 0; i < s; i++)
    {
      if (f[i])
        count++;
    }

    primes = new int[count];

    // 把質數轉移到結果陣列中
    for (i = 0, j = 0; i < s; i++)
    {
      if (f[i]) // 質數
        primes[j++] = i;
    }
  }

  private static void Sieve()
  {
    int i;
    int j;

    for (i = 2; i < Math.Sqrt(s) + 1; i++)
    {
      if (f[i]) // 如果未被劃掉，就劃掉其倍數
      {
        for (j = 2 * i; j < s; j += i)
          f[j] = false; // 倍數不是質數
      }
    }
  }

  private static void InitializeSieve(int maxValue)
  {
    // 宣告
    s = maxValue + 1; // 陣列大小
    f = new bool[s];
    int i;

    // 將陣列元素初始化為true.
    for (i = 0; i < s; i++)
      f[i] = true;

    // 去掉已知的非質數
    f[0] = f[1] = false;
  }
}