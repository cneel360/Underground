using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;


public class PlayerShootingSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimcam;
    [SerializeField] private StarterAssetsInputs inputmanager;
    private ThirdPersonController startercontroller;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private LayerMask aimcolliderlayermask = new LayerMask();
    [SerializeField] private Transform debugtransform;
    void Awake()
    {
        if (inputmanager == null)
        {
            inputmanager = GetComponent<StarterAssetsInputs>();
        }
        if (startercontroller == null)
        {
            startercontroller = GetComponent<ThirdPersonController>();
        }

        if (aimcam == null)
        {
            Debug.LogWarning("Aim camera not assigned in PlayerShootingSystem.");
        }
    }

    void Update()
    {
        if (inputmanager != null)
        {
            //   Debug.Log("Aim input state: " + inputmanager.aim);

            if (inputmanager.aim)
            {
                aimcam.gameObject.SetActive(true);
                startercontroller.SetCameraSensitivity(aimSensitivity);
            }
            else
            {
                aimcam.gameObject.SetActive(false);
                startercontroller.SetCameraSensitivity(normalSensitivity);
            }
        }
        else
        {
            Debug.LogError("InputManager is missing on PlayerShootingSystem.");
        }
        Vector3 mouseWorldposition = Vector3.zero;
        Vector2 screencenterpoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray targetray = Camera.main.ScreenPointToRay(screencenterpoint);
        if (Physics.Raycast(targetray, out RaycastHit raycasthit, 999f, aimcolliderlayermask))
        {
            debugtransform.position = raycasthit.point;
            mouseWorldposition = raycasthit.point;
        }
        Vector3 WorldAimTarget = mouseWorldposition;

    }
}
