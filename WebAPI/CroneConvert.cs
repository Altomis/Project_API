using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCrontab;

namespace WebAPI
{
    public static class CroneConvert
    {
        public static DateTime[] ConvertCrone(string cron)
        {
            DateTime[] convertedcrone = new DateTime[10];
            DateTime now = DateTime.UtcNow;
            var parsedcrone = CrontabSchedule.Parse(cron);
            for (int i = 0; i < 10; i++)
            {
                convertedcrone[i] = parsedcrone.GetNextOccurrence(now);
                now = convertedcrone[i];
            }
            return convertedcrone;
        }


    }
}