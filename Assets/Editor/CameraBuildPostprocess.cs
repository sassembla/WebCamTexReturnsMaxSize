using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;

public static class CameraBuildPostprocess
{
    [PostProcessBuild(999)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            var plistPath = Path.Combine(path, "Info.plist");
            var plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            var rootDict = plist.root;
            rootDict.SetString("NSCameraUsageDescription", "カメラを使います。");

            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}
#endif