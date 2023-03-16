using UnityEngine;

public class ColliderBounds : MonoBehaviour
{
    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;

    [SerializeField] GameObject Wall;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        CreateWalls();
    }

    void CreateWalls()
    {

        GameObject wall3 = Instantiate(Wall);
        wall3.transform.position = m_Min;

        GameObject wall2 = Instantiate(Wall);
        wall2.transform.position = m_Max;

        GameObject wall1 = Instantiate(Wall);
        wall1.transform.position = new Vector3(m_Min[0], m_Max[1], m_Max[2]);

        GameObject wall4 = Instantiate(Wall);
        wall4.transform.position = new Vector3(m_Max[0], m_Max[1], m_Min[2]);

        GameObject middle1 = Instantiate(Wall);
        middle1.transform.position = new Vector3((wall1.transform.position.x - wall2.transform.position.x) / 2, 0f, (wall1.transform.position.z - wall2.transform.position.z) / 2);

    }

}