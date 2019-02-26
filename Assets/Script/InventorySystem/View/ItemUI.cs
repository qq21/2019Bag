///<summary>描述: 负责显示物品的UI显示  View层 负责控制UI显示
///作者:唐泽彬 
///创建时间: 2019/02/13 09:19:59 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BagSystems
{
    public class ItemUI : MonoBehaviour
    {
        public Text text;

        public Image image;


        public void UpdateImg(Sprite sprite)
        {
            image.sprite = sprite;
        }
        /// <summary>
        ///  更换  图片精灵
        /// </summary>
        /// <param name="scr">路径</param>
        public void UpdateImg(string scr)
        {
            //TODO:  加载图片资源
            
            Sprite sp = Resources.Load<Sprite>(scr);

            UpdateImg(sp);
        }

        /// <summary>
        /// 更新 物品 数量
        /// </summary>
        /// <param name="str"></param>
        public void UpdateText(string str)
        {
            text.text = str;
        }
    }
}