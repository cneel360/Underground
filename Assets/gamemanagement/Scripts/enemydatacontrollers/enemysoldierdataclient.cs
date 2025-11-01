using UnityEngine;

public class enemysoldierdataclient : MonoBehaviour
{
    public int dataid;
    public GameObject enemy;
    public datamanager datamanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
   void aliveupdate()
    {
        if (enemy.activeSelf)
        {
            datamanager.data.enemylivecount[dataid] = 1;
        }
        else
        {
            datamanager.data.enemylivecount[dataid] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        aliveupdate();
    }
}
