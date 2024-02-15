interface ICalculator
{
    double Add(double a, double b);
}

class SimpleCalculator : ICalculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Привет! Это мини-калькулятор.");
        ICalculator calculator = new SimpleCalculator();

        double num1 = 0, num2 = 0;
        bool isValidInput = false;

        do
        {
            try
            {
                Console.Write("Введите первое число: ");
                string input1 = Console.ReadLine();

                if (!double.TryParse(input1, out num1))
                    throw new FormatException();

                Console.Write("Введите второе число: ");
                string input2 = Console.ReadLine();

                if (!double.TryParse(input2, out num2))
                    throw new FormatException();

                isValidInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите число.");
            }
            finally
            {
                Console.WriteLine("Для продолжения введите числа снова.");
            }
        } while (!isValidInput);

        double sum = calculator.Add(num1, num2);
        Console.WriteLine($"Сумма чисел {num1} и {num2} равна {sum}.");
    }
}