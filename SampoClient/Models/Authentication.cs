using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.Mvvm.Native;
using FO.Models;

namespace SampoClient.Models
{
    internal class Authentication : BaseVM
    {
        int idsha;
        string
            login,
            password;
        //private ForOrganizatorsClient client;
        private Dancer dancer;

        /*
        public Authentication()
        {
            client = new ForOrganizatorsClient("NetTcpBinding_IForOrganizators");
        }
        public Authentication(ForOrganizatorsClient client)
        {
            this.client = client;
        }
        */

        public int IDsha
        {
            get => idsha;
            set { idsha = value; OnPropertyChanged(); }
        }
        public string Login
        {
            get => login;
            set { login = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }
        //public ForOrganizatorsClient Client => client;
        public Dancer Dancer => dancer;

        /*
        public bool Authenticate()
            => client.AuthorizationWithIDsha(Dancer.IDsha, password, out Dancer);
        public bool Authenticate(int IDsha, string password)
            => client.AuthorizationWithIDsha(IDsha, password, out Dancer);
        public bool Authenticate(string login, string password)
            => client.AuthorizationWithLogin(login, password, out Dancer);
        public Sampo GetSampo(int id)
            => client.GetSampo(id);
        */
    }
}
