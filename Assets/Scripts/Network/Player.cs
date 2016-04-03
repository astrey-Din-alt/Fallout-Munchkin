using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public PhotonView photonView = null;
    void Update()
    {
        photonView = PhotonView.Get(this);
        if (photonView.isMine)
        {
            InputMovement();
        }
        else
        {
            SyncedMovement();
        }
    }

    private void SyncedMovement()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        syncTime += Time.deltaTime;
        rigidbody.position = Vector2.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + Vector2.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position - Vector2.right * speed * Time.deltaTime);
    }

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector2 syncStartPosition = Vector2.zero;
    private Vector2 syncEndPosition = Vector2.zero;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (stream.isWriting)
        {
            stream.SendNext(rigidbody.position);
        }
        else
        {
            syncEndPosition = (Vector2)stream.ReceiveNext();
            syncStartPosition = rigidbody.position;

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
        }
    }
}
