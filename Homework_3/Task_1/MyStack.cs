namespace Task_1
{
    internal class MyStack
    {
        private char[] _chars;
        private int _count;

        public MyStack(int capacity = 0)
        {
            if (capacity < 0) throw new ArgumentException("Capacity cannot be negative");
            _chars = new char[capacity];
            _count = 0;
        }

        public void Push(char ch)
        {
            if (_count >= _chars.Length) Resize();
            _chars[_count++] = ch;
        }

        private void Resize()
        {
            char[] _temp = new char[(_chars.Length == 0) ? 4 : 2 * _chars.Length];
            for (int i = 0; i < _chars.Length; i++)
                _temp[i] = _chars[i];
            _chars = _temp;        
        }
        public void Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Cannot pop: stack is empty");
                _count--;
        }

        public char Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return _chars[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}
