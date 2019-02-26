///<summary>描述:
///作者:唐泽彬 
///创建时间: 2019/02/13 17:13:53 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class DragItemUI : ItemUI
    {

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void SetLocalPos(Vector2 pos)
        {
            transform.localPosition = pos;
        }
    }
}