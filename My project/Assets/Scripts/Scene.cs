using UnityEngine;

public class Scene: MonoBehaviour
{
    public Transform SceneStart;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}