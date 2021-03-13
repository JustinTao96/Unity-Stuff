using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetMaps : ManagerTemplate<PresetMaps>
{

    // FOREST
    public List<List<Room>> ForestMaps = new List<List<Room>> { };
    public int ForestMapWidth = 5;
    public int ForestMapHeight = 5;


    // ICE
    public List<List<Room>> IceMaps = new List<List<Room>> { };





    // || LAYOUTS ||
    // 5x5 layouts: 

    List<Room.ROOMTYPE> fiveTimesFiveLayoutTemplate = new List<Room.ROOMTYPE>
    {
       Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
       Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
       Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
       Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
       Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
    };

    public List<bool> Layout1 = new List<bool>
    {
        false, false, false, true,  true,
        true,  true,  false, true,  true,
        false, false, false, true,  true, 
        true,  true,  false, true,  true,
        true,  true,  false, false, false
    };



    // TEST WIP: MAYBE DONT USE. 
    public class Layout2
    {
        List<bool> wallLayout = new List<bool>
        {
          false, false, false, true,  true,
          true,  true,  false, true,  true,
          false, false, false, true,  true,
          true,  true,  false, true,  true,
          true,  true,  false, false, false
        };

        List<Room.ROOMTYPE> typeLayout = new List<Room.ROOMTYPE>
        {
            Room.ROOMTYPE.ENTRANCE, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
            Room.ROOMTYPE.EMPTY,    Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
            Room.ROOMTYPE.EMPTY,    Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
            Room.ROOMTYPE.EMPTY,    Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY,
            Room.ROOMTYPE.EMPTY,    Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.EMPTY, Room.ROOMTYPE.BOSS,
        };
    }




    // || FUNCTIONS ||


    // Listof Listof Rooms -> Listof Listof Rooms. 
    // populates the values in all map lists to create a list of maps.
    public void PopulateAllMapsList()
    {
        ClearAllMapsList(); 
        PopulateForestMapsList();
        // populateicemapslist
        // ...
    }

    // Listof Listof Rooms -> Listof Listof Rooms. 
    // deletes all values in all map lists to save space. 
    public void ClearAllMapsList()
    {
        ForestMaps.Clear();
        // icemaps.clear()
        // ...
    }

    // populates the forest maps. 
    public void PopulateForestMapsList()
    {
        ForestMaps.Clear();

        // add each room layout that you want for forest maps
        ForestMaps.Add(CreateRoomLayout(Layout1));

    }

    private List<Room> CreateRoomLayout(List<bool> layout)
    {
        // generate a list of rooms based on the layout size. 
        List<Room> temp = CreateEmptyMap(layout.Count);
        
        // set each value in the listof rooms to either wall or path. 
        for (int i = 0; i < layout.Count; i++)
        {
            temp[i].wall = layout[i];
            temp[i].index = i; 
        }



        return temp;     
    }



    // @signature int int -> Listof Room. 
    // create a list of room with x width and y height
    private List<Room> CreateEmptyMap(int size)
    {
        List<Room> temp = new List<Room>();
 
        for (int i = 0; i < size; i++)
        {
            Room newRoom = new Room();
            temp.Add(newRoom); 
        }

        return temp; 
    }

}
