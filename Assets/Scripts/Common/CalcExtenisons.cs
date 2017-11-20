using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Common
{
    public class CalcExtenisons
    {

        public static int[] GenerateCode()
        {
            var code = new int[6];
            for (int i = 0; i < 6; i++)
            {
                code[i] = Random.Range(0, 10);
            }

            return code;
        }

        public static void LogArray<T>(IEnumerable<T> array)
        {
            Debug.Log("Array = " + String.Join("",
                          new List<T>(array)
                              .ConvertAll(i => i.ToString())
                              .ToArray()));
        }
    }
}
