using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        else if (core=="tower1") {
            CompleteTowerXZ();
        }
        else if (core == "tower2") {
            CompleteTower_XZ();
        }
        else if (core == "tower3") {
            CompleteTowerX_Z();
        }
        else if (core == "tower4") {
            CompleteTower_X_Z();
        }
        else if (core == "wallR") {
            CompleteWall_X();
        }
        else if (core == "wallL") {
            CompleteWall_Z();
        }
        else if (core == "build1") {
            CompleteBuildingXZ();
        }
        else if (core == "build2") {
            CompleteBuilding_XZ();
        }
        else if (core == "build3") {
            CompleteBuildingX_Z();
        }
        else if (core == "build4") {
            CompleteBuilding_X_Z();
        }
        else if (core == "build5") {
            CompleteBuildingXX();
        }
        else if (core == "build6") {
            CompleteBuilding_XX();
        }
        else if (core == "build7") {
            CompleteBuildingZZ();
        }
        else if (core == "build8") {
            CompleteBuilding_ZZ();
        }
    }

    #region Ground
    private void CompleteGround() {
        List<string> s = new List<string> { "towerxz", "tower_xz", "towerx_z", "tower_x_z",
                                            "ground",
                                            "wall_x", "wall_z",
                                            "buildingxz","building_xz","buildingx_z","building_x_z",
                                            "buildingxx","buildingzz","building_xx","building_zz"};
        this._xfront = s;
        this._xback = s;
        
        this._zfront = s;
        this._zback= s;

    }
    #endregion

    #region Tower
    // XZ means positive X and positive Z, so Tower is looking to positive direction
    // _XZ means negative X and positive Z, so Tower is looking to the opposite side 
    private void CompleteTowerXZ() {
        
        this._xfront = new List<string> {"wall_x", "ground"};
        this._xback = new List<string> { "tower_xz"};

        this._zfront = new List<string> { "wall_z", "ground" };
        this._zback = new List<string> { "towerx_z" };
    }

    private void CompleteTower_XZ() {

        this._xfront = new List<string> { "towerxz"};
        this._xback = new List<string> { "wall_x", "ground" };

        this._zfront = new List<string> { "wall_z", "ground" };
        this._zback = new List<string> { "tower_x_z" };
    }

    private void CompleteTowerX_Z() {

        this._xfront = new List<string> { "wall_x", "ground" };
        this._xback = new List<string> { "tower_x_z" };

        this._zfront = new List<string> { "towerxz" };
        this._zback = new List<string> { "wall_z", "ground" };
    }

    private void CompleteTower_X_Z() {

        this._xfront = new List<string> { "towerx_z" };
        this._xback = new List<string> { "wall_z", "ground" };

        this._zfront = new List<string> { "tower_xz" };
        this._zback = new List<string> { "wall_z", "ground" };
    }
    #endregion

    #region Wall

    //CompleteWall_X means the wall is along X-axis
    public void CompleteWall_X() {
        this._xfront = new List<string> { "tower_x_z", "tower_xz" };
        this._xback = new List<string> { "towerxz","towerx_z" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "ground" };
    }

    //CompleteWall_X means the wall is along Z-axis
    public void CompleteWall_Z() {
        this._xfront = new List<string> { "ground" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "towerx_z", "tower_x_z" };
        this._zback = new List<string> { "towerxz","tower_xz" };
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

        this._xfront = new List<string> { "ground" };
        this._xback = new List<string> { "building_zz", "building_x_z" };

        this._zfront = new List<string> { "buildingxx", "buildingxz" };
        this._zback = new List<string> { "ground" };

    }
    private void CompleteBuilding_X_Z() {

        this._xfront = new List<string> { "building_zz", "buildingx_z" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "building_xx","building_xz" };
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

        this._zfront = new List<string> { "buildingxz" };
        this._zback = new List<string> { "buildingx_z" };

    }
    private void CompleteBuildingZZ() {

        this._xfront = new List<string> { "buildingxz" };
        this._xback = new List<string> { "building_xz" };

        this._zfront = new List<string> { "ground" };
        this._zback = new List<string> { "buildingcenter" };

    }
    private void CompleteBuilding_XX() {

        this._xfront = new List<string> { "buildingcenter" };
        this._xback = new List<string> { "ground" };

        this._zfront = new List<string> { "building_xz" };
        this._zback = new List<string> { "building_x_z" };

    }
    private void CompleteBuilding_ZZ() {

        this._xfront = new List<string> { "buildingx_z" };
        this._xback = new List<string> { "building_x_z" };

        this._zfront = new List<string> { "buildingcenter" };
        this._zback = new List<string> { "ground" };

    }
    #endregion

    #endregion

}
