using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    public Tile[] tiles;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
public enum type
{
    plataform,
    flayingPlataform,
    water
}