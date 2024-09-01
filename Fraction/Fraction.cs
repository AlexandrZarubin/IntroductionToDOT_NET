using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		public int Integer { get; set; }
		public int Numeration { get; set; }
		int denominator;
		public int Denominator
		{
			get => denominator;
			set
			{
				if (value == 0) value = 1;
				denominator = value;
			}
		}
		public Fraction()
		{
			denominator = 1;
			Console.WriteLine($"DefConsructor: {this.GetHashCode()}");
		}
		public Fraction(int integer)
		{
			Integer = integer;
			Denominator = 1;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(int numerator, int denominator)
		{
			Numeration = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numeration = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(Fraction other)
		{

			this.Integer = other.Integer;
			this.Numeration = other.Numeration;
			this.Denominator = other.Denominator;
		}
		public Fraction(double value)
		{
			value += 1e-10;
			Integer = (int)value;
			denominator = (int)1e+9;
			value -= Integer;
			Numeration = (int)(value * denominator);
			reduce();
		}
		~Fraction() { Console.WriteLine($"Destructor: {this.GetHashCode()}"); }
		//				Arithmetical operators:
		public static Fraction operator *(Fraction left, Fraction right)
		{
			/*Fraction left_copy = new Fraction(left);
			Fraction right_copy = new Fraction(right);
			left_copy.ToImproper();
			right_copy.ToImproper();*/
			//Fraction left_copy = left.ToImproper();
			//Fraction right_copy = right.ToImproper();
			//Fraction result = new Fraction
			//	(
			//		left_copy.Numerator * right_copy.Numerator,
			//		left_copy.Denominator * right_copy.Denominator
			//	);
			//return result.ToProper();
			/*return new Fraction
				(
					left_copy.Numerator * right_copy.Numerator,
					left_copy.Denominator * right_copy.Denominator
				);*/
			return new Fraction
			(
				left.ToImProper().Numeration * right.ToImProper().Numeration,
				left.ToImProper().Denominator * right.ToImProper().Denominator
			);
		}
		static public Fraction operator/(Fraction left,Fraction right)
		{
			return left * right.Inverted();
		}
		// Перегрузка оператора +
		public static Fraction operator +(Fraction left, Fraction right)
		{
			return new Fraction
			(
				left.ToImProper().Numeration * right.Denominator + right.ToImProper().Numeration * left.Denominator,
				left.Denominator * right.Denominator
			).ToProper();
		}
		// Перегрузка оператора -
		public static Fraction operator -(Fraction left, Fraction right)
		{
			return new Fraction
			(
				left.ToImProper().Numeration * right.Denominator - right.ToImProper().Numeration * left.Denominator,
				left.Denominator * right.Denominator
			).ToProper();
		}
		public static bool operator ==(Fraction left, Fraction right)
		{
			return left.ToImProper().Numeration * right.ToImProper().Denominator == right.ToImProper().Numeration * left.ToImProper().Denominator;

		}
		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		// Перегрузка оператора <
		public static bool operator <(Fraction left, Fraction right)
		{
			return left.ToImProper().Numeration * right.Denominator < right.ToImProper().Numeration * left.Denominator;
		}
		// Перегрузка оператора >
		public static bool operator >(Fraction left, Fraction right)
		{
			return left.ToImProper().Numeration * right.Denominator > right.ToImProper().Numeration * left.Denominator;
		}
		// Перегрузка оператора <=
		public static bool operator <=(Fraction left, Fraction right)
		{
			return !(left > right);
		}
		// Перегрузка оператора >=
		public static bool operator >=(Fraction left, Fraction right)
		{
			return !(left < right);
		}

		// Префиксный инкремент
		public static Fraction operator ++(Fraction fraction)
		{
			fraction.Integer++;
			return fraction;
		}
		//// Постфиксный инкремент
		//public static Fraction operator ++(Fraction fraction, int unused)
		//{

		//	Fraction temp = new Fraction(fraction);  // Сохраняем текущее состояние
		//	fraction.Integer++;
		//	return temp;  // Возвращаем старое значение
		//}

		// Префиксный декремент
		public static Fraction operator --(Fraction fraction)
		{
			fraction.Integer--;
			return fraction;
		}
		//// Постфиксный декремент
		//public static Fraction operator --(Fraction fraction, int unused)
		//{
		//	Fraction temp = new Fraction(fraction);  // Сохраняем текущее состояние
		//	fraction.Integer--;
		//	return temp;  // Возвращаем старое значение
		//}

		public Fraction ToProper()
		{
			//int rest = Numeration / Denominator;
			//Integer += rest;
			//Numeration %= Denominator;
			//return this;

			/*Fraction proper = new Fraction();
			proper.Integer += Numeration / Denominator;
			proper.Numeration = Numeration % Denominator;
			proper.Denominator = Denominator;
			return proper;*/
			return new Fraction(
				Integer += Numeration / Denominator,
				Numeration = Numeration % Denominator,
				Denominator = Denominator);
		}
		public Fraction ToImProper()
		{
			//Numeration += Integer * Denominator;
			//Integer = 0;
			//return this;
			return new Fraction(Numeration + Integer * Denominator, Denominator);
		}
		public Fraction Inverted()
		{
			// Fraction inverted = new Fraction(this);
			//inverted.ToImproper();
			Fraction inverted = ToImProper();
			//(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			//https://stackoverflow.com/questions/804706/swap-two-variables-without-using-a-temporary-variable
			int buffer = inverted.Numeration;
			inverted.Numeration = inverted.Denominator;
			inverted.Denominator = buffer;
			return inverted;
		}
		public void Print()
		{
			if(Integer!=0) Console.Write(Integer);
			if(Numeration!=0)
			{
				if(Integer!=0) Console.Write("(");
                Console.Write($"{Numeration}/{denominator}");
				if(Integer!=0) Console.WriteLine(")");
            }
			else if(Integer==0) Console.Write(0);
            Console.WriteLine();
        }
		Fraction reduce()
		{
			//https://www.webmath.ru/poleznoe/formules_12_7.php
			int more, less, rest;
			if (Numeration > denominator) { more = Numeration; less = denominator; }
			else { less = Numeration; more = denominator; }
			do
			{
				rest = more % less;
				more = less;
				less = rest;
			} while (rest!=0);
			int GCD = more; //Greatest Common Divisor
			Numeration /= GCD;
			denominator /= GCD;
			return this;
		}
	}
}
