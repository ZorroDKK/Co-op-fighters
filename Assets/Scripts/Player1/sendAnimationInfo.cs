using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendAnimationInfo : MonoBehaviour
{
    public pMove playerScript;

    public void spellStartSpeed()
    {
        playerScript.moveSpeed = 0;
    }

    public void spellEndSpeed()
    {
        playerScript.moveSpeed = playerScript.setWalkSpeed;
    }

    public void startSpell()
    {
        playerScript.spellSpawning();
    }
}
