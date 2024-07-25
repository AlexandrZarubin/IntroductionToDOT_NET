//#define CONSOLE_PARAMETERS
//#define INPUT_DATA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOT_NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Introduction to .NET";
#if CONSOLE_PARAMETERS
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			//Console.CursorLeft = 22;
			//Console.CursorTop = 11;
			Console.SetCursorPosition(22, 11);
			Console.Write("Hello .NET\n");//выводит строку на экран
			Console.WriteLine("Introduction");//выводит строку на экран, и перерводит курсор в начало следующий строки
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ResetColor();
			Console.Beep(37, 5000);//бассы  
#endif
#if INPUT_DATA
			Console.WriteLine("Введите Ваше имя: ");
			string first_name = Console.ReadLine();
			Console.WriteLine("Введите вашу фамилию: ");
			string second_name = Console.ReadLine();
			int age = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Ваше имя: " + first_name + " выша фамилия: " + second_name + " Ваш возраст: " + age);//Конкатенация строк
			Console.WriteLine(string.Format("Ваша имя: {0},Ваша фамилия: {1}, Ваш возраст: {2}", first_name, second_name, age));//Форматирование строк
			Console.WriteLine($"ваше имя: {first_name},Ваша фамилия: {second_name}, ваш возраст: {age}"); //интерполяция строк  
#endif


		}
	}
}
