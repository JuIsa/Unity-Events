using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class XZTileManager : MonoBehaviour
{
    public GameObject towerXZPref;
    public GameObject tower_XZPref;
    public GameObject towerX_ZPref;
    public GameObject tower_X_ZPref;

    public GameObject groundPref;

    public GameObject wall_xPref;
    public GameObject wall_zPref;

    public GameObject buildingxzPref;
    public GameObject building_xzPref;
    public GameObject buildingx_zPref;
    public GameObject building_x_zPref;

    public GameObject buildingxxPref;
    public GameObject building_xxPref;
    public GameObject buildingzzPref;
    public GameObject building_zzPref;

    private string[] tiles = new string[] {"towerxz", "tower_xz", "towerx_z", "tower_x_z",
                                            "ground",
                                            "wall_x", "wall_z",
                                            "buildingxz","building_xz","buildingx_z","building_x_z",
                                            "buildingxx","buildingzz","building_xx","building_zz"};

    private float x = 0;
    private float z = 0;
    private List<XZTile> xztiles = new List<XZTile>(); 
    void Start()
    {
        XZTile ground = new XZTile("ground", groundPref);
        
        XZTile towerxz = new XZTile("towerxz", towerXZPref);
        XZTile tower_xz = new XZTile("tower_xz", tower_XZPref);
        XZTile towerx_z = new XZTile("towerx_z", towerX_ZPref);
        XZTile tower_x_z = new XZTile("tower_x_z", tower_X_ZPref);

        XZTile wall_x = new XZTile("wall_x", wall_xPref);
        XZTile wall_z = new XZTile("wall_z", wall_zPref);

        XZTile buildingxz = new XZTile("buildingxz", buildingxzPref );
        XZTile building_xz = new XZTile("building_xz", building_xzPref);
        XZTile buildingx_z= new XZTile("buildingx_z", buildingx_zPref);
        XZTile building_x_z = new XZTile("building_x_z", building_x_zPref);

        XZTile buildingxx = new XZTile("buildingxx",buildingxxPref);
        XZTile building_xx = new XZTile("building_xx",  building_xxPref);
        XZTile buildingzz = new XZTile("buildingzz", buildingzzPref);
        XZTile building_zz = new XZTile("building_zz", building_zzPref);

        xztiles.Add(ground);
        xztiles.Add(towerxz);
        xztiles.Add(towerx_z);
        xztiles.Add(tower_x_z);
        xztiles.Add(tower_xz);

        xztiles.Add(wall_x);
        xztiles.Add(wall_z);

        xztiles.Add(buildingxx);
        xztiles.Add(buildingxz);
        xztiles.Add(buildingx_z);
        xztiles.Add(buildingzz);
        xztiles.Add(building_xx);
        xztiles.Add(building_xz);
        xztiles.Add(building_x_z);
        xztiles.Add(building_zz);
        

        //Debug.Log(ground.ToString());



        for (int i=0; i < 10; i++) {
            z = 0;
            for(int j = 0; j < 10; j++) {
                string randomTile = tiles[Random.Range(0, tiles.Length)];
                Debug.Log(randomTile);
                Instantiate(XZTile.generate(randomTile, xztiles), new Vector3(x,0,z), XZTile.generate(randomTile, xztiles).transform.rotation);
                z += 2;
            }
            x += 2;
        }
        

    }

    
}
