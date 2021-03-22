using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class TAccessor : MonoBehaviour
{
    public List<string> mylist = null;

    public Dictionary<string, List<GameObject>> dicModules = null;
    public List<GameObject> modules = null;

    public int x = 0; //Test

    public void Start()
    {
        dicModules = new Dictionary<string, List<GameObject>>();
        mylist = new List<string>(new string[] { "Collider", "Pool", "Renderer" });
        modules = new List<GameObject>();

        foreach (string gameScript in mylist)
        {
            for (int i = 0; i < this.transform.childCount; i++) // Liste les salles
            {
                GameObject child = this.transform.GetChild(i).gameObject;
                if (child.GetComponent(gameScript) != null)
                {
                    x++;
                }
                modules.Add(child);
            }
            dicModules.Add(gameScript, modules);
            modules.Clear();
        }
    }
}
