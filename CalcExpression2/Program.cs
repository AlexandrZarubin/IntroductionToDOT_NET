using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExpression2
{
	internal class Program
	{
		static bool isOperators(char A)
		{
			return A == '+' || A=='-' || A=='*' || A=='/';
		}
		static void Main(string[] args)
		{
			//Console.Write("Введите простое арифметическое выражение: ");
			//string expression = Console.ReadLine();
			string expression = "-22+33-8*4+7/8+9-2+3*5+6*9*2";
			string SubExpresion="";
			int index = 0;
			bool flagOperand = true;
			if (expression[0]=='-')
			{ 
				index = 1;
				SubExpresion= expression.Substring(1);//создаем строку без первого элемента 
				expression = SubExpresion;
			}
			string[] numbers= expression.Split('+', '-', '*', '/');
			if (index == 1)
			{
				numbers[0] = "-"+numbers[0];
			}
			List<char> operators = new List<char>();
			bool flag = false;

			foreach (var item in expression)
			{
				if (isOperators(item))
				{
					operators.Add(item);// добавление в list
				}
			}
			double result = 0;
			while (operators.Count>0)
			{
				foreach (var item in operators)
				{
					if (item == '*' || item == '/') flagOperand = true;
				}
				if (flagOperand == true)
				{
					for (int i = 0; i < operators.Count; i++)
					{
						
						if (operators[i] == '*' || operators[i] == '/')
						{
							double leftOperand = double.Parse(numbers[i]);
							double rightOperand = double.Parse(numbers[i + 1]);
							// result = 0;
							if (operators[i] == '*')
							{
								result = leftOperand * rightOperand;
							}
							else if (operators[i] == '/')
							{
								result = leftOperand / rightOperand;
							}
							flag = true;
						}

						if (flag == true)
						{
							numbers[i] = result.ToString();
							List<string> list = new List<string>(numbers);
							list.Remove(numbers[i + 1]);//удаление элемента
							numbers = list.ToArray();//list в массив
							list = null;
							operators.RemoveAt(i);//удаление элемента
							flag = false;
							i--;
						}
						flagOperand = false;
						continue;
					}
				}
				else {
					for (int i = 0; i < operators.Count;)
					{
						if (operators[i] == '+' || operators[i] == '-')
						{
							double leftOperand = double.Parse(numbers[i]);
							double rightOperand = double.Parse(numbers[i + 1]);
							//result = 0;
							if (operators[i] == '+')
							{
								result = leftOperand + rightOperand;
							}
							else if (operators[i] == '-')
							{
								result = leftOperand - rightOperand;
							}
							flag = true;
							if (flag == true)
							{
								numbers[i] = result.ToString();
								List<string> list = new List<string>(numbers);
								list.Remove(numbers[i + 1]);
								numbers = list.ToArray();
								list = null;
								operators.RemoveAt(i);
								flag = false;

							}
						}
					}
				}
					Console.WriteLine(numbers[0]);
			}
		}
	}
}
