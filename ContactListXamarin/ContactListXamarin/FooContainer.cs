namespace ContactListXamarin
{
    public struct FooContainer 
    {
        private readonly int _x;
        private readonly int _y;

        public FooContainer (int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int Sum 
        {
            get { return _x + _y; }
        }
    }
}