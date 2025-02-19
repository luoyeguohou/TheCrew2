using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static void Shuffle<T>(T[] array,int seed)
    {
        Random.InitState(seed);
        for (int i = array.Length - 1; i > 0; i--)
        {
            // 生成一个 0 到 i 之间的随机索引
            int j = Random.Range(0, i + 1);

            // 交换元素
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
