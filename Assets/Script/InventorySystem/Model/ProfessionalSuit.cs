///<summary>描述:职业套装类
///作者:唐泽彬 
///创建时间: 2019/02/12 17:06:38 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class ProfessionalSuit : Item
    {
        public ProfessionalSuit(int id, string name, Quality quality, string description, string sprite, ProfessionalType professionalType, Sex sex) : base(id, name, quality, description, sprite)
        {
            this.professionalType = professionalType;
            this.sex = sex;
            this.ItemType = ItemType.ProfessionalSuit;
        }

        ProfessionalType professionalType;
        Sex sex;

        public ProfessionalType ProfessionalType
        {
            get
            {
                return professionalType;
            }

            set
            {
                professionalType = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }
    }
}
