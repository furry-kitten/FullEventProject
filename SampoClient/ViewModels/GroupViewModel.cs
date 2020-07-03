using SampoClient.Models;
using SampoClient.Models.Перечисления;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampoClient.ViewModels
{
    public class GroupViewModel : Models.BaseVM
    {
        /*
         * Создать список танцоров
         */
        private Sampo selectedSampo;
        private ObservableCollection<Partner>
            liders = new ObservableCollection<Partner>
            {
                new Partner("Name", "Surname", Gender.Male),
                new Partner("Name1",  "Surname1",  Gender.Male),
                new Partner("Name2",  "Surname2",  Gender.Male)
            },
            folowers = new ObservableCollection<Partner>
            {
                new Partner("FName", "FSurname", Gender.Male),
                new Partner("FName1",  "FSurname1",  Gender.Male),
                new Partner("FName2",  "FSurname2",  Gender.Male)
            };

        public GroupViewModel()
        {
            selectedSampo = new Sampo("Название", 200, 1);
            selectedSampo.Liders = liders;
            selectedSampo.Followers = folowers;
        }

        public Sampo SelectedSampo
        {
            get => selectedSampo;
            set
            {
                selectedSampo = value;
                OnPropertyChanged();
            }
        }
    }
}
