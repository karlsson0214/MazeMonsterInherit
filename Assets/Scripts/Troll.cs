using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Monster
{

    // Start is called before the first frame update
    protected override void Start()
    {
        // call Start() in super class Monster
        base.Start();
    }

    protected override void SelectDirection()
    {
        // select new direction, not same direction
        int deltaDirection = Random.Range(1, 3); // 1, 2 or 3
        direction += deltaDirection;
        direction = direction % 4;
    }


}
