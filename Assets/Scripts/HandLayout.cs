using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLayout : Layout
{
    [SerializeField] private float yPos = 30;

    public override Vector3 CalculatePosition(int siblingIndex, int totalSiblingsCount)
    {
        var index = siblingIndex - (totalSiblingsCount - 1) / 2f;
        var absIndex = Mathf.Abs(index);

        return new Vector2(positionOffset.x * index, yPos + positionOffset.y * Mathf.Pow(2, absIndex));
    }

    public override Vector3 CalculateRotation(int siblingIndex, int totalSiblingsCount)
    {
        return rotationOffset * (siblingIndex - (totalSiblingsCount - 1) / 2f);
    }
}
