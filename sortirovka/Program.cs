using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sortirovka
{
    class Program
    {
        private const int arrayLenght = 10;
        private static Regex rg = new Regex("[ -0123456789]");
        public static bool isNumericString(string strToCheck)
        {
            return rg.IsMatch(strToCheck);
        }
        static void Main(string[] args)
        {

            string input = string.Empty;
            Console.WriteLine("Введите " + arrayLenght + " натуральных целых чисел через пробел");
            do
            {
                //input = Console.Read();           //считываем ввод пользователя
                char symb = (char)Console.Read();

            }
            while ();
            string[] numbers = input.Split(' ');        //создали массив стрингов и записили в массив значения введёные пользователем
            int[] sequence = new int[arrayLenght];

            for (int i = 0; i < numbers.Length; i++)
            {
                sequence[i] = int.Parse(numbers[i]);    //перевод массива стрингов в массив интов
            }

            for (int j = 0; j < (sequence.Length - 1); j++)             //прогон проверки для каждого элемента массива
            {

                for (int i = 0; i < (sequence.Length - 1); i++)         //цикл для перевода максимального значения в конец массива
                {
                    if (sequence[i] > sequence[i + 1])
                    {
                        ThirdGlass(sequence, i);
                    }
                    for (int k = 0; k < (sequence.Length - 1); k++)      //цикл для перевода чётного значения в конец массива
                    {
                        if (sequence[k] % 2 != 0 && sequence[k + 1] % 2 == 0)
                        {
                            ThirdGlass(sequence, k);
                        }
                    }

                }
            }
            for (int i = 0; i < sequence.Length; i++)               //вывод результата
            {
                Console.Write(sequence[i] + " ");
            }

            Console.Read();
        }

        private static void ThirdGlass(int[] array, int i)
        {
            int temp = array[i];                         //объявляется и используется "третий стакан" для записи значений
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }

    }
}

