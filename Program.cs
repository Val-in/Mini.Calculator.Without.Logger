namespace Mini.Calculator.Without.Logger
{
    public class Program
    {
        interface ISum
        {
            decimal Sum(decimal a, decimal b);
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the first number:");
                decimal a = EnterNumber();

                Console.WriteLine("Enter the second number:");
                decimal b = EnterNumber();

                ISum calculator = new SumTwoNumbers();
                decimal result = calculator.Sum(a, b);

                Console.WriteLine($"The sum is: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Calculation finished.");
            }
        }

        public static decimal EnterNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Enter a valid number!");
                }
            }
        }

        public class SumTwoNumbers : ISum
        {
            public decimal Sum(decimal a, decimal b)
            {
                return a + b;
            }
        }
    }
}
