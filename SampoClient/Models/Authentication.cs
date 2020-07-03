using SampoClient.HostingSampo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SPartner = SampoClient.HostingSampo.Partner;
using SGender = SampoClient.HostingSampo.Gender;
using DevExpress.Mvvm.Native;

namespace SampoClient.Models
{
    internal class Authentication : BaseVM
    {
        int idsha;
        string
            login,
            password;
        private ForOrganizatorsClient client;
        private SPartner partner;

        public Authentication()
        {
            client = new ForOrganizatorsClient();
        }
        public Authentication(ForOrganizatorsClient client)
        {
            this.client = client;
        }

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
        public ForOrganizatorsClient Client => client;
        public Partner Partner => partner;

        public bool Authenticate()
            => client.AuthorizationWithIDsha(partner.IDsha, password, out partner);
        public bool Authenticate(int IDsha, string password)
            => client.AuthorizationWithIDsha(IDsha, password, out partner);
        public bool Authenticate(string login, string password)
            => client.AuthorizationWithLogin(login, password, out partner);
        public Sampo GetSampo(int id)
            => client.GetSampo(id);
        public List<Sampo> GetSampoList(string city)
            => ClassesConverter.Convert(client.GetSampoList(city)).ToList();
        public ObservableCollection<Sampo> GetSampoColletion(string city)
            => ClassesConverter.Convert(client.GetSampoList(city)).ToObservableCollection();
        public ObservableCollection<Partner> GetPartners(string firstname, string secondname)
            => ClassesConverter.Convert(client.GetAllPartners(firstname, secondname));
        public ObservableCollection<Partner> GetPartners(string firstname, string secondname, string patronymic)
            => ClassesConverter.Convert(client.GetPartners(firstname, secondname, patronymic));
    }
}
