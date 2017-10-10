using System;
using System.Text;

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

            int breakCounter = 0, i = 0;
            StringBuilder builder = new StringBuilder();
            char[] chars = Text.ToCharArray();
            while(i < Text.Length)
            {
                if(breakCounter == columns)
                {
                    while(i < Text.Length && (chars[i] != ' ' &&
                                            chars[i] != '\n'))
                    {
                        // move to the next "whitespace" to break on.
                        builder.Append(chars[i]);
                        i++;
                    }
                    // add the break only if we know 
                    // we are not at the end of the text
                    if(i < Text.Length)
                    {
                        builder.Append('\n');
                    }
                    
                    breakCounter = 0;
                }
                else
                {
                    breakCounter++;
                    builder.Append(chars[i]);
                }

                i++;
            }

            Text = builder.ToString();
        }
    }
}