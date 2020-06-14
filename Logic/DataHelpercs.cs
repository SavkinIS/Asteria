
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Models
{
    /// <summary>
    /// Класс Для помощи взаимодействия 
    /// </summary>
    public class DataHelpercs
    {
        DataApi data;
        public DataHelpercs()
        {
            data = new DataApi();
        }

        /// <summary>
        /// Обработка формы записи
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="wk_select"></param>
        /// <param name="message"></param>
        public void FormProcessing(string name, string phone, string date, string time, string wk_select, string message, string specName)
        {
            //int specId = data.GetSpecialists().Value.Where(s => (s.Name == specName)).FirstOrDefault().Id;
            var clients = data.GetClients().Value.Where(ph => (ph.Phone == phone)).FirstOrDefault();

            if (clients == null)
            {
                var client = new Client()
                {
                    Name = name,
                    Phone = phone
                };

                data.AddClient(client);

                
                clients = data.GetClients().Value.Last();

            }

            var spec = data.GetSpecialists().Value.Where(s => (s.Name == specName)).FirstOrDefault();

            if (spec != null)
            {
                #region ConvertToData
                DateTime dt = ConvertToDate(date, ref time);

                #endregion

                var free = data.GetRecords(dt, spec.Id);

                if (free.Result == null)
                {
                    var record = new Record()
                    {
                        ClientId = clients.Id,
                        SpecId = spec.Id,
                        Date = dt,
                        Time = dt.TimeOfDay,
                        TypeWork = wk_select
                    };

                    data.AddRecord(record);
                }

            }

        }

        /// <summary>
        /// Возвращает новую дату, конвертируя спроковое представление даты и времени
        /// </summary>
        /// <param name="date">дата </param>
        /// <returns></returns>
       public static DateTime ConvertToDate(string date)
        {
            int day = 0;
            int month = 0;
            int year = Convert.ToInt32(date.Substring(0, 4));
            try
            {
                month = Convert.ToInt32(date.Substring(5, 2));
            }
            catch
            {
                month = Convert.ToInt32(date.Substring(5, 1));
            }
            try
            {
                day = Convert.ToInt32(date.Substring(8, 2));
            }
            catch
            {
                try
                {
                    day = Convert.ToInt32(date.Substring(8, 1));
                }
                catch
                {
                    day = Convert.ToInt32(date.Substring(7, 1));
                }
               
            }
            


            DateTime dt = new DateTime(year, month, day);
            return dt;
        }

        /// <summary>
        /// Возвращает новую дату, конвертируя строковое представление даты и времени
        /// </summary>
        /// <param name="date">дата </param>
        /// <param name="time">время</param>
        /// <returns></returns>
        private static DateTime ConvertToDate(string date, ref string time)
        {
            int year = Convert.ToInt32(date.Substring(0, 4));
            int month = Convert.ToInt32(date.Substring(5, 2));
            int day = Convert.ToInt32(date.Substring(8, 2));
            if (time.StartsWith('9')) time = "0" + time;
            int hour = Convert.ToInt32(time.Substring(0, 2));
            int minutes = Convert.ToInt32(time.Substring(3, 2));
            DateTime dt = new DateTime(year, month, day, hour, minutes, 0);
            return dt;
        }




        /// <summary>
        /// Метод Возвращает расписание на определённую дату
        /// </summary>
        /// <param name="date"></param>
        /// <param name="specName"></param>
        /// <returns></returns>
        public List<string> CreateSheets(string date, string specName)
        {
            int specId = data.GetSpecialists().Value.Where(s => (s.Name == specName)).FirstOrDefault().Id;

            var d = ConvertToDate(date);
            var list = data.GetRecords(d, specId).Value.ToList();

            FreeTime ft = new FreeTime(list, d);

            return ft.FreTime;
        }
    }
}
