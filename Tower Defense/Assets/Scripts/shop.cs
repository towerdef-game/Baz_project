
using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBlueprint gun;  
    public TurretBlueprint Missle;
    public TurretBlueprint laser;
    public TurretBlueprint wall;
    
    BuildManager BuildManager;
    // Start is called before the first frame update
    void Start()
    {
        BuildManager = BuildManager.instance;
    }

    public void GunTurret()
    {
        Debug.Log("Gun");
        BuildManager.SelectTurretToBuild(gun);
    }
    public void MissileTurret()
    {
        Debug.Log("Missile");
        BuildManager.SelectTurretToBuild(Missle);
    }
    public void LaserTurret()
    {
        Debug.Log("Laser");
        BuildManager.SelectTurretToBuild(laser);
    }
    public void Wall()
    {
        Debug.Log("wall");
        BuildManager.Trapbuild(wall);
    }
}
