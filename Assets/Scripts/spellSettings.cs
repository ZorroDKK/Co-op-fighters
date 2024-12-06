using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class spellSettings : MonoBehaviour
{
    [CanBeNull] public pMove player1 ;
    public bool player1Selected =false;
    [CanBeNull] public p2Move player2 ;
    public bool player2Selected =false;
    public float spellDamage;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player1Selected)
        {
            player1 = FindObjectOfType<pMove>();
            spellDamage = player1.spellDamage;
        }

        if (player2Selected)
        {
            player2 = FindObjectOfType<p2Move>();
            //spellDamage = player2.spellDamage;
        }
        fire();
    }

    public void fire()
    {
        if (player1Selected)
        {
            if (player1.isToTheRight)
            {
                rb.velocity = Vector2.right * player1.spellSpeed;
            }
            else if (!player1.isToTheRight)
            {
                rb.velocity = Vector2.left * player1.spellSpeed;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
