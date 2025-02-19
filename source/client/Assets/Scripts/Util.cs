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
            // ����һ�� 0 �� i ֮����������
            int j = Random.Range(0, i + 1);

            // ����Ԫ��
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
