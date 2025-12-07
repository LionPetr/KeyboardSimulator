using UnityEditor;
using UnityEditor.Build.Reporting;

public class WebGLBuildHelper
{
    [MenuItem("Build/Build WebGL for GitHub Pages")]
    public static void BuildWebGL()
    {
        // Set build options
        UnityEditor.PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;

        // Set build path
        string path = "Build/WebGL";

        // Build
        BuildReport report = BuildPipeline.BuildPlayer(
            new BuildPlayerOptions
            {
                scenes = new[] { "Assets/Scenes/SampleScene.unity" }, // add your scenes
                locationPathName = path,
                target = BuildTarget.WebGL,
                options = BuildOptions.None
            }
        );

        if (report.summary.result == BuildResult.Succeeded)
            UnityEngine.Debug.Log("WebGL build succeeded!");
        else
            UnityEngine.Debug.LogError("WebGL build failed!");
    }
}