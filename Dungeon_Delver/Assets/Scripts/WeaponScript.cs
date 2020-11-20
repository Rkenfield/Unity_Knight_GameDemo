using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public int Damage;

    public bool attacking;

    


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && attacking == true )
        {
            applyDamage(other.gameObject);
        }
     
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" )
        {
            attacking = false;
        }
    }

    void applyDamage(GameObject enemy)
    {
        EnemyAI enemyScript = enemy.GetComponent<EnemyAI> ();
        enemyScript.TakeDamage(Damage);
        Debug.Log("enemy hit");
    }

}
