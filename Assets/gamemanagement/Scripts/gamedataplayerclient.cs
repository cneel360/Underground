using UnityEngine;

public class gamedataplayerclient : MonoBehaviour
{
    public datamanager datamanager;
    public Vector3 objposition;
    public PlayerShootingSystem playershootsys;
    public playerhealth playerhealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(datamanager.savegameconfig.loadfromsave ==1)
        {
            Loadgamedata();
        }
        
    }
    void updateposition()
    {
        objposition = gameObject.transform.position;
        datamanager.data.position = objposition;
    }
    void updateshootsysinfo()
    {
        int magazine = playershootsys.magazine;
        datamanager.data.magizine = magazine;
    }
    void updatehealthinfo()
    {
        float healthnum = playerhealth.health;
        datamanager.data.health = healthnum;
    }
     void Loadgamedata()
    {
        gameObject.transform.position = datamanager.data.position;
        playershootsys.magazine = datamanager.data.magizine;
        playerhealth.health = datamanager.data.health;
    }
    // Update is called once per frame
    void Update()
    {
        updateposition();
        updateshootsysinfo();
        updatehealthinfo();
    }
}
