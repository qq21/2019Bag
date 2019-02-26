///<summary>描述:   服饰类  散件 服饰
///作者:唐泽彬 
///创建时间: 2019/02/12 17:25:38 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class Suit : ProfessionalSuit
    {
        SuitType suitType;
        public Suit(int id, string name, Quality quality, string description, string sprite, ProfessionalType professionalType, Sex sex, SuitType suitType) : base(id, name, quality, description, sprite, professionalType, sex)
        {
            this.suitType = suitType;
            this.ItemType = ItemType.Suit;
        }


        public SuitType SuitType
        {
            get
            {
                return suitType;
            }

            set
            {
                suitType = value;
            }
        }
    }
}