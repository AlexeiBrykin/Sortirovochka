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
        private static Regex rg = new Regex("^[0-9 -]+$");

        public static bool IsTenNumbers(string strToCheck)
        {
            string[] result = strToCheck.Split(' ');

            if (result.Length != 10)
            {
                Console.WriteLine("Введено " + result.Length + " чисел");
                return false;
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (!int.TryParse(result[i], out int a))
                {
                    Console.WriteLine("Строка " + result[i] + " не является числом");
                    return false;
                }
            }

            return true;
        }

        public static bool IsNumericString(string strToCheck)
        {
            return rg.IsMatch(strToCheck);
        }

        static void Main(string[] args)
        {
            string input = string.Empty;
            bool check = false;
            Console.WriteLine("Введите " + arrayLenght + " натуральных целых чисел через пробел");
            do
            {
                input = Console.ReadLine();             //считываем ввод пользователя

                if (!IsNumericString(input))
                {
                    Console.WriteLine("Используйте только цифры, знак минуса и пробелы");
                    continue;
                }

                if (IsTenNumbers(input))
                {
                    check = true;
                }
            }
            while (!check);
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

