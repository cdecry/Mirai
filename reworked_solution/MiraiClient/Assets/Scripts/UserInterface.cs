using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class UserInterface : MonoBehaviour
{
    public GameObject inventoryPanel, hairPanel, clothesPanel, boardsPanel, accessoriesPanel, favouritesPanel;
    public Button inventoryButton, closeInventoryButton, hairButton, clothesButton, boardsButton, accessoriesButton, favouritesButton;

    public static GameObject imagePrefab;
    public static GameObject itemSlot;
    public static Transform hairContainer;
    public static Transform clothesContainer;
    public static Transform boardsContainer;
    public static Transform accessoriesContainer;
    public static Transform favouritesContainer;

    public static SpriteAtlas spritePack;

    private void Awake()
    {
        imagePrefab = Instantiate(Resources.Load("imagePrefab")) as GameObject;
        spritePack = Instantiate(Resources.Load("Items")) as SpriteAtlas;
        itemSlot = Instantiate(Resources.Load("itemSlot")) as GameObject;

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
        DontDestroyOnLoad(imagePrefab);

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
        AddToInventory("redSquidHair1", 0);
    }

    public void slushNRushButton()
    {
        Client.ToSlushNRush();
    }

    public void shadyButton()
    {
        Client.ToShady();
    }

    #region Inventory

    public static void AddToInventory(string spriteName, int itemType)
    {

        GameObject item = Instantiate(imagePrefab) as GameObject;
        item.GetComponent<Image>().sprite = spritePack.GetSprite(spriteName);
        item.transform.SetParent(itemSlot.transform, false);

        switch(itemType)
        {
            case 0: //hair
                itemSlot.transform.SetParent(hairContainer, false);
                break;
            case 1: //clothes
                itemSlot.transform.SetParent(clothesContainer, false);
                break;
            case 2: //boards
                itemSlot.transform.SetParent(boardsContainer, false);
                break;
            case 3: //accessories
                itemSlot.transform.SetParent(accessoriesContainer, false);
                break;
            case 4: //favourites
                itemSlot.transform.SetParent(favouritesContainer, false);
                break;
        }
        
        //message.transform.localScale = messagePrefab.transform.localScale;
        Debug.Log("added hair :>");
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
    #endregion

}
