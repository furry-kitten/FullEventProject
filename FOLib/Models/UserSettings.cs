using FO.Properties;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace FO.Models
{
    public class UserSettings : BaseVM
    {
        private static readonly string
            currentDirectory = $@"{Environment.CurrentDirectory}",
            fileName = $"default",
            format = ".conf";

        private string filePath = string.Empty;
        private bool autoEnter = false;
        //private Authentication authentication;

        private Settings settings = new Settings();

        public UserSettings()
        {
            //authentication = new Authentication();
            filePath = $@"{currentDirectory}\{fileName}{format}";
            settings.FilePath = filePath;

            settings.Save();
            SaveChanges();
        }
        /*
        public UserSettings(Authentication authentication, bool auto)
        {
            autoEnter = auto;
            this.authentication = authentication;
            filePath = $@"{currentDirectory}\{fileName}{format}";
        }
        */
        public bool AutoEnter
        {
            get => autoEnter;
            set { autoEnter = value; OnPropertyChanged(); }
        }
        /*
        public Authentication Authentication
        {
            get => authentication;
            set { authentication = value; OnPropertyChanged(); }
        }
        */
        public static string FileName => fileName;
        public static string CurrentDirectory => currentDirectory;

        public static UserSettings DeserializeSettings()
        {
            var settings = new UserSettings();

            if (!Directory.Exists($@"{currentDirectory}"))
                Directory.CreateDirectory($@"{currentDirectory}");

            if (File.Exists($@"{currentDirectory}\{fileName}{format}"))
                using (var file = new FileStream($@"{currentDirectory}\{fileName}{format}", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(UserSettings));
                    settings = (UserSettings)formatter.Deserialize(file);
                }

            return settings;
        }
        public string FilePath
        {
            get => settings.FilePath;
            set
            {
                settings.FilePath = value;
                settings.Save();
                OnPropertyChanged();
            }
        }

        public void SaveChanges()
        {
            if (!Directory.Exists($@"{currentDirectory}"))
                Directory.CreateDirectory($@"{currentDirectory}");

            using (var file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(UserSettings));
                formatter.Serialize(file, this);

                File.SetAttributes(file.Name, FileAttributes.Hidden);
            }
        }
        public string GetConnectionString(Type? type = Type.Debug)
        {
            switch (type)
            {
                case Type.Debug:
                    return settings.HomeConnectionString;
                case Type.Release:
                    return settings.ConnectionString;
                default:
                    return string.Empty;
            }
        }

        public enum Type
        {
            Debug,
            Release
        }
    }
}
