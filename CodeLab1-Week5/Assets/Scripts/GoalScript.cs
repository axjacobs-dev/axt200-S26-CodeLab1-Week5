using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Great Job");
        ASCIILevelLoader.instance.CurrentLevel++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
