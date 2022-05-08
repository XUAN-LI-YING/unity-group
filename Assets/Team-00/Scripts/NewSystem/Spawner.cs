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
    //Animator animator;
    private bool Des;
    Vector2 setTrap ;
    public static Spawner instance;
    

    void Update()
    {
        Des = GameData.Des;
        //Debug.Log(Des);
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
        //get the world space poistion of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mousePos);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos); 
            //Debug.Log(cellPosDefault);
            //setTrap = new Vector2(cellPosDefault.x - 0.35f ,cellPosDefault.y + 0.12f);
            // get the center position of the cell
            //var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            setTrap = new Vector2(cellPosCentered.x - 1.22f ,cellPosCentered.y - 0.42f);

            //Debug.Log(cellPosCentered);
            //Debug.Log(setTrap);
            //check if we can spawn in that cell(collider)
        //Detect when mouse id clicked (first touch clicked)
        if(Input.GetMouseButtonDown(0))
        {
            
            if(spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                //spawn the trap
                //testSprite.transform.position = cellPosCentered;
                SpawnTrap(setTrap);
                //Disable the collider
                spawnTilemap.SetColliderType(cellPosDefault,Tile.ColliderType.None);
                /*//TEST enable sprite
                testSprite.enabled = true;*/
                Des = false;
                GameData.Des = Des;
            }
            /*else
            {
                //TEST Disable sprite
                testSprite.enabled = false;
                //TEST Enable the collider
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.Sprite);
            }*/
        }
        if(Des == true)
            {
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.Sprite);  
            }
        
    }

    void SpawnTrap(Vector3 position)
    {
        GameObject trap = Instantiate(trapsPrefabs[spawnID],spawnTrapRoot);
        trap.transform.position = position;
        //if ()
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

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if(spawnID != -1)
        {
            if(other.CompareTag ("Player"))
            {
                animator.Play("Player@Build");
            }
        }
    }*/

}
