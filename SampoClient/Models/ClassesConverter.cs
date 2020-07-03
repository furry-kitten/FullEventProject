using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SSampo = SampoClient.HostingSampo.Sampo;
using SPartner = SampoClient.HostingSampo.Partner;
using SGender = SampoClient.HostingSampo.Gender;
using SampoClient.Models.Перечисления;
using System.Collections.ObjectModel;

namespace SampoClient.Models
{
    internal static class ClassesConverter
    {

        public static Gender Convert(SGender gender)
        {
            Gender sGender = Gender.Male;

            switch (gender)
            {
                case SGender.Male: sGender = Gender.Male; break;
                case SGender.Female: sGender = Gender.Female; break;
            }

            return sGender;
        }
        public static Partner Convert(SPartner partner) => new Partner(partner.Name, partner.Surname, Convert(partner.Gender), partner.Phone, partner.IDsha)
        {
            ID = partner.ID
        };
        public static Sampo Convert(SSampo sampo) => new Sampo(sampo.Entitling, sampo.Price, sampo.Organizator)
        {
            Currency = sampo.Currency,
            Rules = sampo.Rules,
            Location = sampo.Location,
            Liders = Convert(sampo.Liders),
            Followers = Convert(sampo.Followers)
        };
        public static ObservableCollection<Partner> Convert(SPartner[] partners)
        {
            ObservableCollection<Partner> partners1 = new ObservableCollection<Partner>();

            foreach (var partner in partners)
                partners1.Add(Convert(partner));

            return partners1;
        }
        public static ObservableCollection<Sampo> Convert(SSampo[] sampos)
        {
            var list = new ObservableCollection<Sampo>();

            foreach (var sampo in sampos)
                list.Add(Convert(sampo));

            return list;
        }
        public static SGender Convert(Gender gender)
        {
            SGender sGender = SGender.Male;

            switch (gender)
            {
                case Gender.Male: sGender = SGender.Male; break;
                case Gender.Female: sGender = SGender.Female; break;
            }

            return sGender;
        }
        public static SPartner Convert(Partner partner) => new SPartner
        {
            Name = partner.Name,
            Surname = partner.Surname,
            Gender = Convert(partner.Gender),
            Phone = partner.Phone,
            IDsha = partner.IDsha,
            ID = partner.ID
        };
        public static SSampo Convert(Sampo sampo) => new SSampo
        {
            Entitling = sampo.Entitling,
            Organizator = sampo.Organizator,
            Price = sampo.Price,
            Currency = sampo.Currency,
            Rules = sampo.Rules,
            Location = sampo.Location,
            Liders = Convert(sampo.Liders),
            Followers = Convert(sampo.Followers)
        };
        public static SPartner[] Convert(ObservableCollection<Partner> partners)
        {
            ObservableCollection<SPartner> partners1 = new ObservableCollection<SPartner>();

            foreach (var partner in partners)
                partners1.Add(Convert(partner));

            return partners1.ToArray();
        }
        public static SSampo[] Convert(ObservableCollection<Sampo> sampos)
        {
            ObservableCollection<SSampo> sampos1 = new ObservableCollection<SSampo>();

            foreach (var partner in sampos)
                sampos1.Add(Convert(partner));

            return sampos1.ToArray();
        }
        public static SPartner[] Convert(List<Partner> partners)
        {
            List<SPartner> partners1 = new List<SPartner>();

            foreach (var partner in partners)
                partners1.Add(Convert(partner));

            return partners1.ToArray();
        }
        public static SSampo[] Convert(List<Sampo> sampos)
        {
            List<SSampo> sampos1 = new List<SSampo>();

            foreach (var partner in sampos)
                sampos1.Add(Convert(partner));

            return sampos1.ToArray();
        }
    }
}
