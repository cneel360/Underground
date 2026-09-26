#if !defined(SHADERGRAPH_PREVIEW)
StructuredBuffer<float3> _Positions;
#endif

void VertexTranslator_float(uint InstanceID, float3 InPos, out float3 OutPos)
{
    OutPos = InPos;
#if defined(SHADERGRAPH_PREVIEW)
    OutPos = InPos;
#else
    OutPos = InPos + _Positions[InstanceID];
#endif
}