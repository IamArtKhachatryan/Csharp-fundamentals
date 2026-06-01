namespace Task_2
{
    internal class MyStack
    {
        private (int,int)[] _coordinats;
        private int _count;

        public MyStack(int capacity = 0)
        {
            if (capacity < 0) throw new ArgumentException("Capacity cannot be negative");
            _coordinats = new (int,int)[capacity];
            _count = 0;
        }

        public void Push((int x, int y) coord)
        {
            if (_count >= _coordinats.Length) Resize();
            _coordinats[_count++] = coord;
        }

        private void Resize()
        {
            (int,int)[] _temp = new (int,int)[(_coordinats.Length == 0) ? 4 : 2 * _coordinats.Length];
            for (int i = 0; i < _coordinats.Length; i++)
                _temp[i] = _coordinats[i];
            _coordinats = _temp;        
        }
        public void Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Cannot pop: stack is empty");
                _count--;
        }

        public (int,int) Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return _coordinats[_count - 1];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}
