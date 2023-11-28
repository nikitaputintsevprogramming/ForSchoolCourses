using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveFollower : Follower
{
    protected override void Move()
    {
        transform.position = Vector3.Lerp(transform.position, Target, Speed);
    }
}
