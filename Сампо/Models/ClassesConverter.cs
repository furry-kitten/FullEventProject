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
    public static class ClassesConverter
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
        public static List<Partner> Convert(SPartner[] partners)
        {
            List<Partner> partners1 = new List<Partner>();

            foreach (var partner in partners)
                partners1.Add(Convert(partner));

            return partners1;
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
        public static SPartner[] Convert(List<Partner> partners)
        {
            List<SPartner> partners1 = new List<SPartner>();

            foreach (var partner in partners)
                partners1.Add(Convert(partner));

            return partners1.ToArray();
        }
    }
}
