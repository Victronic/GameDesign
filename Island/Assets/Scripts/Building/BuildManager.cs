using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject foundation;
    public GameObject wall;
    public GameObject celling;

    public BuildSystem buildSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !buildSystem.isBuilding)
        {
            buildSystem.NewBuild(foundation);
        }

        if (Input.GetKeyDown(KeyCode.J) && !buildSystem.isBuilding)
        {
            buildSystem.NewBuild(wall);
        }

        if (Input.GetKeyDown(KeyCode.K) && !buildSystem.isBuilding)
        {
            buildSystem.NewBuild(celling);
        }
    }
}
