using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTester : MonoBehaviour
{
    // Variablen für Abstandsmessung und Skalierung der Kreise (können im Editor in Echtzeit verändert und an die räumlichen Gegebenheiten vor Ort angepasst werden)
    public Double distance;
    public float diameter;

    void Start()
    {
        
    }

    void Update()
    {
        // Erzeuge ein eindimensionales Array ("people") in dem sich alle Personen befinden, die aktuell in der Szene sichtbar sind
        var people = GameObject.FindGameObjectsWithTag("Mensch");

        // Vergleiche das Array mit sich selbst, um festzustellen, ob zwei Personen den von uns definierten Abstand (Variable "abstand") unterschreiten
        for (int i = 0; i < people.Length; i++)
        {
            // Initialisiere den Kollisionsindex der aktuell zu überprüfenden Person [i]
            int collisionIndex = 0;

            // Setze den Scale des Indikators (Kreis) auf die von uns definierte Größe (Variable "durchmesser")
            people[i].transform.localScale = new Vector3(diameter, 0.1f, diameter);

            // Vergleiche die Position der aktuellen Person [i] mit den Positionen aller anderen Personen
            for (int p = 0; p < people.Length; p++)
            {   
                if (i != p && (people[i].transform.position - people[p].transform.position).magnitude < distance)
                {
                    // Erhöhe den Kollisionsindex wenn die Person nicht sie selbst ist (i != p) UND der Abstand zur Person [p] kleiner als die Variable "abstand" ist
                    collisionIndex++;
                    Debug.Log("Abstand Mensch["+i+"] zu Mensch["+p+"] beträgt: " + (people[i].transform.position - people[p].transform.position).magnitude);
                }
                if (collisionIndex > 0)
                {
                    // Wenn der Kollisionsindex größer als 0 ist, setze den Wert "Color" des Materials unseres Indikators auf "red"
                    people[i].GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    // Wenn der Kollisionsindex nicht größer als 0 ist, setze den Wert "Color" des Materials unseres Indikators auf "green"
                    people[i].GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }
}