using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using System.IO;

namespace DAN_XLIX_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Reads or Writes from the file
    /// </summary>
    class FileReadWrite
    {
        private readonly string file = @"~\..\..\..\OwnerAccess.txt";
        /// <summary>
        /// Read admin from the file and save it
        /// </summary>
        public void ReadAdminFile()
        {
            // Load this only if the file exists
            if (File.Exists(file))
            {
                string[] readFile = File.ReadAllLines(file);

                for (int i = 0; i < readFile.Length; i++)
                {
                    if (!string.IsNullOrEmpty(readFile[i]))
                    {
                        string[] trim = readFile[i].Split(',');
                        Admin.AdminUsername = trim[0];
                        Admin.AdminPassword = trim[1];
                    }
                }
            }
        }
    }
}
