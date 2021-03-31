using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject foundation;
    public GameObject wall;
    public GameObject celling;

    public BuildSystem buildSystem;
    public Construction_Element building;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !buildSystem.isBuilding && building.floor !=0 )
        {
            buildSystem.NewBuild(foundation);
            building.floor--;
        }

        if (Input.GetKeyDown(KeyCode.J) && !buildSystem.isBuilding && building.wall != 0)
        {
            buildSystem.NewBuild(wall);
            building.wall--;
        }
        

        if (Input.GetKeyDown(KeyCode.K) && !buildSystem.isBuilding && building.ceil != 0)
        {
            buildSystem.NewBuild(celling);
            building.ceil--;
        }
        
    }

}
