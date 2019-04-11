using System;

namespace _20_Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsValid(string s)
        {
            bool ans = false;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i + 1] == GetNextChar(s[i]))
                    ans = true;
                else if (GetNextChar(s[i]) != '\0')
                {
                    Push(s[i + 1]);
                    ans = false;
                }
            }
            return ans;
        }

        public char GetNextChar(char cc)
        {
            char c = '\0';
            switch (cc)
            {
                case '(':
                    c = ')';
                    break;
                case '[':
                    c = ']';
                    break;
                case '{':
                    c = '}';
                    break;
            }
            return c;
        }
        char[] stack = new char[100];
        int top = 0;
        public void Push(char c)
        {
            stack[top] = c;
            top++;
        }
        public char Pop()
        {
            if (top > 0)
                return stack[top--];
            return null;
        }
    }
}
