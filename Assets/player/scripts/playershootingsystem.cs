using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;


public class PlayerShootingSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimcam;
    [SerializeField] private StarterAssetsInputs inputmanager;
    private ThirdPersonController startercontroller;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private LayerMask aimcolliderlayermask = new LayerMask();
    [SerializeField] private Transform debugtransform;
    [SerializeField] private GameObject bulletProjectile;
    [SerializeField] private Transform spawnbulletpos;
    private Vector3  mouseWorldposition;
    private Animator playeranimator;

    void Awake()
    {
        if (playeranimator == null)
        {
            playeranimator = GetComponent<Animator>();
        }
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
             mouseWorldposition = Vector3.zero;
            Vector2 screencenterpoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray targetray = Camera.main.ScreenPointToRay(screencenterpoint);
            if (Physics.Raycast(targetray, out RaycastHit raycasthit, 999f, aimcolliderlayermask))
            {
                debugtransform.position = raycasthit.point;
                mouseWorldposition = raycasthit.point;
            }
            //   Debug.Log("Aim input state: " + inputmanager.aim);

            if (inputmanager.aim)

            {
                Vector3 WorldAimTarget = mouseWorldposition;
                WorldAimTarget.y = transform.position.y;
                Vector3 AimDirection = (WorldAimTarget - transform.position).normalized;
                aimcam.gameObject.SetActive(true);
                startercontroller.SetCameraSensitivity(aimSensitivity);
                transform.forward = Vector3.Lerp(transform.forward, AimDirection, Time.deltaTime * 20f);
                startercontroller.SetRotateonmove(false);
                playeranimator.SetLayerWeight(1, Mathf.Lerp(playeranimator.GetLayerWeight(1),1f,Time.deltaTime*7.125f));
            }
            else
            {
                aimcam.gameObject.SetActive(false);
                startercontroller.SetCameraSensitivity(normalSensitivity);
                startercontroller.SetRotateonmove(true);
                playeranimator.SetLayerWeight(1, Mathf.Lerp(playeranimator.GetLayerWeight(1),0f,Time.deltaTime*7.4827f));
            }
        }
        else
        {
            Debug.LogError("InputManager is missing on PlayerShootingSystem.");
        }
        if (inputmanager.shoot)
        {
            Vector3 aimdir = (mouseWorldposition - spawnbulletpos.position).normalized;
            Instantiate(bulletProjectile, spawnbulletpos.position, Quaternion.LookRotation(aimdir,Vector3.up));
            inputmanager.shoot = false;
        }
       
        

    }
}
