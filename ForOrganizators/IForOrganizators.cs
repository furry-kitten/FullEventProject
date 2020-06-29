using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ForOrganizators.Models;

namespace ForOrganizators
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IForOrganizators" в коде и файле конфигурации.
    [ServiceContract]
    public interface IForOrganizators
    {
        //  Все обращения к базе данных должны быть сделаны с помощью транзакций!

        /// <summary>
        /// Подтверждает наличие пользователя в базе данных
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="partner">Возвращает всю информацию о танцоре из базы данных</param>
        /// <returns></returns>
        [OperationContract]
        bool AuthorizationWithLogin(string login, string password, out Partner partner);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDsha">Номер асх</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="partner">Возвращает всю информацию о танцоре из базы данных</param>
        /// <returns></returns>
        [OperationContract]
        bool AuthorizationWithIDsha(int IDsha, string password, out Partner partner);

        /// <summary>
        /// Возвращает список партнёров по совпадению ФИО
        /// </summary>
        /// <param name="firstname">Имя</param>
        /// <param name="secondname">Фамилия</param>
        /// <param name="patronymic">Отвество</param>
        /// <returns></returns>
        [OperationContract]
        List<Partner> GetPartners(string firstname, string secondname, string patronymic);

        /// <summary>
        /// Возвращает список всех сампо
        /// </summary>
        /// <returns>список типа List<Sampo></returns>
        [OperationContract]
        List<Sampo> GetSampoList(string city); //  Возможно добавить количество

        /// <summary>
        /// Возвращает одно сампо и предоставляет всю информацию о нём
        /// </summary>
        /// <param name="id">Внутренний номер сампо</param>
        /// <returns>Возвращает класс Sampo</returns>
        [OperationContract]
        Sampo GetSampo(int id);     //  Нужно ли?
    }
}
