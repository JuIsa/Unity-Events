using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearSelf : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Sphere");
        StartCoroutine(checkDistance());
    }

    IEnumerator checkDistance() {
        while (true) {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < 2.5) {
                this.GetComponent<MeshRenderer>().enabled = false;
            } else {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.1f);

        }
    }
  
}
