using UnityEngine;
using System.Collections.Generic;

// Removed [ExecuteAlways] so it never runs in Edit Mode
public class GrassTerrainSpawner : MonoBehaviour
{
    [Header("References")]
    public Terrain terrain;
    public Mesh grassBladeMesh;
    public Material grassMaterial;

    [Header("Grass Settings")]
    public int instanceCount = 50000;
    public float maxDistance = 100f;
    public Vector2 bladeScale = new Vector2(0.5f, 1.5f);
    public int targetLayerIndex = 0;
    [Range(0f, 1f)] public float densityThreshold = 0.3f;

    private ComputeBuffer positionBuffer;
    private RenderParams renderParams;

    // Start runs once when entering Play Mode
    void Start()
    {
        SetupBuffers();
    }

    void OnDisable()
    {
        CleanUp();
    }

    public void SetupBuffers()
    {
        if (terrain == null || grassBladeMesh == null || grassMaterial == null) return;

        CleanUp();

        TerrainData tData = terrain.terrainData;
        Vector3 tPos = terrain.transform.position;
        Vector3 tSize = tData.size;

        int mapWidth = tData.alphamapWidth;
        int mapHeight = tData.alphamapHeight;
        float[,,] splatmapData = tData.GetAlphamaps(0, 0, mapWidth, mapHeight);

        List<Vector3> validPositions = new List<Vector3>();
        int maxAttempts = instanceCount * 5;
        int attempts = 0;

        while (validPositions.Count < instanceCount && attempts < maxAttempts)
        {
            attempts++;

            float normX = Random.value;
            float normZ = Random.value;

            int mapX = Mathf.Clamp(Mathf.FloorToInt(normX * mapWidth), 0, mapWidth - 1);
            int mapZ = Mathf.Clamp(Mathf.FloorToInt(normZ * mapHeight), 0, mapHeight - 1);

            float layerWeight = splatmapData[mapZ, mapX, targetLayerIndex];

            if (layerWeight >= densityThreshold)
            {
                float height = tData.GetInterpolatedHeight(normX, normZ);

                Vector3 worldPos = new Vector3(
                    tPos.x + normX * tSize.x,
                    tPos.y + height,
                    tPos.z + normZ * tSize.z
                );

                validPositions.Add(worldPos);
            }
        }

        if (validPositions.Count == 0) return;
        Debug.Log($"Found {validPositions.Count} valid grass positions on layer {targetLayerIndex}.");
        positionBuffer = new ComputeBuffer(validPositions.Count, sizeof(float) * 3);
        positionBuffer.SetData(validPositions.ToArray());
            grassMaterial.SetFloat("_MaxDistance", maxDistance);
        grassMaterial.SetBuffer("_Positions", positionBuffer);

        renderParams = new RenderParams(grassMaterial)
        {
            worldBounds = new Bounds(tPos + tSize * 0.5f, tSize)
        };
    }

    void Update()
    {
        // Only executes during Play Mode
        if (positionBuffer == null || grassBladeMesh == null || grassMaterial == null) return;

        Graphics.RenderMeshPrimitives(renderParams, grassBladeMesh, 0, positionBuffer.count);
    }

    void CleanUp()
    {
        if (positionBuffer != null)
        {
            positionBuffer.Release();
            positionBuffer = null;
        }
    }
}