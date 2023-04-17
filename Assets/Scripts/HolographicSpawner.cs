using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolographicSpawner : MonoBehaviour
{
    [SerializeField] bool isSun;
    [SerializeField] Color sunColor;
    [SerializeField] float sunSize;
    [SerializeField] bool isMars;
    [SerializeField] Color marsColor;
    [SerializeField] bool isPhobos;
    [SerializeField] Color phobosColor;
    [SerializeField] float phobosSpeed;
    [SerializeField] bool isSpaceGrid;
    [SerializeField] Color spaceGridColor;
    [Range(0, 500)]
    [SerializeField] float spaceGridSize;
    [SerializeField] float spaceGridSpace;
    [SerializeField] float spaceGridHeight;
    private GameObject mars;
    private GameObject phobos;

    void Start()
    {
        mars = new GameObject("Mars");
        phobos = new GameObject("Phobos");
        phobos.transform.SetParent(mars.transform, true);
    }

    void Update()
    {
        if(isSpaceGrid)
            SpaceGrid();

        if(isSun)
            BuildSun();

        if(isMars)
            BuildMars();

        if(isPhobos)
            BuildPhobos();
    }

    void SpaceGrid()
    {
        if(spaceGridSpace != 0)
        {
            for(int i = 0; i < spaceGridSize / Mathf.Abs(spaceGridSpace); ++i)
            {
                // x lines
                Debug.DrawLine(new Vector3(-spaceGridSize, spaceGridHeight, spaceGridSpace * i), new Vector3(spaceGridSize, spaceGridHeight, spaceGridSpace * i), spaceGridColor);
                // -x lines
                Debug.DrawLine(new Vector3(-spaceGridSize, spaceGridHeight, -spaceGridSpace * i), new Vector3(spaceGridSize, spaceGridHeight, -spaceGridSpace * i), spaceGridColor);
                // z lines
                Debug.DrawLine(new Vector3(spaceGridSpace * i, spaceGridHeight, -spaceGridSize), new Vector3(spaceGridSpace * i, spaceGridHeight, spaceGridSize), spaceGridColor);
                // -z lines
                Debug.DrawLine(new Vector3(-spaceGridSpace * i, spaceGridHeight, -spaceGridSize), new Vector3(-spaceGridSpace * i, spaceGridHeight, spaceGridSize), spaceGridColor);
            }
        }       
    }

    void BuildSun()
    {
        for(int i = 0; i < 200; ++i)
        {
            Debug.DrawLine(Random.onUnitSphere * sunSize, Random.onUnitSphere * sunSize, sunColor);
        }
    }

    void BuildMars()
    {
        mars.transform.position = new Vector3(Mathf.Cos(Time.time) * 300 + 50, 0, Mathf.Sin(Time.time) * 150 + 100);
        for(int i = 0; i < 50; ++i)
        {
            Debug.DrawLine(Random.onUnitSphere * 10 + mars.transform.position, Random.onUnitSphere * 10 + mars.transform.position, marsColor);
        }
    }

    void BuildPhobos()
    {
        phobos.transform.position = mars.transform.position + new Vector3(Mathf.Cos(Time.time * phobosSpeed) * 20, Mathf.Sin(Time.time * phobosSpeed) * 20, 0);
        for(int i = 0; i < 25; ++i)
        {
            Debug.DrawLine(Random.onUnitSphere * 5 + phobos.transform.position, Random.onUnitSphere * 5 + phobos.transform.position, phobosColor);
        }
    }
}
