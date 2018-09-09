using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler,
    IPointerExitHandler,
    IPointerUpHandler, ISelectHandler, IUpdateSelectedHandler, IDeselectHandler, IDragHandler,
    IEndDragHandler, IDropHandler, IScrollHandler, IMoveHandler
{

    public delegate void UIPointerEventDelegate(GameObject go, PointerEventData data);

    public delegate void UIBaseEventDelegate(GameObject go, BaseEventData data);

    public delegate void UIAxisEventDelegate(GameObject go, AxisEventData data);

    public UIPointerEventDelegate onClick = delegate { };
    public UIPointerEventDelegate onDown = delegate { };
    public UIPointerEventDelegate onEnter = delegate { };
    public UIPointerEventDelegate onExit = delegate { };
    public UIPointerEventDelegate onUp = delegate { };
    public UIBaseEventDelegate onSelect = delegate { };
    public UIBaseEventDelegate onUpdateSelect = delegate { };
    public UIBaseEventDelegate onDeSelect = delegate { };
    public UIPointerEventDelegate onDrag = delegate { };
    public UIPointerEventDelegate onEndDrag = delegate { };
    public UIPointerEventDelegate onDrop = delegate { };
    public UIPointerEventDelegate onScroll = delegate { };
    public UIAxisEventDelegate onMove = delegate { };

    /// <summary>
    /// 用于对任意UI对象快速获取UI事件监听器
    /// </summary>
    /// <param name="go">对象</param>
    /// <returns>结果</returns>
    public static UIEventListener Get(GameObject go)
    {
        return go.GetComponent<UIEventListener>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick(gameObject, eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onDown(gameObject, eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter(gameObject, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit(gameObject, eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onUp(gameObject, eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelect(gameObject, eventData);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        onUpdateSelect(gameObject, eventData);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        onDeSelect(gameObject, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag(gameObject, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag(gameObject, eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        onDrop(gameObject, eventData);
    }

    public void OnScroll(PointerEventData eventData)
    {
        onScroll(gameObject, eventData);
    }

    public void OnMove(AxisEventData eventData)
    {
        onMove(gameObject, eventData);
    }
}
