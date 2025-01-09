using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    [Flags]
    public enum DaysOfWeekEnum
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
        All = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday
    }
}
