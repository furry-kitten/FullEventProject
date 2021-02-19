using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models
{
    public class Dancer : DBClass
    {
        #region Переменные
        private int
            idsha = -1;

        private List<Classes> classes = new List<Classes>();
        private Person person;
        private List<Event> eventSubList;
        #endregion
        //===========================================================================================
        #region Конструкторы
        public Dancer() { }
        /// <summary>
        /// Создаёт экземпляр класса Dancer
        /// </summary>
        /// <param name="person">Информация о личночти</param>
        /// <param name="idsha">ID АСХ танцора в таблице танцоров хастла</param>
        public Dancer(Person person, int idsha)
        {
            this.person = person;
            this.idsha = idsha;
        }
        #endregion
        //===========================================================================================
        #region Поля класса
        /// <summary>
        /// Возвращает номер АСХ танцора
        /// Возвращает -1, если номер не указан
        /// </summary>
        public int IDsha
        {
            get => idsha;
            set { idsha = value;OnPropertyChanged(); }
        }
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
        public Person Person
        {
            get => person;
            set { person = value; OnPropertyChanged(); }
        }
        public List<Classes> Classes
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }
        public Guid PersonKey { get; set; }
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
            //var stringGender = gender == Gender.Female ? "Женский" : "Мужской";
            var ranking = string.Empty;

            if (!(classes == null || classes.Count == 0))
            {
                ranking = "\nРейтинг АСХ\n";
                var jnj = classes.Where((c) => c.SHAClasses.Direction == Direction.JnJ).ToList();
                var classic = classes.Where((c) => c.SHAClasses.Direction == Direction.Classic).ToList();

                if (jnj.Count > 0)
                {
                    ranking += "JnJ:\t\t";

                    foreach (var jnjClass in jnj)
                        ranking += $"{jnjClass} ";

                    ranking += "\n";
                }

                if (classic.Count > 0)
                {
                    ranking += "Классика:\t";

                    foreach (var classicClass in classic)
                        ranking += $"{classicClass} ";

                    ranking += "\n";
                }
            }

            /*
            return
                $"Номер АСХ:\t{idsha}\n" +
                $"ФИО:\t\t{Name} {surname} {patronym}\n" +
                $"Пол:\t\t{stringGender}\n" +
                $"Рейтинг\t\tАСХ\n" +
                $"JnJ:\t\t{}{}\n" +
                $"Классика:\t\t{}{}\n" +
                $"Телефон:\t{phone}\n";
            */
            return
                $"Номер АСХ:\t{idsha}\n" +
                $"{person}" +
                $"{ranking}";
        }
    }
}
