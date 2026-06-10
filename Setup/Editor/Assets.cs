using System.IO;
using UnityEditor;

namespace Jimothy.Setup
{
    internal static class Assets
    {
        public static void ImportAsset(string asset, string folder)
        {
            string basePath =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string assetsFolder = Path.Combine(basePath, "Unity/Asset Store-5.x");

            AssetDatabase.ImportPackage(Path.Combine(assetsFolder, folder, asset), false);
        }
    }
}