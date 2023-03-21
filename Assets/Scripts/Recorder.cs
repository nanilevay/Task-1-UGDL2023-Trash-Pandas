using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    [SerializeField] private GameObject replayObjectPrefab;
    public Queue<ReplayData> recordingQueue { get; private set; }

    private Recording recording;

    [SerializeField] private bool isDoingReplay = false;

    private void Awake()
    {
        recordingQueue = new Queue<ReplayData>();
    }

    private void Start()
    {
        //Subscribe to Events
        //GameEventsManager.Instantiate.onGoalReached += OnGoalReached;
        //GameEventsManager.Instantiate.onRestartLevel += OnRestartLevel;
    }

    private void Update()
    {
        if(!isDoingReplay)
        {
            return;
        }

        bool hasMoreFrames = recording.PlayNextFrame();

        //Check if we're finished, so we can restart ------------------- Has to be changed
        if(!hasMoreFrames)
        {
            RestartReplay();
        }
    }

    private void OnDestroy()
    {
        //Unsubscribe to Events
        //GameEventsManager.Instantiate.onGoalReached -= OnGoalReached;
        //GameEventsManager.Instantiate.onRestartLevel -= OnRestartLevel;
    }

    private void OnGoalReached()
    {
        StartReplay();
    }

    private void OnRestartLevel()
    {
        Reset();
    }

    public void RecordReplayFrame(ReplayData data)
    {
        recordingQueue.Enqueue(data);
        Debug.Log("Recorded Data:" + data.position);
    }

    private void StartReplay()
    {
        isDoingReplay = true;
        //initialize the recording
        recording = new Recording(recordingQueue);
        //Reset the current recording queu for next time
        recordingQueue.Clear();
        //Instances the replay Obj
        recording.InstantiateReplayObject(replayObjectPrefab);
    }

    private void RestartReplay()
    {
        isDoingReplay = true;
        //restart our queued data from the beginning
        recording.RestartFromBeginning();
    }
    private void Reset()
    {
        isDoingReplay = false;
        //reset the recorder to a clean slate
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfExists();
        recording = null;
    }
}
