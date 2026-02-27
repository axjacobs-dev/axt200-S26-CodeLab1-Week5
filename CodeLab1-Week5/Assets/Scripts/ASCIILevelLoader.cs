using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    //prefab in Unity for objects
    public GameObject blackWidow;
    public GameObject bush;
    public GameObject cicada;
    public GameObject farmHouse;
    public GameObject logCabin;
    public GameObject smallHouse;
    public GameObject tree;
    public GameObject water;
    public GameObject whiteTree;
    public GameObject wall;
    public GameObject player;
    public GameObject door;
    public string fileLocation; //declares string for file location

    string fullPath; //full path to the current level file

    int currentLevel = 0;

    GameObject loadedLevel;

    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get
        {
            return currentLevel;
        }
    }

    //next to ints are the 'easy' way to resolve offsets
    public int xOffset; //number to adjust offset of level loaded location
    
    public int yOffset; //number to adjust offset of instantiated prefab

    public static ASCIILevelLoader instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //creating full path to file location
        fullPath = Application.dataPath + "/" + fileLocation;
        //runs function that pulls info from file to create new level based on file contents
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        Destroy(loadedLevel);
        loadedLevel = new GameObject("Level " + currentLevel);
        string fullPath = this.fullPath.Replace("<num>", currentLevel + "");
        
        //read the file and put each line into a slot of the "lines" string array
        //will give us an array of strings where every string is a line in the file
        string[] lines = File.ReadAllLines(fullPath);
      
        //goes through each line in the array and puts it into whatever variable you declare
        //but here we are using it for debugging
        foreach (string line in lines)
        {
            Debug.Log(line);
//the 'harder' way to handle offsets
            int lengthOfLine = line.Length / 2; //check to see how long this line is

            if (lengthOfLine > xOffset) // if it is longer than the current offset
            //then replace current offset with this one
            {
                xOffset = lengthOfLine;
            }
        }

        yOffset = lines.Length / 2;  //offset y based on how mnay lines there are in the filed
        //xOffset = lines[0].Length / 2; // offset x by the length of the string of the first line
        //DONE: loop through all the lines in the file
        
        for (int y = 0; y < lines.Length; y++) //y determines the y position in the world
        { 
            string currentLineFromFile = lines[y];
            //DONE: look at every character in each line
            for (int x = 0; x < lines[y].Length; x++) //x determines the x position in the world
            {
                //gets the character from that line at x
                char currentChar = currentLineFromFile[x];
                GameObject newObject = null;

                switch (currentChar)
                {
                    case 'B':
                        newObject = Instantiate<GameObject>(blackWidow);
                        break;
                    case 'b':
                        newObject = Instantiate<GameObject>(bush);
                        break;
                    case 'w':
                        newObject = Instantiate<GameObject>(whiteTree);
                        break;
                    case 'T':
                        newObject = Instantiate<GameObject>(tree);
                        break;     
                    case 'W':
                        newObject = Instantiate<GameObject>(wall);
                      //  newWall.transform.position = new Vector2(-xOffset + x, yOffset - y);
                        break;
                    case 'P':
                        newObject = Instantiate<GameObject>(player);
                       // newPlayer.transform.position = new Vector2(-xOffset + x, yOffset - y);
                        break;
                    case 'd':
                        newObject = Instantiate<GameObject>(door);
                        break;
                    case 'F':
                        newObject = Instantiate<GameObject>(farmHouse);
                        break;
                    case 'R':
                        newObject = Instantiate<GameObject>(smallHouse);
                        break;
                    case 'L':
                        newObject = Instantiate<GameObject>(logCabin);
                        break;
                    case 'C':
                        newObject = Instantiate<GameObject>(cicada);
                        break;
                    case 'a':
                        newObject = Instantiate<GameObject>(water);
                        break;
                    default:
                        break;
                }
                if (newObject != null)
                {
                    newObject.transform.position = new Vector2(-xOffset + x, yOffset - y);
                    newObject.transform.SetParent(loadedLevel.transform.parent);
                }

                // if (currentChar == 'W')
                // {        
                //     //DONE: create new gameObject base on the character
                //     //creates wall prefab
                //     //you could instantiate it at a specific spot if what follows 'wall' is
                //     //Vector3.zero [but be more specific if you want], Quaternion.identity
                //     // GameObject newWall = Instantiate<GameObject>(wall);
                //     // newWall.transform.position = new Vector2(-xOffset + x, -y + yOffset);
                //     //x is index of character in the string, y is line
                //     //but remember that in the file an increase in number
                //     //translates differently when set to a coordinate
                //     //so make y -y if you want it to appear as it is in the file
                // }
                //
                // if (currentChar == 'P')
                // {
                //     // GameObject newPlayer = Instantiate<GameObject>(player);
                //     // newPlayer.transform.position = new Vector2(-xOffset + x, -y + yOffset);
                // }
            }
        }
       
    }
}
