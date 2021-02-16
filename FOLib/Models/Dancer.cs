using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FO.Models.Перечисления;

namespace FO.Models
{
    public class Dancer : DBClass
    {
        #region Переменные
        private string
            surname,
            patronym;

        private int
            phone = -1,
            idsha = -1;

        //private List<Classes> classes = new List<Classes>();
        private Gender gender;
        private List<Event> eventSubList;
        #endregion
        //===========================================================================================
        #region Конструкторы
        /// <summary>
        /// Создаёт экземпляр класса Dancer
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        public Dancer(string name, string surname, Gender gender)
        {
            Name = name;
            this.surname = surname;
            this.gender = gender;
        }
        /// <summary>
        /// Создаёт экземпляр класса Dancer
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        /// <param name="phone">Контактный телефон танцора</param>
        public Dancer(string name, string surname, Gender gender, int phone)
        {
            this.Name = name;
            this.surname = surname;
            this.gender = gender;
            this.phone = phone;
        }
        /// <summary>
        /// Создаёт экземпляр класса Dancer
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        /// <param name="phone">Контактный телефон танцора</param>
        /// <param name="idsha">ID АСХ танцора в таблице танцоров хастла</param>
        public Dancer(string name, string surname, Gender gender, int phone, int idsha)
        {
            this.Name = name;
            this.surname = surname;
            this.gender = gender;
            this.phone = phone;
            this.idsha = idsha;
        }
        #endregion
        //===========================================================================================
        #region Поля класса
        /// <summary>
        /// Возвращает номер АСХ танцора
        /// Возвращает -1, если номер не указан
        /// </summary>
        public int IDsha => idsha;
        /// <summery>
        /// Задаёт/возвращает телефон танцора
        /// Возвращает -1, если номер не указан
        /// </summery>
        public int Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает фамилию
        /// </summary>
        public string Surname
        {
            get => surname;
            set { surname = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает Отчество
        /// </summary>
        public string Patronym
        {
            get => patronym;
            set { patronym = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает пол танцора
        /// </summary>
        public Gender Gender => gender;
        /// <summary>
        /// Задаёт/возвращает текущий класс танцора в классике
        /// </summary>
        /*
        public List<Classes> Currentclasses
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }
        */
        /// <summary>
        /// Задаёт/возвращает список сампо, нa которые подписан танцор
        /// </summary>
        public List<Event> EventSubList
        {
            get => eventSubList;
            set { eventSubList = value; OnPropertyChanged(); }
        }
        #endregion
        /**********************************************************/
        #region Перегрузка операторов

        #endregion

        public override bool Equals(object obj)
        {
            Dancer dancer;
            try
            {
                dancer = obj as Dancer;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

            return dancer.IDsha == this.idsha;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var stringGender = gender == Gender.Female ? "Женский" : "Мужской";

            return
                $"Номер АСХ:\t{idsha}\n" +
                $"ФИО:\t\t{Name} {surname} {patronym}\n" +
                $"Пол:\t\t{stringGender}\n" +/*
                $"Рейтинг\t\tАСХ\n" +
                $"JnJ:\t\t{}{}\n" +
                $"Классика:\t\t{}{}\n" +*/
                $"Телефон:\t{phone}\n";
        }
    }
}
