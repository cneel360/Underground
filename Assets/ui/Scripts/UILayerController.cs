using UnityEngine;

public class UILayerController : MonoBehaviour
{
    public bool OnTop;
    public bool OnBottom;

    public bool runonindex;
    public int layerindex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (OnTop)
        {
            GoOnTop();
        }
        if (OnBottom)
        {
            GoOnBottom();
        }
        if (runonindex)
        {
            GobyIndex();
        }
    }
    void GoOnTop()
    {
        transform.SetAsLastSibling();
    }
    void GoOnBottom()
    {
        transform.SetAsFirstSibling();
    }
    void GobyIndex()
    {
        transform.SetSiblingIndex(layerindex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
