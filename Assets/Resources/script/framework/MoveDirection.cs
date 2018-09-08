using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlideVector { nullVector, up, down, left, right };

public class MoveDirection : UIEventListener
{
    private Vector2 touchFirst = Vector2.zero; //手指开始按下的位置
    private Vector2 touchSecond = Vector2.zero; //手指拖动的位置
    private SlideVector currentVector = SlideVector.nullVector;//当前滑动方向
    private float timer = 0;//时间计数器  
    public float offsetTime = 0.1f;//判断的时间间隔 
    public float SlidingDistance = 80f;

    public delegate void DirChange(GameObject go, SlideVector dir);
    public DirChange OnDirChange = delegate { };


    void Awake()
    {
        onDown = new UIPointerEventDelegate(OnDown);
        onDrag = new UIPointerEventDelegate(OnDrag);
        onUp = new UIPointerEventDelegate(OnUp);
    }
        
    public void OnDown(GameObject go, PointerEventData data)
    {
        touchFirst = data.position;//记录开始按下的位置
        Debug.Log("toufirst" +  touchFirst.ToString());
    }

    public void OnDrag(GameObject go, PointerEventData data)
    {
        touchSecond = data.position;

        timer += Time.deltaTime;  //计时器

        if (timer > offsetTime)
        {
            touchSecond = data.position; //记录结束下的位置
            Vector2 slideDirection = touchFirst - touchSecond;
            float x = slideDirection.x;
            float y = slideDirection.y;

            if (y + SlidingDistance < x && y > -x - SlidingDistance)
            {

                if (currentVector == SlideVector.left)
                {
                    return;
                }

                Debug.Log("left");

                currentVector = SlideVector.left;
            }
            else if (y > x + SlidingDistance && y < -x - SlidingDistance)
            {
                if (currentVector == SlideVector.right)
                {
                    return;
                }

                Debug.Log("right");

                currentVector = SlideVector.right;
            }
            else if (y > x + SlidingDistance && y - SlidingDistance > -x)
            {
                if (currentVector == SlideVector.down)
                {
                    return;
                }

                Debug.Log("down");

                currentVector = SlideVector.down;
            }
            else if (y + SlidingDistance < x && y < -x - SlidingDistance)
            {
                if (currentVector == SlideVector.up)
                {
                    return;
                }

                Debug.Log("up");

                currentVector = SlideVector.up;
            }

            OnDirChange(gameObject, currentVector);

            timer = 0;
            touchFirst = touchSecond;
        }
    }

    public void OnUp(GameObject go, PointerEventData data)
    {
        currentVector = SlideVector.nullVector;
    }
}
