using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class enemydeathcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public GameObject Soldier;
    void Start()
    {
        
    }
  public  void ActivateLife()
    {
        Soldier.SetActive(true);
    }
 public void Die()
    {
        Soldier.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
