using System;

namespace FO.Models
{
    public class DBClass : BaseVM
    {
        private Guid id = Guid.NewGuid();
        private string name = string.Empty;
        private string comment = string.Empty;

        public DBClass() { }
        public DBClass(string name, string comment)
        {
            this.name = name;
            this.comment = comment;
        }

        public Guid Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
        public string Comment
        {
            get => comment;
            set { comment = value; OnPropertyChanged(); }
        }
    }
}
