using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

/// <summary>
/// 状态类
/// </summary>
public abstract class FSMState
{
    /// <summary>
    /// 为每一个子类初始化当前的状态
    /// </summary>
    protected int stateID;
    public int ID
    {
        get { return stateID; }
    }
    public FSMState()
    {

    }
    public FSMState(int id)
    {
        stateID = id;
    }
    /// <summary>
    /// 这个方法用来设立进入状态前的条件
    /// 在状态机分配它到当前状态之前他会被自动调用
    /// </summary>
    public virtual void DoBeforeEntering() { }
    /// <summary>
    /// 这个方法用来让一切都是必要的，例如在有限状态机变化到另一个时重置变量
    /// 在状态机切换到新的状态之前它会被自动调用
    /// </summary>
    public virtual void DoBeforeLeaving() { }

    /// <summary>
    /// 切换状态后对应的行动
    /// </summary>
    public virtual void Do() { }
}

