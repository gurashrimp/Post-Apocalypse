using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Button gun;
    public float attackRate = 2f;
    float nextAttackTime = 0;
    
    void Start()
    {
        
        gun.onClick.AddListener(TaskOnClick);
    }
   
    void TaskOnClick()
    {
        if (Time.time >= nextAttackTime)
        {    
            Shoot(); ;
            nextAttackTime = Time.time + 1f / attackRate;
        }
        
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
