using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    public class Accepted<T> : BaseRule
    {
        private T item;

        public Accepted()
        {
        }
        public Accepted(string name, string decription) : base(name, decription)
        {
        }

        public T MainParametr
        {
            get => item;
            set { item = value; OnPropertyChanged(); }
        }

        public virtual bool Accept(T item) => true;
        public virtual Accepted<T> GenerateRule() => new Accepted<T>();
    }
}
