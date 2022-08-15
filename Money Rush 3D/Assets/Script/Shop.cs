using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
        public Mesh PlayerGun;
    }

    [SerializeField] List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Text CoinsText;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;
    Button SelectBtn;
    MeshFilter MeshFilter;
    Mesh Mesh;
    public GunController Gun;

    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild (0).gameObject;

        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate (ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild (0).GetComponent <Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(3).GetComponent<Button>();
            buyBtn.interactable = !ShopItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, onShopItemBtnClicked);
            MeshFilter = Gun.GetComponent<MeshFilter>();
            SelectBtn = g.transform.GetChild(2).GetComponent<Button>();
            SelectBtn.interactable = false; 
            SelectBtn.AddEventListener(i, se);
        }

        Destroy(ItemTemplate);

        //change UI Text: coins
        SetCoinsUI();
    }

    void onShopItemBtnClicked(int itemIndex)
    {

        if (Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            // purchase Item
            ShopItemsList[itemIndex].IsPurchased = true;
            MeshFilter.mesh = ShopItemsList[itemIndex].PlayerGun;

            // enabel the butten
            SelectBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            SelectBtn.interactable = true;

            // disable the butten
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";


            //change UI Text: coins
            SetCoinsUI();
        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
        }
    }

    void se (int itemIndex)
    {
        if (SelectBtn)
        {
            MeshFilter.mesh = ShopItemsList[itemIndex].PlayerGun;
        }
    }
    /*-----------------------Shop Coins UI----------------------*/

    void SetCoinsUI()
    {
        CoinsText.text = Game.Instance.Coins.ToString();
    }

}
