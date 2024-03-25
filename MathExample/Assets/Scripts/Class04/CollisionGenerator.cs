using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGenerator : MonoBehaviour
{
    public GameObject[] cololiders;

    private void OnClear()
    {
        foreach (var item in cololiders)
        {
            item.SetActive(false);
        }
    }
    public void OnColliderClick(int id)
    {
        OnClear();

        switch (id)
        {
            case 0:
                OnBoxCollider();
                break;
            case 1:
                OnCircleCollider();
                break;
            case 2:
                OnAABBCollider();
                break;
        }
    }
    
    public void OnBoxCollider()
    {
        cololiders[0].SetActive(true);
    }

    public void OnCircleCollider()
    {
        cololiders[1].SetActive(true);

    }

    public void OnAABBCollider()
    {
        cololiders[2].SetActive(true);
    }
}
