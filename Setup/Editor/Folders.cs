using System.IO;
using UnityEditor;
using UnityEngine;

namespace Jimothy.Setup
{
    internal static class Folders
    {
        public static void Delete(string folderName)
        {
            string pathToDelete = $"Assets/{folderName}";

            if (AssetDatabase.IsValidFolder(pathToDelete))
            {
                AssetDatabase.DeleteAsset(pathToDelete);
            }
        }

        public static void Move(string newParent, string folderName)
        {
            string sourcePath = $"Assets/{folderName}";
            if (AssetDatabase.IsValidFolder(sourcePath))
            {
                string destinationPath = $"Assets/{newParent}/{folderName}";
                string error = AssetDatabase.MoveAsset(sourcePath, destinationPath);

                if (!string.IsNullOrEmpty(error))
                {
                    Debug.LogError($"Failed to move {folderName}: {error}");
                }
            }
        }

        public static void Create(string root, params string[] folders)
        {
            var fullPath = Path.Combine(Application.dataPath, root);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            foreach (var folder in folders)
            {
                CreateSubFolders(fullPath, folder);
            }
        }

        private static void CreateSubFolders(string rootPath, string folderHierarchy)
        {
            var folders = folderHierarchy.Split("/");
            var currentPath = rootPath;

            foreach (var folder in folders)
            {
                currentPath = Path.Combine(currentPath, folder);
                if (!Directory.Exists(currentPath))
                {
                    Directory.CreateDirectory(currentPath);
                }
            }
        }
    }
}