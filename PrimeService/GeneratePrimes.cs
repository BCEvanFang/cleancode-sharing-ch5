using System;

public class PrimeGenerator
{
  private static bool[] isCrossed;
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
    for (i = 2; i < isCrossed.Length; i++)
    {
      if (NotCrossed(i))
        count++;
    }

    result = new int[count];

    // 把質數轉移到結果陣列中
    for (i = 2, j = 0; i < isCrossed.Length; i++)
    {
      if (NotCrossed(i)) // 質數
        result[j++] = i;
    }
  }

  private static void CrossOutMultiples()
  {
    int maxPrimeFactor = CalcMaxPrimeFactor();
    for (int i = 2; i < maxPrimeFactor + 1; i++)
    {
      if (NotCrossed(i)) // 如果未被劃掉，就劃掉其倍數
        CrossOutMultiplesOf(i);
    }
  }

  private static int CalcMaxPrimeFactor()
  {
    double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
    return (int)maxPrimeFactor;
  }

  private static void CrossOutMultiplesOf(int i)
  {
    for (int multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
    {
      isCrossed[multiple] = true;
    }
  }

  private static bool NotCrossed(int i)
  {
    return isCrossed[i] == false;
  }

  private static void InitializeArrayOfIntegers(int maxValue)
  {
    // 宣告
    isCrossed = new bool[maxValue + 1];
    for (int i = 2; i < isCrossed.Length; i++)
      isCrossed[i] = false;
  }
}