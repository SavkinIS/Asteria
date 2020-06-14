using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Models
{
    /// <summary>
    /// Класс создает расписание работников
    /// </summary>
    public class FreeTime
    {
        
        List<string> freTime;
       
        public FreeTime(List<Record> Records, DateTime needDay)
        {
            
            SheetsList(Records, needDay);

        }

        public List<string> FreTime { get => freTime; set => freTime = value; }

        /// <summary>
        /// Заполняем freTime свободными временными интервалами
        /// </summary>
        /// <param name="Records">Список записей</param>
        void SheetsList(List<Record> Records, DateTime needDay)
        {
            FreTime = new List<string>();
            TimeSpan begin = new TimeSpan(9, 0, 0);
            TimeSpan end = new TimeSpan(20, 0, 0);
            TimeSpan addSpan = new TimeSpan(0, 15, 0);
            DateTime today = DateTime.Now;
            TimeSpan nowTime = DateTime.Now.TimeOfDay;

            if(needDay.Date == today.Date)
            {
                while (begin < nowTime)
                {
                    begin = begin.Add(addSpan);
                }
            }

            List<TimeSpan> sL = new List<TimeSpan>();

            foreach(var rec in Records)
            {
                sL.Add(rec.Time);
            }

            while(begin< end)
            {
                if (sL.Select(t => (t == begin)).FirstOrDefault()== false)
                {
                    FreTime.Add(begin.ToString("hh':'mm"));
                }
                begin = begin.Add(addSpan);
            }
        }

    }
}
