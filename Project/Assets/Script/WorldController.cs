using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class WorldController : MonoBehaviour
{
    #region Statics
    static WorldController instance;
    public static WorldController I
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance) { return; }
            else
            {
                instance = value;
            }
        }
    }

    #endregion

    [Range(.05f, .005f)]
    [SerializeField] float scale;
    [SerializeField] int width;
    [SerializeField] int height;

    public World World { get; private set; }

    private void Awake()
    {
        #region Statics
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning($"Already a {name} in scene. Deleting this one!");
            Destroy(gameObject);
            return;
        }
        #endregion

        Camera.main.transform.position += new Vector3(width / 2, height / 2);

        World = new World(width, height, scale);
    }
}
