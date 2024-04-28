using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Unlockable
{
    protected override void UnlockBehavior()
    {
        gameObject.SetActive(false);
    }

    protected override void ResetBehavior()
    {
        gameObject.SetActive(true);
    }
}
