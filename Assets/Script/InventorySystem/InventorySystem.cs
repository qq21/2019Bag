///<summary>描述:游戏存货系统 
///作者:唐泽彬 
///创建时间: 2019/02/12 16:49:22 
///版本:v1.0
///</summary>using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
namespace BagSystems
{
    public class InventorySystem : MonoBehaviour
    {

        /// <summary>
        ///   涉及到  背包的分类， 衣服 服饰类， 道具类 不放一起;   背包物品表  
        /// </summary>
        public Dictionary<ItemType, Dictionary<int, Item>> ItemDic = new Dictionary<ItemType, Dictionary<int, Item>>();

        /// <summary>
        /// 格子总数
        /// </summary>
        public int GridCount;
        static InventorySystem _instance;
        public GridPanelUI gridPanelUI;

        bool isShowtoolTip = false;
        bool isDrag = false;
        private RectTransform _rectTransform;
        Transform oldTran;
        Transform newTran;
        public TooltipUI tooltipUI;
        public DragItemUI dragItemUI;
        public static InventorySystem Instance
        {
            get
            {
                return _instance;
            }
        }

        private GameObject btnList;

        /// <summary>
        /// 记录当前背包物品的类型 ,用来显示当前要面试 的面板
        /// </summary>
        public ItemType currentBagType;
        private void Awake()
        {
            _instance = this;


            Init();

            StoreItem(30001, 1);
            StoreItem(10000, 2);

            StoreItem(40000, 1);
            StoreItem(20005);
            StoreItem(20001);
            StoreItem(20002);
            StoreItem(20003);
            StoreItem(20004);

        }

       
        void Init()
        {


            if (gridPanelUI == null)
            {
                gridPanelUI = transform.GetComponentInChildren<GridPanelUI>();
            }

            btnList = transform.parent.Find("Btns_Right").gameObject;


            _rectTransform = transform.GetComponent<RectTransform>();
            LoadItem();


            EventInit();


            #region Test code
            //Suit item= GetItem<Suit>(20001);
            //Props skinPiece = GetItem<Props>(10000);
            //Props prop
            #endregion
        }

        void EventInit()
        {
            //  Point   Event
            GridUI.onEnter += GridUIOnEnter;
            GridUI.onExit += GridUIOnExit;


            //Drag Event
            GridUI.onEnterDrag += GridUIOnDragEnter;
            GridUI.onEndDrag += GridUIOnDragExit;

            Button[] btns = btnList.transform.GetComponentsInChildren<Button>();



            btns[0].onClick.AddListener(() =>
            {
                currentBagType = ItemType.ProfessionalSuit;
                gridPanelUI.Show(ItemType.ProfessionalSuit);
            });
            btns[1].onClick.AddListener(() =>
            {
                gridPanelUI.Show(ItemType.Skin);
                currentBagType = ItemType.Skin;

            }); btns[2].onClick.AddListener(() =>
            {
                gridPanelUI.Show(ItemType.Props);
                currentBagType = ItemType.Props;
            });

            btns[3].onClick.AddListener(() =>
            {            
                currentBagType = ItemType.Other;
                gridPanelUI.Show(ItemType.Other);
            });
        }

        private void Update()
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, Input.mousePosition, null, out pos);
            if (!isDrag)
            {
                if (isShowtoolTip)
                {
                    tooltipUI.Show();
                }
            }
            else
            {
                dragItemUI.Show();
                dragItemUI.SetLocalPos(pos);
            }

            //模拟存储
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                StoreItem(30001, 1);
                StoreItem(10000, 2);

                StoreItem(40000, 1);

            }
        }
        #region  GridUI  OnPointEvent
        public void GridUIOnEnter(string Rec)
        {
            Item item = ItemModel.GetItem(Rec);
            if (item == null)
            {
                return;
            }
            tooltipUI.UpdateText(item);
            isShowtoolTip = true;
            tooltipUI.Show();


        }
        public void GridUIOnExit(string Rec)
        {
            isShowtoolTip = false;
            // tooltipUI.Hide();
        }

        #endregion
        /// <summary>
        ///  拖拽 实现 思路 是   用一个DragItem作为 拖拽 时 显示的 物体;
        ///  在进入Drag的时候 取它的数据 更新图片,数据
        /// </summary>
        /// <param name="trans"></param>
        #region  GridUI  OnDragEvent
        public void GridUIOnDragEnter(Transform trans)
        {
            if (trans.childCount == 0)
            {
                //空格子
                return;
            }

            isDrag = true;

            oldTran = trans; //记录 下     正在 操作的物体;
            Item item = ItemModel.GetItem(trans.name);
            dragItemUI.UpdateImg(item.Sprite);

            //拖拽的时候 删除掉 前面的物体  遍历格子 底下的 显示的所有物体 
            for (int i = 0; i < trans.childCount; i++)
            {
                Destroy(trans.GetChild(i).gameObject);
            }
            //不删除数据
        }

        public void GridUIOnDragExit(Transform oldTrans, Transform newTrans)
        {
            if (oldTran == null)
            {
                return;
            }

            newTran = newTrans;
            isDrag = false;
            dragItemUI.Hide();
            //扔物品
            if (newTrans == null)
            {
                Item item = ItemModel.GetItem(oldTrans.name);
                CreateItem(item, oldTrans);
                Debug.Log("丢弃物品!");
                // ItemModel.DeleteItem(oldTran.name);
            }
            //格子
            else if (newTrans.CompareTag("Grid"))
            {
                //有物品
                if (newTrans.childCount > 0)
                {
                    Debug.Log(newTrans);
                    //交换 数据 

                    Item oriItem = ItemModel.GetItem(oldTrans.name);
                    Item newItem = ItemModel.GetItem(newTrans.name);


                    if (oldTran.childCount > 0)
                    {
                        Destroy(oldTran.GetChild(0).gameObject);
                    }
                    if (newTran.childCount > 0)
                    {
                        Destroy(newTran.GetChild(0).gameObject);
                    }

                    ItemModel.DeleteItem(oldTrans.name);
                    ItemModel.DeleteItem(newTran.name);

                    CreateItem(oriItem, newTrans);//在 新格子上 ，创建旧物品
                    CreateItem(newItem, oldTrans);//在 旧 格子上，创建 新物品
                    
                }

                else//无 物品  空格子
                {

                    //获取 拖住的物品 的数据
                    Item oriItem = ItemModel.GetItem(oldTrans.name);

                    //删除 原来格子的数据
                    ItemModel.DeleteItem(oldTrans.name);

                    //在 新格子上创建 Item
                    CreateItem(oriItem, newTrans);
                }

            }
            else  //放回原来 位置
            {
                Item item = ItemModel.GetItem(oldTrans.name);
                CreateItem(item, oldTrans);
            }
        }
        #endregion

        string GetTooltipText(Item item)
        {
            if (item == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("名称:{0}\n用途{1}\n", item.Name, item.Description);
            return sb.ToString();
        }
        /// <summary>
        ///存储功能 
        /// </summary>
        /// <param name="ItemId">物品Id</param>
        public void StoreItem(int ItemId, int count = 1)
        {
            ItemType type = GetItemType(ItemId);
            // Debug.Log(type);
            //表中不存在 该物品
            if (!ItemDic[type].ContainsKey(ItemId))
            {
                return;
            }

            //TODO:判断 背包中是否已经有改类的物品         判断物品类型是否可以 叠加

            //已经存在
            string gridName = ItemModel.GetGridName(ItemId);
            if (gridName != "")
            {
                //更新数量.

                switch (type)
                {
                    case ItemType.ProfessionalSuit:
                        break;
                    case ItemType.Suit:
                        break;
                    case ItemType.Props:
                        count -= 1;
                        Props props = ItemModel.GetItem(gridName) as Props;
                        props.Count += count;
                        //Debug.Log(props.Count);
                        tooltipUI.UpdateText(ItemModel.GetItem(gridName));
                        break;
                    case ItemType.Skin:
                        break;
                    case ItemType.Other:
                        break;
                    default:
                        break;
                }
             
            }
            else
            {
                Debug.Log("1");
                //没有 获取空格子
                //获取空格子
                Transform emptyGrid = gridPanelUI.GetEmeptyGrid(type);
                if (emptyGrid == null)
                {
                    Debug.Log("物品已满");
                    return;
                }

                Item item = ItemDic[type][ItemId];
                if (item.ItemType == ItemType.Props)
                {
                    Props props = item as Props;
                    props.Count = count;
                }

                CreateItem(item, emptyGrid);

            }


        }

        /// <summary>
        /// 道具:10000~20000,衣物装饰:20000~30000,皮肤:30000~40000,其他40000~+>>;
        /// </summary>
        /// <param name="id">物品Id</param>
        /// <returns>物品类型</returns>
        public ItemType GetItemType(int id)
        {
            ItemType type = ItemType.Other;
            //道具类
            if (id >= 10000 && id < 20000)
            {
                type = ItemType.Props;
            }//衣物服饰类
            else if (id >= 20000 && id < 30000)
            {
                type = ItemType.ProfessionalSuit;

            }//皮肤类
            else if (id >= 30000 && id < 40000)
            {
                type = ItemType.Skin;
            }//其他类
            else if (id >= 40000)
            {
                type = ItemType.Other;
            }
            return type;
        }
        /// <summary>
        /// 从表 中 得到 物品
        /// </summary>
        /// <typeparam name="T">物品类型</typeparam>
        /// <param name="id">物品的Id</param>
        /// <returns>某个类型的物品数据</returns>
        public T GetItem<T>(int id) where T : Item
        {
            ItemType type = GetItemType(id);
            if (ItemDic[type].ContainsKey(id))
            {
                return ItemDic[type][id] as T;
            }
            else
            {
                return default(T);
            }
        }

        public static void DestoryItem()
        {
        }

        /// <summary>
        ///  从格子底下 创建物品， 数据保存在ItemModel中
        /// </summary>
        /// <param name="item">数据</param>
        /// <param name="gridTrans">格子的Trans</param>
        void CreateItem(Item item, Transform gridTrans)
        {
            //TODO: 资源工厂 去加载，不同资源 对于不同工厂，待架构

            GameObject itemGoTemp = Resources.Load<GameObject>("Prefabs/Item");//拿到 模板

            GameObject itemGo = Instantiate(itemGoTemp);

            if (item == null)
            {
                return;
            }
            itemGo.GetComponent<ItemUI>().UpdateImg(item.Sprite);

            itemGo.transform.SetParent(gridTrans);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.transform.localScale = Vector3.one;

            //储存数据  进 格子里
            ItemModel.StoreItem(gridTrans.name, item);
        }



        /// <summary>
        /// 加载 数据 读取 ;
        /// </summary>
        void LoadItem()
        {
            ItemDic = new Dictionary<ItemType, Dictionary<int, Item>>();
            //道具
            Dictionary<int, Item> PropDic = new Dictionary<int, Item>();
            //皮肤
            Dictionary<int, Item> SkinDic = new Dictionary<int, Item>();
            //职业套装 套装散件
            Dictionary<int, Item> ProfessionSuitDic = new Dictionary<int, Item>();
            //其他  
            Dictionary<int, Item> otherDic = new Dictionary<int, Item>();




            //散件
            Suit furPants = new Suit(20001, "皮裤", Quality.Green, "兽皮制作而成的裤子", "Items/pants", ProfessionalType.Boxer, Sex.Boy, SuitType.Pants);
            Suit furPants2 = new Suit(20002, "皮肩", Quality.Green, "兽皮制作而成的护腕", "Items/shoulders", ProfessionalType.Boxer, Sex.Boy, SuitType.Jacket);
            Suit furPants3 = new Suit(20003, "皮鞋", Quality.Green, "兽皮制作而成的boots", "Items/boots", ProfessionalType.Boxer, Sex.Boy, SuitType.Shoe);
            Suit furPants4 = new Suit(20004, "铜帽", Quality.Puple, "兽皮制作而成的helmets", "Items/helmets", ProfessionalType.Boxer, Sex.Boy, SuitType.Hat);
            Suit furPants5 = new Suit(20005, "cloaks", Quality.Orange, "兽皮制作而成的cloaks", "Items/cloaks", ProfessionalType.Boxer, Sex.Boy, SuitType.Cloak);
            ProfessionalSuit furPants6 = new ProfessionalSuit(20006, "sword", Quality.Orange, "兽皮制作而成的sword", "Items/sword", ProfessionalType.Boxer, Sex.Boy);

            Skin furPants7 = new Skin(30001, "coins", Quality.Green, "coins", "Items/coins", ProfessionalType.Boxer, Sex.Boy);
            Props skinPiece = new Props(10000, "皮肤碎片", Quality.Orange, "用来合成皮肤", "Items/gem", PropsType.Other, 1);
            Item mistery = new Item(40000, "神秘物品", Quality.Orange, "非常神秘的物品", "Items/scroll");

            //装饰
            ProfessionSuitDic.Add(furPants.Id, furPants);
            ProfessionSuitDic.Add(furPants2.Id, furPants2);
            ProfessionSuitDic.Add(furPants3.Id, furPants3);
            ProfessionSuitDic.Add(furPants4.Id, furPants4);
            ProfessionSuitDic.Add(furPants5.Id, furPants5);
            ProfessionSuitDic.Add(furPants6.Id, furPants6);

            //皮肤
            SkinDic.Add(furPants7.Id, furPants7);

            //道具
            PropDic.Add(skinPiece.Id, skinPiece);

            //其他
            otherDic.Add(mistery.Id, mistery);

            ItemDic.Add(ItemType.Props, PropDic);
            ItemDic.Add(ItemType.Skin, SkinDic);
            ItemDic.Add(ItemType.ProfessionalSuit, ProfessionSuitDic);
            ItemDic.Add(ItemType.Other, otherDic);
        }

    }
}