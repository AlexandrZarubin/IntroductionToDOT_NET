using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExpression
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string expression;
			string[] numbers;
			do
			{
				Console.Write("Введите простое арифметическое выражение: ");
				expression = Console.ReadLine();
				expression = expression.Replace(',', '.');

				try
				{
					numbers = expression.Split('+', '-', '*', '/');
					if (numbers.Length != 2)
					{
						Console.WriteLine("Вы допустили ошибку, попробуйте еще раз.");
						continue;
					}

					double a = Convert.ToDouble(numbers[0]);
					double b = Convert.ToDouble(numbers[1]);
					Console.WriteLine(a + "\t" + b);

					switch (expression[expression.IndexOfAny(new char[] { '+', '-', '*', '/' })])
					{
						case '+': Console.WriteLine($"{a} + {b} = {a + b}"); break;
						case '-': Console.WriteLine($"{a} - {b} = {a - b}"); break;
						case '*': Console.WriteLine($"{a} * {b} = {a * b}"); break;
						case '/':
							if (b == 0)
							{
								Console.WriteLine("Деление на ноль невозможно.");
							}
							else
							{
								Console.WriteLine($"{a} / {b} = {a / b}");
							}
							break;
						default:
							Console.WriteLine("Вы допустили ошибку, попробуйте еще раз.");
							break;
					}
				}
				catch (FormatException)
				{
					//если неможет преобразовать строку в число
					Console.WriteLine("Неправильный формат чисел. Попробуйте еще раз.");
					numbers = new string[0]; // сброс массива для повторения цикла
				}
				catch (Exception ex)
				{
					//Все остальные исключения
					Console.WriteLine($"Произошла ошибка: {ex.Message}. Попробуйте еще раз.");
					numbers = new string[0]; // сброс массива для повторения цикла
				}
			} while (numbers.Length != 2);
		}
	}
}
