using System;
using System.Text;

namespace MSE.TaskProfile.WebApi.Helpers
{
    public static class HelperClass
    {
        private static int[] GenerateIdentifierDigits()
        {
            int topTenSum = 0;
            int[] digits = new int[11];
            Random rnd = new Random();

            //find first 9 digits
            for (int i = 0; i < digits.Length - 2; i++)
            {
                //the first digit cannot be zero
                if (i == 0)
                {
                    digits[i] = rnd.Next(1, 9);
                }
                digits[i] = rnd.Next(0, 9);
            }

            /*The mod10 of the result gives us the 10th digit when the sum of the 
            2nd, 4th, 6th and 8th digits is subtracted 
            from the 7 times the sum of the 1st, 3rd, 5th, 7th and 9th digits.*/
            digits[9] =
                (((digits[0] + digits[2] + digits[4] + digits[6] + digits[8]) * 7)
                -
                (digits[1] + digits[3] + digits[5] + digits[7])) % 10;


            /*The mod10 of the result from the sum of the first ten digits gives us the 11th digit. */
            for (int i = 0; i < digits.Length - 1; i++)
            {
                topTenSum += digits[i];
            }

            digits[10] = topTenSum % 10;

            return digits;
        }

        public static long GenerateTCIdentifier()
        {
            
            int[] digits = GenerateIdentifierDigits();
            StringBuilder sb = new StringBuilder(digits.Length);

            //Concatenate digits
            foreach (var digit in digits)
            {
                sb.Append(digit);
            }

            return long.Parse(sb.ToString());
        }
    }
}
