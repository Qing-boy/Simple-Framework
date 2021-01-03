using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instacne;
    public static T Instance
    {
        get
        {
            if (MonoSingletonObject.go == null)
            {
                MonoSingletonObject.go = new GameObject("MonoSingletonObject");
                DontDestroyOnLoad(MonoSingletonObject.go);
            }

            if (MonoSingletonObject.go != null)
            {
                instacne = MonoSingletonObject.go.AddComponent<T>();
            }

            return instacne;
        }
    }

    public static bool destroyOnLoad = false;
    public void AddSceneChangeEvent(){
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        if(destroyOnLoad == true)
        {
            if(instacne != null){
                DestroyImmediate(instacne);
            }
        }
    }
}

//缓存物体
public class MonoSingletonObject
{
    public static GameObject go;
}