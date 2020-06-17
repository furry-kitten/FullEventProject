using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сампо.Models
{
    public class Partner : BaseVM
    {
        private int id;
        private string name;
        private string surname;
        private int phone = -1;
        private int idsha = -1;
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
            set { id = value; }
        }
            
        /// <summary>
        /// Задаёт/возвращает имя танцора
        /// </summary>
        public string Name
        {
            get => name;
            set { name = value; }
        }

        /// <summary>
        /// Задаёт/возвращает фамилию
        /// </summary>
        public string Surname
        {
            get => surname;
            set { surname = value; }
        }

        /// <summery>
        /// Задаёт/возвращает телефон танцора
        /// Возвращает -1, если номер не указан
        /// </summery>
        public int Phone
        {
            get => phone;
            set { phone = value; }
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
    }
}
