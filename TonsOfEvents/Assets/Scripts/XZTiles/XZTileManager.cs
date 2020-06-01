using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class XZTileManager : MonoBehaviour
{
    #region Prefabs
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

    public GameObject buildingcenterPref;
    #endregion

    private float rayDistance = 2.0f;
    private float rayDuration = 20.0f;

    private string[] tiles = new string[] {"towerxz", "tower_xz", "towerx_z", "tower_x_z",
                                            "ground",
                                            "wall_x", "wall_z",
                                            "buildingxz","building_xz","buildingx_z","building_x_z",
                                            "buildingxx","buildingzz","building_xx","building_zz",
                                            "buildingcenter"};

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

        XZTile buildingcenter = new XZTile("buildingcenter", buildingcenterPref);

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
        xztiles.Add(buildingcenter);
        StartCoroutine(startShooting());
        

    }

    public IEnumerator startShooting() {
        while (true) {
            for (int i = 0; i < 10; i++) {
                z = 0;
                for (int j = 0; j < 10; j++) {
                    List<string> possibleTiles = new List<string>();
                    if (j == 0) {
                        string randomTile = tiles[Random.Range(0, tiles.Length)];
                        possibleTiles = new List<string> { randomTile };
                    }
                    else{
                        string possibleTile = shootRays(x, z);
                        XZTile previousXZTile = whatIsPreviousTile(possibleTile);
                        Debug.Log(previousXZTile.GetCore());
                        possibleTiles = previousXZTile.getTiles_Z();
                        if(possibleTiles == null)Debug.Log("f");
                    }
                    //Debug.Log(possibleTiles);
                    int randNum=0;
                    foreach(string s in possibleTiles) {
                        randNum++;
                    }

                    if (randNum== 1) {
                        randNum = 0;
                    }
                    else {
                        randNum = Random.Range(0, possibleTiles.Count-1);
                    }
                    Instantiate(XZTile.generate(possibleTiles[randNum], xztiles), new Vector3(x, 0, z), XZTile.generate(possibleTiles[randNum], xztiles).transform.rotation);
                    
                    yield return new WaitForSeconds(1.0f);
                    z += 2;
                }
                x += 2;
            }
            yield break;
        }
    }

    public string shootRays(float x, float z) {
        Vector3 from = new Vector3(x, 1.0f, z);

        Vector3 xx = new Vector3(rayDistance, 0, 0);
        Vector3 _xx = new Vector3(-rayDistance, 0, 0);
        Vector3 zz = new Vector3(0, 0, rayDistance);
        Vector3 _zz = new Vector3(0, 0, -rayDistance);
        VisualizeRays(x,z);

        RaycastHit objectHit;
        if(Physics.Raycast(from, xx, out objectHit, rayDistance)) {
            Debug.Log("RayCast hit x: " + objectHit.collider.name);  
        }
        if (Physics.Raycast(from, _xx, out objectHit, rayDistance)) {
            Debug.Log("RayCast hit -x: " + objectHit.collider.name);
        }
        if (Physics.Raycast(from, zz, out objectHit, rayDistance)) {
            Debug.Log("RayCast hit z: " + objectHit.collider.name);
        }
        if (Physics.Raycast(from, _zz, out objectHit, rayDistance)) {
            Debug.Log("RayCast hit -z: " + objectHit.collider.name);
            return objectHit.collider.name;
        }
        return null;
    }

    private void VisualizeRays(float x,float z) {
        Vector3 from = new Vector3(x, 1.0f, z);

        Vector3 xx = new Vector3(rayDistance, 0, 0);
        Vector3 _xx = new Vector3(-rayDistance, 0, 0);
        Vector3 zz = new Vector3(0, 0, rayDistance);
        Vector3 _zz = new Vector3(0, 0, -rayDistance);

        Debug.DrawRay(from, xx, Color.red, rayDuration);
        Debug.DrawRay(from, _xx, Color.yellow, rayDuration);
        Debug.DrawRay(from, zz, Color.green, rayDuration);
        Debug.DrawRay(from, _zz, Color.blue, rayDuration);
    }

    private XZTile whatIsPreviousTile(string possibleTile) {
        foreach(XZTile xz in xztiles) {
            if (possibleTile == xz.GetCore() + "(Clone)") {
                return xz;
            }
        }
        
        return null;
    }

}
