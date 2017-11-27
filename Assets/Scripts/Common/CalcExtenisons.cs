using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Common
{
    public class CalcExtenisons
    {

        public static int[] GenerateCode()
        {
            var code = new int[6] { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < 6; i++)
            {
                var rValue = Random.Range(0, 10);
                while (code.Contains(rValue))
                {
                    rValue = Random.Range(0, 10);
                }
                code[i] = rValue;
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

        public static bool IsEqualForOneLevel(int number1, int number2)
        {
            if (number1 == number2 + 1 || number1 == number2 - 1)
                return true;

            if (number1 == 0 && number2 == 9)
                return true;

            if (number1 == 9 && number2 == 0)
                return true;

            return false;
        }

        public static string FloatToTime(float toConvert, string format)
        {
            switch (format)
            {
                case "00.0":
                    return string.Format("{0:00}:{1:0}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds
                    break;
                case "#0.0":
                    return string.Format("{0:#0}:{1:0}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds
                    break;
                case "00.00":
                    return string.Format("{0:00}:{1:00}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds
                    break;
                case "00.000":
                    return string.Format("{0:00}:{1:000}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                    break;
                case "#00.000":
                    return string.Format("{0:#00}:{1:000}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                    break;
                case "#0:00":
                    return string.Format("{0:#0}:{1:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60);//seconds
                    break;
                case "#00:00":
                    return string.Format("{0:#00}:{1:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60);//seconds
                    break;
                case "0:00.0":
                    return string.Format("{0:0}:{1:00}.{2:0}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds
                    break;
                case "#0:00.0":
                    return string.Format("{0:#0}:{1:00}.{2:0}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds
                    break;
                case "0:00.00":
                    return string.Format("{0:0}:{1:00}.{2:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds
                    break;
                case "#0:00.00":
                    return string.Format("{0:#0}:{1:00}.{2:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds
                    break;
                case "0:00.000":
                    return string.Format("{0:0}:{1:00}.{2:000}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                    break;
                case "#0:00.000":
                    return string.Format("{0:#0}:{1:00}.{2:000}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                    break;
            }
            return "error";
        }
    }
}
