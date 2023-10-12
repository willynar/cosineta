using System.Collections;

namespace Logic.Utilities
{
    public class LUtilities
    {
        public static IEnumerable GetTimeZoneInfo()
        {
            // Este for sirve para ver los ID de las zonas horarias
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                yield return z.Id;
            }
        }

        public static DateTime GetDateTimeNowUTC()
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone;
            try
            {
                cstZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            }
            catch
            {
                cstZone = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");
            }
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            return cstTime;
        }
    }
}
