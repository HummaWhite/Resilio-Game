using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public bool unlocked = false;

    public virtual void UnlockBehavior() {}

    public void Unlock()
    {
        UnlockBehavior();
        unlocked = true;
    }

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
