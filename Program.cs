using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateDifference
{
    class Program
    {
       static  int Month = 0, Days=0, Year=0;
        
        public static int day_between(int beg, int fn)
        {
            int days = 0;
              for (int i = beg + 1; i < fn; i++)
                {
                    days += days_in_month(i);
                    Month++;
                    // Console.WriteLine(days);

               
            }
           
            return days;
        }

        static bool  check_date(string[] b, string[] e)
        {
            int nber;
            if (b.Length != 3 || e.Length != 3 || b[2].Length !=4 || e[2].Length != 4)
            {
                Console.WriteLine("Wrong date format detected; Check date entered");
                return false;

            }
            if (!int.TryParse(b[0], out nber) || !int.TryParse(b[1], out nber) || !int.TryParse(b[2], out nber))
            {
                Console.WriteLine("The first string is not a date");

                return false;

            }

            if (!int.TryParse(e[0], out nber) || !int.TryParse(e[1], out nber) || !int.TryParse(e[2], out nber))
            {
                Console.WriteLine("The second string is not a date");

                return false;

            }
            int m1 = Convert.ToInt32(b[0]),
                day1 = Convert.ToInt32(b[1]),
                y1 = Convert.ToInt32(b[2]),

               m2 = Convert.ToInt32(e[0]),
              day2 = Convert.ToInt32(e[1]),
            y2 = Convert.ToInt32(e[1]);
            //check the if the mont is valide
            if (m1 > 12 || m2 > 12) {
                Console.WriteLine("The month is out of range");
                return false;
            }

            if (day1 > days_in_month(m1))
            {
                Console.WriteLine("The day of a date is ouf range for the month");
                return false;

            };
            if (day2 > days_in_month(m2))
            {
                Console.WriteLine("The day of a date is ouf range for the month");
                return false;

            };

                return true;
        }



        //check if it is a leap year and return 1 if it is true
      public static  int  is_leap_year(int y)
        {
            int result = 0;
            if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0) result = 1;
            return result;

        }
        //calculate the days between 2 dates
       public static void difference3(string[] d1, string[] d2)
        {
            Year = Month = Days = 0;


            int   diff_month,  year_end, year_begin;
            int month_end, month_bgn, day_end, day_begin;
            diff_month = Math.Abs(Convert.ToInt32(d1[0]) - Convert.ToInt32(d2[0]));
            month_end = Convert.ToInt32(d2[0]);
            month_bgn = Convert.ToInt32(d1[0]);
            day_end = Convert.ToInt32(d2[1]);
            day_begin = Convert.ToInt32(d1[1]);
            year_end = Convert.ToInt32(d2[2]);
            year_begin = Convert.ToInt32(d1[2]);

            if (year_begin == year_end)
            {
                if(month_bgn == month_end)
                {
                    Year = 1;
                    Month = 1;
                    Days = day_end - day_begin + 1;


                }
                else if(month_end == month_bgn +1)
                {
                    Year = 1;
                    Month = 2 ;
                  //  Days = day_between(month_bgn, month_end)   ;

                    Days = days_in_month(month_bgn)- day_begin + day_end +1;


                }
                else
                    if (month_end > month_bgn + 1)
                {
                    Year = 1;
                   
                    Days = day_between(month_bgn, month_end);

                    Days += days_in_month(month_bgn) + day_begin + day_end ;
 Month = month_end - month_bgn+1;


                }


            }
            if(year_end-year_begin ==1)
            {
                //if(month_bgn> month_end)
                if(month_end==1)
                Days = day_between(month_bgn,12) + day_between(1,month_end)+31;
                else
                    Days += day_between(month_bgn, 12) + day_between(1, month_end) + 31+31;

                Days += days_in_month(month_bgn) - day_begin + day_end +1;
                Year = 2;

                Month = 12 - month_bgn + month_end+1;


            }
            if (year_end - year_begin > 1)

            {
                Year = 2;
                //full years
                for(int i= year_begin+1; i< year_end; i++)
                {
                    Days += 365+is_leap_year(i);
                    Month += 12;
                    Year++;

                   
                }
                //
            Month += 12 - month_bgn + month_end+1;
                Days += day_between(month_bgn, 12) + day_between(1,month_end) + 31+31;
                Days += days_in_month(month_bgn) - day_begin + day_end + 1;



            }

            //Console.WriteLine("year = " + Year);
            //Console.WriteLine("Month = " + Month);
            Console.WriteLine("Days = " + Days);
            Console.WriteLine("Hours = " + Days * 24);
            Console.WriteLine("Minutes = " + Days * 24 * 60);

         
        }
        
        //return the days in a month
        static public int days_in_month(int month)
        {
            int nb_days = 30;
            switch (month)
            {
                case 2: nb_days = 28;
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    nb_days = 31;
                    break;


            }
            return nb_days;


        }
        static void Main(string[] args)
        {
            char[] delimiterChars = { '/', '-', ' ' };
            string date1, date2;
            bool continue_run = true;
            Console.WriteLine("Hello, \nWelcome to my program, Enter 2 date and I will return the difference in days, hours and minutes");
            

            while(continue_run)
            {Console.WriteLine();
                Console.WriteLine("Accepted date Formats MM/DD/YYYY ,  MM-DD-YYYY ,  MM DD YYYY");
                
            Console.Write("Enter the first date  : ");
            date1 = Console.ReadLine();
            string[] l1 = date1.Split(delimiterChars);
            Console.WriteLine();
            Console.Write("Enter the second date : ");
            date2 = Console.ReadLine();
            string[] l2 = date2.Split(delimiterChars);

                if (check_date(l1, l2))
                {
                    Days = Month = Year = 0;
                    //if the year of the first date is greater
                    if (Convert.ToInt32(l1[2]) > Convert.ToInt32(l2[2]))
                    { 
                        difference3(l2, l1);
                     
                    }

                    else if (Convert.ToInt32(l1[2]) == Convert.ToInt32(l2[2]) && Convert.ToInt32(l1[1]) > Convert.ToInt32(l2[1]))
                    {
                      
                        difference3(l2, l1);
                      
                    }
                    else
                    { 
                        difference3(l1,l2 );
                     
                    }
                }

                        Console.Write("Continue running the program?? Yes(Y) other key to Quit: ");
                continue_run = Console.ReadKey().Key == ConsoleKey.Y;
           

          
}
            Console.WriteLine();
            Console.WriteLine("Thank you for your time: Albert NGOUDJOU");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();






        }
    }
}
