using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public int Health;

    public GameObject weapon;

    public GameObject shield;

    private bool isDead;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && isDead == false)
        {
            death();
        }
        else if(isDead == true)
        {
          //  SceneManager.LoadScene("DevinTestLevel");
        }
    }

    void death()
    {
        isDead = true;
        animator.SetTrigger("IsDead");
        //SceneManager.LoadScene("DevinTestLevel");
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0 && isDead == false)
        {
            death();
        }
    }

}
