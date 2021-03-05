/*
 
    -----------------------
    UDP-Send
    -----------------------
    // [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]
   
    // > gesendetes unter
    // 127.0.0.1 : 8050 empfangen
   
    // nc -lu 127.0.0.1 8050
 
        // todo: shutdown thread at the end
*/
using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSend : MonoBehaviour
{
  private static int localPort;

  // prefs
  private string IP;  // define in init
  public int port;  // define in init

  // "connection" things
  IPEndPoint remoteEndPoint;
  UdpClient client;

  // gui
  string strMessage = "";


  // call it from shell (as program)
  private static void Main()
  {
    UDPSend sendObj = new UDPSend();
    sendObj.init();

    // sendObj.inputFromConsole();

    sendObj.sendEndless(" endless infos \n");

  }

  public void Start()
  {
    init();
  }

  void OnGUI()
  {
    Rect rectObj = new Rect(40, 60, 200, 400);
    GUIStyle style = new GUIStyle();
    style.alignment = TextAnchor.UpperLeft;
    GUI.Box(rectObj, "# UDPSend-Data\n127.0.0.1 " + port + " #\n"
                + "shell> nc -lu 127.0.0.1  " + port + " \n"
            , style);

    strMessage = GUI.TextField(new Rect(40, 120, 140, 20), strMessage);
    if (GUI.Button(new Rect(190, 120, 40, 20), "send"))
    {
      sendString(strMessage + "\n");
    }
  }

  public void init()
  {
    print("UDPSend.init()");

    IP = "127.0.0.1";
    port = 8017;

    remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
    client = new UdpClient();

    print("Sending to " + IP + " : " + port);
    print("Testing: nc -lu " + IP + " : " + port);

  }

  private void inputFromConsole()
  {
    try
    {
      string text;
      do
      {
        text = Console.ReadLine();

        if (text != "")
        {
          byte[] data = Encoding.UTF8.GetBytes(text);
          client.Send(data, data.Length, remoteEndPoint);
        }
      } while (text != "");
    }
    catch (Exception err)
    {
      print(err.ToString());
    }

  }

  // sendData
  public void sendString(string message)
  {
    try
    {
      //if (message != "")
      //{

      byte[] data = Encoding.UTF8.GetBytes(message);
      client.Send(data, data.Length, remoteEndPoint);
      //}
    }
    catch (Exception err)
    {
      print(err.ToString());
    }
  }


  private void sendEndless(string testStr)
  {
    do
    {
      sendString(testStr);


    }
    while (true);

  }

}

