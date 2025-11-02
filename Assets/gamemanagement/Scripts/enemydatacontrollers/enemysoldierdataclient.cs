using UnityEngine;

public class enemysoldierdataclient : MonoBehaviour
{
    public int dataid;
    public GameObject enemy;
    public datamanager datamanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   if(datamanager.savegameconfig.loadfromsave ==1)
        {
            loadenemyposition();
            loadisalive();
        }
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
    void enemypositionupdate()
    {
        datamanager.data.enemypositions[dataid] = enemy.transform.position;
    }
    void loadenemyposition()
    {
        enemy.transform.position = datamanager.data.enemypositions[dataid];

    }
void loadisalive()
    {
        if (datamanager.data.enemylivecount[dataid] == 1)
        {
            enemy.SetActive(true);
        } else if(datamanager.data.enemylivecount[dataid] == 0)
        {
            enemy.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        aliveupdate();
        enemypositionupdate();
    }
}
