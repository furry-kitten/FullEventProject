using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ForOrganizators.Models.Перечисления;

namespace ForOrganizators.Models
{
    [DataContract]
    public class Partner : BaseVM
    {
        private int 
            id,
            classicPoint = 0,
            jnjPoint = 0,
            phone = -1,
            idsha = -1;
        private ClassicClasses currentClassicClass = ClassicClasses.E;
        private JnJClasses currentJnJClass = JnJClasses.Begginer;
        private string
            name,
            surname;

        private Gender gender;
        private List<int> sampoSubList;

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
        [DataMember]
        public int ID 
        { 
            get => id; 
            set { id = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает имя танцора
        /// </summary>
        [DataMember]
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает фамилию
        /// </summary>
        [DataMember]
        public string Surname
        {
            get => surname;
            set { surname = value; OnPropertyChanged(); }
        }
        /// <summery>
        /// Задаёт/возвращает телефон танцора
        /// Возвращает -1, если номер не указан
        /// </summery>
        [DataMember]
        public int Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает номер АСХ танцора
        /// Возвращает -1, если номер не указан
        /// </summary>
        [DataMember]
        public int IDsha => idsha;
        /// <summary>
        /// Возвращает текущие баллы в текущем классе
        /// </summary>
        [DataMember]
        public int PointsInClassic
        {
            get => classicPoint;
            set { classicPoint = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает текущие баллы в текущем классе
        /// </summary>
        [DataMember]
        public int PointsInJnJ
        {
            get => jnjPoint;
            set { jnjPoint = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Возвращает пол танцора
        /// </summary>
        [DataMember]
        public Gender Gender => gender;
        /// <summary>
        /// Задаёт/возвращает текущий класс танцора в классике
        /// </summary>
        [DataMember]
        public ClassicClasses CurrentClassicClass
        {
            get => currentClassicClass;
            set { currentClassicClass = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает текущий класс танцора в днд
        /// </summary>
        [DataMember]
        public JnJClasses CurrentJnJClass
        {
            get => currentJnJClass;
            set { currentJnJClass = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// Задаёт/возвращает список сампо, но которые подписан танцор
        /// </summary>
        [DataMember]
        public List<int> SampoSubList
        {
            get => sampoSubList;
            set { sampoSubList = value; OnPropertyChanged(); }
        }
    }
}
