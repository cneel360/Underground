using UnityEngine;
using Cinemachine;
using StarterAssets;

public class PlayerShootingSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimcam;
    [SerializeField] private  StarterAssetsInputs inputmanager;

    void Awake()
    {
        if (inputmanager == null)
        {
            inputmanager = GetComponent<StarterAssetsInputs>();
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
            }
            else
            {
                aimcam.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("InputManager is missing on PlayerShootingSystem.");
        }
    }
}
