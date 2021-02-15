using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO.Models.Rules
{
    internal class Accepted<T> : BaseRule
    {
        private T item;

        public Accepted(string name, string decription) : base(name, decription)
        {
        }

        public virtual bool Accept(T item) => true;
    }
}
