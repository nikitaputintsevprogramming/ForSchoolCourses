using System.Collections;
using UnityEngine;

public class LinearFollower : Follower
{
    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _leader.position, _speed);
    }
}
