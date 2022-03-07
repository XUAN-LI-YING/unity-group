using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public SpriteRenderer testSprite;
    //list of traps(prefabs) that will instatiate
    public List<GameObject> trapsPrefabs;
    //Transform of the spawning traps(Root Object)
    public Transform spawnTrapRoot;
    //list of traps(UI)
    public List<Image> trapsUI;
    //id of trap to spawn
    int spawnID = -1;
    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;

    void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse id clicked (first touch clicked)
        if(Input.GetMouseButtonDown(0))
        {
            //get the world space poistion of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos); 
            //Debug.Log(cellPosDefault);
            
            // get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            Debug.Log(cellPosCentered);
            //check if we can spawn in that cell(collider)
            if(spawnTilemap.GetColliderType(cellPosDefault)== Tile.ColliderType.Sprite)
            {
                //spawn the trap
                //testSprite.transform.position = cellPosCentered;
                SpawnTrap(cellPosCentered);
                //Disable the collider
                spawnTilemap.SetColliderType(cellPosDefault,Tile.ColliderType.None);
                /*//TEST enable sprite
                testSprite.enabled = true;*/
            }
            /*else
            {
                //TEST Disable sprite
                testSprite.enabled = false;
                //TEST Enable the collider
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.Sprite);
            }*/
        }
        
    }

    void SpawnTrap(Vector3 position)
    {
        GameObject trap = Instantiate(trapsPrefabs[spawnID],spawnTrapRoot);
        trap.transform.position = position;

        DeselectTrap();
    }

    public void SelectTrap(int id)
    {
        DeselectTrap();
        //Set the spawnID
        spawnID = id;
        //Highlight the tower
        trapsUI[spawnID].color = Color.white;
    }

    public void DeselectTrap()
    {
        spawnID = -1;
        foreach(var t in trapsUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }


}
