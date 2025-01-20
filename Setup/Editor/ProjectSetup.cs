using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Jimothy.Setup
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
            // Editor Coroutines (Editor Auto Save dependency): https://assetstore.unity.com/packages/tools/utilities/editor-coroutines-27373
            // Assets.ImportAsset("Editor Coroutines.unitypackage",
            //     "Marijn Zwemmer/Editor ExtensionsUtilities");

            // Editor Console Pro: https://assetstore.unity.com/packages/tools/utilities/editor-console-pro-11889
            Assets.ImportAsset("Editor Console Pro.unitypackage",
                "FlyingWorm/Editor ExtensionsSystem");

            // Selection History: https://assetstore.unity.com/packages/tools/utilities/selection-history-184204
            // Assets.ImportAsset("Selection History.unitypackage",
            //     "Staggart Creations/Editor ExtensionsUtilities");

            // Color Studio: https://assetstore.unity.com/packages/tools/painting/color-studio-151892
            Assets.ImportAsset("Color Studio.unitypackage",
                "Kronnect/Editor ExtensionsPainting");

            // Editor Auto Save: https://assetstore.unity.com/packages/tools/utilities/editor-auto-save-234445
            // Assets.ImportAsset("Editor Auto Save.unitypackage",
            //     "IntenseNation/Editor ExtensionsUtilities");

            // Better Hierarchy: https://assetstore.unity.com/packages/tools/utilities/better-hierarchy-272963?aid=1101lw3sv
            Assets.ImportAsset("Better Hierarchy.unitypackage",
                "Toaster Head/Editor ExtensionsUtilities");
            
            // Better Transform: https://assetstore.unity.com/packages/tools/utilities/better-transform-size-notes-global-local-workspace-child-parent--276554
            Assets.ImportAsset(
                "Better Transform - Size Notes Global-Local workspace child parent transform.unitypackage",
                "Tiny Giant Studio/Editor ExtensionsUtilities");
            
            // UI Preview for Prefabs and Canvases: https://assetstore.unity.com/packages/tools/utilities/ui-preview-for-prefabs-and-canvases-226906
            Assets.ImportAsset("UI Preview for Prefabs and Canvases.unitypackage",
                "KAMGAM/Editor ExtensionsUtilities");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import Beautify 3", false, -500)]
        public static void ImportBeautify()
        {
            // Beautify 3: https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/beautify-3-advanced-post-processing-233073
            Assets.ImportAsset("Beautify 3 - Advanced Post Processing.unitypackage",
                "Kronnect/ShadersFullscreen Camera Effects");
        }
        
        [MenuItem("Tools/Setup/Specific Assets/Import Asset Inventory 2", false, -600)]
        public static void ImportAssetInventory()
        {
            // Asset Inventory 2: https://assetstore.unity.com/packages/tools/utilities/asset-inventory-2-275893
            Assets.ImportAsset("Asset Inventory 2.unitypackage",
                "Impossible Robert/Editor ExtensionsUtilities");
        }
        
        [MenuItem("Tools/Setup/Specific Assets/Import Audio Preview Tool", false, -700)]
        public static void ImportAudioPreviewTool()
        {
            // Audio Preview Tool: https://assetstore.unity.com/packages/tools/audio/audio-preview-tool-244446
            Assets.ImportAsset("Audio Preview Tool.unitypackage",
                "Warped Imagination/Editor ExtensionsAudio");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import Logwin", false, -800)]
        public static void ImportLogwin()
        {
            // Logwin: https://assetstore.unity.com/packages/tools/utilities/logwin-log-debug-values-tracker-149558
            Assets.ImportAsset("LogwinLog - Debug Values Tracker.unitypackage",
                "Julien Foucher/Editor ExtensionsUtilities");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import Odin Inspector and Serializer", false, -999)]
        public static void ImportOdin()
        {
            // Odin Inspector
            Assets.ImportAsset("Odin Inspector and Serializer.unitypackage",
                "Sirenix/Editor ExtensionsSystem");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import Odin Validator", false, -998)]
        public static void ImportOdinValidator()
        {
            // Odin Inspector
            Assets.ImportAsset("Odin Validator.unitypackage",
                "Sirenix/Editor ExtensionsUtilities");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import DOTween Pro", false, -990)]
        public static void ImportDOTweenPro()
        {
            // DOTween Pro
            Assets.ImportAsset("DOTween Pro.unitypackage",
                "Demigiant/Editor ExtensionsVisual Scripting");
        }

        [MenuItem("Tools/Setup/Specific Assets/Import Animancer Pro", false, -980)]
        public static void ImportAnimancer()
        {
            // Animancer Pro
            Assets.ImportAsset("Animancer Pro.unitypackage",
                "Kybernetik/ScriptingAnimation");
        }

        [MenuItem("Tools/Setup/Specific Assets/Grabbit", false, -900)]
        public static void ImportGrabbit()
        {
            // Grabbit: https://assetstore.unity.com/packages/tools/utilities/grabbit-editor-physics-transforms-182328
            Assets.ImportAsset("Grabbit - Editor Physics Transforms.unitypackage",
                "Jungle/Editor ExtensionsUtilities");
        }

        [MenuItem("Tools/Setup/Install Essential Packages")]
        public static void InstallEssentialPackages()
        {
            Packages.InstallPackages(new[]
            {
                "com.unity.cinemachine", // Cinemachine
                "git+https://github.com/itsJimothy/Unity-Utilities.git", // Jimothy's Unity Utilities
                "git+https://github.com/starikcetin/Eflatun.SceneReference.git#upm", // Eflatun Scene Reference
            });
        }

        [MenuItem("Tools/Setup/Remove Junk Packages")]
        public static void RemoveJunkPackages()
        {
            Packages.RemovePackages(new[]
            {
                "com.unity.collab-proxy", // Unity's Version Control - Bloated, use git instead
                "com.unity.visualscripting", // Visual Scripting
                "com.unity.ide.visualstudio", // Visual Studio Editor - This is a Rider household
                "com.unity.timeline", // Timeline
            });
        }

        [MenuItem("Tools/Setup/Fetch .gitignore")]
        public static async void FetchGitignore()
        {
            const string url =
                "https://gist.githubusercontent.com/itsJimothy/06b39890e0b9e9676fcb8f6265424fa9/raw/3fddae40b78ffe49b96f94f6cc22005f2688ae25/.gitignore";

            var content = await Imports.FetchGist(url);

            await File.WriteAllTextAsync(".gitignore", content);

            Debug.Log("Fetched .gitignore.");
        }

        [MenuItem("Tools/Setup/Fetch .gitattributes")]
        public static async void FetchGitattributes()
        {
            const string url =
                "https://gist.githubusercontent.com/itsJimothy/270a377f000448979d38b697116faf34/raw/14f23b26b7e14692fc2f6422cafb1410ce2a130d/.gitattributes";

            var content = await Imports.FetchGist(url);

            await File.WriteAllTextAsync(".gitattributes", content);

            Debug.Log("Fetched .gitattributes.");
        }

        [MenuItem("Tools/Setup/All of the below", false, 99)]
        public static void SetupProject()
        {
            CreateFolders();
            FetchGitignore();
            FetchGitattributes();
            ImportEssentialAssets();
            InstallEssentialPackages();
            RemoveJunkPackages();
        }
    }
}