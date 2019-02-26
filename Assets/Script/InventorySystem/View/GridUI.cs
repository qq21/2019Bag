///<summary>描述:
///作者:唐泽彬 
///创建时间: 2019/02/13 16:12:06 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
namespace BagSystems
{
    public class GridUI : MonoBehaviour, IPointerEnterHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerExitHandler
    {
        //public delegate void OnPointEvent(string RecTransform);
        //public static OnPointEvent onEnter;
        // public static OnPointEvent onExit;

        //public delegate void OnDragEvent(Transform Trans);
        //public static OnDragEvent onEnterDrag;
        //public static OnDragEvent onExitDrag;


        public static Action<string> onEnter;
        public static Action<string> onExit;

        public static Action<Transform> onEnterDrag;
        public static Action<Transform, Transform> onEndDrag;


        // Func<int, string> func;
        // Use this for initialization

      

        #region  Pointer 事件
        //鼠标/手指  离开的 委托 事件
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerEnter.transform.CompareTag("Grid"))
            {
                if (onExit != null)
                {
                    onExit(transform.name);
                }
            }
        }

        //void IDragHandler.OnDrag(PointerEventData eventData) { }  

        //鼠标/手指  进入的 委托 事件
        public void OnPointerEnter(PointerEventData eventData)
        {

            if (eventData.pointerEnter.transform.CompareTag("Grid"))
            {
                if (onEnter != null)
                {
                    //空格子
                    //if (transform.CompareTag("BagItem"))
                    //{
                    onEnter(transform.name);

                    //  Debug.Log(transform.name);
                    //}
                }
            }
        }
        #endregion

        #region  Drag 拖的处理
        //Drag   在拖的 状态
        public void OnDrag(PointerEventData eventData)
        {
            //   onEndDrag(transform, eventData.pointerDrag.transform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {

           
                if (eventData.button == PointerEventData.InputButton.Left)
               {
              
                if (onEndDrag != null)
                {
                    if (eventData.pointerEnter == null)
                    {
                        //结束拖的时候  底下没有物品
                        //拖到一个空 格子或者 外面
                        onEndDrag(transform, null);
                    }
                    else
                    {
                
                        //结束拖的时候  底下有物品
                        //拖到一个 有物品的格子，或者其他UI
                        onEndDrag(transform, eventData.pointerEnter.transform);
                    }

                }
            }

        }

        //进入拖
        public void OnBeginDrag(PointerEventData eventData)
        {
           
                if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (onEnterDrag != null)
                {
                    onEnterDrag(transform);
                }
            }
        }
        #endregion
    }
}