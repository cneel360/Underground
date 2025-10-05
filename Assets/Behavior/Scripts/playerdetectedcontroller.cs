using NUnit.Framework;
using UnityEngine;


public class playerdetectedcontroller : MonoBehaviour
{
    public Transform player;
    public Vector3 distance;
    public Transform self;
    public bool isplayerdetected;
    public float distanceX;
    public float distanceY;
    public float distanceZ;
    public float Groundplanedetectionrange;
    public float Verticaldetectionrange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self = gameObject.transform;   
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.position - self.position;
        distanceX = Mathf.Abs(distance.x);
        distanceY = Mathf.Abs(distance.y);
        distanceZ = Mathf.Abs(distance.z);

        if (distanceX < Groundplanedetectionrange && distanceZ < Groundplanedetectionrange)
        {
            if (distanceY < Verticaldetectionrange)
            {
                isplayerdetected = true;
            }
            else
            {
                isplayerdetected = false;
            }
        }
        else
        {
            isplayerdetected =false;
        }


    }
}
