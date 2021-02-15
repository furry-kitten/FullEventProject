using FO.Models;
using FO.Models.Перечисления;

using SampoClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampoClient.ViewModels
{
    public class GroupViewModel : BaseVM
    {
        /*
         * Создать список танцоров
         */
        private Event selectedEvent;
        private List<Dancer>
            liders = new List<Dancer>
            {
                new Dancer("Name", "Surname", Gender.Male),
                new Dancer("Name1",  "Surname1",  Gender.Male),
                new Dancer("Name2",  "Surname2",  Gender.Male)
            },
            folowers = new List<Dancer>
            {
                new Dancer("FName", "FSurname", Gender.Male),
                new Dancer("FName1",  "FSurname1",  Gender.Male),
                new Dancer("FName2",  "FSurname2",  Gender.Male)
            };

        public GroupViewModel()
        {
            selectedEvent = new Event("Название", 200, new Dancer("FName2", "FSurname2", Gender.Male));
            selectedEvent.Liders = liders;
            selectedEvent.Followers = folowers;
        }

        public Event SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged();
            }
        }
    }
}
