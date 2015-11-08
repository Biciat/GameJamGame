using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

    public LifeUnit[] lives;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void youGotHit(int hit) {
        if (0 <= hit && hit < lives.Length)
        {
            lives[hit].vanish();
        }
    }

}
