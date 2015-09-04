using System;
using System.Diagnostics;
using System.IO;
using TestSharp;

namespace SpecFlowHelper.Integrations
{
    public static class DownloadFolder
    {
        public static string GetPath()
        {
            var path = Environment.GetEnvironmentVariable(@"USERPROFILE");

            Debug.Assert(!String.IsNullOrWhiteSpace(path), "User downloads folder not found");

            path = Path.Combine(path, "Downloads");

            return path;
        }

        public static bool ExistsFile(string filename)
        {
            var filePath = Path.Combine(GetPath(), filename);

            return File.Exists(filePath);
        }

        public static string[] GetFiles(string searchPattern = "*.*")
        {
            return Directory.GetFiles(GetPath(), searchPattern);
        }

        public static string GetFile(string fileName)
        {
            var filePath = Path.Combine(GetPath(), fileName);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            return null;
        }

        public static int CountFiles(string searchPattern = "*.*")
        {
            return GetFiles(searchPattern).Length;
        }

        public static void DeleteFiles(string searchPattern = "*.*")
        {
            DirectoryHelper.DeleteAllFiles(GetPath(), searchPattern, true);
        }
    }
}
