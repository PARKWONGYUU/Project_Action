using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnit : Unit
{
    public bool battle = false;
    public PlayerUnit player;
    public Vector3 tr;

    public void Start()
    {
        StartCoroutine(MonsterAI());
    }
    IEnumerator MonsterAI()
    {
        float t = 0;

        while(!battle)
        {
            t += Time.deltaTime;
            Vector3 newPos = new Vector3(tr.x + Random.Range(-3, 3), tr.y, tr.z + Random.Range(-3, 3));

            yield return null;
        }
    }
    public override void Idle()
    {
    }
    public override void Move()
    {
        UnitState state = UnitState.MOVE;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Attack()
    {
    }
    public override void Dead()
    {
    }
    public override void Jump()
    {
    }
    public override void Skill()
    {
    }
}
