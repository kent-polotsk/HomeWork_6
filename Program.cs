using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6
{
    internal class Program
    {
        /// <summary>
        /// Метод добавления элемента в массив
        /// </summary>
        /// <param name="array">Входной массив</param>
        /// <param name="value">Добавляемое значение</param>
        /// <returns>Возвращает итоговый массив либо NULL</returns>
        private static string[] AddValueToArray(string[] array, string value)
        {
            if (array == null || value == null) return null;
            if (value == "" && array.Length == 0) 
            { 
                Console.WriteLine("В пустой массив нечего добавить"); 
                return array; 
            }
            for (int i = 0; i < array.Length; i++)
                if (array[i].ToUpper() == value.ToUpper()) 
                {
                    Console.WriteLine($"Элемент \"{value}\" уже присутствует в массиве под номером {i+1}") ;
                    return array; 
                }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i] == "")
                {
                    array[i] = value;
                    return array;
                }
            }
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
            return array;
        }


        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            bool correctEnter = false;
            string input, repeat;
            int arraySize = 0, columnCount = 0, rowCount = 0 ;
            string[] array;

            Console.WriteLine("Задание 1");
            do
            {
                while (!correctEnter)
                {
                    Console.WriteLine("Введите количество элементов массива (от 0 до 20): ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int result))
                    {
                        if (result >= 0 && result <= 20)
                        {
                            correctEnter = true;
                            arraySize = result;
                        }
                        else Console.WriteLine("Некорректный ввод");
                    }
                    else Console.WriteLine("Некорректный ввод");
                }

                correctEnter = false;
                array = new string[arraySize];
                string value = null;

                if (arraySize > 0)
                    Console.WriteLine($"Введите {arraySize} элементов массива подтверждая ввод нажатием Enter:");
                for (int i = 0; i < array.Length; i++)
                    array[i] = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Введите добавляемый элемент:");
                value = Console.ReadLine();
                if (value == null) Console.WriteLine("NULL");
                var array2 = AddValueToArray(array, value);
                if (array2 != null && value != null)
                    for (int j = 0; j < array2.Length; j++)
                        Console.Write($"{array2[j]} ");
                else Console.WriteLine("NULL");
                Console.WriteLine();
                Console.WriteLine("Нажмите ENTER для продолжения или введите \"y\" для повтора задания:");
                repeat = Console.ReadLine();

            } while (repeat == "y" || repeat == "Y");
            GC.Collect();

            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
           
            Console.WriteLine("Задание 2");
            do 
            {
                while (!correctEnter)
                {
                    Console.WriteLine("Введите количество строк двумерного массива (от 1 до 15): ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int result))
                    {
                        if (result > 0 && result <= 15)
                        {
                            correctEnter = true;
                            rowCount = result;
                        }
                        else Console.WriteLine("Некорректный ввод");
                    }
                    else Console.WriteLine("Некорректный ввод");
                }
                correctEnter = false;
                while (!correctEnter)
                {
                    Console.WriteLine("Введите количество столбцов двумерного массива (от 1 до 15): ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int result))
                    {
                        if (result > 0 && result <= 15)
                        {
                            correctEnter = true;
                            columnCount = result;
                        }
                        else Console.WriteLine("Некорректный ввод");
                    }
                    else Console.WriteLine("Некорректный ввод");
                }
                correctEnter = false;
                
                double [,] firstArray = new double[rowCount, columnCount];
                double[,] secondArray = new double[rowCount, columnCount];
                Random rnd = new Random();
                
                Console.WriteLine("Для заполнения массивов случайными числами нажмите ENTER\nДля ручного ввода введите \"y\":");
                input = Console.ReadLine();

                if (input == "y" || input == "Y")
                {
                    Console.WriteLine("Введите элементы первого массива (ввод построчно, элементы разделены пробелом):");   
                    for (int i = 0; i < rowCount; i++)
                    {
                        do
                        {
                            input = Console.ReadLine();
                            var temp = input.Split(' ');
                            for (int j = 0; j < columnCount; j++)
                                if (temp.Length >= columnCount && double.TryParse(temp[j], out double result))
                                {
                                    firstArray[i,j] = result; 
                                    correctEnter = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Некорректный ввод {i+1} строки, повторите");
                                    correctEnter = false;
                                    break;
                                }
                        } while (!correctEnter);
                    }
                    correctEnter = false;

                    Console.WriteLine("Введите элементы второго массива (ввод построчно, элементы разделены пробелом):");
                    for (int i = 0; i < rowCount; i++)
                    {
                        do
                        {
                            input = Console.ReadLine();
                            var temp = input.Split(' ');
                                for (int j = 0; j < columnCount; j++)
                                if (temp.Length >= columnCount && double.TryParse(temp[j], out double result))
                                {
                                    secondArray[i, j] = result;
                                    correctEnter = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Некорректный ввод {i+1} строки, повторите");
                                    correctEnter = false;
                                    break;
                                }
                        } while (!correctEnter); 
                     }
                }
                else
                     for (int i = 0; i < rowCount; i++)
                       for (int j = 0; j < columnCount; j++) 
                       {
                           firstArray[i,j] = rnd.Next(-100,100); 
                           secondArray[i,j] = rnd.Next(-100,100);
                       }

                Console.WriteLine("First array");
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                        Console.Write($"{firstArray[i, j]}\t");  
                    Console.WriteLine();
                }
                Console.WriteLine("Second array");
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                        Console.Write($"{secondArray[i,j]}\t");
                    Console.WriteLine();
                }
                Console.WriteLine("Result array");
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                        Console.Write($"{firstArray[i,j]+secondArray[i,j]}\t");
                    Console.WriteLine();
                }

                GC.Collect(0, GCCollectionMode.Forced);
                Console.WriteLine("Нажмите ENTER для завершения работы или введите \"y\" для повтора задания:");
                repeat = Console.ReadLine();
                
            } while (repeat == "y" || repeat == "Y");
        }
    }
}
