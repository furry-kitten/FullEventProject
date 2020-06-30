using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SPartner = Сампо.HostingSampo.Partner;
using Сампо.HostingSampo;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.Native;

namespace Сампо.Models
{
    internal class Authentication
    {
        private ForOrganizatorsClient client;
        
        public Authentication()
        {
            client = new ForOrganizatorsClient();
        }
        public Authentication(ForOrganizatorsClient client)
        {
            this.client = client;
        }

        public ForOrganizatorsClient Client => client;

        public bool Authenticate(int IDsha, string password, out SPartner partner) => client.AuthorizationWithIDsha(IDsha, password, out partner);
        public bool Authenticate(string login, string password, out SPartner partner) => client.AuthorizationWithLogin(login, password, out partner);
        public Sampo GetSampo(int id) => client.GetSampo(id);
        public List<Sampo> GetSampoList(string city) => ClassesConverter.Convert(client.GetSampoList(city)).ToList();
        public ObservableCollection<Sampo> GetSampoColletion(string city) => ClassesConverter.Convert(client.GetSampoList(city)).ToObservableCollection();
        public ObservableCollection<Partner> GetPartners(string firstname, string secondname) => ClassesConverter.Convert(client.GetAllPartners(firstname, secondname));
        public ObservableCollection<Partner> GetPartners(string firstname, string secondname, string patronymic) => ClassesConverter.Convert(client.GetPartners(firstname, secondname, patronymic));
    }
}
