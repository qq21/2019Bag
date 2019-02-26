///<summary>描述: 皮肤 类
///作者:唐泽彬 
///创建时间: 2019/02/12 17:10:12 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class Skin : Item
    {
        public Skin(int id, string name, Quality quality, string description, string sprite, ProfessionalType professionalType, Sex sex) : base(id, name, quality, description, sprite)
        {
            this.professionalType = professionalType;
            this.sex = sex;
            this.ItemType = ItemType.Skin;
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