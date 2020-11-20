using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverCharacterAttackandBlock : MonoBehaviour
{
    private Animator animator;

    public bool isBlocking;

    public bool isAttacking;

    public GameObject weapon;

    public GameObject shield;

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        else if(Input.GetKey(KeyCode.Mouse1))
        {
            Block();
        }
        else
        {  
            animator.SetBool("Isblocking", false);
            isBlocking = false;
            isAttacking = false;
        }       
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        isAttacking = true;
        weapon.GetComponent<WeaponScript>().attacking = true;
    }

    private void Block()
    {
        animator.SetBool("Isblocking", true);
        isBlocking = true;
        weapon.GetComponent<WeaponScript>().attacking = false;
    }
}
