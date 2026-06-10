using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Jimothy.Setup
{
    internal static class Packages
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
}