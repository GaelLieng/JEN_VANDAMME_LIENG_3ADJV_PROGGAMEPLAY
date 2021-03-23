using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAccessor<T> where T : TModule
{
    private static TAccessor<T> _instance;
    public static TAccessor<T> Instance()
    {
        if (_instance == null)
            _instance = new TAccessor<T>();
        return _instance;
    }

    Dictionary<int, T> Modules;

    public TAccessor()
    {
        Modules = new Dictionary<int, T>();
    }

    public void Register(int parObjectId, T parModule)
    {
        Modules.Add(parObjectId, parModule);
    }

    public void Unregister(int parObjectId)
    {
        Modules.Remove(parObjectId);
    }

    public Dictionary<int, T> GetAllModule()
    {
        return Modules;
    }

    public T TryGetModule(int parObjectId)
    {
        if (ContainObject(parObjectId))
            return Modules[parObjectId];

        return (default(T));
    }

    public int GetNumberRegisteredModules()
    {
        return Modules.Count;
    }

    public bool ContainObject(int parObjectId)
    {
        return Modules.ContainsKey(parObjectId);
    }
}
