using Unity.VisualScripting;
using UnityEngine;

public class daycyclemanager : MonoBehaviour
{
    [Header("Sun Settings")]
    public Light sunLight;
    public Gradient suncolorshift;
    public AnimationCurve intensitycurve;

    [Header("Time Settings")]
    [Range(0f, 1f)] public float timeofday;
    public float timemultiplier = 0.05f; // Set a small value in Inspector (e.g., 0.01 to 0.05)

    [Header("Skybox Settings")]
    public Material baseskymat;
    public Gradient mainskycolorshift;
    public Gradient skyhorizoncolorshift;
    public Color groundcolorday;
    public Color groundcolornight;
    private Material skyboxMaterial; // Internal runtime instance
    public Cubemap dayskymap;
    public Cubemap nightskymap;

    void Start()
    {
        // Check if base material is assigned
        if (baseskymat != null)
        {
            // Creates a runtime copy in memory to prevent modifying the asset file
            skyboxMaterial = new Material(baseskymat);
            
            // Assign the new instance to the active scene skybox
            RenderSettings.skybox = skyboxMaterial;
        }
        else
        {
            Debug.LogWarning("DayCycleManager: Please assign 'baseskymat' in the Inspector!");
        }
    }

    void Update()
    {
        UpdateTime(); 
        updateSun();
        updateskybox();
    }

    void UpdateTime()
    {
        // 1. ADVANCE TIME OVER FRAMES
        timeofday += Time.deltaTime * timemultiplier;

        // Loop between 0.0 and 1.0
        if (timeofday >= 1f)
        {
            timeofday %= 1f;
        }
        else if (timeofday < 0f)
        {
            timeofday = 0f;
        }
    }

    void updateSun()
    {
        if (sunLight == null) return;

        float sunRotationX = (timeofday * 360f) - 90f;
        sunLight.transform.localRotation = Quaternion.Euler(sunRotationX, 180f, 0f);

        if (suncolorshift != null) sunLight.color = suncolorshift.Evaluate(timeofday);
        if (intensitycurve != null) sunLight.intensity = intensitycurve.Evaluate(timeofday);
    }

    void updateskybox()
    {
        if (skyboxMaterial == null) return;

        // Evaluate gradients based on timeofday
        if (mainskycolorshift != null)
        {
            Color currentsky = mainskycolorshift.Evaluate(timeofday);
            Debug.Log($"Time: {timeofday} | Updating SkyColor to: {currentsky}");
            skyboxMaterial.SetColor("_SkyColor", currentsky); // 2. USE SetColor
        }

        if (skyhorizoncolorshift != null)
        {
            Color currenthorizon = skyhorizoncolorshift.Evaluate(timeofday);
            skyboxMaterial.SetColor("_HorizonColor", currenthorizon); // 2. USE SetColor
        }
        if(timeofday > .75 || timeofday < .25)
        {
         //   skyboxMaterial.SetVector("_skycolor_master", new Vector4(0f,0f,0.05f,1f));
            skyboxMaterial.SetTexture("_skymap", nightskymap);
            skyboxMaterial.SetColor("_GroundColor",groundcolornight);
        }
        else
        {
        //    skyboxMaterial.SetVector("_skycolor_master", new Vector4(1f,1f,1f,1f));
             skyboxMaterial.SetTexture("_skymap", dayskymap);
               skyboxMaterial.SetColor("_GroundColor",groundcolorday);
        }
    }
}