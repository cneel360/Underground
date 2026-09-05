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
   public  float internalpos;
     public float internaltargetpos;
     public  float targetdistance;
    public  float targetdistanceabsolute;
     public    float calculatedmovetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
   void movedoorcalcs()
    {
        
         internalpos= Mathf.Lerp(closedposition, openposition, basedoorposition);
        internaltargetpos = Mathf.Lerp(closedposition, openposition, target);
         targetdistance = basedoorposition - target;
         targetdistanceabsolute = Mathf.Clamp(Mathf.Abs(targetdistance),0,1);
         calculatedmovetime = doormovetime * targetdistanceabsolute;
    }
     void movedoor()
    {
        if(basedoorposition != target)
        {
                    float step = Time.deltaTime / Mathf.Max(doormovetime, 0.0001f);
        basedoorposition = Mathf.MoveTowards(basedoorposition, target, step);
        basedoorposition = Mathf.Clamp01(basedoorposition); // safety, since [Range] doesn't enforce at runtime
             float currentAngle = doorobject.eulerAngles.y;
           float newangle = Mathf.LerpAngle(currentAngle,internaltargetpos,calculatedmovetime * Time.deltaTime );
           doorobject.eulerAngles = new Vector3(doorobject.eulerAngles.x, newangle, doorobject.eulerAngles.z);
           
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        movedoorcalcs();
        movedoor();
    }
}
