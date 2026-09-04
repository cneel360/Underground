using System;
using System.Linq.Expressions;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;

public class doorcontroller : MonoBehaviour
{
    public Transform doorobject;
    public float closedposition;
    public float openposition;
    public float doormovetime;
    [Range(0,1)]
     public float basedoorposition;

    [Range(0,1)]
     public float target;
     float internalpos;
      float internaltargetpos;
      float targetdistance;
      float targetdistanceabsolute;
         float calculatedmovetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
   void movedoorcalcs()
    {
        
         internalpos= Mathf.Lerp(closedposition, openposition, basedoorposition);
        internaltargetpos = Mathf.Lerp(closedposition, openposition, target);
         targetdistance = basedoorposition - target;
         targetdistanceabsolute = Mathf.Clamp(targetdistance,0,1);
         calculatedmovetime = doormovetime * targetdistanceabsolute;
    }
     void movedoor()
    {
        if(basedoorposition != target)
        {
           float newangle = Mathf.LerpAngle(doorobject.rotation.y,internaltargetpos,calculatedmovetime * Time.deltaTime );
           doorobject.eulerAngles = new Vector3(doorobject.eulerAngles.x, newangle, doorobject.eulerAngles.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        movedoorcalcs();

    }
}
