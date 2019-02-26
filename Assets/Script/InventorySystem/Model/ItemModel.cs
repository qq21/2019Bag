///<summary>描述:  存储背包物品的数据， 数据类     背包里存在的Item ,键是格子的名字，值是 物品数据
///作者:唐泽彬 
///创建时间: 2019/02/13 17:20:08 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    public class ItemModel
    {
       
         static Dictionary<string,Item> itemDic = new Dictionary<string, Item>();

        /// <summary>
        /// 存储 物品数据
        /// </summary>
        /// <param name="key">格子名字</param>
        /// <param name="item">数据</param>
        public static void StoreItem(string key, Item  item)
        {
            //该格子有物品   
            if (itemDic.ContainsKey(key))
            {
                itemDic.Remove(key);
            }

            itemDic.Add(key, item);
        }
 
        /// <summary>
        /// 获取 已经 背包里 已经存在的物品 所在的格子 名字
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static string GetGridName(int itemId)
        {
            foreach (var item in itemDic)
            {
                //背包中 存在该物品  
                if (item.Value.Id==itemId)
                {
                    switch (itemDic[item.Key].ItemType)
                    {
                        case ItemType.ProfessionalSuit:
                            //TODO: 获取 皮肤 碎片等等....
                            break;
                        case ItemType.Suit:
                            break;
                        case ItemType.Props:
                            Props props = itemDic[item.Key] as Props;
                            props.Count++;
                            //更新数量
                            break;
                        case ItemType.Skin:
                            break;
                        case ItemType.Other:
                            break;
                        default:
                            break;
                    }
                    return  item.Key;
                }
            }
            return "";
        }

        /// <summary>
        /// 取 item 数据 通过物品名字
        /// </summary>
        /// <param name="key">格子名字</param>
        /// <returns></returns>
        public static Item GetItem(string key)
        {
            if (itemDic.ContainsKey(key))
            {
                return itemDic[key];
            }
            else
            {
 
                return null;
            }
        }

        /// <summary>
        /// 通过物品名字 删除 物品 
        /// </summary>
        /// <param name="key">格子名</param>
        public static void DeleteItem(string key)
        {
            if (itemDic.ContainsKey(key))
            {
                itemDic.Remove(key);
            }
            else
            {
                Debug.LogWarning("该物品不存在" + key);
            }
        }
    }
}