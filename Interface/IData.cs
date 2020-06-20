using Asteria.Models;
using Asteria.Models.Admin;
using Asteria.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Interface
{
    interface IData
    {
        #region Client
        /// <summary>
        /// Получаем всех клиентов
        /// </summary>
        /// <returns>Все клиенты</returns>
        ActionResult<IEnumerable<Client>> GetClients();
        /// <summary>
        /// Получаем клиента
        /// </summary>
        /// <param name="id">айди клиента</param>
        /// <returns></returns>
        ActionResult<Client> GetClients(int id);
        /// <summary>
        /// Добавить клиента
        /// </summary>
        /// <param name="client"></param>
        void AddClient(Client client);

        /// <summary>
        ///  Изменение клиента
        /// </summary>         
        /// <param name="new_client">client, with new parameters</param>
        /// <returns></returns>
        string PutClient(Client new_client, long id);

        /// <summary>
        /// Удаление Клиента
        /// </summary>
        /// <param name="id"> id Clients</param>
        Client DelClient(int id);


        #endregion

        #region Records
        /// <summary>
        /// Возвращает все записи
        /// </summary>
        /// <returns></returns>
        ActionResult<IEnumerable<Record>> GetRecords();

        /// <summary>
        /// Возвращает  записи по дате
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date);


        /// <summary>
        /// Возвращает  записи по дате и специалисту
        /// </summary>
        /// <param name="date"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        ActionResult<IEnumerable<Record>> GetRecords(DateTime dt, int specId);


        /// <summary>
        /// Возвращает  записи по дате и специалисту
        /// </summary>
        /// <param name="date"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date, string spec);
        /// <summary>
        /// Возвращает одну запись по айди
        /// <param name="id"> айди записи</param>
        /// </summary>
        /// <returns></returns>
        ActionResult<Record> GetRecords(int id);

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="record"></param>
        void AddRecord(Record record);



        /// <summary>
        /// Изменение Записи
        /// </summary>
        /// <param name="newRecord">Record с изменениями</param>
        /// <param name="id">изеняемая запись</param>
        /// <returns></returns>
        string PutRecord(RecordsDTO newRecord, long id);

        /// <summary>
        /// Удаление Record
        /// </summary>
        /// <param name="id">номер Удаляемого Record</param>
        /// <returns></returns>
        Record DelRecord(int id);

        #endregion

        #region Specialist
        /// <summary>
        /// Возвращает всех специалистов 
        /// </summary>
        /// <returns></returns>
        ActionResult<IEnumerable<Specialist>> GetSpecialists();



        /// <summary>
        /// Возвращает специалиста по Имени специалиста
        /// </summary>
        /// <param name="id">Имя</param>
        /// <returns></returns>
        ActionResult<Specialist> GetSpecialists(int id);

        /// <summary>
        /// Добавить специалиста
        /// </summary>
        /// <param name="specialist"></param>
        void AddSpecialist(Specialist specialist);

        /// <summary>
        /// Изменение клиента
        /// </summary>
        /// <param name="newSpecialist">Новый клиент</param>
        /// <param name="id">id клиента</param>
        /// <returns></returns>
        string PutSpecialist(Specialist newSpecialist, long id);

        /// <summary>
        /// Возвращантт специалиста по его имени
        /// </summary>
        /// <param name="namespec"></param>
        /// <returns></returns>
        ActionResult<IEnumerable<Specialist>> GetSpecialists(string namespec);

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id">id клиента</param>
        /// <returns></returns>
        Specialist DelSpecialist(int id);
        #endregion

        #region Admin
        ActionResult<string> Login(UserLogin user);

        void Logout();

        ActionResult<string> Registr(UserRegistration user);
        #endregion
    }
}
