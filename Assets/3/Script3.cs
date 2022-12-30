using LiteNetLib.Utils;
using UnityEngine;

public class Script3 : MonoBehaviour
{
    [SerializeField] private Transform transformDataToSend;
    [SerializeField] private Transform playerTransform;

    NetDataWriter dataWriter = new NetDataWriter();
    NetDataReader dataReader = new NetDataReader();

    private void Update()
    {
        // *** Don't modify this method. ***

        // First, we serialize transformDataToSend in the data writer.
        dataWriter.Reset();
        SerializeTransform(transformDataToSend, dataWriter);

        byte[] data = dataWriter.CopyData();
        Debug.Log($"Serialized data. Total bytes: {data.Length}");

        // Now, we deserialize the data back, and use it to set the playerTransform. They should match.
        dataReader.SetSource(data);
        DeserializeTransform(playerTransform, dataReader);
    }

    private void SerializeTransform(Transform transform, NetDataWriter dataWriter)
    {
        switch (transform.position.x)
        {
            case < -5.0f:
                transform.position = new Vector2(-5.0f, transform.position.y);
                dataWriter.Put(transform.position.x);
                break;
            
            case > 5.0f:
                transform.position = new Vector2(5.0f, transform.position.y);
                dataWriter.Put(transform.position.x);
                break;
            
            default:
                dataWriter.Put(transform.position.x);
                break;
        }

        switch(transform.position.y)
        {
            case < -5.0f:
                transform.position = new Vector2(transform.position.x, -5.0f);
                dataWriter.Put(transform.position.y);
                break;

            case > 5.0f:
                transform.position = new Vector2(transform.position.x, 5.0f);
                dataWriter.Put(transform.position.y);
                break;

            default:
                dataWriter.Put(transform.position.y);
                break;
        }
        //dataWriter.Put(transform.position.z);

        //dataWriter.Put(transform.eulerAngles.x);
        //dataWriter.Put(transform.eulerAngles.y);
        
        if(transform.eulerAngles.x != 0.0f || transform.eulerAngles.y != 0.0f)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z);
            dataWriter.Put(transform.eulerAngles.z);
        }
        else
        {
            dataWriter.Put(transform.eulerAngles.z);
        } 
    }

    private void DeserializeTransform(Transform transform, NetDataReader dataReader)
    {
        Vector2 newPosition = new Vector2();
        newPosition.x = dataReader.GetFloat();
        newPosition.y = dataReader.GetFloat();
        //newPosition.z = dataReader.GetFloat();

        Vector3 newRotation = new Vector3();
        //newRotation.x = dataReader.GetFloat();
        //newRotation.y = dataReader.GetFloat();
        newRotation.z = dataReader.GetFloat();

        transform.position = newPosition;
        transform.eulerAngles = newRotation;


    }
}