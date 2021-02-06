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
        private int
            classicPoint = 0,
            jnjPoint = 0;

        private string
            surname;

        private int
            phone = -1,
            idsha = -1;

        private List<Classes> classes = new List<Classes>();
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
        /// Возвращает текущие баллы в текущем классе
        /// </summary>
        public int PointsInClassic
        {
            get => classicPoint;
            set { classicPoint = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает текущие баллы в текущем классе
        /// </summary>
        public int PointsInJnJ
        {
            get => jnjPoint;
            set { jnjPoint = value; OnPropertyChanged(); }
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
        /// Возвращает пол танцора
        /// </summary>
        public Gender Gender => gender;
        /// <summary>
        /// Задаёт/возвращает текущий класс танцора в классике
        /// </summary>
        public List<Classes> Currentclasses
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }
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
    }
}
