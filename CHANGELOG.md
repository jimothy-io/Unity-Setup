## [Unreleased]

---

## [1.1.7] - 2025-08-24
### Fix gist URLs
- Use gist URLs that point to the most recent version instead of specific ones.

---

## [1.1.7] - 2025-08-24
### Adds non-LFS .gitattributes option and removes "fetch all of the above" method
- Add "Fetch non-LFS .gitattributes" menu item.
- Rename "Fetch .gitattributes" to "Fetch LFS .gitattributes".
- Remove "all of the above" menu item.

---

## [1.1.7] - 2025-08-03
### Minor folder structure adjustments
- Use `Code` instead of `Scripts`.

---

## [1.1.6] - 2025-08-03
### Minor asset adjustments
- Switch to new Better Transform asset (old one was deprecated).

---

## [1.1.5] - 2025-06-12
### Minor asset adjustments
- Remove Logwin from essential asset imports due to issues with the current version.
- Remove Editor Auto Save from essential asset imports due to how invasive it is in the editor.
- Add Advanced FPS Counter to essential asset imports.

---

## [1.1.4] - 2025-06-11
### Re-adds disabled assets to essential asset imports
- Add the following assets to essential asset imports:
  - Selection History
  - Logwin
  - Editor Auto Save
- Removes the following assets from specific asset imports:
  - Logwin

---

## [1.1.3] - 2025-06-09
### Adds asset to essential asset imports
- Add the following asset to essential asset imports:
  - Wingman

---

## [1.1.2] - 2025-06-06
### Fixes minor bugs
- Update gist URL for fetching `.gitignore`.

---

## [1.1.1] - 2025-05-13
### Fixes dependency issue.
- Fix a dependency issue caused by Unity not allowing git dependencies in package.json.

---

## [1.1.0] - 2025-05-12
### Renames package, updates documentation, and cleans up essential package imports
- Rename this package from `Unity Setup Automation` to `jUnitySetup`.
- Move `jUnityUtilities` from essential package imports to dependencies.

---

## [1.0.16] - 2025-04-30
### Adds asset to specific asset imports
- Add the following asset to specific asset imports:
  - UMotion Pro

---

## [1.0.15] - 2025-04-26
### Re-adds removed asset to essential asset imports
- Add the following asset to essential asset imports:
  - Better Hierarchy

---

## [1.0.14] - 2025-04-24
### Adds and removes assets from essential asset imports
- Add the following assets to essential asset imports:
  - vRuler
  - vFolders 2
  - vInspector 2
  - vHierarchy 2
  - vTabs 2
  - vFavorites 2
- Remove the follow asset from essential asset imports:
  - Better Hierarchy

---

## [1.0.13] - 2025-01-20
### Adds assets to specific and essential asset imports
- Add the following asset to specific asset imports:
  - Final IK
- Add the following asset to essential asset imports:
  - UI Preview

---

## [1.0.12] - 2024-12-22
### Adds Beautify 3 to specific asset imports
- Add the following asset to specific asset imports:
  - Beautify 3

---

## [1.0.11] - 2024-12-20
### Reorganizes asset imports
- Move the following assets from essential to specific imports:
  - Logwin (using deprecated API)
  - Audio Preview Tool
  - Asset Inventory 2

---

## [1.0.10] - 2024-12-18
### Adds asset to essential asset imports
- Add the following asset to essential asset imports:
    - Better Transform

---

## [1.0.9] - 2024-12-08
### Adds asset to essential asset imports
- Add the following asset to essential asset imports:
  - Logwin

---

## [1.0.8] - 2024-12-08
### Adds menu item to fetch .gitattributes from gist
- Add the following menu item:
  - Tools/Setup/Fetch .gitattributes

---

## [1.0.7] - 2024-12-06
### Removes asset from essential asset imports, moves asset to specific asset imports
- Remove the following asset from essential asset imports:
    - Selection History
- Move the following asset to specific asset imports:
    - Grabbit

---

## [1.0.6] - 2024-12-02
### Adds assets to essential asset imports
- Add the following asset to specific asset imports:
    - Grabbit
    - Asset Inventory 2

---

## [1.0.5] - 2024-11-03
### Fix build errors
- Changes assembly definition platform to Editor to prevent build errors.

---

## [1.0.4] - 2024-09-03
### Adds asset to specific asset imports
- Fix duplicate menu item warning.
- Add the following asset to specific asset imports:
  - Odin Validator

---

## [1.0.3] - 2024-08-18
### Adds asset to specific asset imports
- Add the following asset to specific asset imports:
  - Animancer Pro

---

## [1.0.2] - 2024-08-18
### Adds package to essential packages
- Add the following package to essential packages:
  - Eflatun.SceneReference

---

## [1.0.1] - 2024-08-12
### Minor additions, improvements and reorganizing
- Change the following name for accuracy:
  - Tools/Setup/Specific Packages/Import Odin Inspector and Serializer
  - to
  - Tools/Setup/Specific Assets/Import Odin Inspector and Serializer
- Add the following menu items:
  - Tools/Setup/Specific Assets/Import DOTween Pro

---

## [1.0.0] - 2024-08-12
### First Release
- Add the following menu items:
  - Tools/Setup/Create Folders
  - Tools/Setup/Import Essential Assets
  - Tools/Setup/Install Essential Packages
  - Tools/Setup/Remove Junk Packages
  - Tools/Setup/Fetch .gitignore
  - Tools/Setup/Specific Packages/Import Odin Inspector and Serializer
