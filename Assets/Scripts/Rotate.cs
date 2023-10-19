using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Transform centrPlanet;
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject[] satellites;

    [SerializeField] private float koefSpeedPlanet = 0.05f;
    [SerializeField] private float speedSatellite = 0.01f;

    private void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
        satellites = GameObject.FindGameObjectsWithTag("satellite");
    }

    private void Update()
    {
        for (int planet = 0; planet < planets.Length; planet++)
        {
          
            if (planet == 0)
            {
                centrPlanet = planets[planet].transform;
                planet++;
            }
            print(planet);

            GameObject CurrentPlanet = planets[planet];
            float speedPlanet = (planet + koefSpeedPlanet) / planet;
            CurrentPlanet.transform.RotateAround(centrPlanet.position, CurrentPlanet.transform.up, speedPlanet);
            CurrentPlanet.transform.RotateAround(CurrentPlanet.transform.position, CurrentPlanet.transform.up, speedPlanet);

            for (int satellite = 0; satellite < satellites.Length; satellite++)
            {
                GameObject CurrentSatellite = satellites[satellite];
                CurrentSatellite.transform.RotateAround(CurrentSatellite.transform.parent.transform.position, CurrentSatellite.transform.up, speedSatellite);
                CurrentSatellite.transform.RotateAround(CurrentSatellite.transform.position, CurrentSatellite.transform.up, speedSatellite);
            }
        }
    }
}
