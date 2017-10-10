using System;

namespace LineBreak
{
    public class LineBreaker
    {
        public string Text { get; private set; }
        public LineBreaker(string text)
        {
            Text = text;
        }

        public void Break(int columns)
        {
            if(columns < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columns));
            }

            if(columns == 0)
            {
                return;
            }
        }
    }
}