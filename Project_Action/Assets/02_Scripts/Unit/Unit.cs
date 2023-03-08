using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Animator anim;
    public enum UnitState
    {
        IDLE,
        MOVE,
        ATTACK,
        JUMP,
        ROLL,
        SKILL,
        DEAD,
    };
    public UnitState nowState;
    public void ChangeState(UnitState state)
    {
        nowState = state;
    }
    public void ChangeAnim(string str, bool on = true)
    {
        if (on)
            anim.SetTrigger(str);
        else
            anim.ResetTrigger(str);
    }
    public abstract void Idle();
    public abstract void Move();
    public abstract void Attack();
    public abstract void Skill();
    public abstract void Dead();
    public abstract void Jump();
}
