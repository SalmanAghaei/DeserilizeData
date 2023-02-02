using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Toolkit.DateTimes;


public static class DateTimeUtils
{
  
    public static (int year,int month,int day) ValidDate(this string str)
    {
        str.Replace("/", "");
        var year = int.Parse(str.Substring(0, 4));
        var month = int.Parse(str.Substring(4, 2));
        var day = int.Parse(str.Substring(6, 2));
        return (year,month,day);
    }


    public static bool ValidDateString(this string str)
    {
        try
        {
            if (str.Length > 8 || str.Length < 8)
                return false;
            var year = int.Parse(str.Substring(0, 4));
            var month = int.Parse(str.Substring(4, 2));
            var day = int.Parse(str.Substring(6, 2));
            return true;
        }
        catch
        {
            return false;
        }
       
    }
    public static DateTime PersianToMiladiDate(this string str)
    {
        var date=str.ValidDate();
        var calender = new PersianCalendar();
        var miladiDate = calender.ToDateTime(date.year, date.month, date.day, 0, 0, 0,0);
        return miladiDate;
    } 
    public static string PersianToMiladiDateToString(this string str)
    {
        var date=str.ValidDate();
        var calender = new PersianCalendar();
        var miladiDate = calender.ToDateTime(date.year, date.month, date.day, 0, 0, 0,0);
        return miladiDate.ToShortDateString();
    }
    public static string MiladiToPersianDate(this DateTime date)
    {
     
        var pc = new PersianCalendar();
        var persianDate = string.Format("{0}{1}{2}",
            pc.GetYear(date), 
            pc.GetMonth(date)<10? $"0{pc.GetMonth(date)}": pc.GetMonth(date).ToString(),
            pc.GetDayOfMonth(date)<10?$"0{pc.GetDayOfMonth(date)}": pc.GetDayOfMonth(date).ToString()
            );
        return persianDate;
    }
}
