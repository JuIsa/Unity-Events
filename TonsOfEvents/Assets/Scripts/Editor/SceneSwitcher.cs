using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class SceneSwitcher : EditorWindow
{
    
    
    [MenuItem("Window/Switcher")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(SceneSwitcher));
    }

    private void OnGUI() {
        float width = 200f;
        GUILayout.Label("Switcher", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Chaotic Attractor", GUILayout.Width(width)) ) {
            Debug.Log("ChaosAttractor");
            EditorSceneManager.OpenScene("Assets/Scenes/Attractors.unity");
        }
        else if (GUILayout.Button("Dance of Cubes", GUILayout.Width(width))) {
            Debug.Log("Dance");
            EditorSceneManager.OpenScene("Assets/Scenes/DanceOfCubes.unity");
        }
        else if (GUILayout.Button("Particle Attractor", GUILayout.Width(width))) {
            Debug.Log("Particle");
            EditorSceneManager.OpenScene("Assets/Scenes/ParticleAttractor.unity");
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Events", GUILayout.Width(width))) {
            Debug.Log("Events");
            EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
        } 
        else if (GUILayout.Button("Living Blocks", GUILayout.Width(width))) {
            Debug.Log("Livibg Blocks");
            EditorSceneManager.OpenScene("Assets/Scenes/LivingBlocks.unity");
        } 
        else if (GUILayout.Button("Dissapear", GUILayout.Width(width))) {
            Debug.Log("D");
            EditorSceneManager.OpenScene("Assets/Scenes/Dissapear.unity");
        }
        else if (GUILayout.Button("Tiles", GUILayout.Width(width))) {
            Debug.Log("Tiles");
            EditorSceneManager.OpenScene("Assets/Scenes/TileGenerator.unity");
        }
        GUILayout.EndHorizontal();
        
    }
}
