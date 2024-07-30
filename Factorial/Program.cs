//#define	Factorial1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if Factorial1
			Console.WriteLine("ВВедите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
			long f = 1;
			int i = 1;
			try
			{
				for (; i <= n; i++)
				{
					f *= i;
					Console.WriteLine($"{i}! = {f}");
				}
				Console.WriteLine($"Конечный результат: {--i}! = {f};");
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
				i--;
				Console.WriteLine($"Последний правильный результат: {i}! = {f};");
			} 
#endif
			Console.WriteLine("ВВедите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
			BigInteger f = 1;
			int i = 1;
			for (; i <= n; i++)
			{
				f *= i;
				//Console.WriteLine($"{i}! = {f}");
			}
			Console.WriteLine($"Последний правильный результат: {i}! = {f};");

		}
	}
}
