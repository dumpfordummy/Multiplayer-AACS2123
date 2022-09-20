using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> activeBuildingType;
    private PathNode townhallNode, currentNode;
    private GridBase<PathNode> grid = GridHandler.grid;
    private int typeOfButton = 0;
    private woodResources woodResouce;
    private stoneResources stoneResource;
    private GameObject unlockTower1;
    private GameObject unlockTower2;
    private GameObject unlockTower3;
    private GameObject unlockStoneWall;
    public int buildTower1WoodQty;
    public int buildTower1StoneQty;
    public int buildTower2WoodQty;
    public int buildTower2StoneQty;
    public int buildTower3WoodQty;
    public int buildTower3StoneQty;
    public int buildStoneWallWoodQty;
    public int buildStoneWallStoneQty;
    private int posX, posY;

    private void Start()
    {
        townhallNode = grid.GetGridObject(GameObject.Find("/TownHall").GetComponent<Transform>().position);
        townhallNode.isOccupied = true;
        Pathfinding.obstacleList.Add(townhallNode);
        woodResouce = GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>();
        stoneResource = GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>();
        unlockTower1 = GameObject.FindGameObjectWithTag("UnlockTower1");
        unlockTower2 = GameObject.FindGameObjectWithTag("UnlockTower2");
        unlockTower3 = GameObject.FindGameObjectWithTag("UnlockTower3");
        unlockStoneWall = GameObject.FindGameObjectWithTag("UnlockStoneWall");
    }

    void Update()
    {
        PlaceBuildingValidate();

        if (Input.GetMouseButtonDown(0) && typeOfButton != 0)
        {
            GridBase<PathNode>.GetXY(GridBase<PathNode>.GetMouseWorldPosition(), out posX, out posY);
            currentNode = Pathfinding.GetNode(posX, posY);

            if (typeOfButton == 5) // shovel
            {
                RemoveTower(currentNode);
            }
            else
            {
                PlaceBuilding();
            }
        }
    }

    private void PlaceBuildingValidate()
    {
        if (woodResouce.getWoodQty() >= buildTower1WoodQty && stoneResource.getStoneQty() >= buildTower1StoneQty)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                typeOfButton = (typeOfButton == 1) ? 0 : 1;
            }
            unlockTower1.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
            unlockTower1.GetComponent<RectTransform>().localScale = Vector3.one;

        if (woodResouce.getWoodQty() >= buildTower2WoodQty && stoneResource.getStoneQty() >= buildTower2StoneQty)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                typeOfButton = (typeOfButton == 2) ? 0 : 2;
            }
            unlockTower2.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
            unlockTower2.GetComponent<RectTransform>().localScale = Vector3.one;

        if (woodResouce.getWoodQty() >= buildTower3WoodQty && stoneResource.getStoneQty() >= buildTower3StoneQty)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                typeOfButton = (typeOfButton == 3) ? 0 : 3;
            }
            unlockTower3.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
            unlockTower3.GetComponent<RectTransform>().localScale = Vector3.one;

        if (woodResouce.getWoodQty() >= buildStoneWallWoodQty && stoneResource.getStoneQty() >= buildStoneWallStoneQty)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                typeOfButton = (typeOfButton == 4) ? 0 : 4;
            }
            unlockStoneWall.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
            unlockStoneWall.GetComponent<RectTransform>().localScale = Vector3.one;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            typeOfButton = (typeOfButton == 5) ? 0 : 5;
        }

        if (typeOfButton == 0)
        {
            ResetButtonPosition(tower1: true, tower2: true, tower3: true, tower4: true, shovel: true);
        }
        else if (typeOfButton == 1)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(65, 55);
            ResetButtonPosition(tower2: true, tower3: true, tower4: true, shovel: true);
        }
        else if (typeOfButton == 2)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(185, 55);
            ResetButtonPosition(tower1: true, tower3: true, tower4: true, shovel: true);
        }
        else if (typeOfButton == 3)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(305, 55);
            ResetButtonPosition(tower1: true, tower2: true, tower4: true, shovel: true);
        }
        else if (typeOfButton == 4)
        {
            GameObject.FindGameObjectWithTag("StoneWallButton").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(425, 55);
            ResetButtonPosition(tower1: true, tower2: true, tower3: true, shovel: true);
        }
        else if (typeOfButton == 5)
        {
            GameObject.FindGameObjectWithTag("ShovelButton").GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(Screen.width - 65, 25);
            ResetButtonPosition(tower1: true, tower2: true, tower3: true, tower4: true);
        }
    }

    private void PlaceBuilding()
    {
        if (Pathfinding.obstacleList.Contains(currentNode))
            return;

        Instantiate(activeBuildingType[typeOfButton].prefab, grid.GetWorldPosition(posX, posY) + new Vector3(0.5f, 0.75f), Quaternion.identity);
        Pathfinding.obstacleList.Add(currentNode);

        if (typeOfButton == 1)
        {
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(buildTower1WoodQty);
            GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(buildTower1StoneQty);
        }
        else if (typeOfButton == 2)
        {
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(buildTower2WoodQty);
            GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(buildTower2StoneQty);
        }
        else if (typeOfButton == 3)
        {
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(buildTower3WoodQty);
            GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(buildTower3StoneQty);
        }
        else if (typeOfButton == 4)
        {
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().decWoddQty(buildStoneWallWoodQty);
            GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().decStoneQty(buildStoneWallStoneQty);
        }
        typeOfButton = 0;
    }

    private void RemoveTower(PathNode node)
    {
        Vector3 towerPos = grid.GetWorldPosition(node.x, node.y) + new Vector3(0.5f, 0.75f);
        GameObject[] defenseList = GameObject.FindGameObjectsWithTag("Defense");
        foreach (GameObject defense in defenseList)
        {
            if (defense.transform.position == towerPos && defense.name != "TownHall")
            {
                Destroy(defense);
                Pathfinding.obstacleList.Remove(node);
                break;
            }
        }
    }

    private void ResetButtonPosition(bool? tower1 = false, bool? tower2 = false, bool? tower3 = false, bool? tower4 = false, bool? shovel = false)
    {
        if (tower1 == true)
        {
            GameObject.FindGameObjectWithTag("Tower1Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        if (tower2 == true)
        {
            GameObject.FindGameObjectWithTag("Tower2Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        if (tower3 == true)
        {
            GameObject.FindGameObjectWithTag("Tower3Button").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        if (tower4 == true)
        {
            GameObject.FindGameObjectWithTag("StoneWallButton").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        if (shovel == true)
        {
            GameObject.FindGameObjectWithTag("ShovelButton").GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}
