using System;

namespace Array7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 4, 6, 8, 10, 12 };
            int number = 19;
            bool checkValue = check(arr, number);
            Console.WriteLine("Hello World!");
            if (checkValue){
                Console.WriteLine("arraydeki reqemlerin her hasilarinsa cemi teyin etdiyiniz edede uygundur");
            }
            else
            {
                Console.WriteLine("Uygunsuzlug ERRRRRORR");
            }
            Console.ReadKey();
        }
        public static bool check(int[]array,int number)
        {
            //Merhele bir arrayda verilmis ededin tapilmasi
            int length = array.Length;
            foreach (var n in array)
            {
                if (n == number)
                {
                    return true;
                }
            }
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == number)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < array.Length-2; i++)
            {
                for (int j = i+1; j < array.Length-1; j++)
                {
                    for (int k = j+1; k < array.Length; k++)
                    {
                        if (array[i] + array[j] + array[k] == number)
                        {
                            return true;
                        }
                    }
                }
            }

            for (int l = 0; l < array.Length-3; l++)
            {
                for (int i = 0; i < array.Length - 2; i++)
                {
                    for (int j = i + 1; j < array.Length - 1; j++)
                    {
                        for (int k = j + 1; k < array.Length; k++)
                        {
                            if (array[l]+array[i] + array[j] + array[k] == number)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            for (int n = 0; n < length-1; n++)
            {

            }

            return false;
        }
        public static bool rec(int[]arr,int number, int  count)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            if (sum == number)
            {
                return true;
            }
            return false;

        }
        public static bool mainfunc(int[]array,int number)
        {
            bool check = false;
            int count = array.Length;
            for (int i = 0; i < array.Length-1; i++)
            {
                count++;
                check = rec(array, number, count);
            }
            return check;
        }
        public static bool metod(int[]array,int?[] indexArray,int?numberCount,int mainNumber)
        {
            //int[] arr = { 2, 4, 6, 8, 10, 12 };
            if (numberCount != null)
            {
                int?[] newArrayIndex = new int?[(int)numberCount];
                for (int i = 0; i < numberCount; i++)
                {
                    newArrayIndex[i] = i;
                }
                return metod(array, newArrayIndex, null, mainNumber);
                
            }
            else if(indexArray!=null)
            {
                int sum = 0;
                for (int i = 0; i < indexArray.Length; i++)
                {
                    sum += array[i];
                }
                if (sum == mainNumber)
                {
                    return true;
                }


            }
            return false;
        }
    }
}
