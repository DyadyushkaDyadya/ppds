using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Reflection;

namespace Mod
{

    public static class Mod
    {
        private static Type LoaderType;
        public static string path;
        public static void OnLoad()
        {
            path = ModAPI.Metadata.MetaLocation;
            Assembly DLL = Assembly.Load(File.ReadAllBytes(Path.Combine(ModAPI.Metadata.MetaLocation, @"DiscordStats.dll")));
            LoaderType = DLL.GetType("DiscordStats.Discord");
            var DiscordManagerType = DLL.GetType("DiscordStats.DiscordManager");
            LoaderType.GetMethod("Main").Invoke(null, new object[0] { });
            if (GameObject.Find("managerDiscordStats") == null)
            {
                new GameObject("managerDiscordStats").AddComponent(DiscordManagerType);
            }
        }
    }

}