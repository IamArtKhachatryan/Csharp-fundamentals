namespace Task_1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string? input = Console.ReadLine();
            Console.WriteLine(
                checker(input)
                    ? "The string is correct"
                    : "The string is incorrect"
            );
        }

        private static bool checker(string? input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (input.Length % 2 == 1) return false;
            MyStack stack = new MyStack();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[') {
                    stack.Push(input[i]); continue;
                }
                if (stack.IsEmpty()) return false;
                switch (stack.Pop(), input[i])
                {
                    case ('(', ')'):
                    case ('{', '}'):
                    case ('[', ']'):
                        break;
                    default: return false;
                }
            }
            return stack.IsEmpty();
        }
    }
}
