///<summary>描述:
///作者:唐泽彬 
///创建时间: 2019/02/13 16:47:37 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BagSystems
{
    public class TooltipUI : MonoBehaviour
    {

        Text tex_Des;
        Image img_Icon;
        Text tex_Name;
        Text tex_Count;
        Button btn_Use;

        Item tempItem;

       
        public void UpdateText(Item item)
        {
            tempItem = item;
            tex_Des.text = "道具描述:" + item.Description;
            //Debug.Log(item.ItemType);
            if (item.ItemType==ItemType.Props)
            {
                 
                    Props props = item as Props;
                    tex_Count.text = props.Count.ToString();
                    //Debug.Log(tex_Count.text);
            }
            else
            {
                tex_Count.text = "1";
            }

            tex_Name.text = item.Name;
            img_Icon.sprite = Resources.Load<Sprite>(item.Sprite);

           
        }

        
        public void SetLocalPos(Vector2 pos)
        {
            transform.localPosition = pos;
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        private void Awake()
        {
            Init();
            Hide();
        }

        void Init()
        {
            tex_Des = transform.GetChild(0).Find("Img_Tooltip").GetComponentInChildren<Text>();
            img_Icon = transform.GetChild(0).Find("Left").GetChild(0).GetComponent<Image>();
            tex_Name = transform.GetChild(0).Find("Tex_Name").GetComponent<Text>();
            tex_Count= transform.GetChild(0).Find("Tex_Count").GetChild(0).GetComponent<Text>();
            btn_Use= transform.GetChild(0).Find("Btn_Buttom").GetChild(0).GetComponent<Button>();
            
            tex_Des.text = "道具描述:";
            img_Icon.sprite = null;
            tex_Name.text = "";
            tex_Count.text = "0";

        }
         
    }
}