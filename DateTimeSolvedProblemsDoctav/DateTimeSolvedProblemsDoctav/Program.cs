using System;
using System.Globalization;

namespace DateTimeSolvedProblemsDoctav
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problems solved for: https://github.com/irinascurtu/siit-net/blob/master/DateTime.md");
            //1. Write a program to display the:
            //a) Current date and time
            //b) Current year
            //c) Month of year
            //d) Week number of the year
            //e) Weekday of the week
            //f) Day of year 
            //g) Day of the month
            //h) Day of week
            //j) if the current year is a leap year or not
            DateInfo();

            //2. Write a program to add N year(s) to the current date and display the new date.
            AddNYears(10);

            //3. Write a program to display the date and time in a human-friendly string.
            HumanFriendlyDate();

            //4. Write a program to add 5 seconds to the current time and print it to the console.
            Add5Seconds();

            //5. Write a program to get current time in milliseconds.
            GetCurrentTimeInMilliseconds();

            //6. Write a program that calculates the date six months from the current date.
            SixMonthsFromCurrentDate();

            ////7. Write a program to get the first and last second of a day.
            DateTime today = DateTime.Now;
            FirstAndLastSecondOfDay(today);

            //8. Write a program to calculate two date difference in seconds.
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime(2019, 12, 30);
            DifferenceInSeconds(date1, date2);

            //9. Given a date of birth, calculate the age of a person.
            //Input: 10, 09, 1989 
            //Output: 29
            CalculateAge();

            //10. Write a program to get the dates 30 days before and after from the current date, and display it to the console
            DaysBeforeAfter30();

            //11. Write a program to calculate a number of days between two dates.
            DifferenceInDays(date1, date2);

            //12. Write a program to print yesterday, today, tomorrow.
            YesterdayTodayTomorrow();

            //10. Write program to print next 5 days starting from today.
            Next5Days();

            //*11. Write a program to find the date of the first Monday of a given week
            //Input  : 2015, 50
            //Output : Mon Dec 14 00:00:00 2015  
            FirstMonday();

            //*12. Write a program to get days between two dates.
            date1 = DateTime.Now;
            date2 = new DateTime(2019, 11, 30);
            DaysBetween2Dates(date1, date2);

            //13. Write a program to select all the Sundays of a specified year and display their dates
            AllTheSundays(2020);
        }

        //1. Write a program to display the:
        //a) Current date and time
        //b) Current year
        //c) Month of year
        //d) Week number of the year
        //e) Weekday of the week
        //f) Day of year
        //g) Day of the month
        //h) Day of week
        //j) if the current year is a leap year or not
        public static void DateInfo()
        {
            DateTime currentDate = new DateTime();
            currentDate = DateTime.Now;
            Console.WriteLine($"Current date and time: {currentDate.ToString()}");
            Console.WriteLine($"Current year: {currentDate.Year}");
            Console.WriteLine($"Month of the year: {currentDate.Month}");
            Console.WriteLine("Week number of the year: " + CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
            Console.WriteLine($"Weekday of the week: {currentDate.DayOfWeek}");
            Console.WriteLine($"Day of year: {currentDate.DayOfYear}");
            Console.WriteLine($"Day of month: {currentDate.Day}");
            Console.WriteLine($"Day of week: {currentDate.DayOfWeek}");

            if (currentDate.Year % 4 == 0)
            {
                Console.WriteLine($"The year is a leap year.");
            }
            else
            {
                Console.WriteLine($"The year is NOT a leap year.");
            }
        }

        //2. Write a program to add N year(s) to the current date and display the new date.
        public static void AddNYears(int N)
        {
            DateTime currentDate = new DateTime();
            currentDate = DateTime.Now;
            DateTime nextDate;
            nextDate = currentDate.AddYears(N);
            Console.WriteLine($"The {currentDate} after {N} years will be {nextDate}");
        }

        //3. Write a program to display the date and time in a human-friendly string.
        public static void HumanFriendlyDate()
        {
            DateTime currentDate = DateTime.Now;
            Console.WriteLine($"Today is {currentDate.Day}/{currentDate.Month}/{currentDate.Year} and the time is {currentDate.Hour}:{currentDate.Minute}");
        }

        //4. Write a program to add 5 seconds to the current time and print it to the console.
        public static void Add5Seconds()
        {
            DateTime currentDate = DateTime.Now;
            DateTime nextTime = currentDate.AddSeconds(5);
            Console.WriteLine($"Current time is {currentDate.TimeOfDay} and after 5 seconds it will be {nextTime.TimeOfDay}");
        }

        //5. Write a program to get current time in milliseconds.
        public static void GetCurrentTimeInMilliseconds()
        {
            DateTime currentDate = DateTime.Now;
            decimal totalMilliseconds = currentDate.TimeOfDay.Milliseconds + 1000 * currentDate.TimeOfDay.Seconds + 1000 * 60 * currentDate.TimeOfDay.Minutes + 1000 * 60 * 60 * currentDate.TimeOfDay.Hours;
            Console.WriteLine($"Current date in milliseconds: {totalMilliseconds}");
        }

        //6. Write a program that calculates the date six months from the current date.
        public static void SixMonthsFromCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            DateTime nexttDate = currentDate.AddMonths(6);
            Console.WriteLine($"{currentDate} after six months: {nexttDate}");
        }

        //7. Write a program to get the first and last second of a day.
        public static void FirstAndLastSecondOfDay(DateTime day)
        {
            DateTime beginingOfTheDay = new DateTime(day.Year, day.Month, day.Day);
            DateTime endOfTheDay = beginingOfTheDay.AddHours(24);
            TimeSpan intervalOneMillisecond = TimeSpan.FromMilliseconds(1);
            endOfTheDay = endOfTheDay - intervalOneMillisecond;
            Console.WriteLine($"Beginning of the day: {beginingOfTheDay}. End of the day: {endOfTheDay}");
        }

        //8. Write a program to calculate two date difference in seconds.
        public static void DifferenceInSeconds(DateTime date1, DateTime date2)
        {
            TimeSpan diferenta = date2 - date1;
            Console.WriteLine($"The difference (seconds) between {date2} and {date1} is: {diferenta.TotalSeconds}");
        }

        //9. Given a date of birth, calculate the age of a person.
        //Input: 10, 09, 1989 
        //Output: 29
        public static void CalculateAge()
        {
            string birth = "10, 09, 1989";
            int day = int.Parse(birth.Substring(0, birth.IndexOf(',')));
            birth = birth.Substring(birth.IndexOf(',') + 1);
            int month = int.Parse(birth.Substring(0, birth.IndexOf(',')));
            birth = birth.Substring(birth.IndexOf(',') + 1);
            int year = int.Parse(birth);
            //build the date in C# format
            DateTime birthDate = new DateTime(year, month, day);
            DateTime currentDate = DateTime.Today;
            //calculate the age
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
                age--;
            Console.WriteLine($"Age = {age} years.");
        }

        //10. Write a program to get the dates 30 days before and after from the current date, and display it to the console
        public static void DaysBeforeAfter30()
        {
            DateTime currentDate = DateTime.Today;
            TimeSpan period = new TimeSpan(30, 0, 0, 0);
            DateTime beforeDate = currentDate - period;
            DateTime afterDate = currentDate + period;
            Console.WriteLine($"Current date is {currentDate}. 30 days before is {beforeDate}. 30 days after is {afterDate}");
        }

        //11. Write a program to calculate a number of days between two dates.
        public static void DifferenceInDays(DateTime date1, DateTime date2)
        {
            TimeSpan diferenta = date2 - date1;
            Console.WriteLine($"The difference (days) between {date2} and {date1} is: {diferenta.Days}");
        }

        //12. Write a program to print yesterday, today, tomorrow.
        public static void YesterdayTodayTomorrow()
        {
            DateTime today = DateTime.Today;
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
            DateTime yesterday = today - oneDay;
            DateTime tomorrow = today + oneDay;
            Console.WriteLine($"Yesterday: {yesterday.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Today: {today.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Tomorrow: {tomorrow.ToString("yyyy-MM-dd")}");

        }

        //10. Write program to print next 5 days starting from today.
        public static void Next5Days()
        {
            Console.WriteLine();
            DateTime today = DateTime.Today;
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
            for (int i = 0; i < 5; i++)
            {
                today = today + oneDay;
                Console.WriteLine($"Day {i + 1} is: {today.ToString("yyyy-MM-dd")}");
            }
        }

        //*11. Write a program to find the date of the first Monday of a given week
        //Input  : 2015, 50
        //Output : Mon Dec 14 00:00:00 2015      
        public static void FirstMonday()
        {
            int year = 2015;  //or from the console
            int weeks = 50;   //or from the console
            TimeSpan weeksAdded = new TimeSpan(7 * weeks, 0, 0, 0);  //350 days will be added to the first day of the year (50 weeks x 7 days)
            DateTime myDate = new DateTime(year, 1, 1) + weeksAdded;
            while (myDate.DayOfWeek != DayOfWeek.Monday)  //get back until the first Monday
            {
                TimeSpan oneDay = new TimeSpan(1, 0, 0, 0);
                myDate = myDate - oneDay;
            }
            Console.WriteLine($"The first Monday in the week {weeks} of the year {year} is on {myDate}");
        }

        //*12. Write a program to get days between two dates.
        public static void DaysBetween2Dates(DateTime date1, DateTime date2)
        {
            TimeSpan difference = date2 - date1;
            Console.WriteLine($"The number of days between {date2} and {date1} is: {difference.Days}");
        }

        //*13. Write a program to select all the Sundays of a specified year and display their dates
        public static void AllTheSundays(int year)
        {
            DateTime currentDate = new DateTime(year, 1, 1); //first day of the year
            TimeSpan oneDay = new TimeSpan(1, 0, 0, 0); //day by day we'll check the days of the year
            while (year == currentDate.Year)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine($"Sunday: {currentDate.ToString("yyyy-MM-dd")}");
                }
                currentDate += oneDay;

            }
        }
    }
}
