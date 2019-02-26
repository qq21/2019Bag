///<summary>描述:道具类型 
///作者:唐泽彬 
///创建时间: 2019/02/15 09:10:14 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class Props : Item
    {
        PropsType propsType = PropsType.Other;
         
        int count;
        public Props(int id, string name, Quality quality, string description, string sprite, PropsType propsType,int count) : base(id, name, quality, description, sprite)
        {
            this.PropsType = propsType;
            this.count = count;
            ItemType = ItemType.Props;
        }

        public PropsType PropsType
        {
            get
            {
                return propsType;
            }

            set
            {
                propsType = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        
    }
}