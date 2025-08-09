using UnityEngine;

public class ammocrate : MonoBehaviour
{
    public int ammonum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public int Collectbullets(int magazine)
    {
        magazine += ammonum;
        ammonum = 0;
        return magazine;
   }


    // Update is called once per frame
    void Update()
    {
        
    }
}
