using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 该类便是有限状态机类
/// 它持有NPC的状态集合，并且有添加，删除状态的方法，以及改变当前正在执行的状态
/// </summary>
public class FSMSystem
{

    private Dictionary<int, FSMState> states;
    //通过预装一个过渡的唯一方式来改变状态机的状态
    //不要直接改变当前的状态

    /// <summary>
    /// 当前的状态ID
    /// </summary>
    private int currentStateID;
    /// <summary>
    /// 当前的状态类信息
    /// </summary>
    private FSMState currentFSMState;

    public int CurrentStateID
    {
        get
        {
            return currentStateID;
        }

    }

    public FSMState CurrentFSMState
    {
        get
        {
            return currentFSMState;
        }

    }

    public FSMSystem()
    {
        states = new Dictionary<int, FSMState>();
    }
    /// <summary>
    /// 这个方法为有限状态机置入新的状态
    /// 或者在改状态已经存在列表时打印错误信息
    /// 第一个添加的状态也是最初的状态
    /// </summary>
    public void AddState(FSMState s)
    {
        //添加前检查是否为空
        if (s == null)
        {
            Debug.LogError("FSM error:Null reference is not allowed");
        }

        ////被装在的第一个状态也是初始状态
        //if (states.Count == 0)
        //{
        //    states.Add(s.ID, s);
        //    currentFSMState = s;
        //    currentStateID = s.ID;
        //    return;
        //}

        //如果该状态未被添加过，则加入集合
        if(states.ContainsKey(s.ID))
        {
            Debug.LogError("FSM error: There already exist " + s.ID.ToString());
            return;
        }
        states.Add(s.ID, s);
    }
    public FSMState GetState(int stateID)
    {
        return states[stateID];
    }
    /// <summary>
    /// 删除一个已存在状态机中的状态
    /// 在它不存在时打印错误信息
    /// </summary>
    /// <param name="id"></param>
    public void DeleteState(int id)
    {
        if (states.ContainsKey(id))
        {
            states.Remove(id);
            return;
        }
        Debug.LogError("FSM error:Can't delete state " + id.ToString() + ",it was not in list");
    }
    /// <summary>
    /// 该方法基于当前状态和过渡状态是否通过来尝试改变状态机的状态，当当前状态没有目标状态用来过渡时则打印错误信息
    /// 切换当前状态到下一个要转换的状态
    /// </summary>
    /// <param name="trans"></param>
    public void ChangeState(int id)
    {
        if (!states.ContainsKey(id))
        {
            Debug.LogError("FSM error: State " + id + "not exist.");
            return;
        }

        //更新当前的状态机和状态编号
        currentStateID = id;
        //在状态变为新状态前执行后处理
        if (currentFSMState != null)
        {
            currentFSMState.DoBeforeLeaving();
        }

        currentFSMState = states[id];

        //在状态可以使用Reason（动机）或者Act（行为）之前为它的决定条件重置它自己
        currentFSMState.DoBeforeEntering();

    }
}
