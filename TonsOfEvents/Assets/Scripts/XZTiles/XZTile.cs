using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XZTile
{
    private string _core;
    private GameObject _pref; 
    private List<string> _xfront;
    private List<string> _xback;
    private List<string> _zfront;
    private List<string> _zback;

    public XZTile(string core, GameObject pref) {
        _core = core;
        _pref = pref;
        InitializeAutoComplete(core);
    }
    public XZTile(string core,GameObject pref, List<string> xf, List<string> xb, List<string> zf, List<string> zb) 
    {
        _core = core;
        _xfront = xf;
        _xback = xb;
        _zfront = zf;
        _zback = zb;
        _pref = pref;
        InitializeAutoComplete(core);
    }

    public override string ToString() {
        string final = "X Front: ";
        foreach(string s in this._xfront) {
            final += s;
            final += ", ";
        }
        final += "\nX Back: ";
        foreach (string s in this._xback) {
            final += s;
            final += ", ";
        }
        final += "\nZ Front: ";
        foreach (string s in this._zfront) {
            final += s;
            final += ", ";
        }
        final += "\nZ Back: ";
        foreach (string s in this._zback) {
            final += s;
            final += ", ";
        }
        return final;
    }

    public string GetCore() {
        return _core;
    }

    public List<string> getTiles_Z() {
        return _zfront;
    }

    public List<string> getTiles_X() {
        return _xfront;
    }

    public static GameObject generate(string what, List<XZTile> list) {
        foreach(XZTile t in list) {
            if (what == t._core) {
                return t._pref;
            }
        }
        return null;
    }

    private void InitializeAutoComplete(string core) {
        if (core == "ground") {
            CompleteGround();
        }
        else if (core=="towerxz") {
            CompleteTowerXZ();
        }
        else if (core == "tower_xz") {
            CompleteTower_XZ();
        }
        else if (core == "towerx_z") {
            CompleteTowerX_Z();
        }
        else if (core == "tower_x_z") {
            CompleteTower_X_Z();
        }
        else if (core == "wall_x") {
            CompleteWall_X();
        }
        else if (core == "wall_z") {
            CompleteWall_Z();
        }
        else if (core == "buildingxz") {
            CompleteBuildingXZ();
        }
        else if (core == "building_xz") {
            CompleteBuilding_XZ();
        }
        else if (core == "buildingx_z") {
            CompleteBuildingX_Z();
        }
        else if (core == "building_x_z") {
            CompleteBuilding_X_Z();
        }
        else if (core == "buildingxx") {
            CompleteBuildingXX();
        }
        else if (core == "building_xx") {
            CompleteBuilding_XX();
        }
        else if (core == "buildingzz") {
            CompleteBuildingZZ();
        }
        else if (core == "building_zz") {
            CompleteBuilding_ZZ();
        }
        else if(core== "buildingcenter") {
            CompleteBuildingCenter();
        }
    }

    #region Ground
    private void CompleteGround() {
        this._xfront = new List<string> { "tower_xz", "tower_x_z",
                                          "ground", "wall_z",
                                          "building_x_z","building_xz",
                                          "building_xx"}; 

        this._xback = new List<string> { //"towerxz", "towerx_z",
                                         "ground", "wall_z",
                                         "buildingxz","buildingx_z",
                                         "buildingxx"};

        this._zfront = new List<string> { "towerx_z", "tower_x_z",
                                          "ground", "wall_x",
                                          "building_x_z",
                                          "building_zz"}; 

        this._zback= new List<string> { //"towerxz", "tower_xz",
                                        "ground", "wall_x",
                                        "buildingxz","building_xz",
                                        "buildingzz"};

    }
    #endregion

    #region Tower
    // XZ means positive X and positive Z, so Tower is looking to positive direction
    // _XZ means negative X and positive Z, so Tower is looking to the opposite side 
    private void CompleteTowerXZ() {
        
        this._xfront = new List<string> {"wall_x",};//
        this._xback = new List<string> { "tower_xz", "ground" };

        this._zfront = new List<string> { "wall_z",};//
        this._zback = new List<string> { "towerx_z", "ground" };
    }

    private void CompleteTower_XZ() {

        this._xfront = new List<string> { "towerxz", "ground" };
        this._xback = new List<string> { "wall_x", "ground" };//

        this._zfront = new List<string> { "wall_z", };//
        this._zback = new List<string> { "tower_x_z", "ground" };
    }

    private void CompleteTowerX_Z() {

        this._xfront = new List<string> { "wall_x", };//
        this._xback = new List<string> { "tower_x_z", "ground" };

        this._zfront = new List<string> { "towerxz", "ground" };
        this._zback = new List<string> { "wall_z","ground"};//
    }

    private void CompleteTower_X_Z() {

        this._xfront = new List<string> { "towerx_z", "ground" };
        this._xback = new List<string> { "wall_z", "ground" };//

        this._zfront = new List<string> { "tower_xz", "ground" };
        this._zback = new List<string> { "wall_z", "ground" };//
    }
    #endregion

    #region Wall

    //CompleteWall_X means the wall is along X-axis
    public void CompleteWall_X() {
        this._xfront = new List<string> { "tower_x_z", "tower_xz","wall_x" };
        this._xback = new List<string> { "towerxz","towerx_z","wall_z" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "ground" };
    }

    //CompleteWall_X means the wall is along Z-axis
    public void CompleteWall_Z() {
        this._xfront = new List<string> { "ground" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "wall_z","towerx_z", "tower_x_z" };
        this._zback = new List<string> { "towerxz","tower_xz","wall_z" };
    }
    #endregion

    #region Building

    #region Corners
    //XZ means facing positive X and Z sides;
    private void CompleteBuildingXZ() {

        this._xfront = new List<string> { "ground" };
        this._xback = new List<string> { "buildingzz", "building_xz" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "buildingxx", "buildingx_z" };

    }
    private void CompleteBuilding_XZ() {

        this._xfront = new List<string> { "buildingxz", "buildingzz" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "building_xx", "building_x_z" };

    }
    private void CompleteBuildingX_Z() {

        this._xfront = new List<string> { "ground", "building_xz" };
        this._xback = new List<string> { "building_zz", "building_x_z" };

        this._zfront = new List<string> { "buildingxx", "buildingxz" };
        this._zback = new List<string> { "ground" };

    }
    private void CompleteBuilding_X_Z() {

        this._xfront = new List<string> { "building_zz", "buildingx_z", "buildingcenter" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "building_xx","building_xz", "buildingcenter" };
        this._zback = new List<string> { "ground" };

    }
    #endregion

    #region Centers
    // XX means tower is facing absolute X side
    // ZZ means tower is facing absolute Z side
    // _XX means tower is facing absolute -X side
    private void CompleteBuildingXX() {

        this._xfront = new List<string> { "ground" };
        this._xback = new List<string> { "buildingcenter" };

        this._zfront = new List<string> { "buildingxz", "buildingcenter",  };//
        this._zback = new List<string> { "buildingx_z" };

    }
    private void CompleteBuildingZZ() {

        this._xfront = new List<string> { "buildingxz", "buildingcenter",};//extra ground
        this._xback = new List<string> { "building_xz" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "buildingcenter" };

    }
    private void CompleteBuilding_XX() {

        this._xfront = new List<string> { "buildingcenter", "buildingxx" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "building_xz", "buildingcenter" };
        this._zback = new List<string> { "building_x_z" };

    }
    private void CompleteBuilding_ZZ() {

        this._xfront = new List<string> { "buildingx_z", "buildingcenter" };
        this._xback = new List<string> { "building_x_z" };

        this._zfront = new List<string> { "buildingcenter", "buildingxz" };
        this._zback = new List<string> { "ground" };

    }

    private void CompleteBuildingCenter() {
        this._xfront = new List<string> { "buildingxx", "buildingcenter", "ground" };//extra ground
        this._xback = new List<string> { "building_xx" };

        this._zfront = new List<string> { "buildingzz", "buildingcenter","ground" };//extra ground
        this._zback = new List<string> { "building_zz" };
    }

    #endregion



    #endregion

}
