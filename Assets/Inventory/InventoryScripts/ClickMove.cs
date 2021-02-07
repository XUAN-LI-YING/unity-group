using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClickMove : MonoBehaviour
{
    private static readonly List<Vector2Int> tileOffset = new List<Vector2Int>()    //建立儲存移動方向的List
    {
        Vector2Int.right,Vector2Int.left
    };

    private static readonly Dictionary<string, int> tileMoveCostDictinonary = new Dictionary<string, int>() //格子需消耗的點數
    {
        { "Base",1}
    };
    private Camera mainCamera;
    private List<Vector2Int> movePointRangeList;        //tilemap座標
    private List<Vector2Int> blockingPointList;         //大於1格子tilemap座標
    private List<int> blockingRemainList;               //消耗點數




    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        movePointRangeList = new List<Vector2Int>();
        blockingPointList = new List<Vector2Int>();
        blockingRemainList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            raycastHit2D = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
            if (raycastHit2D.collider != null)
            {
                switch(raycastHit2D.transform.tag)
                {
                    case "Infantry":
                        currentSelect = RaycastHit2D.transform;

                        if (movePointObjParent.childCount == 0)
                        {
                            DisplayMovementRange(GridLayout.WorldToCell(raycastHit2D.point));
                        }
                        else
                        {
                            currentSelect = null;

                            CleanMovementRangeObj();
                        }
                        break;
                    case "TileMap":
                        if (currentSelect != null)
                        {
                            currentSelect.localPosition = GridLayout.CellToLocal(GridLayout.WorldToCell(RaycastHit2D.point));

                            currentSelect = null;

                            CleanMovementRangeObj();
                        }
                        break;
                }
            }
        }
    }
}
