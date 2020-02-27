﻿using System;

namespace Array7
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Salam bu tedbiqde reqem toplusu daxil edirsiz ve bir denede tek reqe tedbiq size daxil etdiyiniz topluda her hansi ededin " +
                "verdiyiniz tek edede uygunun olub olmadigini ve topluda her hansi ededlerin ceminin verdiyiniz reqeme uygun olub olmadigi tapacaq.");
            mainm();
        }


        #region Bad Way
        //public static bool check(int[]array,int number)
        //{
        //    //Merhele bir arrayda verilmis ededin tapilmasi
        //    int length = array.Length;
        //    foreach (var n in array)
        //    {
        //        if (n == number)
        //        {
        //            return true;
        //        }
        //    }
        //    for (int i = 0; i < array.Length-1; i++)
        //    {
        //        for (int j = i+1; j < array.Length; j++)
        //        {
        //            if (array[i] + array[j] == number)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    for (int i = 0; i < array.Length-2; i++)
        //    {
        //        for (int j = i+1; j < array.Length-1; j++)
        //        {
        //            for (int k = j+1; k < array.Length; k++)
        //            {
        //                if (array[i] + array[j] + array[k] == number)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }

        //    for (int l = 0; l < array.Length-3; l++)
        //    {
        //        for (int i = 0; i < array.Length - 2; i++)
        //        {
        //            for (int j = i + 1; j < array.Length - 1; j++)
        //            {
        //                for (int k = j + 1; k < array.Length; k++)
        //                {
        //                    if (array[l]+array[i] + array[j] + array[k] == number)
        //                    {
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    for (int n = 0; n < length-1; n++)
        //    {

        //    }

        //    return false;
        //}
        //public static bool rec(int[]arr,int number, int  count)
        //{
        //    int sum = 0;
        //    foreach (var item in arr)
        //    {
        //        sum += item;
        //    }
        //    if (sum == number)
        //    {
        //        return true;
        //    }
        //    return false;

        //}
        #endregion
        public static void mainm()
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Reqem toplusu daxil edin mes:12,13,15,62,88,99,100");

                string arrayString = Console.ReadLine();
                int arraySize = 0;
                try
                {
                    arraySize = arrayString.Split(",").Length;
                }
                catch
                {
                    Console.WriteLine("Zehmet olmasa duzgun sekilde reqem toplusunu daxil edin mes:5,8,7");
                    mainm();
                }
                int[] array = new int[arraySize];
                try
                {

                    int count = 0;
                    foreach (var item in arrayString.Split(","))
                    {
                        array[count] = int.Parse(item);
                        count++;
                    }
                }
                catch
                {
                    Console.WriteLine("Zehmet olmasa duzgun reqem toplusu daxil edin");
                    mainm();
                }
                int singleInt = 0;
                Console.WriteLine("Zehmet olmasa istediyin bir reqem daxilo edin.");
                string singleStr = Console.ReadLine();
                try
                {
                    singleInt = int.Parse(singleStr);
                }
                catch
                {
                    Console.WriteLine("Duzgun eded daxil etmediniz");
                    mainm();
                }
                Console.WriteLine(singleInt);
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }
                bool checkValue = forCount(array, singleInt);
                if (checkValue)
                {
                    Console.WriteLine("arraydeki reqemlerin her hasilarinsa cemi teyin etdiyiniz edede uygundur");
                }
                else
                {
                    Console.WriteLine("Daxil etdiyiniz arrayde sizin edede uygun eded ve arrayinizin her hansi ededlerinin cemi verdiyiniz eded edecek cem tapilmadi");
                }
                Console.WriteLine("---------------------------------------------------------------");

            }
        }

        public static bool forCount(int[] array, int number)
        {
            foreach (var n in array)
            {
                if (n == number)
                {
                    return true;
                }
            }
            if (array.Length == 1)
            {
                return false;
            }
            int topSum = 0;
            foreach (var n in array)
            {
                topSum += n;
            }
            if (topSum == number)
            {
                return true;
            }
            if (array.Length == 2)
            {
                return false;
            }
            bool check = false;
            for (int i = 2; i < array.Length; i++)
            {
                check = metod(array, null, i, number, null);
                if (check == true)
                {
                    return true;
                }
            }
            return check;
        }
        public static bool metod(int[] array, int?[] indexArray, int? numberCount, int mainNumber, int? indexArrayNumber)
        {

            if (numberCount != null)
            {
                int?[] newArrayIndex = new int?[(int)numberCount];
                for (int i = 0; i < numberCount; i++)
                {
                    newArrayIndex[i] = i;
                }
                return metod(array, newArrayIndex, null, mainNumber, newArrayIndex.Length - 1);
            }
            else
            {

                for (int i = (int)indexArrayNumber; i <= indexArrayNumber + array.Length - indexArray.Length; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < indexArray.Length; j++)
                    {
                        sum += array[(int)indexArray[j]];
                    }
                    if (sum == mainNumber)
                    {
                        return true;
                    }
                    if (i < indexArrayNumber + array.Length - indexArray.Length)
                    {
                        indexArray[(int)indexArrayNumber] = i + 1;
                    }
                }
                if (indexArrayNumber == 0)
                {
                    return false;
                }
                indexArrayNumber--;
                return metod(array, indexArray, null, mainNumber, indexArrayNumber);
            }

        }
    }
}
