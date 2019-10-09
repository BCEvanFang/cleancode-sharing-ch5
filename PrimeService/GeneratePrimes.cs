using System;

public class PrimeGenerator
{
  private static bool[] crossedOut;
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
      UncrossIntegerUpTo(maxValue);
      CrossOutMultiples();
      PutUncrossedIntegersIntoResult();
      return result;
    }
  }

  private static void PutUncrossedIntegersIntoResult()
  {
    result = new int[NumberOfUncrossedIntegers()];

    // 把質數轉移到結果陣列中
    for (int i = 2, j = 0; i < crossedOut.Length; i++)
    {
      if (NotCrossed(i)) // 質數
        result[j++] = i;
    }
  }

  private static int NumberOfUncrossedIntegers()
  {
    int count = 0;
    for (int i = 2; i < crossedOut.Length; i++)
    {
      if (NotCrossed(i))
        count++;
    }
    return count;
  }

  private static void CrossOutMultiples()
  {
    int maxPrimeFactor = DetermineIterationLimit();
    for (int i = 2; i < maxPrimeFactor + 1; i++)
    {
      if (NotCrossed(i)) // 如果未被劃掉，就劃掉其倍數
        CrossOutMultiplesOf(i);
    }
  }

  private static int DetermineIterationLimit()
  {
    double iterationLimit = Math.Sqrt(crossedOut.Length);
    return (int)iterationLimit;
  }

  private static void CrossOutMultiplesOf(int i)
  {
    for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
    {
      crossedOut[multiple] = true;
    }
  }

  private static bool NotCrossed(int i)
  {
    return crossedOut[i] == false;
  }

  private static void UncrossIntegerUpTo(int maxValue)
  {
    // 宣告
    crossedOut = new bool[maxValue + 1];
    for (int i = 2; i < crossedOut.Length; i++)
      crossedOut[i] = false;
  }
}