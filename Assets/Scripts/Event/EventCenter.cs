using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件中心 单例模式对象
/// 1.Dictionary
/// 2.委托
/// 3.观察者设计模式
/// </summary>
public class EventCenter : BaseManager<EventCenter>
{
    //key - 事件的名字
    //value - 对应的是 监听这个 事件，对就的委托函数
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">准备用来处理事件的委托函数</param>
    public void AddEventListener(string name,UnityAction<object> action)
    {
        //有没有对应的事件监听
        if(eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        else
        {
            eventDic.Add(name, action);
        }
    }

    /// <summary>
    /// 移除对应事件的监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">对应之前添加的委托函数</param>
    public void RemoveEventListener(string name,UnityAction<object> action)
    {
        //有没有对应的事件监听
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">哪一个名字的事件触发了</param>
    public void EventTrigger(string name,object info)
    {
        //有没有对应的事件监听
        if (eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke(info);
        }      
    }

    /// <summary>
    /// 清空事件中心
    /// 主要用在 场景切换时
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
