#if !defined(SHADERGRAPH_PREVIEW)
StructuredBuffer<float3> _Positions;
float _MaxDistance;
#endif

void VertexTranslator_float(uint InstanceID, float3 InPos, out float3 OutPos)
{
    OutPos = InPos; // preview / default fallback

#if !defined(SHADERGRAPH_PREVIEW)
    float3 instanceWorldPos = _Positions[InstanceID];
    float dist = distance(_WorldSpaceCameraPos, instanceWorldPos);

    if (dist > _MaxDistance)
    {
        // Collapse to a single point -> zero-area triangle, gets culled by rasterizer
        OutPos = instanceWorldPos;
    }
    else
    {
        OutPos = InPos + instanceWorldPos;
    }
#endif
}