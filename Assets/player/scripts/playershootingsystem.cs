using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UIElements;

public class PlayerShootingSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimcam;
    [SerializeField] private StarterAssetsInputs inputmanager;
    private ThirdPersonController startercontroller;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float normalSensitivity;

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
    }
}
