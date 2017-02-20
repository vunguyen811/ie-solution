using System;

namespace IESolution.Helper
{
    public class CommonHelper
    {
        public static string GenerateString()
        {
            try
            {
                var random = new Random();
                string[] str =
                {
                    "bw9bRxurTb", "fysH1iajxe52r1GVigOYZtJhIH24M7",
                    "fysH1iajxe52r1GVigOYZtJhIH24M7O2itTbN1HskDO7AS0CKd",
                    "fysH1iajxe52r1GVigOYZtJhIH24M7O2itTbN1HskDO7AS0CKdh4VAnmeAykfWNqG2JxXe8gPWoLUBWpHqjjPKXX6hwC3WCDqYr7"
                };

                return str[random.Next(0, 3)];
            }
            catch (Exception)
            {
                return "exception";
            }

        }

        public static int GenerateDigit()
        {
            Random rng = new Random();
            return rng.Next(10);
        }
    }
}