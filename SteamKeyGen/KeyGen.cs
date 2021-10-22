using System;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SteamKeyGen
{
    class KeyGen
    {

        private string KeyLetters;
        private string KeyNumbers;
        private int KeyChars;
        private char[] LetterArray;
        private char[] NumberArray;


        protected internal string KeyLetters_
        {
            set
            {
                KeyLetters = value;
            }
        }

        protected internal string KeyNumbers_
        {
            set
            {
                KeyNumbers = value;
            }
        }

        protected internal int KeyChars_
        {
            set
            {
                KeyChars = value;
            }
        }

        public string GenerateKey()
        {
            StringBuilder stringBuilder = new StringBuilder();
            LetterArray = KeyLetters.ToCharArray();
            NumberArray = KeyNumbers.ToCharArray();
            int keyChars = KeyChars;
            checked
            {
                for (int i = 1; i <= keyChars; i++)
                {
                    VBMath.Randomize();
                    float num1 = VBMath.Rnd();
                    short num2 = -1;
                    bool flag = (int)Math.Round((double)(unchecked(num1 + 111f))) % 2 == 0;
                    if (flag)
                    {
                        while (num2 < 0)
                        {
                            num2 = Convert.ToInt16(unchecked((float)LetterArray.GetUpperBound(0) * num1));
                        }
                        string text = Conversions.ToString(LetterArray[(int)num2]);
                        bool flag2 = (int)Math.Round((double)(unchecked((float)num2 * num1 * 99f))) % 2 != 0;
                        if (flag2)
                        {
                            text = this.LetterArray[(int)num2].ToString();
                            text = text.ToUpper();
                        }
                        stringBuilder.Append(text);
                    }
                    else
                    {
                        while (num2 < 0)
                        {
                            num2 = Convert.ToInt16(unchecked((float)this.NumberArray.GetUpperBound(0) * num1));
                        }
                        stringBuilder.Append(this.NumberArray[(int)num2]);
                    }
                }
                return stringBuilder.ToString();
            }
        }
    }
}
