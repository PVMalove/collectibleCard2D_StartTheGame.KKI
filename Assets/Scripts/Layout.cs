using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Layout : MonoBehaviour
{
    [SerializeField] protected Vector3 rotationOffset = new Vector3(0, 0, -10);
    [SerializeField] protected Vector2 positionOffset = new Vector2(100, -14);

    public abstract Vector3 CalculatePosition(int siblingIndex, int totalSiblingsCount);

    public abstract Vector3 CalculateRotation(int siblingIndex, int totalSiblingsCount);
}
