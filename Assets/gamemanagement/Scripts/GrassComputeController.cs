using UnityEngine;
using UnityEngine.Rendering;

public class GrassComputeSpawner : MonoBehaviour
{
    [Header("References")]
    public ComputeShader grassComputeShader;
    public Terrain terrain;
    public Mesh grassMesh;
    public Material grassMaterial;

    [Header("Settings")]
    public int instanceCount = 50000;
    public float maxDistance = 100f;
    public int targetLayerIndex = 0;

    private GraphicsBuffer instanceBuffer;
    private GraphicsBuffer argsBuffer;
    private RenderParams renderParams;
    private int kernelCSMain;

    void OnEnable()
    {
        // Subscribe to URP's camera rendering event
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;

        InitializeBuffers();
    }

    void OnDisable()
    {
        // Unsubscribe from rendering event
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;

        CleanUp();
    }

    void InitializeBuffers()
    {
        if (terrain == null || grassMesh == null || grassMaterial == null || grassComputeShader == null) return;

        CleanUp();

        kernelCSMain = grassComputeShader.FindKernel("CSMain");

        // Buffer holding blade position data
        instanceBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Append, instanceCount, sizeof(float) * 3);

        // Indirect Draw Arguments Buffer
        argsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, 1, GraphicsBuffer.IndirectDrawIndexedArgs.size);

        GraphicsBuffer.IndirectDrawIndexedArgs[] args = new GraphicsBuffer.IndirectDrawIndexedArgs[1];
        args[0].indexCountPerInstance = grassMesh.GetIndexCount(0);
        args[0].instanceCount = 0; // Overwritten dynamically by GPU CopyCount
        args[0].startIndex = 0;
        args[0].baseVertexIndex = 0;
        args[0].startInstance = 0;

        argsBuffer.SetData(args);

        // Pass buffer to grass material shader
        grassMaterial.SetBuffer("_Positions", instanceBuffer);

        // Expand world bounds so URP doesn't cull the entire draw call
        Bounds totalBounds = terrain.terrainData.bounds;
        totalBounds.center += terrain.transform.position;
        totalBounds.Expand(100f);

        renderParams = new RenderParams(grassMaterial)
        {
            worldBounds = totalBounds
        };
    }

    private void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        // Render in both Game and Scene views
        if (camera.cameraType != CameraType.Game && camera.cameraType != CameraType.SceneView) return;

        DispatchComputeAndDraw(camera);
    }

    private void DispatchComputeAndDraw(Camera cam)
    {
        if (terrain == null || grassMesh == null || instanceBuffer == null || argsBuffer == null) return;

        // Reset append buffer count every frame
        instanceBuffer.SetCounterValue(0);

        // Calculate GPU-compatible View-Projection matrix
        Matrix4x4 projMatrix = GL.GetGPUProjectionMatrix(cam.projectionMatrix, false);
        Matrix4x4 vpMatrix = projMatrix * cam.worldToCameraMatrix;

        // Pass variables to Compute Shader
        grassComputeShader.SetMatrix("_VPMatrix", vpMatrix);
        grassComputeShader.SetVector("_CameraPosition", cam.transform.position);
        grassComputeShader.SetFloat("_MaxDistance", maxDistance);
        grassComputeShader.SetVector("_TerrainSize", terrain.terrainData.size);
        grassComputeShader.SetVector("_TerrainPos", terrain.transform.position);
        grassComputeShader.SetInt("_InstanceCount", instanceCount);
        grassComputeShader.SetInt("_TargetLayerIndex", targetLayerIndex);

        // Set textures and buffers
        grassComputeShader.SetTexture(kernelCSMain, "_HeightMap", terrain.terrainData.heightmapTexture);
        grassComputeShader.SetTexture(kernelCSMain, "_SplatMap", terrain.terrainData.alphamapTextures[0]);
        grassComputeShader.SetBuffer(kernelCSMain, "_VisibleInstancesBuffer", instanceBuffer);

        // Dispatch Compute Shader
        int threadGroups = Mathf.CeilToInt((float)instanceCount / 64f);
        grassComputeShader.Dispatch(kernelCSMain, threadGroups, 1, 1);

        // Copy visible count integer to byte offset 4 (instanceCount) of argsBuffer
        GraphicsBuffer.CopyCount(instanceBuffer, argsBuffer, sizeof(uint));

        // Submit Indirect Draw Call
        Graphics.RenderMeshIndirect(renderParams, grassMesh, argsBuffer);
    }

    void CleanUp()
    {
        if (instanceBuffer != null)
        {
            instanceBuffer.Release();
            instanceBuffer = null;
        }

        if (argsBuffer != null)
        {
            argsBuffer.Release();
            argsBuffer = null;
        }
    }
}