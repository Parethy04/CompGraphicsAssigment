using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightingSwap : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] Terrain terrain;
    [SerializeField] GameObject[] LightingChanges;
    List<Renderer> _renderer = new List<Renderer>();
    [SerializeField] Material[] _diffuseMaterials;
    [SerializeField] Material[] _diffuseAndAmbientMaterials;
    [SerializeField] Material[] _SpecularMaterials;


    // Start is called before the first frame update
    private void Start()
    {
        LightingChanges = GameObject.FindGameObjectsWithTag("LightingChange");


        foreach (var gameobject in LightingChanges)
            _renderer.Add(gameobject.GetComponent<Renderer>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) SwapNone();
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwapDiffuse();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwapDiffuseAndAmbient();
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwapSpecular();
    }

    public void SwapDiffuse()
    {
        Light.GetComponent<Light>().enabled = true;
        for (var i = 0; i < _renderer.Count; i++)
            if (_renderer[i].name.Contains("Wall"))
                _renderer[i].material = _diffuseMaterials[0];
            else if (_renderer[i].name.Contains("Mons"))
                _renderer[i].material = _diffuseMaterials[1];
            else if (_renderer[i].name.Contains("Cube")) _renderer[i].material = _diffuseMaterials[2];
        terrain.materialTemplate = _diffuseMaterials[3];
    }

    public void SwapDiffuseAndAmbient()
    {
        Light.GetComponent<Light>().enabled = true;
        for (var i = 0; i < _renderer.Count; i++)
            if (_renderer[i].name.Contains("Wall"))
                _renderer[i].material = _diffuseAndAmbientMaterials[0];
            else if (_renderer[i].name.Contains("Mons"))
                _renderer[i].material = _diffuseAndAmbientMaterials[1];
            else if (_renderer[i].name.Contains("Cube")) _renderer[i].material = _diffuseAndAmbientMaterials[2];
        terrain.materialTemplate = _diffuseAndAmbientMaterials[3];
    }

    public void SwapSpecular()
    {
        Light.GetComponent<Light>().enabled = true;
        for (var i = 0; i < _renderer.Count; i++)
            if (_renderer[i].name.Contains("Wall"))
                _renderer[i].material = _SpecularMaterials[0];
            else if (_renderer[i].name.Contains("Mons"))
                _renderer[i].material = _SpecularMaterials[1];
            else if (_renderer[i].name.Contains("Cube")) _renderer[i].material = _SpecularMaterials[2];

        terrain.materialTemplate = _SpecularMaterials[3];
    }


    public void SwapNone()
    {
        Light.GetComponent<Light>().enabled = false;
    }
}
