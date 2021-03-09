using FO.Models.Перечисления;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FO.Models
{
    public class Dancer : DBClass
    {
        #region Переменные
        private int
            idsha = -1;

        private List<Classes> classes = new List<Classes>();
        private Person person;
        private Teacher teacher;
        private List<Event> eventSubList = new List<Event>();
        private List<Club> clubs = new List<Club>();
        private List<LastEventsChanges> lastEventsChanges = new List<LastEventsChanges>();
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
        public Teacher Teacher
        {
            get => teacher;
            set { teacher = value; OnPropertyChanged(); }
        }
        public Person Person
        {
            get => person;
            set { person = value; OnPropertyChanged(); }
        }
        public List<Club> Clubs
        {
            get => clubs;
            set { clubs = value; OnPropertyChanged(); }
        }
        public List<Classes> Classes
        {
            get => classes;
            set { classes = value; OnPropertyChanged(); }
        }
        public Guid PersonId { get; set; }
        public Guid? TeacherId { get; set; }
        public List<LastEventsChanges> LastEventsChanges
        {
            get => lastEventsChanges;
            set { lastEventsChanges = value; OnPropertyChanged(); }
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
                Console.WriteLine($"{e.Message}\n" +
                    $"{e.InnerException.Message}");

                return false;
            }

            if (dancer == null)
                dancer = new Dancer();

            return dancer.IDsha == this.idsha;
        }
        public Classes[] GetCurrentClasses()
        {
            Classes[] currentClass = new Classes[2];
            var classes = this.classes.OrderBy(c => c.SHAClasses.Significance).ToList();
            var jnj = classes.Where(c => c.SHAClasses.Direction == Direction.JnJ).ToList();
            var classic = classes.Where(c => c.SHAClasses.Direction == Direction.Classic).ToList();

            return currentClass;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            //var stringGender = gender == Gender.Female ? "Женский" : "Мужской";
            var ranking = string.Empty;
            var stringClubs = "Клуб(ы):\t";

            if (!(classes == null || classes.Count == 0))
            {
                ranking = "\nРейтинг АСХ\n";
                var jnj = classes.Where((c) => c.SHAClasses.Direction == Direction.JnJ).ToList();
                var classic = classes.Where((c) => c.SHAClasses.Direction == Direction.Classic).ToList();

                if (jnj.Count > 0)
                {
                    ranking += "JnJ:";

                    foreach (var jnjClass in jnj)
                        ranking += $"\n\t\t{jnjClass}";

                    ranking += "\n";
                }

                if (classic.Count > 0)
                {
                    ranking += "Классика:";

                    foreach (var classicClass in classic)
                        ranking += $"\n\t\t{classicClass}";

                    ranking += "\n";
                }
            }

            foreach (var club in clubs)
                stringClubs += $" {club}";
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
                $"\n{stringClubs}" +
                $"{ranking}";
        }
    }
}
