using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Сампо.Models;

namespace ForOrganizators
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ForOrganizators" в коде и файле конфигурации.
    public class ForOrganizators : IForOrganizators
    {
        public bool AuthorizationWithIDsha(int IDsha, string password, out Partner partner)
        {
            //  Запрос к базе с использованием библиотеки доступнгой только серверу (с выводом класса Partner)
            //  Если такого танцора не было найдено Вернуть пустой класс

            partner = null; //  SelectPartner(IDsha, password);

            if (partner == null) return false;
            else return true;
        }

        public bool AuthorizationWithLogin(string login, string password, out Partner partner)
        {
            //  Запрос к базе с использованием библиотеки доступнгой только серверу (с выводом класса Partner)
            //  Если такого танцора не было найдено Вернуть пустой класс

            partner = null; //  SelectPartner(login, password);

            if (partner == null) return false;
            else return true;
        }
        
        public List<Partner> GetPartners(string firstname, string secondname, string patronymic) => new List<Partner>
        {
            new Partner("Unknown", "Unknown", Gender.Male),
            new Partner("Unknown1", "Unknown1", Gender.Male),
            new Partner("Unknown2", "Unknown2", Gender.Male)
        };
        /*
        {
            //  Запрос к базе с ипользованием библиотеки доступной только серверу (С выводом списка классов танцоров) Для этого запроса достаточно вернуть ФИО и клубную  принадлежность для каждого танцора
            //  return SelectPartners(firstname, secondname, patronymic) 
        }
        */
        public List<Partner> GetPartners(string firstname, string secondname) => new List<Partner>
        {
            new Partner("Unknown", "Unknown", Gender.Male),
            new Partner("Unknown1", "Unknown1", Gender.Male),
            new Partner("Unknown2", "Unknown2", Gender.Male)
        };
        /*
        {
            //  Запрос к базе с ипользованием библиотеки доступной только серверу (С выводом списка классов танцоров) Для этого запроса достаточно вернуть ФИО и клубную  принадлежность для каждого танцора
            //  return SelectPartners(firstname, secondname) 
        }
        */

        public Sampo GetSampo(int id) => new Sampo("UnKnown", 0, -1);
        /*
        {
            //  Запрос к базе с использованием библиотеки доступнгой только серверу (с выводом класса Sampo)
            //  return SelectSampo(id);
        }
        */

        public List<Sampo> GetSampoList(string city) => new List<Sampo> {
        new Sampo("UnKnown ", 0, -1),
        new Sampo("UnKnown1", 0, -1),
        new Sampo("UnKnown2", 0, -1),
        new Sampo("UnKnown3", 0, -1),
        new Sampo("UnKnown4", 0, -1),
        new Sampo("UnKnown5", 0, -1),
        new Sampo("UnKnown6", 0, -1),
        new Sampo("UnKnown7", 0, -1),
        new Sampo("UnKnown8", 0, -1),
        new Sampo("UnKnown9", 0, -1)
        };
        /*
        {
            //  Запрос к базе с ипользованием библиотеки доступной только серверу (С выводом списка классов сампо) Для этого запроса достаточно вернуть id, названиеб место проведения и город для каждого сампо
            //  
            //  Сделать проверку на файл. Все ли сампо существуют. В дальнейшем отправлять файл с сампо 
            //  
            //  return SelectAllSampo(city)
        }
        */
    }

    
}
