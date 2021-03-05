using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FO.Models
{
    public class Club : DBClass
    {
        private List<Dancer> membership = new List<Dancer>();
        private GroupOfOrganiziers group;
        private List<Teacher> teachers = new List<Teacher>();
        private string city = "";

        public Club() : base()
        {

        }
        public Club(string name, string comment) : base(name, comment)
        {
            group = new GroupOfOrganiziers(name, string.Empty);
        }
        public Club(string name)
        {
            city = GetCity(name);
            this.Name = GetName(name);
            this.Comment = "Восстановлен из excel";

            group = new GroupOfOrganiziers(Name, string.Empty);
        }

        public List<Dancer> Membership
        {
            get => membership;
            set { membership = value; OnPropertyChanged(); }
        }
        public List<Teacher> Teachers
        {
            get => teachers;
            set { teachers = value; OnPropertyChanged(); }
        }
        public GroupOfOrganiziers Group
        {
            get => group;
            set { group = value; OnPropertyChanged(); }
        }
        public string City
        {
            get => city;
            set { city = value; OnPropertyChanged(); }
        }

        public List<Dancer> GetAllDancers()
        {
            var dancers = new List<Dancer>(membership);
            var teachers = NewListDancer(this.teachers);

            foreach (var dancer in teachers)
                if (dancers.Contains(dancer))
                    dancers.Add(dancer);

            dancers.OrderBy(d => d.Person.Name);

            return dancers;
        }

        private List<Dancer> NewListDancer(List<Teacher> teachers)
        {
            var dancers = new List<Dancer>();

            foreach (var teacher in teachers)
                dancers.Add(teacher.Dancer);

            return dancers;
        }

        public override string ToString()
        {
            var city = !string.IsNullOrEmpty(this.city) ? $" (г.{this.city})" : "";

            return $"{Name}{city}";
        }

        public bool IsNamesEquals(string target)
        {
            if (CheckForExist(target))
            {
                if (target != this.ToString())
                    return false;
            }

            var equals = false;
            //N-Club => 2H-club
            //В-12 => 2H-club
            //''=>''
            if (this.ToString().ToLower().Contains("moveon".ToLower()) && target.ToLower().Contains("MoveOn".ToLower())) equals = false;
            else equals = false;

            /*
            var index = newData.Clubs.FindIndex(c => c.Name.ToLower() == target.ToLower());

            if ((index) > -1)
                return club.ToString().ToLower() == target.ToLower();
            */

            var brackets = false;
            var hasBrackets = false;
            var firstPart = false;
            var city1 = this.city.ToLower();
            var city2 = GetCity(target).ToLower();
            var name = this.Name;
            var targetName = GetName(target);

            if (!string.IsNullOrEmpty(city1) || !string.IsNullOrEmpty(city2))
            {
                hasBrackets = true;

                if (!string.IsNullOrEmpty(city1) && !string.IsNullOrEmpty(city2))
                    brackets = IsPartsEquals(city1, city2);
            }

            firstPart = IsNamesInPartsEquals(name, targetName);

            equals = hasBrackets ? firstPart && brackets : firstPart;

            /*
            if (target != ToString() && equals)
                Console.WriteLine($"{target} = {this}");
            if (equals && this.ToString() != target)
                Console.WriteLine(
                    $"********************************************\n" +
                    $"{target} => {this}" +
                    $"\n********************************************");
            */

            return equals;
        }
        private bool IsNamesInPartsEquals(string name, string targetName)
        {
            var parts = GetParts(RemoveSybols(name));
            var targetParts = GetParts(RemoveSybols(targetName));
            var matches = 0;
            var equal = true;

            //parts = RemoveSybols(parts);
            //targetParts = RemoveSybols(targetParts);

            if (parts.Length == 1 && targetParts.Length == 1)
                return IsPartsEquals(parts[0], targetParts[0]);

            foreach (var item in targetParts)
            {
                var equalItem = false;

                foreach (var targetItem in parts)
                {
                    equalItem |= IsPartsEquals(item, targetItem);

                    if (equalItem)
                        break;
                }

                equal &= equalItem;

                if (!equal) break;
            }

            return equal;
            //if (IsPartsEquals(item, targetItem))
            //matches++;

            //return (double)matches / Math.Max(parts.Length, targetParts.Length) > 0.5;
        }
        private string[] GetParts(string str) => str.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        private string[] RemoveSybols(string[] strs)
        {
            var newParts = new List<string>();

            foreach (var item in strs)
            {
                var part = item.Replace('"', ' ').Trim();
                newParts.Add(part.Replace('-', ' ').Trim());
            }

            return newParts.ToArray();
        }
        private string RemoveSybols(string str)
        {
            var newString = str.Replace('-', ' ');

            newString = newString.Replace('"', ' ');

            return newString;
        }
        private bool IsPartsEquals(string string1, string string2)
        {
            var firstPart1 = string1.Substring(0, string1.Length / 3);
            var firtPart2 = string2.Substring(0, string2.Length / 3);
            var secondPart1 = string1.Substring(string1.Length / 3, string1.Length / 3);
            var secondPart2 = string2.Substring(string2.Length / 3, string2.Length / 3);
            var thirdPart1 = string1.Substring(string1.Length / 3 + string1.Length / 3);
            var thirdPart2 = string2.Substring(string2.Length / 3 + string2.Length / 3);
            var matchs = 0;

            if (string1 == string2 && !string.IsNullOrEmpty(string1))
                return true;

            if (firstPart1 == firtPart2 && !string.IsNullOrEmpty(firstPart1))
                matchs++;

            if (secondPart1 == secondPart2 && !string.IsNullOrEmpty(secondPart1))
                matchs++;

            if (thirdPart1 == thirdPart2 && !string.IsNullOrEmpty(thirdPart1))
                matchs++;

            return (double)matchs / 3 > 0.6;
        }
        private string GetCity(string clubName)
        {
            var index = clubName.IndexOf('(');

            if (index == -1) return "";

            var name = clubName.Replace('(', ' ');
            name = name.Replace(')', ' ');
            name = name.Replace('"', ' ');
            name = name.Trim();

            index = name.LastIndexOf(' ');

            var city = name.Substring(index).Trim();

            if (city[0] == 'г')
                city = city.Substring(2);

            return city;
        }
        private string GetName(string clubName)
        {
            var index = clubName.IndexOf('(');

            if (index == -1)
                return clubName;

            return clubName.Substring(0, clubName.Length - (clubName.Length - index)).Trim();
        }
        private bool CheckForExist(string excelName)
        {
            var existClubs = new List<string>
            {
                "AT-Dance",
                "Daily dance",
                "N-Club",
                "2H-club"
            };

            return existClubs.Contains(excelName);
        }
    }
}
