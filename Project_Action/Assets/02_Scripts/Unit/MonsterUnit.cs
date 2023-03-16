using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnit : Unit
{
    public bool battle = false;
    public PlayerUnit player;
    public Transform monsterTr;
    public Vector3 tr;
    public Vector3 velocity;

    public void Start()
    {
        tr = monsterTr.position;
        StartCoroutine(MonsterAI());
    }
    IEnumerator MonsterAI()
    {
        float t = 0;

        Vector3 newPos = new Vector3(tr.x + Random.Range(-5, 5), tr.y, tr.z + Random.Range(-5, 5));
        float distance = Vector3.Distance(monsterTr.position, newPos);
        Vector3 dir = newPos - monsterTr.position;
        dir.y = 0;
        while (!battle)
        {
            t += Time.deltaTime;

            if (t > 5f)
            {
                t = 0;
                newPos = new Vector3(tr.x + Random.Range(-5, 5), tr.y, tr.z + Random.Range(-5, 5));
                distance = Vector3.Distance(monsterTr.position, newPos);
                dir = newPos - monsterTr.position;
                dir.y = 0;
                Move();
            }

            monsterTr.rotation = Quaternion.Lerp(transform.rotation , Quaternion.LookRotation(dir), 0.2f);
            monsterTr.position = Vector3.SmoothDamp(monsterTr.position, newPos, ref velocity, distance * 0.5f);

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
