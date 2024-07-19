using UnityEngine;
using System.Collections.Generic;

// Mediator 인터페이스
public interface IChatMediator
{
    void SendMessage(string message, ChatMember sender);
    void AddMember(ChatMember member);
}

// Concrete Mediator
public class ChatRoom : IChatMediator
{
    private List<ChatMember> members = new List<ChatMember>();

    public void AddMember(ChatMember member)
    {
        members.Add(member);
    }

    public void SendMessage(string message, ChatMember sender)
    {
        foreach (var member in members)
        {
            // 메시지를 보낸 멤버를 제외한 모든 멤버에게 메시지 전달
            if (member != sender)
            {
                member.ReceiveMessage(message, sender.Name);
            }
        }
    }
}

public class WisperChatRoom : IChatMediator
{
    private ChatMember member;

    public void AddMember(ChatMember member)
    {
        this.member = member;
    }

    public void SendMessage(string message, ChatMember sender)
    {
        member.ReceiveMessage(message, sender.Name);
    }
}


public class PrivateChatRoom : IChatMediator
{
    private List<ChatMember> members = new List<ChatMember>();

    public void AddMember(ChatMember member)
    {
        if (member.isPrivate)
            members.Add(member);
    }

    public void SendMessage(string message, ChatMember sender)
    {
        foreach (var member in members)
        {
            // 메시지를 보낸 멤버를 제외한 모든 멤버에게 메시지 전달
            if (member != sender)
            {
                member.ReceiveMessage(message, sender.Name);
            }
        }
    }
}

// Colleague 클래스
public abstract class ChatMember : MonoBehaviour
{
    public bool isPrivate;
    protected IChatMediator mediator;
    public string Name { get; private set; }

    public void SetMediator(IChatMediator mediator)
    {
        this.mediator = mediator;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }

    public abstract void Send(string message);
    public abstract void ReceiveMessage(string message, string senderName);
}

// Concrete Colleague
public class Player_3 : ChatMember
{
    public override void Send(string message)
    {
        Debug.Log($"{Name} sending: {message}");
        mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message, string senderName)
    {
        Debug.Log($"{Name} received: {message} from {senderName}");
    }
}

// Concrete Colleague
public class AI : ChatMember
{
    public override void Send(string message)
    {
        Debug.Log($"AI {Name} sending: {message}");
        mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message, string senderName)
    {
        Debug.Log($"AI {Name} received: {message} from {senderName}");
        // AI could process the message here and potentially respond
    }
}

// 사용 예시
public class Mediator : MonoBehaviour
{
    private IChatMediator chatRoom;
    private IChatMediator wisperChatRoom;
    private IChatMediator privateChatRoom;
    
    private Player_3 Player_31;
    private Player_3 Player_32;
    
    private AI aiPlayer_3;

    void Start()
    {
        chatRoom = new ChatRoom();
        wisperChatRoom = new WisperChatRoom();
        privateChatRoom = new PrivateChatRoom();

        Player_31 = gameObject.AddComponent<Player_3>();
        Player_31.SetName("Player_31");
        Player_31.SetMediator(chatRoom);

        Player_32 = gameObject.AddComponent<Player_3>();
        Player_32.SetName("Player_32");
        Player_32.SetMediator(wisperChatRoom);

        aiPlayer_3 = gameObject.AddComponent<AI>();
        aiPlayer_3.SetName("AIPlayer_3");
        aiPlayer_3.SetMediator(privateChatRoom);

        chatRoom.AddMember(Player_31);
        chatRoom.AddMember(Player_32);
        chatRoom.AddMember(aiPlayer_3);

        // 테스트 메시지 전송
        Player_31.Send("Hello, everyone!");
        aiPlayer_3.Send("Greetings, humans!");
    }
}

// public class Mediator : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
