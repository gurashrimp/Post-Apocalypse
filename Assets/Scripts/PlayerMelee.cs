using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMelee : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackRate = 2f;
    float nextAttackTime = 0;
    public Button melee;
    // Update is called once per frame
    void Start()
    {
        melee.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    meleeAttack();
            //    nextAttackTime = Time.time + 1f / attackRate;
            //}
              
            
        }
        
    }
    void TaskOnClick()
    {
        if (Time.time >= nextAttackTime)
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    meleeAttack();
            //    nextAttackTime = Time.time + 1f / attackRate;
            //}     
                meleeAttack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    void meleeAttack()
    {
        animator.SetTrigger("staffAttack");
        Collider2D[] hitEnemy= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemy)
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
