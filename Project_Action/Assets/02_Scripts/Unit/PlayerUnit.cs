using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    bool rolling = false;
    bool invincible = false;

    private void Awake()
    {
        StartCoroutine(InputCoroutine());
    }
    IEnumerator InputCoroutine()
    {
        while (true)
        {
            ChangeAnim(nowState.ToString(), false);

            if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                float hAxis = Input.GetAxisRaw("Horizontal");
                float vAxis = Input.GetAxisRaw("Vertical");

                Vector3 inputDir = Vector3.right * hAxis + Vector3.forward * vAxis;

                inputDir.Normalize();

                transform.position += inputDir * MoveSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputDir), 0.3f);
                Move();
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Roll();
                }
            }
            else
            {
                Idle();
            }
            yield return null;
        }
    }

    public void Roll()
    {
        UnitState state = UnitState.ROLL;

        rolling = true;
        MoveSpeed = 7f;
        StartCoroutine(RollCoroutine());

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    IEnumerator RollCoroutine()
    {
        while(true)
        {
            //rollÁß
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Roll") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                MoveSpeed = 5f;
                rolling = false;
                break;
            }
            yield return null;
        }
    }
    public override void Idle()
    {
        UnitState state = UnitState.IDLE;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Attack()
    {
        UnitState state = UnitState.ATTACK;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Move()
    {
        UnitState state = UnitState.MOVE;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Jump()
    {
        UnitState state = UnitState.JUMP;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Skill()
    {
        UnitState state = UnitState.SKILL;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
    public override void Dead()
    {
        UnitState state = UnitState.DEAD;

        ChangeState(state);
        ChangeAnim(state.ToString());
    }
}
