using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TModule : MonoBehaviour
{
    void Awake()
    {
        Register();
    }

    void OnDestroy()
    {
        Unregister();
    }

    public abstract void Register();
    public abstract void Unregister();
}
