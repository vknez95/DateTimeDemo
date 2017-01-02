using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace DateTimeDemo
{
    public class Program
    {
        [DllImport("kernel32")]
        public static extern void GetSystemTimeAsFileTime(out FILETIME lpSystemTimeAsFileTime);

        public static void Main(string[] args)
        {
            FILETIME ft;

            GetSystemTimeAsFileTime(out ft);

            UInt64 time = (UInt64)ft.dwHighDateTime;
            time = (time << 32) + (UInt64)ft.dwLowDateTime;

            Console.WriteLine(time);

            DateTime dt = DateTime.UtcNow;

            Console.WriteLine("{0} {1}", dt.ToString("dddd, MMMM dd, yyyy"), dt.ToString("h:mm:ss tt"));
            
            Console.ReadLine();
        }
    }
}
