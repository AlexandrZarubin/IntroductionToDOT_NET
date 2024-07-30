//#define CONSOLE_PARAMETERS
//#define INPUT_DATA
//#define DATA_TYPES
#define LITERALS
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOT_NET
{
	internal class Program
	{
		static readonly string delimiter = "\n---------------------------------------------------------------------------\n";
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
#if DATA_TYPES
			string msg = "{0,-8} |{1,-15}| {2}\t| {3,-40}";
			string delimiter1 = new string('-', 90);

			Console.WriteLine(msg, "Тип",".Net", "Размер (в байтах)", "Диапазон значений");
			Console.WriteLine(delimiter1);
			//Console.WriteLine(delimiter);
			Console.WriteLine(string.Format(msg, "byte",typeof(byte), sizeof(byte), $"{byte.MinValue} до {byte.MaxValue}"));
			Console.WriteLine(string.Format(msg, "sbyte", typeof(sbyte), sizeof(sbyte), $"{sbyte.MinValue} до {sbyte.MaxValue}"));
			Console.WriteLine(string.Format(msg, "short", typeof(short), sizeof(short), $"{short.MinValue} до {short.MaxValue}"));
			Console.WriteLine(string.Format(msg, "ushort", typeof(ushort), sizeof(ushort), $"{ushort.MinValue} до {ushort.MaxValue}"));
			Console.WriteLine(string.Format(msg, "int", typeof(int), sizeof(int), $"{int.MinValue} до {int.MaxValue}"));
			Console.WriteLine(string.Format(msg, "uint", typeof(uint), sizeof(uint), $"{uint.MinValue} до {uint.MaxValue}"));
			Console.WriteLine(string.Format(msg, "long", typeof(long), sizeof(long), $"{long.MinValue} до {long.MaxValue}"));
			Console.WriteLine(string.Format(msg, "ulong", typeof(ulong), sizeof(ulong), $"{ulong.MinValue} до {ulong.MaxValue}"));
			Console.WriteLine(delimiter1);
			Console.WriteLine(string.Format(msg, "float", typeof(float), sizeof(float), $"{float.MinValue} до {float.MaxValue}"));
			Console.WriteLine(string.Format(msg, "double", typeof(double), sizeof(double), $"{double.MinValue} до {double.MaxValue}"));
			Console.WriteLine(string.Format(msg, "decimal", typeof(decimal), sizeof(decimal), $"{decimal.MinValue} до {decimal.MaxValue}"));
			Console.WriteLine(delimiter1);
			Console.WriteLine(string.Format(msg, "char", typeof(char), sizeof(char), $"{(int)char.MinValue} до {(int)char.MaxValue}"));
			Console.WriteLine(delimiter1);
			Console.WriteLine(string.Format(msg, "bool", typeof(bool), sizeof(bool), $"{bool.FalseString} или {bool.TrueString}"));

			/*
			 * float	4byte	0,(38)	точность 7
			 * double	8byte	0,(308)	точность 15
			 * decimal	16byte	0,(28)	точность 728
			 */
#endif

#if LITERALS
            Console.WriteLine(((object)5).GetType());
            Console.WriteLine("+".GetType());
#endif

        }

	}

}
