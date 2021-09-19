using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject FollowTarget;
    public int PositionsAgo = 10;
    public float Delta = 1.0f;
    public int Steps = 30;

    private LinkedList<Vector3> _positions;
    private Queue<Vector3> _targets;
    private Vector3 _lastPos;
    private int step;
    // Start is called before the first frame update
    void Start()
    {
        _positions = new LinkedList<Vector3>();
        _positions.AddFirst(FollowTarget.transform.position);

        _targets = new Queue<Vector3>();

        _lastPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 last = _positions.Last.Value;
        Vector3 followPos = FollowTarget.transform.position;
        if (Vector3.Distance(followPos, last) > Delta)
        {
            _positions.AddLast(new Vector3(followPos.x, followPos.y, followPos.z));
        }

        if (_positions.Count > PositionsAgo)
        {
            Vector3 tenAgo = _positions.First.Value;
            _positions.RemoveFirst();
            _targets.Enqueue(tenAgo);
        }

        HandleMovement();
    }

    void HandleMovement()
    {
        if (_targets.Count == 0)
        {
            return;
        }

        if (step < Steps)
        {
            transform.position = Vector3.Lerp(_lastPos, _targets.Peek(), (float)step / Steps);
            step++;
        }
        else if (step == Steps)
        {
            _lastPos = _targets.Dequeue();
            transform.position = _lastPos;
            step = 1;
        }
    }
}
