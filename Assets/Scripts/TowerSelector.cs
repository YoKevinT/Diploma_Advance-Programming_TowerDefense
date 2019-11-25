using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public int currentTower = 1;
    public void SpawnTower(Vector3 position)
    {
        // Load the Tower Resource
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/Tower " + currentTower);
        // Spawn a new Instance of Tower & Reposition new tower to given "position"
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // If mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast from ScreenPointToRay
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out hit))
            {
                // If we hit a Placeable & not taken
                Placeable p = hit.collider.GetComponent<Placeable>();

                if (p && !p.isOccupied)
                {
                    // Place Tower on that Placeable
                    SpawnTower(hit.transform.position);
                    p.isOccupied = true;
                }
            }
        }
    }
}





    