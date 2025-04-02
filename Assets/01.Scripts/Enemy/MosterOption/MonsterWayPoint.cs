using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWayPoint : MonoBehaviour
{
    [SerializeField] Color _lineColor = Color.yellow;
    Transform[] _points;

    void OnDrawGizmos()
    {
        Gizmos.color = _lineColor;
        _points = GetComponentsInChildren<Transform>(); //내기준이지만 나를 포함. 0번째는 나를 가져옴

        int nextIndex = 1;
        Vector3 currPos = _points[nextIndex].position;
        Vector3 nextPos;

        for (int n = 0; n <= _points.Length; n++)
        {
            nextPos = (++nextIndex >= _points.Length) ? _points[1].position : _points[nextIndex].position;
            Gizmos.DrawLine(currPos, nextPos);
            currPos = nextPos;
        }
    }

}
