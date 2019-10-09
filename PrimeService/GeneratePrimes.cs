using System;

public class PrimeGenerator
{
  private static bool[] f;
  private static int[] result;

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
      InitializeArrayOfIntegers(maxValue);
      CrossOutMultiples();
      PutUncrossedIntegersIntoResult();
      return result;
    }
  }

  private static void PutUncrossedIntegersIntoResult()
  {
    int i;
    int j;

    // 有多少個質數?
    int count = 0;
    for (i = 0; i < f.Length; i++)
    {
      if (f[i])
        count++;
    }

    result = new int[count];

    // 把質數轉移到結果陣列中
    for (i = 0, j = 0; i < f.Length; i++)
    {
      if (f[i]) // 質數
        result[j++] = i;
    }
  }

  private static void CrossOutMultiples()
  {
    int i;
    int j;

    for (i = 2; i < Math.Sqrt(f.Length); i++)
    {
      if (f[i]) // 如果未被劃掉，就劃掉其倍數
      {
        for (j = 2 * i; j < f.Length; j += i)
          f[j] = false; // 倍數不是質數
      }
    }
  }

  private static void InitializeArrayOfIntegers(int maxValue)
  {
    // 宣告
    f = new bool[maxValue + 1];
    f[0] = f[1] = false; // 非質數，也非倍數

    // 將陣列元素初始化為true.
    for (int i = 2; i < f.Length; i++)
      f[i] = true;
  }
}