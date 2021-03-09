using FO.Models.ForClient;
using EPPlusTest;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OfficeOpenXml;
using Newtonsoft.Json;
using DBLib.Masters;
using FO.Models.Перечисления;

namespace FO.Models
{
    public class DBRefreshing
    {
        private AllData allData,
            newData = new AllData();

        private string
            clubs = "клубы", lastClubColumnValue = "Комментарий",
            dancersList = "список танцоров", lastDancerColumnValue = "Баллы\nДнД",
            classic = "rating", lastClassicColumnValue = "A",
            jnj = "rating ДнД", lastJnJColumnValue = "Ch";
        private Dictionary<Dancer, string> needToAdd = new Dictionary<Dancer, string>();

        public DBRefreshing(AllData data)
        {
            allData = data;
            newData.SHAClasses = data.SHAClasses;
        }

        public AllData NewData => newData;

        public AllData Refresh(string filePath)    //  C:\Users\tokar\Downloads\dancers.xlsm
        {
            Console.WriteLine("Refreshing data base is starting...");

            FileInfo fileInfo = new FileInfo(filePath);

            SerializeDataAsinc(allData);

            Console.WriteLine($"Opening the Excel file from {filePath}");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(fileInfo))
            {
                Console.WriteLine($"Reading the Excel file");
                
                Console.WriteLine($"Reading clubs");
                newData.Clubs = ReadClubs(package, package.Workbook.Worksheets[clubs]);
                
                Console.WriteLine($"Reading dancers");
                newData.Dancers = ReadDancers(package, package.Workbook.Worksheets[dancersList]);
                
                Console.WriteLine($"Writing clesses to dancers");
                GetClassesToDancers(package, package.Workbook.Worksheets.Where(ws=>ws.Name == classic || ws.Name == jnj).ToList());
            }

            newData.SHAClasses = allData.SHAClasses;
            Console.WriteLine($"Data from data base is already copied!");

            try
            {
                Console.WriteLine($"Trying to call master");

                var helper = new DBHelper();

                helper.RefreshDB(newData);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Some problems...\n" +
                    $"{e.Message}\n" +
                    $"{e.InnerException.Message}");
            }

            SerializeDataAsinc(newData, "NewData");

            return newData;
        }

        private Dictionary<int, string[]> ReadData(ExcelWorksheet worksheet, string lastCoulumnValue, int startRow)
        {
            var boundary = GetBoundary(worksheet, lastCoulumnValue, startRow);
            var captions = GetCaptions(worksheet, startRow- 1, boundary[1]);
            var lines = GetLines(worksheet, startRow, boundary);

            return lines;
        }
        private void GetClassesToDancers(ExcelPackage package, List<ExcelWorksheet> worksheet)
        {
            var row = 13;
            var classic = ReadData(worksheet.Find(ws=> ws.Name == this.classic), lastClassicColumnValue, row);
            var jnj = ReadData(worksheet.Find(ws => ws.Name == this.jnj), lastJnJColumnValue, row);
            var count = Math.Min(classic.Values.Count, jnj.Values.Count);

            for (int i = 0; i < count; i++)
            {
                var numRow = i + row;
                var data = classic[numRow];
                var data1 = jnj[numRow];
                var idSHA = int.Parse(data[0]);
                var dancer = newData.Dancers.Find(d => d.IDsha == idSHA);

                var classes = new List<Classes>
                {
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "E"),
                        Points = byte.Parse(data[5]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "D"),
                        Points = byte.Parse(data[6]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "C"),
                        Points = byte.Parse(data[7]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "B"),
                        Points = byte.Parse(data[8]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "A"),
                        Points = byte.Parse(data[9]),
                        Dancer = dancer
                    }
                };

                idSHA = int.Parse(data1[0]);
                dancer = newData.Dancers.Find(d => d.IDsha == idSHA);
                classes.AddRange(new List<Classes>
                {
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "Begginer"),
                        Points = byte.Parse(data1[5]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "Rising Star"),
                        Points = byte.Parse(data1[6]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "Main"),
                        Points = byte.Parse(data1[7]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "Star"),
                        Points = byte.Parse(data1[8]),
                        Dancer = dancer
                    },
                    new Classes
                    {
                        SHAClasses = newData.SHAClasses.Find(c=>c.Name == "Champion"),
                        Points = byte.Parse(data1[9]),
                        Dancer = dancer
                    }
                });

                var jnjDancer = classes.Where(c => c.SHAClasses.Direction == Direction.JnJ).OrderBy(c=>c.SHAClasses.Significance).ToList();
                var classicDancer = classes.Where(c => c.SHAClasses.Direction == Direction.Classic).OrderBy(c => c.SHAClasses.Significance).ToList();
                var newClasses = new List<Classes>();

                if(newClasses.Find(c=> c.Points > 0) != null)
                    for (int c = jnjDancer.Count - 1; c >= 0; c--)
                    {
                        if (jnjDancer[c].Points > 0 || newClasses.Where(c => c.SHAClasses.Direction == Direction.JnJ).ToList().Count > 0)
                            newClasses.Add(jnjDancer[c]);

                        if (classicDancer[c].Points > 0 || newClasses.Where(c => c.SHAClasses.Direction == Direction.Classic).ToList().Count > 0)
                            newClasses.Add(classicDancer[c]);
                    }

                if (newClasses.Where(c => c.SHAClasses.Direction == Direction.JnJ).OrderBy(c => c.SHAClasses.Significance).ToList().Count == 0)
                    newClasses.Add(jnjDancer.Find(c=>c.SHAClasses.Significance == 1));

                if (newClasses.Where(c => c.SHAClasses.Direction == Direction.Classic).OrderBy(c => c.SHAClasses.Significance).ToList().Count == 0)
                    newClasses.Add(classicDancer.Find(c => c.SHAClasses.Significance == 1));

                newData.Classes.AddRange(newClasses.OrderBy(c=>c.SHAClasses.Direction).ThenBy(c=>c.SHAClasses.Significance));
                dancer.Classes.AddRange(newClasses.OrderBy(c => c.SHAClasses.Direction).ThenBy(c => c.SHAClasses.Significance));
            }
        }
        private List<Club> ReadClubs(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var clubs = new List<Club>();
            var startCell = new int[] { 2, 6 };//  ячейка G6
            var lines = ReadData(worksheet, lastClubColumnValue, 2);

            foreach (var item in lines)
            {
                var data = item.Value;

                clubs.Add(GetClub(data));
            }

            clubs.OrderBy(c => c.Name);

            Console.WriteLine($"Clubs added: {clubs.Count}");

            return clubs;
        }
        private List<Dancer> ReadDancers(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var dancers = new List<Dancer>();
            var startCell = new int[] { 3, 10 };//  ячейка J3
            var lines = ReadData(worksheet, lastDancerColumnValue, 3);

            foreach (var item in lines)
            {
                var data = item.Value;
                var snp = GetSNP(data[1]);
                var person = GetPerson(snp);
                var dancerClubs = data[4].Split(',');
                var idsha = int.Parse(data[0]);
                List<Club> subClubs = new List<Club>();

                if (idsha == 2656)
                    idsha = int.Parse(data[0]);

                person.Gender = data[7] == "м" ? Gender.Male : Gender.Female;

                var dancer = new Dancer
                {
                    IDsha = idsha,
                    Person = person,
                    PersonId = person.Id,
                    Clubs = subClubs
                };
                dancers.Add(dancer);

                foreach (var club in dancerClubs)
                {
                    //var dc = newData.Clubs.Find(c => IsNamesEquals(c.Name, club));
                    var dc = newData.Clubs.Find(c => c.IsNamesEquals(club));

                    if (dc == null)
                    {
                        //Console.WriteLine($"The club with name {club} is not exist");
                        needToAdd.Add(dancer, club);

                        continue;
                    }
                    else
                    {
                        //Console.WriteLine($"{club} = {dc}");
                    }

                    subClubs.Add(dc);
                }

                foreach (var club in subClubs)
                {
                    club.Membership.Add(dancer);
                }
            }

            Console.WriteLine($"Dancers added: {dancers.Count}");

            if (needToAdd.Count > 0)
            { var message = "";

                foreach (var value in needToAdd.Values.Distinct())
                {
                    message += $"\nNeed to add manual '{value}' into dancer(es) subscribe list with id(s) ";

                    foreach (var key in needToAdd.Where(nta => nta.Value == value))
                    {
                        message += $" {key.Key.IDsha} ";
                    }
                }

                Console.WriteLine($"{message}");

                using (var file = new StreamWriter("Need To Add Manual", false, Encoding.UTF8))
                {
                    var ntam = JsonConvert.SerializeObject(needToAdd);
                    
                    file.WriteLine(ntam);
                }
            }
            else
                needToAdd = null;

            return dancers;
        }
        private string GetCity(string clubName)
        {
            var index = clubName.IndexOf('г') + 2;

            if (index == -1)
                index = clubName.IndexOf('(');

            if (index == -1)
                return "";

            var city = clubName.Substring(index);

            city = city.Replace('(', ' ').TrimStart();
            city = city.Replace(')', ' ').TrimEnd();

            return city;
        }
        private string GetName(string clubName)
        {
            var index = clubName.IndexOf('(');

            if (index == -1)
                return clubName;

            return clubName.Substring(0, clubName.Length - (clubName.Length - index)).Trim();
        }
        private Club GetClub(string[] data)
        {
            /*
            var club = new Club
            {
                Name = data[1]
            };
            /*/
            var club = new Club(data[1]);
            //*/
            var group = new GroupOfOrganiziers
            {
                Club = club,
                ClubId = club.Id,
                Name = club.Name
            };

            club.Group = group;

            newData.Clubs.Add(club);
            newData.Groups.Add(group);

            return club;
        }
        private Person GetPerson(string[] data)
        {
            var person = new Person
            {
                Sername = data[0],
                Name = data[1],
                Patronym = data[2]
            };

            newData.People.Add(person);

            return person;
        }
        private string[] GetSNP(string snp)
        {
            var newSNP = new string[] { "", "", "" };
            var index1 = snp.IndexOf(' ');
            var index2 = snp.LastIndexOf(' ');

            if (index1 != -1)
            {
                newSNP[0] = snp.Substring(0, index1 + 1).Trim();
                newSNP[1] = index1 == index2 ? snp.Substring(index1).Trim() : snp.Substring(index1, index2 + 1 - index1).Trim();
                newSNP[2] = index1 == index2 ? "" : snp.Substring(index2).Trim();
            }

            return newSNP;
        }
        private Dictionary<int, string[]> GetLines(ExcelWorksheet worksheet, int firstDataRow, int[] boundary)
        {
            var lines = new Dictionary<int, string[]>();
            var linesCount = boundary[0];
            var columnsCount = boundary[1];

            for (int i = firstDataRow; i <= linesCount; i++)
                lines.Add(i, GetDataFromString(worksheet, i, columnsCount));

            return lines;
        }
        private string[] GetDataFromString(ExcelWorksheet worksheet, int row, int columnsCount)
        {
            var data = new string[columnsCount];

            for (int i = 1; i <= columnsCount; i++)
            {
                var obj = worksheet.Cells[row, i].Value;
                data[i - 1] = (obj ?? "").ToString();
            }

            return data;
        }
        private string[] GetCaptions(ExcelWorksheet worksheet, int row, int columnCount)
        {
            var captions = new List<string>();

            for(int i = 1; i <= columnCount; i++)
            {
                var value = worksheet.Cells[row, i].Value;

                if (value == null)
                    continue;

                captions.Add(value.ToString());
            }

            return captions.ToArray();
        }
        private int[] GetBoundary(ExcelWorksheet worksheet, string lastCoulumnValue, int? startRow = null)
        {
            var startPoint = new int[2];
            var boundary = new int[2];
            object cellValue;
            int row = startRow ?? 2;
            int col = 1;
            int i = row, j = 0;

            cellValue = worksheet.Cells[row, col].Value;

            while (cellValue.ToString() != lastCoulumnValue)
            {
                cellValue = worksheet.Cells[row - 1, ++j].Value ?? "";
            }

            while (cellValue != null)
            {
                cellValue = worksheet.Cells[++i, col].Value;
            }

            boundary[0] = --i;
            boundary[1] = j;

            return boundary;
        }
        private DirectoryInfo CheckDirectory(string directoryPath)
        {
            DirectoryInfo directoryInfo;

            if (!Directory.Exists(directoryPath))
                directoryInfo = Directory.CreateDirectory(directoryPath);
            else
                directoryInfo = new DirectoryInfo(directoryPath);

            return directoryInfo;
        }
        private async Task SerializeDataAsinc(AllData data, string directoryName = "")
        {
            string path = directoryName == string.Empty ? "" : $@"{directoryName}\";

            await Task.Run(() => SerializeData(data.People, $"{directoryName}People"));
            await Task.Run(() => SerializeData(data.Dancers, $"{directoryName}Dancers"));
            await Task.Run(() => SerializeData(data.Activities, $"{directoryName}Activities"));
            await Task.Run(() => SerializeData(data.Changes, $"{directoryName}Changes"));
            await Task.Run(() => SerializeData(data.Classes, $"{directoryName}Classes"));
            await Task.Run(() => SerializeData(data.Clubs, $"{directoryName}Clubs"));
            await Task.Run(() => SerializeData(data.Groups, $"{directoryName}Groups"));
            await Task.Run(() => SerializeData(data.NominationCompetitors, $"{directoryName}NominationCompetitors"));
            await Task.Run(() => SerializeData(data.Plans, $"{directoryName}Plans"));
            await Task.Run(() => SerializeData(data.Periodicities, $"{directoryName}Periodicities"));
            await Task.Run(() => SerializeData(data.SHAClasses, $"{directoryName}SHAClasses"));
            await Task.Run(() => SerializeData(data.Teachers, $"{directoryName}Teachers"));

            Console.WriteLine($"Serialition has been dane");
        }
        private void SerializeData(object data, string name = "CurrentData")
        {

            var settings = new UserSettings();
            var filePath = $@"{settings.CurrentDirectory}\{name}.json";

            Console.WriteLine($"Serialize data from data base into {filePath}");

            //var formatter = new XmlSerializer(typeof(AllData));
            var jsonData = JsonConvert.SerializeObject(data);

            if (!File.Exists($@"{filePath}"))
                //using (var file = new FileStream($@"{filePath}", FileMode.Create))
                //formatter.Serialize(file, data);
            //else
                //using (var file = new FileStream($@"{filePath}", FileMode.Open))
                //formatter.Serialize(file, data);
                File.Create(filePath);

            File.WriteAllText(filePath, jsonData);
        }
        private List<Activity> GetActivities(List<Event> events)
        {
            var activities = new List<Activity>();

            foreach (var @event in events)
                activities.Add(new Activity() { Event = @event });

            return activities;
        }
        private bool IsPartsEquals(string string1, string string2)
        {
            var firstPart1 = string1.Substring(0, string1.Length / 2);
            var firtPart2 = string2.Substring(0, string2.Length / 2);
            var secondPart1 = string1.Substring(string1.Length / 2);
            var secondPart2 = string2.Substring(string2.Length / 2);

            if (string1 == string2 || firstPart1 == firtPart2 || secondPart1 == secondPart2)
                return true;

            return false;
        }
    }
}
