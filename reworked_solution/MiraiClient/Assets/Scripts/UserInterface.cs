using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.EventSystems;

public class UserInterface : MonoBehaviour
{
    public GameObject inventoryPanel, hairContainer, clothesContainer, boardsContainer, accessoriesContainer, aurasContainer, favouritesContainer;
    public GameObject hairPanel, topsPanel, bottomsPanel, outfitsPanel, socksPanel, shoesPanel, boardsPanel, headAccPanel, earsAccPanel, faceAccPanel, backAccPanel, bodyAccPanel, aurasPanel, favouritesPanel;
    public Button inventoryButton, closeInventoryButton, hairButton, clothesButton, boardsButton, accessoriesButton, aurasButton, favouritesButton;
    public Button topsButton, bottomsButton, outfitsButton, socksButton, shoesButton, headAccButton, earsAccButton, faceAccButton, backAccButton, bodyAccButton;


    public static Transform hairPanelT, topsPanelT, bottomsPanelT, outfitsPanelT, socksPanelT, shoesPanelT, boardsPanelT;
    public static Transform headAccPanelT, earsAccPanelT, faceAccPanelT, backAccPanelT, bodyAccPanelT, aurasPanelT, favouritesPanelT;

    public static SpriteAtlas spritePack;

    public static int X_SPACE_BETWEEN_ITEM;
    public static int NUMBER_OF_COLUMN;
    public static int Y_SPACE_BETWEEN_ITEM;

    public static bool disableClickMovement;

    private List<int> _list;

    private void Awake()
    {
        X_SPACE_BETWEEN_ITEM = 100;
        NUMBER_OF_COLUMN = 4;
        Y_SPACE_BETWEEN_ITEM = 100;

        //imagePrefab = Instantiate(Resources.Load("imagePrefab")) as GameObject;

        spritePack = Instantiate(Resources.Load("Items")) as SpriteAtlas;

        hairPanelT = hairPanel.transform;
        topsPanelT = topsPanel.transform;
        bottomsPanelT = bottomsPanel.transform;
        outfitsPanelT = outfitsPanel.transform;
        socksPanelT = socksPanel.transform;
        shoesPanelT = shoesPanel.transform;

        boardsPanelT = boardsPanel.transform;
        headAccPanelT = headAccPanel.transform;
        earsAccPanelT = earsAccPanel.transform;
        faceAccPanelT = faceAccPanel.transform;
        backAccPanelT = backAccPanel.transform;
        bodyAccPanelT = bodyAccPanel.transform;
        aurasPanelT = aurasPanel.transform;
        favouritesPanelT = favouritesPanel.transform;

        disableClickMovement = false;

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
        hairButton.onClick.AddListener(OpenHairPanel);
        clothesButton.onClick.AddListener(OpenClothesPanel);
        boardsButton.onClick.AddListener(OpenBoardsPanel);
        accessoriesButton.onClick.AddListener(OpenAccessoriesPanel);
        aurasButton.onClick.AddListener(OpenAurasPanel);
        favouritesButton.onClick.AddListener(OpenFavouritesPanel);

        topsButton.onClick.AddListener(OpenTopsPanel);
        bottomsButton.onClick.AddListener(OpenBottomsPanel);
        outfitsButton.onClick.AddListener(OpenOutfitsPanel);
        socksButton.onClick.AddListener(OpenSocksPanel);
        shoesButton.onClick.AddListener(OpenShoesPanel);

        headAccButton.onClick.AddListener(OpenHeadAccPanel);
        earsAccButton.onClick.AddListener(OpenEarsAccPanel);
        faceAccButton.onClick.AddListener(OpenFaceAccPanel);
        backAccButton.onClick.AddListener(OpenBackAccPanel);
        bodyAccButton.onClick.AddListener(OpenBodyAccPanel);

        closeInventoryButton.onClick.AddListener(CloseInventoryPanel);
    }

    void OpenInventoryPanel()
    {
        PlayerController.mouseMovement = false;
        disableClickMovement = true;
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
        slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = spritePack.GetSprite(spriteName);
        slot.transform.GetChild(0).gameObject.GetComponent<Image>().type = Image.Type.Simple;
        slot.transform.GetChild(0).gameObject.GetComponent<Image>().SetNativeSize();
        //item.transform.SetParent(slot.transform, false);
        //slot.GetComponent<RectTransform>().localPosition = GetPosition(i);

        switch(itemType)
        {
            case 0: //hair
                slot.transform.SetParent(hairPanelT, false);
                break;
            case 1: //top
                slot.transform.SetParent(topsPanelT, false);
                break;
            case 2: //bottom
                slot.transform.SetParent(bottomsPanelT, false);
                break;
            case 3: //outfit
                slot.transform.SetParent(outfitsPanelT, false);
                break;
            case 4: //socks
                slot.transform.SetParent(socksPanelT, false);
                break;
            case 5: //shoes
                slot.transform.SetParent(shoesPanelT, false);
                break;
            case 6: //boards
                slot.transform.SetParent(boardsPanelT, false);
                break;
            case 7: //head accessory
                slot.transform.SetParent(headAccPanelT, false);
                break;
            case 8: //ears accessory
                slot.transform.SetParent(earsAccPanelT, false);
                break;
            case 9: //face accessory
                slot.transform.SetParent(faceAccPanelT, false);
                break;
            case 10: //back accessory
                slot.transform.SetParent(backAccPanelT, false);
                break;
            case 11: //body accessory
                slot.transform.SetParent(bodyAccPanelT, false);
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
            case 4: //socks
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Socks").transform, false);
                break;
            case 5: //shoes
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Shoes").transform, false);
                break;
            case 6: //boards
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("Board").transform, false);
                break;
            case 7: //head acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("HeadAcc").transform, false);
                break;
            case 8: //ears acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("EarsAcc").transform, false);
                break;
            case 9: //face acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("FaceAcc").transform, false);
                break;
            case 10: //back acc
                item.transform.SetParent(GameManager.players[_clientID].transform.Find("BackAcc").transform, false);
                break;
            case 11: //body acc
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
        disableClickMovement = false;
        inventoryPanel.SetActive(false);
    }

    void OpenHairPanel()
    {
        Debug.Log("Opened Hair Container");
        hairContainer.SetActive(true);
        clothesContainer.SetActive(false);
        boardsContainer.SetActive(false);
        accessoriesContainer.SetActive(false);
        aurasContainer.SetActive(false);
        favouritesContainer.SetActive(false);
    }

    void OpenClothesPanel()
    {
        hairContainer.SetActive(false);
        clothesContainer.SetActive(true);
        boardsContainer.SetActive(false);
        accessoriesContainer.SetActive(false);
        aurasContainer.SetActive(false);
        favouritesContainer.SetActive(false);
    }

    void OpenBoardsPanel()
    {
        hairContainer.SetActive(false);
        clothesContainer.SetActive(false);
        boardsContainer.SetActive(true);
        accessoriesContainer.SetActive(false);
        aurasContainer.SetActive(false);
        favouritesContainer.SetActive(false);
    }
    void OpenAccessoriesPanel()
    {
        hairContainer.SetActive(false);
        clothesContainer.SetActive(false);
        boardsContainer.SetActive(false);
        accessoriesContainer.SetActive(true);
        aurasContainer.SetActive(false);
        favouritesContainer.SetActive(false);
    }

    void OpenAurasPanel()
    {
        hairContainer.SetActive(false);
        clothesContainer.SetActive(false);
        boardsContainer.SetActive(false);
        accessoriesContainer.SetActive(false);
        aurasContainer.SetActive(true);
        favouritesContainer.SetActive(false);
    }

    void OpenFavouritesPanel()
    {
        hairContainer.SetActive(false);
        clothesContainer.SetActive(false);
        boardsContainer.SetActive(false);
        accessoriesContainer.SetActive(false);
        aurasContainer.SetActive(false);
        favouritesContainer.SetActive(true);
    }

    void OpenTopsPanel()
    {
        topsPanel.SetActive(true);
        bottomsPanel.SetActive(false);
        outfitsPanel.SetActive(false);
        socksPanel.SetActive(false);
        shoesPanel.SetActive(false);
    }

    void OpenBottomsPanel()
    {
        topsPanel.SetActive(false);
        bottomsPanel.SetActive(true);
        outfitsPanel.SetActive(false);
        socksPanel.SetActive(false);
        shoesPanel.SetActive(false);
    }

    void OpenOutfitsPanel()
    {
        topsPanel.SetActive(false);
        bottomsPanel.SetActive(false);
        outfitsPanel.SetActive(true);
        socksPanel.SetActive(false);
        shoesPanel.SetActive(false);
    }

    void OpenSocksPanel()
    {
        topsPanel.SetActive(false);
        bottomsPanel.SetActive(false);
        outfitsPanel.SetActive(false);
        socksPanel.SetActive(true);
        shoesPanel.SetActive(false);
    }

    void OpenShoesPanel()
    {
        topsPanel.SetActive(false);
        bottomsPanel.SetActive(false);
        outfitsPanel.SetActive(false);
        socksPanel.SetActive(false);
        shoesPanel.SetActive(true);
    }

    void OpenHeadAccPanel()
    {
        headAccPanel.SetActive(true);
        earsAccPanel.SetActive(false);
        faceAccPanel.SetActive(false);
        backAccPanel.SetActive(false);
        bodyAccPanel.SetActive(false);
    }

    void OpenEarsAccPanel()
    {
        headAccPanel.SetActive(false);
        earsAccPanel.SetActive(true);
        faceAccPanel.SetActive(false);
        backAccPanel.SetActive(false);
        bodyAccPanel.SetActive(false);
    }

    void OpenFaceAccPanel()
    {
        headAccPanel.SetActive(false);
        earsAccPanel.SetActive(false);
        faceAccPanel.SetActive(true);
        backAccPanel.SetActive(false);
        bodyAccPanel.SetActive(false);
    }

    void OpenBackAccPanel()
    {
        headAccPanel.SetActive(false);
        earsAccPanel.SetActive(false);
        faceAccPanel.SetActive(false);
        backAccPanel.SetActive(true);
        bodyAccPanel.SetActive(false);
    }

    void OpenBodyAccPanel()
    {
        headAccPanel.SetActive(false);
        earsAccPanel.SetActive(false);
        faceAccPanel.SetActive(false);
        backAccPanel.SetActive(false);
        bodyAccPanel.SetActive(true);
    }
    static void ClickItem()
    {
        // find a way to get this object name (which woudl bethe item name
        // client side dummy thing later on
        // for now: directly change clothes on click-
        // sende change cloth req with id
        var itemName = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite.name.Replace("(Clone)", "").Replace("Back", "");

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
