using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector timeLine;
    public SignalReceiver receiver;
    public SignalAsset signal;

    public void OnTimeLineSpeed(float speed) {
        // 타임라인의 속도 제어
        timeLine.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    public void SetSignalEvent() {
        UnityEvent eventContainer = new UnityEvent(); // 이벤트를 담는 변수
        eventContainer.AddListener(() => OnTimeLineSpeed(.2f)); // 이벤트 등록

        receiver.AddReaction(signal, eventContainer); // 시그널에 이벤트를 담아서 등록
    }
}
