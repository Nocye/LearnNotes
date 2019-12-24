using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIEventNotes : MonoBehaviour,IPointerEnterHandler
{
    //使用eventtrigger会自动屏蔽除了你添加以外的其他UI事件,包括父物体的UI事件,比如拖拽,滚动
    public EventTrigger Trigger;

    private void Start()
    {        
        AddTriggersListener(Trigger, EventTriggerType.PointerEnter, PointerEnter);
    }

    public void PointerEnter(BaseEventData data) {
        Debug.Log("鼠标移入游戏物体");    
    }
    
    public static void AddTriggersListener(EventTrigger target, EventTriggerType eventTriggerType, Action<BaseEventData> action)
    {        
        if (target.triggers.Count == 0)
        {
            target.triggers = new List<EventTrigger.Entry>();
        }
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener(callBack);
        target.triggers.Add(entry);
    }

    //====================================================================================================================================================

    //实现UI接口就不会产生这个问题,只会覆盖你实现的接口的事件,不会影响其他事件
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("鼠标移入游戏物体");
    }
}
