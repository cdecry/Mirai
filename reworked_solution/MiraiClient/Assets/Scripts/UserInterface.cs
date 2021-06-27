using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.EventSystems;

public class UserInterface : MonoBehaviour
{
    public GameObject inventoryPanel, hairPanel, clothesPanel, boardsPanel, accessoriesPanel, favouritesPanel;
    public Button inventoryButton, closeInventoryButton, hairButton, clothesButton, boardsButton, accessoriesButton, favouritesButton;

    public static Transform hairContainer;
    public static Transform clothesContainer;
    public static Transform boardsContainer;
    public static Transform accessoriesContainer;
    public static Transform favouritesContainer;

    public static SpriteAtlas spritePack;

    public static int X_SPACE_BETWEEN_ITEM;
    public static int NUMBER_OF_COLUMN;
    public static int Y_SPACE_BETWEEN_ITEM;

    private List<int> _list;

    private void Awake()
    {
        X_SPACE_BETWEEN_ITEM = 100;
        NUMBER_OF_COLUMN = 4;
        Y_SPACE_BETWEEN_ITEM = 100;

        //imagePrefab = Instantiate(Resources.Load("imagePrefab")) as GameObject;

        spritePack = Instantiate(Resources.Load("Items")) as SpriteAtlas;
        //spritePack = Instantiate(Resources.Load("testPack")) as SpriteAtlas;


        //itemSlot = Instantiate(Resources.Load("itemSlot")) as GameObject;

        hairContainer = hairPanel.transform;
        clothesContainer = clothesPanel.transform;
        boardsContainer = boardsPanel.transform;
        accessoriesContainer = accessoriesPanel.transform;
        favouritesContainer = favouritesPanel.transform;

        inventoryPanel.SetActive(false);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(inventoryPanel);
        DontDestroyOnLoad(inventoryButton);
        DontDestroyOnLoad(spritePack);

        // option to choose which container to transform to

    }

    void Start()
    {
        inventoryButton.onClick.AddListener(OpenInventoryPanel);
        closeInventoryButton.onClick.AddListener(CloseInventoryPanel);
        hairButton.onClick.AddListener(OpenHairPanel);
        clothesButton.onClick.AddListener(OpenClothesPanel);
        boardsButton.onClick.AddListener(OpenBoardsPanel);
        accessoriesButton.onClick.AddListener(OpenAccessoriesPanel);
        favouritesButton.onClick.AddListener(OpenFavouritesPanel);
    }

    void OpenInventoryPanel()
    {
        inventoryPanel.SetActive(true);
        Inventory.AddItem(1);
        Inventory.AddItem(2);
        Inventory.AddItem(3);
        Inventory.AddItem(4);
        Inventory.AddItem(5);
        Inventory.AddItem(6);
        Inventory.AddItem(7);
        Inventory.AddItem(8);
        Inventory.AddItem(9);

        Debug.Log("inventory count is " + Inventory.items.Count);

        //_list = new List<int> { 2, 3, 0, 0, 0, 0, 0, 0, 0, 0 };

        //ClientSend.ChangeClothesRequest(_list);

        //Inventory.ChangeClothes(Client.instance.myId, 2);
        //Debug.Log("Client " + Client.instance.myId + " should have changed into clothe id");

    }

        // select dummy prefab, loadin item from itempack sprite atlas
        /*
         * on close inventory, send msg to server with items on dummy >> does user have this in their invnet
         * if yes send message to all players >> add these items in message from itemPack      just like add invent, for debugging trying to maker local add first.
         */

    #region Inventory

    public static void AddToInventory(string spriteName, int itemType)
    {
        var i = Inventory.items.Count;
        //GameObject item = Instantiate(Resources.Load("imagePrefab")) as GameObject;

        //GameObject item = Instantiate(Resources.Load(spriteName)) as GameObject;
        GameObject slot = Instantiate(Resources.Load("itemSlot")) as GameObject;
        slot.GetComponent<Button>().onClick.AddListener(ClickItem);

        if (itemType == 0)
        {
            spriteName = spriteName + "Back";
        }

        slot.GetComponent<Image>().sprite = spritePack.GetSprite(spriteName);
        slot.GetComponent<Image>().type = Image.Type.Simple;
        slot.GetComponent<Image>().SetNativeSize();
        //item.transform.SetParent(slot.transform, false);
        slot.GetComponent<RectTransform>().localPosition = GetPosition(i);

        switch(itemType)
        {
            case 0: //hair
                slot.transform.SetParent(hairContainer, false);
                break;
            case 1: //top
                slot.transform.SetParent(clothesContainer, false);
                break;
            case 2: //bottom
                slot.transform.SetParent(clothesContainer, false);
                break;
            case 3: //outfit
                slot.transform.SetParent(clothesContainer, false);
                break;
            case 4: //shoes
                slot.transform.SetParent(clothesContainer, false);
                break;
            case 5: //boards
                slot.transform.SetParent(boardsContainer, false);
                break;
            case 6: //head accessory
                slot.transform.SetParent(accessoriesContainer, false);
                break;
            case 7: //face accessory
                slot.transform.SetParent(accessoriesContainer, false);
                break;
            case 8: //body accessory
                slot.transform.SetParent(accessoriesContainer, false);
                break;
        }
        
        //message.transform.localScale = messagePrefab.transform.localScale;
    }

    public static void ChangeClothes(int _clientID, string spriteName, int itemType) // for every player     //client ID, not the player id to be implemented, call this for each item ???
    {

        //GameObject item = Instantiate(Resources.Load("imagePrefab")) as GameObject;

        Debug.Log("changeclothes ui spritename " + spriteName);

        if (itemType == 0)
        {
            spriteName = spriteName + "Front";
        }

        GameObject item = Instantiate(Resources.Load(spriteName)) as GameObject;

        switch (itemType)
        {
            case 0: //hair
                GameObject.Destroy(item);
                GameObject hairF = Instantiate(Resources.Load(spriteName)) as GameObject;
                GameObject hairB = Instantiate(Resources.Load(spriteName.Replace("Front", "Back"))) as GameObject;

                hairF.transform.SetParent(GameManager.players[_clientID].transform.Find("HairFront").transform, false);
                hairB.transform.SetParent(GameManager.players[_clientID].transform.Find("HairBack").transform, false);

                item.transform.SetParent(GameManager.players[_clientID].transform.Find("HairFront").transform, false); //front and back
                break;
            case 1: //tops  =
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Top").transform, false);
                break;
            case 2: //bottoms
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Bottom").transform, false);
                break;
            case 3: //outfits
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Outfit").transform, false);
                break;
            case 4: //shoes
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Shoes").transform, false);
                break;
            case 5: //boards
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Board").transform, false);
                break;
            case 6: //head acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("HeadAcc").transform, false);
                break;
            case 7: //face acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("FaceAcc").transform, false);
                break;
            case 8: //body acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("BodyAcc").transform, false);
                break;
        }

        Debug.Log("changed 1 item");

    }


    public static Vector2 GetPosition(int i)
    {
        Debug.Log(50 + X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN));
        return new Vector2(50 + X_SPACE_BETWEEN_ITEM * ((i-1) % NUMBER_OF_COLUMN), (-50 - Y_SPACE_BETWEEN_ITEM * ((i - 1) / (NUMBER_OF_COLUMN))));
    }

    void CloseInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }

    void OpenHairPanel()
    {
        hairPanel.SetActive(true);
        clothesPanel.SetActive(false);
        boardsPanel.SetActive(false);
        accessoriesPanel.SetActive(false);
        favouritesPanel.SetActive(false);
    }

    void OpenClothesPanel()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(true);
        boardsPanel.SetActive(false);
        accessoriesPanel.SetActive(false);
        favouritesPanel.SetActive(false);
    }

    void OpenBoardsPanel()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(false);
        boardsPanel.SetActive(true);
        accessoriesPanel.SetActive(false);
        favouritesPanel.SetActive(false);
    }
    void OpenAccessoriesPanel()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(false);
        boardsPanel.SetActive(false);
        accessoriesPanel.SetActive(true);
        favouritesPanel.SetActive(false);
    }

    void OpenFavouritesPanel()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(false);
        boardsPanel.SetActive(false);
        accessoriesPanel.SetActive(false);
        favouritesPanel.SetActive(true);
    }

    static void ClickItem()
    {
        // find a way to get this object name (which woudl bethe item name
        // client side dummy thing later on
        // for now: directly change clothes on click-
        // sende change cloth req with id
        var itemName = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name.Replace("(Clone)", "").Replace("Back", "");

        var requestedItem = ItemDatabase.items.FirstOrDefault(item => item.reference == itemName);
        if (requestedItem != null)
        {
            var itemList = new List<int> { requestedItem.id, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            ClientSend.ChangeClothesRequest(itemList);
            Debug.Log("ClickItem(): itemID requested is " + requestedItem.id);
            
        }

        

    }
    #endregion

}
