using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public enum ROOMTYPE { EMPTY, ENTRANCE, BOSS, STAIRS, BATTLE, TREASURE, EVENT }

    // Room id ranges from 0 to map.rooms.count
    // room id represents this room's index within a map list. 
    public int index; 
    public bool wall;
    public ROOMTYPE type = ROOMTYPE.EMPTY; 

}
