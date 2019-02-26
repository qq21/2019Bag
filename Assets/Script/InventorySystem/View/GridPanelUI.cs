///<summary>描述:  负责管理所有的Grid
///作者:唐泽彬 
///创建时间: 2019/02/13 09:19:50 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BagSystems
{
    [System.Serializable]
    public struct Grids
    {
        public ItemType itemType;
        public Transform[] grids;
    }
    /// <summary>
    /// 描述:  负责管理所有的Grid
    /// </summary>
    public class GridPanelUI : MonoBehaviour
    {

        public Dictionary<ItemType, Transform[]> grids=new Dictionary<ItemType, Transform[]>();

        
        public Grids[] sGrids;

        private GameObject pro;
        private GameObject skin;
        private GameObject suit;
        private GameObject other;

        private void Awake()
        {
            foreach (var item in sGrids)
            {
                grids.Add(item.itemType, item.grids);
            }

            pro = transform.GetChild(0).gameObject;
            skin = transform.GetChild(1).gameObject;
            suit = transform.GetChild(2).gameObject;
            other = transform.GetChild(3).gameObject;

            Debug.Log(other.GetComponentsInChildren<RectTransform>().Length);

            if (grids[ItemType.Other].Length==0)
            {
                
            }
        }

        public void Show(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.ProfessionalSuit:
                    suit.SetActive(true);
                    pro.SetActive(false);
                    other.SetActive(false);
                    skin.SetActive(false);
                    break;
                case ItemType.Suit:
                    suit.SetActive(true);
                    pro.SetActive(false);
                    other.SetActive(false);
                    skin.SetActive(false);
                    break;
                case ItemType.Props:
                    suit.SetActive(false);
                    pro.SetActive(true);
                    other.SetActive(false);
                    skin.SetActive(false);
                    break;
                case ItemType.Skin:
                    suit.SetActive(false);
                    pro.SetActive(false);
                    other.SetActive(false);
                    skin.SetActive(true);
                    break;
                case ItemType.Other:
                    suit.SetActive(false);
                    pro.SetActive(false);
                    other.SetActive(true);
                    skin.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        
        public Transform GetEmeptyGrid(ItemType itemType)
        {
            for (int i = 0; i < grids[itemType].Length; i++)
            {
                if (grids[itemType][i].childCount <= 0)
                {
                    return grids[itemType][i];
                }
            }
            Debug.Log("物品栏已满！");
            return null;
        }

    }
}