using UnityEngine;

public class enemyfightsys : MonoBehaviour
{
    public GameObject player;
    public Transform playertransform;
    public Vector3 playerpos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initplayertransform();
    }
void UpdatePlayerTransform()
    {
      playerpos = playertransform.position;
    }
  void initplayertransform()
    {
          playertransform = player.transform;
    }

    public int aimcheck(playerdetectedcontroller pdc, Transform enemytransform) 
    {
        if (pdc.shootrange)
        {
            enemytransform.forward = playerpos;
            return 1;
            
        }
        else
        {
             return 0;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        UpdatePlayerTransform();
    }
}
