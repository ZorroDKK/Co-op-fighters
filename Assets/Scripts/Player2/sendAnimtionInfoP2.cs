using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendAnimtionInfoP2 : MonoBehaviour
{
    public  p2Move playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void spellStartSpeed()
    {
        playerScript.moveSpeed = 0;
    }

    public void spellEndSpeed()
    {
        playerScript.moveSpeed = playerScript.setWalkSpeed;
        resetAttack();
    }

    public void startSpell()
    {
        playerScript.spellSpawning();
    }

    public void resetAttack()
    {
        playerScript.resetIsAttacking();
    }
}
