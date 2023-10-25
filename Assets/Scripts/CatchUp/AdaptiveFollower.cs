using System.Collections;
using UnityEngine;

public class AdaptiveFollower : Follower
{
    protected override void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _leader.position, _speed);
    }
}
