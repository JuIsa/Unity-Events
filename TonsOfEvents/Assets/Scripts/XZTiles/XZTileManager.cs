using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private float _rayDistance = 2.0f;
    private float _rayDuration = 20.0f;
    private float _SpawnTimer = 0.1f;
    private int _grid_x = 20;
    private int _grid_z = 20;

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
            for (int i = 0; i < _grid_x; i++) {
                z = 0;
                for (int j = 0; j < _grid_z; j++) {
                    List<string> possibleTiles = new List<string>();
                    if (i != 0 && j == 0) {
                        string[] possibleTile = shootRays(x, z);
                        //XZTile previousZTile = whatIsPreviousZTile(possibleTile[0]);
                        XZTile previousXTile = whatIsPreviousXTile(possibleTile[1]);

                        possibleTiles = previousXTile.getTiles_X();
                        if (possibleTiles == null) Debug.Log("f");
                    }
                    else if(i!=0 && j != 0) {
                        string[] possibleTile = shootRays(x, z);
                        XZTile previousZTile = whatIsPreviousZTile(possibleTile[0]);
                        XZTile previousXTile = whatIsPreviousXTile(possibleTile[1]);
                        possibleTiles = findCommonTile(previousZTile, previousXTile);
                       
                        Debug.Log(possibleTiles.Count+" "+possibleTiles[0]);
                    }
                    else if (j == 0) {
                        string randomTile = tiles[Random.Range(0, tiles.Length)];
                        possibleTiles = new List<string> { randomTile };
                    }
                    else if (i == 0) {
                        string[] possibleTile = shootRays(x, z);
                        XZTile previousZTile = whatIsPreviousZTile(possibleTile[0]);
                        possibleTiles = previousZTile.getTiles_Z();
                    }
                    int randNum;
                    if (possibleTiles.Count == 1) {
                        randNum = 0;
                    }
                    else {
                        randNum = Random.Range(0, possibleTiles.Count);
                    }
                    
                    
                    Instantiate(XZTile.generate(possibleTiles[randNum], xztiles), new Vector3(x, 0, z), XZTile.generate(possibleTiles[randNum], xztiles).transform.rotation);
                    
                    yield return new WaitForSeconds(_SpawnTimer);
                    z += 2;
                }
                x += 2;
            }
            yield break;
        }
    }

    public string[] shootRays(float x, float z) {
        string[] objects = new string[2];
        Vector3 from = new Vector3(x, 1.0f, z);

        Vector3 xx = new Vector3(_rayDistance, 0, 0);
        Vector3 _xx = new Vector3(-_rayDistance, 0, 0);
        Vector3 zz = new Vector3(0, 0, _rayDistance);
        Vector3 _zz = new Vector3(0, 0, -_rayDistance);
        VisualizeRays(x,z);

        RaycastHit objectHit;
        if (Physics.Raycast(from, _zz, out objectHit, _rayDistance)) {
            Debug.Log("RayCast hit -z: " + objectHit.collider.name);
            objects[0] = objectHit.collider.name;
        }

        if (Physics.Raycast(from, _xx, out objectHit, _rayDistance)) {
            Debug.Log("RayCast hit -x: " + objectHit.collider.name);
            objects[1] = objectHit.collider.name;
        }
        
        return objects;
    }

    private void VisualizeRays(float x,float z) {
        Vector3 from = new Vector3(x, 1.0f, z);

        Vector3 xx = new Vector3(_rayDistance, 0, 0);
        Vector3 _xx = new Vector3(-_rayDistance, 0, 0);
        Vector3 zz = new Vector3(0, 0, _rayDistance);
        Vector3 _zz = new Vector3(0, 0, -_rayDistance);

       // Debug.DrawRay(from, xx, Color.red, _rayDuration);
        Debug.DrawRay(from, _xx, Color.yellow, _rayDuration);
       // Debug.DrawRay(from, zz, Color.green, _rayDuration);
        Debug.DrawRay(from, _zz, Color.blue, _rayDuration);
    }

    private XZTile whatIsPreviousZTile(string possibleTile) {
        foreach(XZTile xz in xztiles) {
            if (possibleTile == xz.GetCore() + "(Clone)") {
                return xz;
            }
        }
        
        return null;
    }

    private XZTile whatIsPreviousXTile(string possibleTile) {
        foreach (XZTile xz in xztiles) {
            if (possibleTile == xz.GetCore() + "(Clone)") {
                return xz;
            }
        }

        return null;
    }

    private List<string> findCommonTile(XZTile previousZTile, XZTile previousXTile) {

        List<string> z = previousZTile.getTiles_Z();
        List<string> x = previousXTile.getTiles_X();

        List<string> common = new List<string>() { };
        Debug.Log(z.Count + " " + x.Count);
        for(int i = 0; i < z.Count; i++) {
            Debug.Log(z[i]);
        }
        for (int i = 0; i < x.Count; i++) {
            Debug.Log(x[i]);
        }


        if (x.Count == 1 && z.Count == 1) {
            Debug.Log("Inside first " +z.Count + " " + x.Count);
            //Debug.Log(z);
            if (x[0] == z[0]) {
                common.Add(x[0]);
            }
        }
        else if (x.Count == 1) {
            Debug.Log("Inside second " + z.Count + " " + x.Count);
            for (int i = 0; i < z.Count; i++) {
                Debug.Log(i);
                if (x[0] == z[i]) {
                    common.Add(z[i]);
                }
            }
        }
        else if (z.Count == 1) {
            Debug.Log("Inside third " + z.Count + " " + x.Count);
            for (int i = 0; i < x.Count; i++) {
                Debug.Log(i);
                if (z[0] == x[i]) {
                    common.Add(x[i]);
                }
            }
        }
        else if(x.Count>1 && z.Count>1){ 
            for(int i = 0; i < x.Count; i++) {
                for(int j = 0; j < z.Count; j++) {
                    if (x[i] == z[j]) {
                        common.Add(x[i]);
                    }
                }
            }
            /*
            Debug.Log("Inside fourth " + z.Count + " " + x.Count);
            foreach (string s in z) {
                foreach(string ss in x) {
                    if (s == ss) {
                        common.Add(ss);
                    }
                }
            }
            */
        }
        if (common.Count==0) {
            common = new List<string> { "ground" };
        }
        Debug.Log("Finished finding "+common[0]);
        
        return common;

    }

}
