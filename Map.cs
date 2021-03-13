using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // interp the map of a single floor of a dungeon. 
    public enum MAPTYPE { FOREST, ICE, } // more later


    int mapWidth;
    int mapHeight;
    int currentRoomX;
    int currentRoomY;

    Room currentRoom = new Room(); 


    public MAPTYPE type;
   
    public List<Room> rooms = new List<Room>();

        
    // Move 1 unit left in x,y position
    public void MoveLeft()
    {
        if (currentRoomX > 0)
        {
            currentRoom = GetRoomAtXY((currentRoomX - 1), currentRoomY);
        }
       
    }

    // Move 1 unit right in x,y position
    public void MoveRight()
    {
        if (currentRoomX < mapWidth)
        {
            currentRoom = GetRoomAtXY((currentRoomX + 1), currentRoomY);
        }
    }

    // Move 1 unit up in x,y position
    public void MoveUp()
    {
        if (currentRoomY > 0)
        {
            currentRoom = GetRoomAtXY(currentRoomX, (currentRoomY - 1));
        }
    }

    // Move 1 unit down in x,y position
    public void MoveDown()
    {
        if (currentRoomY < mapHeight)
        {
            currentRoom = GetRoomAtXY(currentRoomX, (currentRoomY + 1));
        }
    }

    // List<room> -> List<room> 
    // populate the empty rooms with presets, then randomize the room types. 
    public void PopulateMap()
    {
        GetPresetMap();
        SetRoomTypes(); 


        // List<Room> -> List<room> 
        // finds the correct list of preset maps for the dungeon and picks one at random. 
        void GetPresetMap()
        {
            PresetMaps.Instance.PopulateAllMapsList();
            List<List<Room>> mapList = new List<List<Room>>();

            switch (this.type)
            {
                case MAPTYPE.FOREST:
                    mapHeight = PresetMaps.Instance.ForestMapHeight;
                    mapWidth = PresetMaps.Instance.ForestMapWidth;
                    mapList = PresetMaps.Instance.ForestMaps;
                    break;

                case MAPTYPE.ICE:
                    break;
            }


            rooms = mapList[Random.Range(0, (mapList.Count - 1))];
        }

        // List<Room> -> List<Room>
        // randomly set the types of rooms that will appear given some rules. 
        void SetRoomTypes()
        {
            // get a list of all traversable rooms
            List<Room> walkableRooms = GetWalkableRooms();

            // find the start point
            FindStart();

            // find the boss point 
            FindBoss();

            // Create min-max number of battle rooms
            CreateBattleRooms();

            // create min-max number of special rooms
            CreateEventRooms();

            // rest of the rooms remain empty. 




            void FindStart()
            {
                // make sure you are doing this on empty rooms
                List<Room> emptyRooms = GetEmptyRooms(); 

                // find random start point within list of walkable rooms. 
                int startPoint = Random.Range(0, (walkableRooms.Count - 1));
                walkableRooms[startPoint].type = Room.ROOMTYPE.ENTRANCE;

                // set current room to start
                currentRoom = rooms[walkableRooms[startPoint].index];

            }

            void FindBoss()
            {
                List<Room> emptyRooms = GetEmptyRooms();

                // get a list of rooms that are farthest from the start point
                List<Room> bossRooms = new List<Room>();
                bossRooms = FindFarthestRooms();


                // Pick one of those rooms at random to be the boss room
                bossRooms[Random.Range(0, (bossRooms.Count - 1))].type = Room.ROOMTYPE.BOSS;



                // WIP
                List<Room> FindFarthestRooms()
                {
                    List<Room> temp = new List<Room>();
                    return temp; 
                }

            }

            void CreateBattleRooms()
            {
                List<Room> emptyRooms = GetEmptyRooms();

            }

            void CreateEventRooms()
            {
                List<Room> emptyRooms = GetEmptyRooms();

            }

        }



    }



    // intx, inty -> Room
    // produce the room at x, y position in the list

    private Room GetRoomAtXY(int x, int y)
    {
        Room temp = new Room();
        int i = 0;

        i = x + mapWidth * y;

        temp = rooms[i]; 
        return temp; 
    }


    // Room -> intx, inty
    // set the currentX and currentY to the Room's coordinates. 

    private void GetCoordinates(Room r)
    {
        // the index of the current room in the RoomList
        int i = r.index; 

        int x = i % mapWidth;    // % is the "modulo operator", the remainder of i / width;
        int y = i / mapWidth;    // where "/" is an integer division


        currentRoomX = x;
        currentRoomY = y; 
    }





    // List<Room> -> List<Room> 
    // get the list of rooms that are traversable by the player within this map.
    private List<Room> GetWalkableRooms()
    {
        List<Room> temp = new List<Room>();

        foreach (Room r in rooms)
        {
            if (r.wall == false)
            {
                temp.Add(r);
            }
        }

        return temp;
    }


    // List<Room> -> List<Room> 
    // get the list of rooms that are traversable by the player within this map.
    private List<Room> GetEmptyRooms()
    {
        List<Room> temp = new List<Room>();
        List<Room> walkableRooms = GetWalkableRooms(); 

        foreach (Room r in walkableRooms)
        {
            if (r.type == Room.ROOMTYPE.EMPTY)
            {
                temp.Add(r);
            }
        }

        return temp;
    }



}
