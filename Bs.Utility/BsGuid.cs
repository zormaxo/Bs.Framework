using System;

namespace Bs.Utility
{
    public static class BsGuid
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public static long GetGuid()
        {
            lock (syncLock)
            {
                int firstNumber = getrandom.Next(100000, 999999);
                int secondNumber = getrandom.Next(100000, 999999);
                return Convert.ToInt64(string.Format("{0}{1}", firstNumber, secondNumber));
            }
        }
    }
}