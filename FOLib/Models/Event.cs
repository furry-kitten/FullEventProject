using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FO.Models.Перечисления;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;

namespace FO.Models
{
    public class Event : DBClass
    {
        #region Переменные
        private string entitling;
        private decimal enterPrice;
        private string rulesPath;
        private string location;
        private string currency = "RUB";
        private char shortCurrency = 'р';

        private List<Nomination> nominations;
        private Periodicity periodicity;
        private GroupOfOrganiziers organizator = new GroupOfOrganiziers();
        private EventType type = new EventType();
        private List<Dancer> dancers = new List<Dancer>();


        #endregion
        /**********************************************************/
        #region Конструкторы
        public Event() { }
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="enterPrice">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        public Event(string name, decimal enterPrice, GroupOfOrganiziers organizator)
        {
            CreateEvent(name, enterPrice, organizator);
        }
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="enterPrice">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        /// <param name="rules">Пусть к файлу с правилами сампо</param>
        public Event(string name, decimal enterPrice, GroupOfOrganiziers organizator, string rulesPath)
        {
            CreateEvent(name, enterPrice, organizator);
            this.rulesPath = rulesPath;
        }
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="enterPrice">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        /// <param name="rules">Пусть к файлу с правилами сампо</param>
        /// <param name="location">Адрес проведение сампо</param>
        public Event(string name, decimal enterPrice, GroupOfOrganiziers organizator, string rulesPath, string location)
        {
            CreateEvent(name, enterPrice, organizator);
            this.rulesPath = rulesPath;
            this.location = location;
        }
        #endregion
        /**********************************************************/
        #region Поля класса
        /// <summary>
        /// Задаёт/возвращает название сампо
        /// </summary>
        public string Entitling
        {
            get => entitling;
            set
            {
                entitling = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Задаёт/возвращает организатора
        /// </summary>
        public GroupOfOrganiziers Organiziers
        {
            get => organizator;
            set
            {
                organizator = value;
                OnPropertyChanged();
            }
        }
        public Periodicity Periodicity
        {
            get => periodicity;
            set
            {
                periodicity = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Задаёт/возвращает стоимость сампо
        /// </summary>
        public decimal EnterPrice
        {
            get => enterPrice;
            set
            {
                enterPrice = value;
                OnPropertyChanged();
            }
        }
        public List<Nomination> Nominations
        {
            get => nominations;
            set { nominations = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает путь к файлу с правилами
        /// </summary>
        public string RulesPath
        {
            get => rulesPath;
            set { rulesPath = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает адрес места проведения сампо
        /// </summary>
        public string Location
        {
            get => location;
            set { location = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает/задаёт валюту для сампо
        /// </summary>
        public string Currency
        {
            get => currency;
            set { currency = value; OnPropertyChanged(); }
        }
        public List<Dancer> Dancers
        {
            get => dancers;
            set { dancers = value; OnPropertyChanged(); }
        }
        public EventType Type
        {
            get => type;
            set { type = value; OnPropertyChanged(); }
        }
        public Guid GroupId { get; set; }
        public Guid PeriodicityId { get; set; }
        #endregion
        /**********************************************************/
        #region Методы класса
        public List<Dancer> Liders() => dancers.Where((d) => d.Person.Gender == Gender.Male).ToList();
        public List<Dancer> Followers() => dancers.Where((d) => d.Person.Gender == Gender.Female).ToList();
        /// <summary>
        /// Добавляет танцора в список сампо
        /// </summary>
        /// <param name="dancer">Экземпляр класса Parther</param>
        public void AddNewDancer(Dancer dancer)
        {
            if (dancer != null)
            {
                dancers.Add(dancer);

                OnPropertyChanged("Dancer");
            }
        }
        [Obsolete("Убедиться, что выполняется сериализация на компьютер и отправляется описание правил на сервер!")]
        /// <summary>
        /// Записывает в файл строки представленные в параметре <paramref name="rules"/>.
        /// </summary>
        /// <param name="rules">Ссылка на сформированный список строковых данных для записи их в файл</param>
        /// <param name="beSureToUpdate">Поставить в true, если выполняется очередное обноление парвил в один день</param>
        public void UpdateRules(ref List<string> rules, bool beSureToUpdate = false)
        {
            if (rules == null)
                return;

            rulesPath = Assembly.GetExecutingAssembly().Location + ($@"/{entitling}rules.dat");
            DateTime LastVersion = Convert.ToDateTime("0");
            bool newRules = false;

            if (File.Exists(rulesPath))
                using (BinaryReader rulesfile = new BinaryReader(File.Open(rulesPath, FileMode.Open)))
                {
                    LastVersion = Convert.ToDateTime(rulesfile.ReadInt32() + rulesfile.ReadInt32());
                }

            if (Convert.ToDateTime(DateTime.Now.Day + '.' + DateTime.Now.Month) > LastVersion)
                newRules = true;

            if (beSureToUpdate || newRules)
            {
                List<string> stringsOfRules = new List<string>();
                stringsOfRules.Add(DateTime.Now.Day.ToString() + '.' + DateTime.Now.Month.ToString());

                foreach (string s in rules)
                    stringsOfRules.Add(s);


                using (BinaryWriter rulesFile = new BinaryWriter(File.Open(rulesPath, FileMode.OpenOrCreate)))
                {
                    foreach (string r in stringsOfRules)
                        rulesFile.Write(r);
                }
            }
        }
        /// <summary>
        /// Записывает строки правил из файла в <paramref name="rules"/>.
        /// </summary>
        /// <param name="rules">Список строковых данных для записи данных из файла (желательно пустой)</param>
        public void WriteRules(ref List<string> rules)
        {
            if (!File.Exists(rulesPath) || rules == null)
                return;

            using (BinaryReader rulesfile = new BinaryReader(File.Open(rulesPath, FileMode.Open)))
            {
                DateTime LastVersion = Convert.ToDateTime(rulesfile.ReadInt32() + rulesfile.ReadInt32());

                while (rulesfile.PeekChar() > -1)
                    rules.Add(rulesfile.ReadString());
            }
        }
        /// <summary>
        /// Записывает строки правил из файла в <paramref name="rules"/>.
        /// </summary>
        /// <param name="rules">Список строковых данных для записи данных из файла (желательно пустой)</param>
        /// <param name="LastVersion">Дата последнего обновления</param>
        public void WriteRules(ref List<string> rules, out DateTime LastVersion)
        {
            if (!File.Exists(rulesPath) || rules == null)
            {
                LastVersion = Convert.ToDateTime("0");
                return;
            }

            using (BinaryReader rulesfile = new BinaryReader(File.Open(rulesPath, FileMode.Open)))
            {
                LastVersion = Convert.ToDateTime(rulesfile.ReadString());

                while (rulesfile.PeekChar() > -1)
                    rules.Add(rulesfile.ReadString());
            }
        }
        #endregion
        /**********************************************************/
        #region Перегрузка операторов

        #endregion

        private void CreateEvent(string name, decimal enterPrice, GroupOfOrganiziers organizator)
        {
            this.entitling = name;
            this.enterPrice = enterPrice;
            this.organizator = organizator;
        }
    }
}
