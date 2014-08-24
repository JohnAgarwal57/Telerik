namespace Stack
{
    using System;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            Print(stack);

            stack.Pop();        
            Print(stack);
            
            stack.Push(15);
            stack.Push(25);
            stack.Push(45);
            Print(stack);

            stack.Pop();
            stack.Pop();
            Print(stack);
        }

        private static void Print(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Peek : {0}", stack.Peek());
        }
    }
}
