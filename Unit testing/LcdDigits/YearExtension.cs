// <copyright file="YearExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Katas
{
    using System;

    /// <summary>
    /// Class for methods which work with the year information.
    /// </summary>
    public static class YearExtension
    {
        /// <summary>
        /// Standart leap year - is one in four years.
        /// </summary>
        public static readonly int StandartLeapYear = 4;

        /// <summary>
        /// Hundred years is normal year except one in four hundred year.
        /// </summary>
        public static readonly int ExceptionHundredLeapYear = 100;

        /// <summary>
        /// One in four hundred year is leap.
        /// </summary>
        public static readonly int ExceptionFourHundredLeapYear = 400;

        /// <summary>
        /// Return true if year is leap.
        /// </summary>
        /// <param name="year">The number of year.</param>
        /// <returns>Bool value.</returns>
        public static bool IsLeap(int year)
        {
            if (year < default(int))
            {
                throw new ArgumentException("We started our chronology from the year 0.");
            }

            if (year % StandartLeapYear == default)
            {
                if (year % ExceptionHundredLeapYear == default)
                {
                    if (year % ExceptionFourHundredLeapYear == default)
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
