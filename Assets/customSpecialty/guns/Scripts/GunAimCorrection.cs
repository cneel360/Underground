using UnityEngine;

public class GunAimCorrection : MonoBehaviour
{
    private Vector3 mousewp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousewp = Vector3.zero;
        Vector2 screencenterpoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray targetray = Camera.main.ScreenPointToRay(screencenterpoint);
        Vector3 WorldAimTarget = mousewp;
        WorldAimTarget.y = transform.position.y;
        Vector3 AimDirection = (WorldAimTarget - transform.position).normalized;
                transform.forward = Vector3.Lerp(transform.forward, AimDirection, Time.deltaTime * 20f);
    }
}
