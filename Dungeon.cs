using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dungeon 
{
    // interpret a single floor of a dungeon. 
    public int id;
    public string name;
    

    public GameObject display;
    public Map map = new Map(); 
    public List<Enemy> spawnList;
    public List<Dungeon> floors;

    // rewards list: 



    public Dungeon(int inputid, string inputname, GameObject inputdisplay)
    {
        this.id = inputid;
        this.name = inputname;
        this.display = inputdisplay; 
    }

}
