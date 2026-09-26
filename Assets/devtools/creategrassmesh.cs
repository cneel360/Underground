using UnityEngine;
#if UNITY_EDITOR
   using UnityEditor;
   #endif
public class creategrassmesh : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Tools/Create Pointed Grass Mesh")]
    public static void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "PointedGrassBlade";

        // Tapered 5-vertex blade (Wide base, narrower middle, sharp tip)
        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.2f, 0.0f, 0.0f), // 0: Bottom-Left
            new Vector3( 0.2f, 0.0f, 0.0f), // 1: Bottom-Right
            new Vector3(-0.1f, 0.5f, 0.0f), // 2: Mid-Left
            new Vector3( 0.1f, 0.5f, 0.0f), // 3: Mid-Right
            new Vector3( 0.0f, 1.0f, 0.0f)  // 4: Tip (Pointed top)
        };

        mesh.uv = new Vector2[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.2f, 0.5f),
            new Vector2(0.8f, 0.5f),
            new Vector2(0.5f, 1.0f)
        };

        // Triangles forming the tapered shape
        mesh.triangles = new int[]
        {
            0, 2, 1, // Bottom quad lower half
            1, 2, 3, // Bottom quad upper half
            2, 4, 3  // Top triangle tip
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        AssetDatabase.CreateAsset(mesh, "Assets/PointedGrassBlade.mesh");
        AssetDatabase.SaveAssets();

        Debug.Log("Pointed Grass Mesh created at Assets/PointedGrassBlade.mesh!");
    }
#endif
}