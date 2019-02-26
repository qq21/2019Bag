///<summary>描述:背包物品类  数据模型层model 
///作者:唐泽彬 
///创建时间: 2019/02/12 16:49:22 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region  enumeration  about Inventory
namespace BagSystems
{
    public enum ItemType
    {
        /// <summary>
        /// 职业套装
        /// </summary>
        ProfessionalSuit,
        /// <summary>
        /// 散件 装扮
        /// </summary>
        Suit,
        /// <summary>
        /// 道具
        /// </summary>
        Props,
        /// <summary>
        /// 皮肤
        /// </summary>
        Skin,
        Other
    }
    //All Item
    public enum Quality
    {
        White,
        Green,
        Puple,
        Orange,
        Other
    }
    /// <summary>
    /// 性别类型
    /// </summary>
    public enum Sex
    {
        Boy,
        Girl,
        /// <summary>
        /// 通用
        /// </summary>
        Common
    }
    /// <summary>
    /// 职业套装类型
    /// </summary>
    public enum ProfessionalType
    {
        Nor7mal,
        Doctor,
        Magic,
        Thief,
        /// <summary>
        /// 萝莉
        /// </summary>
        Luoli,
        /// <summary>
        /// 正太
        /// </summary>
        Zhengtai,
        Boxer,
        Painter,
        /// <summary>
        /// 普通职业
        /// </summary>
        Other = 999

    }
    /// <summary>
    /// 散件  服饰 类型 
    /// </summary>
    public enum SuitType
    {
        Jacket,
        Pants,
        Shoe,
        Hat,
        WeaPon,
        Glasses,
        Earring,
        /// <summary>
        /// 皮肤纹案
        /// </summary>
        Tattoo,
        /// <summary>
        /// 披风
        /// </summary>
        Cloak,
        Other
    }
    /// <summary>
    /// 道具类型
    /// </summary>
    public enum PropsType
    {
        /// <summary>
        /// 礼包
        /// </summary>
        GiftPack,
        /// <summary>
        /// 改名卡
        /// </summary>
        RenameCard,
        /// <summary>
        /// 金币卡
        /// </summary>
        GoldCard,
        /// <summary>
        /// 喇叭
        /// </summary>
        Horn,
        /// <summary>
        /// 背包券
        /// </summary>
        BackPackCard,
        /// <summary>
        /// 合成需要用到的道具
        /// </summary>
        Compound,
        Other

    }
    /// <summary>
    /// 礼包类型
    /// </summary>
    public enum GiftType
    {
        /// <summary>
        /// 染色剂礼包
        /// </summary>
        Colorant,
        /// <summary>
        /// 合成需要用到的 礼包
        /// </summary>
        Compound,
        /// <summary>
        /// 光子科技盒
        /// </summary>
        Suit,
        Other
    }

    #endregion

    /// <summary>
    ///   所有物品的基类   item
    /// </summary>
    public class Item
    {
        private int id;
        private string name;
        ItemType itemType = ItemType.Other;

        Quality quality;
        private string description;


        private string sprite;

        public Item(int id, string name, Quality quality, string description, string sprite)
        {
            this.id = id;
            this.name = name;

            this.quality = quality;
            this.description = description;

            this.sprite = sprite;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public ItemType ItemType
        {
            get
            {
                return itemType;
            }

            set
            {
                itemType = value;
            }
        }

        public Quality Quality
        {
            get
            {
                return quality;
            }

            set
            {
                quality = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }


        public string Sprite
        {
            get
            {
                return sprite;
            }

            set
            {
                sprite = value;
            }
        }

    }
}
