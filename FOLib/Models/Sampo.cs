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
        private decimal price;
        private string rulesPath;
        private string location;
        private string currency = "RUB";
        private char shortCurrency = 'р';

        private Dancer organizator;
        private List<Dancer> boys = new List<Dancer>();
        private List<Dancer> ladiese = new List<Dancer>();
        #endregion
        /**********************************************************/
        #region Конструкторы
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="price">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        public Event(string name, decimal price, Dancer organizator)
        {
            this.entitling = name;
            this.price = price;
            this.organizator = organizator;
        }
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="price">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        /// <param name="rules">Пусть к файлу с правилами сампо</param>
        public Event(string name, decimal price, Dancer organizator, string rules)
        {
            this.entitling = name;
            this.price = price;
            this.organizator = organizator;
            this.rulesPath = rules;
        }
        /// <summary>
        /// Создает новый экземпляр класса Event
        /// </summary>
        /// <param name="name">Название сампо</param>
        /// <param name="price">Стоимость сампо</param>
        /// <param name="organizator">Организатор сампо</param>
        /// <param name="rules">Пусть к файлу с правилами сампо</param>
        /// <param name="location">Адрес проведение сампо</param>
        public Event(string name, decimal price, Dancer organizator, string rules, string location)
        {
            this.entitling = name;
            this.price = price;
            this.organizator = organizator;
            this.rulesPath = rules;
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
        public Dancer Organizator
        {
            get => organizator;
            set
            {
                organizator = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Задаёт/возвращает стоимость сампо
        /// </summary>
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Задаёт/возвращает путь к файлу с правилами
        /// </summary>
        public string Rules
        {
            get => rulesPath;
            set { rulesPath = value; }
        }
        /// <summary>
        /// Задаёт/возвращает адрес места проведения сампо
        /// </summary>
        public string Location
        {
            get => location;
            set { location = value; }
        }
        /// <summary>
        /// Возвращает/задаёт валюту для сампо
        /// </summary>
        public string Currency
        {
            get => currency;
            set { currency = value; }
        }
        public List<Dancer> Liders
        {
            get => boys;
            set { boys = value; OnPropertyChanged(); }
        }
        public List<Dancer> Followers
        {
            get => ladiese;
            set { ladiese = value; OnPropertyChanged(); }
        }
        #endregion
        /**********************************************************/
        #region Методы класса
        /// <summary>
        /// Добавляет танцора в список сампо
        /// </summary>
        /// <param name="dancer">Экземпляр класса Parther</param>
        public void AddNewDancer(Dancer dancer)
        {
            if (dancer != null && dancer.Gender == Gender.Female)
                ladiese.Add(dancer);
            else
                boys.Add(dancer);
        }
        /// <summary>
        /// Возвращает список танцоров в зависимости от пола
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public List<Dancer> GetDancerList(Gender gender) => gender == Gender.Male ? boys : ladiese;
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
    }
}
