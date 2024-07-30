using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string expression;
			string[] numbers;
			do
			{
				Console.WriteLine("Введите простое арифметическое выражение: ");
				expression = Console.ReadLine();
				//Console.WriteLine(expression);
				expression = expression.Replace('.', ',');//Метод Replace() заменяет один символ другим, и возвращает измененную строку,
				numbers = expression.Split('+', '-', '*', '/');//Метод .Split(...) разделяет строку по указанным разделителям
															   // этот метод не изменяет исходную строку, а возвращает изменения строку в виде массива строк
				if(numbers.Length!=2) Console.WriteLine("Вы допустили ошибку, попробуйте еще раз");

            } while (numbers.Length!=2);
													  //исходная строка при этом остается неизменной.
			double a = Convert.ToDouble(numbers[0]);
			double b = Convert.ToDouble(numbers[1]);
            Console.WriteLine(a+"\t"+b);
			switch (expression[expression.IndexOfAny(new char[]{'+', '-', '*', '/' })])
			{
				case '+':Console.WriteLine($"{a} + {b} = {a + b}");break;
				case '-':Console.WriteLine($"{a} - {b} = {a - b}");break;
				case '*':Console.WriteLine($"{a} * {b} = {a * b}");break;
				case '/':Console.WriteLine($"{a} / {b} = {a / b}");break;
			}
        }
	}
}
