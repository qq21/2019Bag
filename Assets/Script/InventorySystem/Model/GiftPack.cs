///<summary>描述:
///作者:唐泽彬 
///创建时间: 2019/02/15 09:13:48 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class GiftPack : Props
    {

        GiftType giftType;
        public GiftPack(int id, string name, Quality quality, string description, string sprite, PropsType propsType, GiftType giftType,int count) : base(id, name, quality, description, sprite, propsType,count)
        {
            propsType = PropsType.GiftPack;
            this.GiftType = giftType;
        }

        public GiftType GiftType
        {
            get
            {
                return giftType;
            }

            set
            {
                giftType = value;
            }
        }
    }
}
