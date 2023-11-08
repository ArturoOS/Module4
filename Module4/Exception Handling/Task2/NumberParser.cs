using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException();

            stringValue = stringValue.Replace(" ","");
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
                throw new FormatException();

            int num = 0;
            int i = 0;
            bool isNegetive = false;

            if (stringValue[i] == '-')
            {
                isNegetive = true;
                i = 1;
            }
            if (stringValue[i] == '+')
            {
                i = 1;
            }
            for (int j = i; j < stringValue.Length; j++)
			{
                if (stringValue[j] >= '0' && stringValue[j] <= '9') 
                {
                    if (isNegetive) 
                    {
                        if (num > 0)
                            num = -1 * num;
                        num = checked(num * 10 - (stringValue[j] - '0'));
                    }
					else
                        num = checked(num * 10 + (stringValue[j] - '0'));
                } 
                else
                    throw new FormatException();
            }
                
            return num;
        }
    }
}