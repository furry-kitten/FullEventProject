using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SSampo = Сампо.HostingSampo.Sampo;
using SPartner = Сампо.HostingSampo.Partner;
using SGender = Сампо.HostingSampo.Gender;
using Сампо.Models.Перечисления;

namespace Сампо.Models
{
    public class Partner : BaseVM
    {
        private int
            id,
            classicPoint = 0,
            jnjPoint = 0;
        private ClassicClasses classicClasses = ClassicClasses.E;
        private JnJClasses jnjClasses = JnJClasses.Begginer;
        private string
            name,
            surname;

        private int
            phone = -1,
            idsha = -1;

        private Gender gender;
        private List<int> sampoIDs;

        //===========================================================================================

        /// <summary>
        /// Создаёт экземпляр класса Partner
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        public Partner(string name, string surname, Gender gender)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
        }

        /// <summary>
        /// Создаёт экземпляр класса Partner
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        /// <param name="phone">Контактный телефон танцора</param>
        public Partner(string name, string surname, Gender gender, int phone)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.phone = phone;
        }

        /// <summary>
        /// Создаёт экземпляр класса Partner
        /// </summary>
        /// <param name="name">Имя танцора</param>
        /// <param name="surname">Фамилия танцора</param>
        /// <param name="gender">Пол танцора</param>
        /// <param name="phone">Контактный телефон танцора</param>
        /// <param name="idsha">ID АСХ танцора в таблице танцоров хастла</param>
        public Partner(string name, string surname, Gender gender, int phone, int idsha)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.phone = phone;
            this.idsha = idsha;
        }

        //===========================================================================================
        /// <summary>
        /// Задаёт/возвращает id танцора
        /// </summary>
        public int ID
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает имя танцора
        /// </summary>
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает фамилию
        /// </summary>
        public string Surname
        {
            get => surname;
            set { surname = value; OnPropertyChanged(); }
        }
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
        /// Возвращает номер АСХ танцора
        /// Возвращает -1, если номер не указан
        /// </summary>
        public int IDsha => idsha;
        /// <summary>
        /// Возвращает пол танцора
        /// </summary>
        public Gender Gender => gender;
        /**********************************************************/
        #region Перегрузка операторов
        public static implicit operator Partner(SPartner partner) => ClassesConverter.Convert(partner);
        public static implicit operator SPartner(Partner partner) => ClassesConverter.Convert(partner);
        #endregion
    }
}
