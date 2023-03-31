using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridBehavior : MonoBehaviour
{
    public bool findDistance = false;
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int endX = 2;
    public int endY = 2;
    public List<GameObject> path = new List<GameObject>();
    void Awake()
    {
        gridArray = new GameObject[rows, columns];
        if (gridPrefab)
            generatGrid();
        else print("missing gridprefab, please assign");
    }

    // Update is called once per frame
    void Update()
    {
        if (findDistance)
        {
            SetDistance();  
            SetPath();
            findDistance = false;
        }
    }
    void generatGrid()
    {
        for(int i =0; i < columns; i++) 
        {
            for(int j=0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefab,new Vector3 (leftBottomLocation.x+scale*i,leftBottomLocation.y,leftBottomLocation.z+scale*j),Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x= i;
                obj.GetComponent<GridStat>().x = j;
                gridArray[i, j] = obj;

            }
        }
    }
    void SetDistance()
    {
        InitialSetup();
        int x = startX;
        int y = startY;
        int[] testArrays = new int[rows * columns];
        for(int step = 1; step < rows * columns; step++)
        {
            foreach(GameObject obj in gridArray)
            {
                if (obj && obj.GetComponent<GridStat>().visited == step - 1)
                    TestFourDirection(obj.GetComponent<GridStat>().x, obj.GetComponent<GridStat>().y, step);
            }
        }
    }
     void SetPath()
    {
        int step;
        int x = endX;
        int y = endY;
        List<GameObject> templist = new List<GameObject>();
        path.Clear();
        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<GridStat>().visited>0)
        {
            path.Add(gridArray[x, y]);
              step = gridArray[x,y].GetComponent<GridStat>().visited - 1;
        }
        else
        {
            print("kan niet naar de gerichte locatie komen");
            return;
        }
        for(int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step,1 ))
                templist.Add(gridArray[x, y + 1]);
            if (TestDirection(x, y, step, 2))
                templist.Add(gridArray[x + 1, y ]);
            if (TestDirection(x, y, step, 3))
                templist.Add(gridArray[x, y - 1]);
            if (TestDirection(x, y, step, 4))
                templist.Add(gridArray[x - 1, y ]);

            GameObject temObj = FindClosest(gridArray[endX, endY].transform, templist);
            path.Add(temObj);
            x = temObj.GetComponent<GridStat>().x;
            y = temObj.GetComponent<GridStat>().y;
            templist.Clear();
        }
       
    }
    void InitialSetup()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridStat>().visited=0;
    }
    bool TestDirection(int x, int y, int step, int direction)
    {
        //int direction verteld welke kant die op moet 
        switch(direction)
        {
            //4 is links
            case 4:
                if (x - 1 > -1 && gridArray[x+1, y ] && gridArray[x + 1, y ].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
                //3 is onder
            case 3:
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
                //2 is rechts
            case 2:
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y ].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
                //links boven 
            case 1:
                if(y+1<rows&& gridArray[x , y + 1] && gridArray[x , y + 1].GetComponent<GridStat>().visited == step)
                    return true;
                else 
                    return false;
        }
        return false;
    }
    void TestFourDirection(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1))
            SetVisited(x, y + 1, step);
        if (TestDirection(x, y, -1, 2))
            SetVisited(x + 1, y , step);
        if (TestDirection(x, y, -1, 3))
            SetVisited(x, y - 1, step);
        if (TestDirection(x, y, -1, 4))
            SetVisited(x - 1, y , step);
    }
    void SetVisited (int x,  int y, int step)
    {
        if(gridArray[x,y])
         gridArray[x,y].GetComponent<GridStat>().visited = step;
        
    }
    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = scale * rows * columns;
        int indexNumber = 0;
        for(int i = 0; i < list.Count; ++i) 
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position)< currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = 1;
            }
        }
        return list[indexNumber];

    }
}
