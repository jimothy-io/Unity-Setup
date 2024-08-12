using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Setup
{
    public static class ProjectSetup
    {
        [MenuItem("Tools/Setup/Create Folders")]
        public static void CreateFolders()
        {
            Folders.Create("_Project", "Animations", "Scripts", "Input", "Ignore", "Imports",
                "Art", "Prefabs");
            AssetDatabase.Refresh();

            Folders.Move("_Project", "Scenes");
            Folders.Move("_Project", "Settings");
            Folders.Delete("TutorialInfo");
            AssetDatabase.Refresh();

            AssetDatabase.MoveAsset("Assets/InputSystem_Actions.inputactions",
                "Assets/_Project/Input/InputActions.inputactions");
            AssetDatabase.DeleteAsset("Assets/Readme.asset");
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Setup/Import Essential Assets")]
        public static void ImportEssentialAssets()
        {
            // Editor Coroutines - Editor Auto Save dependency
            // Assets.ImportAsset("Editor Coroutines.unitypackage",
            //     "Marijn Zwemmer/Editor ExtensionsUtilities");
        
            // Editor Console Pro
            Assets.ImportAsset("Editor Console Pro.unitypackage",
                "FlyingWorm/Editor ExtensionsSystem");

            // Selection History
            Assets.ImportAsset("Selection History.unitypackage",
                "Staggart Creations/Editor ExtensionsUtilities");

            // Color Studio
            Assets.ImportAsset("Color Studio.unitypackage",
                "Kronnect/Editor ExtensionsPainting");

            // Audio Preview Tool
            Assets.ImportAsset("Audio Preview Tool.unitypackage",
                "Warped Imagination/Editor ExtensionsAudio");

            // Editor Auto Save
            // Assets.ImportAsset("Editor Auto Save.unitypackage",
            //     "IntenseNation/Editor ExtensionsUtilities");

            // Better Hierarchy
            Assets.ImportAsset("Better Hierarchy.unitypackage",
                "Toaster Head/Editor ExtensionsUtilities");
        }

        [MenuItem("Tools/Setup/Import Odin Inspector and Serializer")]
        public static void ImportOdin()
        {
            // Odin Inspector
            Assets.ImportAsset("Odin Inspector and Serializer.unitypackage",
                "Sirenix/Editor ExtensionsSystem");
        }

        [MenuItem("Tools/Setup/Install Essential Packages")]
        public static void InstallEssentialPackages()
        {
            Packages.InstallPackages(new[]
            {
                "com.unity.cinemachine", // Cinemachine
                "git+https://github.com/itsJimothy/Unity-Utilities.git", // Jimothy's Unity Utilities
            });
        }
    
        [MenuItem("Tools/Setup/Remove Junk Packages")]
        public static void RemoveJunkPackages()
        {
            Packages.RemovePackages(new[]
            {
                "com.unity.collab-proxy",       // Unity's Version Control - Bloated, use git instead
                "com.unity.visualscripting",    // Visual Scripting
                "com.unity.ide.visualstudio",   // Visual Studio Editor - This is a Rider household
                "com.unity.timeline",           // Timeline
            });
        }

        [MenuItem("Tools/Setup/Fetch .gitignore")]
        public static async void FetchGitignore()
        {
            const string url =
                "https://gist.githubusercontent.com/itsJimothy/06b39890e0b9e9676fcb8f6265424fa9/raw/3fddae40b78ffe49b96f94f6cc22005f2688ae25/.gitignore";

            var content = await Imports.FetchGitignore(url);

            await File.WriteAllTextAsync(".gitignore", content);

            Debug.Log("Fetched .gitignore.");
        }

        [MenuItem("Tools/Setup/All of the below", false, 99)]
        public static void SetupProject()
        {
            CreateFolders();
            FetchGitignore();
            ImportEssentialAssets();
            InstallEssentialPackages();
            RemoveJunkPackages();
        }

        private static class Assets
        {
            public static void ImportAsset(string asset, string folder)
            {
                string basePath =
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                string assetsFolder = Path.Combine(basePath, "Unity/Asset Store-5.x");

                AssetDatabase.ImportPackage(Path.Combine(assetsFolder, folder, asset), false);
            }
        }

        private static class Packages
        {
            private static Queue<string> _packagesToInstall = new();
            private static Queue<string> _packagesToRemove = new();

            private static async void StartNextPackageInstallation()
            {
                var addRequest = Client.Add(_packagesToInstall.Dequeue());

                while (!addRequest.IsCompleted) await Task.Delay(10);

                if (addRequest.Status == StatusCode.Success)
                {
                    Debug.Log("Installed: " + addRequest.Result.packageId);
                }
                else if (addRequest.Status >= StatusCode.Failure)
                {
                    Debug.LogError("Failed to install package: " + addRequest.Error.message);
                }

                if (_packagesToInstall.Count > 0)
                {
                    await Task.Delay(1000);
                    StartNextPackageInstallation();
                }
            }

            private static async void StartNextPackageRemoval()
            {
                var removeRequest = Client.Remove(_packagesToRemove.Dequeue());

                while (!removeRequest.IsCompleted) await Task.Delay(10);

                if (removeRequest.Status == StatusCode.Success)
                {
                    Debug.Log("Uninstalled: " + removeRequest.PackageIdOrName);
                }
                else if (removeRequest.Status >= StatusCode.Failure)
                {
                    Debug.LogError("Failed to uninstall package: " + removeRequest.Error.message);
                }

                if (_packagesToRemove.Count > 0)
                {
                    await Task.Delay(1000);
                    StartNextPackageRemoval();
                }
            }

            public static void InstallPackages(string[] packages)
            {
                foreach (string package in packages)
                {
                    _packagesToInstall.Enqueue(package);
                }

                if (_packagesToInstall.Count > 0)
                {
                    StartNextPackageInstallation();
                }
            }
        
            public static void RemovePackages(string[] packages)
            {
                foreach (string package in packages)
                {
                    _packagesToRemove.Enqueue(package);
                }

                if (_packagesToRemove.Count > 0)
                {
                    StartNextPackageRemoval();
                }
            }
        }

        private static class Folders
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

        private static class Imports
        {
            public static async Task<string> FetchGitignore(string url)
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to fetch .gitignore: " + e.Message);
                }

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }
    }
}