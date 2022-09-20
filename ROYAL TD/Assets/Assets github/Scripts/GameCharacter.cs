using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : GamObj
{
    private int dmgPerHit;
    private int attackDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DmgPerHit(int dmgPerHit)
    {
        this.dmgPerHit = dmgPerHit;
    }

    public int DmgPerHit()
    {
        return dmgPerHit;
    }

    public void AttackDuration(int attackDuration)
    {
        this.attackDuration = attackDuration;
    }

    public int AttackDuration()
    {
        return attackDuration;
    }

    public void characterAttack()
    {

    }

    public void death()
    {

    }
}
