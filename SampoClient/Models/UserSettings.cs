using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace SampoClient.Models
{
    internal class UserSettings : BaseVM
    {
        private static readonly string
            currentDirectory = $@"{Environment.CurrentDirectory}",
            fileName = $"default",
            format = ".stg";

        private string filePath = string.Empty;

        private bool autoEnter = false;
        private Authentication authentication;

        public UserSettings()
        {
            autoEnter = false;
            authentication = new Authentication();
            filePath = $@"{currentDirectory}\{fileName}{format}";
        }
        public UserSettings(Authentication authentication, bool auto)
        {
            autoEnter = auto;
            this.authentication = authentication;
            filePath = $@"{currentDirectory}\{fileName}{format}";
        }

        public bool AutoEnter
        {
            get => autoEnter;
            set { autoEnter = value; OnPropertyChanged(); }
        }
        public Authentication Authentication
        {
            get => authentication;
            set { authentication = value; OnPropertyChanged(); }
        }
        public static string FileName => fileName;
        public static string CurrentDirectory => currentDirectory;

        public void SaveChanges()
        {
            if (!Directory.Exists($@"{currentDirectory}"))
                Directory.CreateDirectory($@"{currentDirectory}");

            using (var file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(file, this);

                File.SetAttributes(file.Name, FileAttributes.Hidden);
            }
        }
        public static UserSettings DeserializeSettings()
        {
            var settings = new UserSettings();

            if (!Directory.Exists($@"{currentDirectory}"))
                Directory.CreateDirectory($@"{currentDirectory}");

            if (File.Exists($@"{currentDirectory}\{fileName}{format}"))
                using (var file = new FileStream($@"{currentDirectory}\{fileName}{format}", FileMode.Open))
                {
                    SoapFormatter formatter = new SoapFormatter();
                    settings = (UserSettings)formatter.Deserialize(file);
                }

            return settings;
        }
    }
}
