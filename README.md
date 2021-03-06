# Unity→UDP→ARENA Demo
<img src="https://img.shields.io/badge/python-3.9-blue" /> <img src="https://img.shields.io/badge/unity-2019.4.18f1-blue"> <img src="https://img.shields.io/badge/arena-0.1.18-blue" /> <img src="https://img.shields.io/badge/maintained%3F-yes-green" /> <img src="https://img.shields.io/github/issues/OliviaLynn/Unity-UDP-ARENA-Demo" />

 Communication from Unity to ARENA via a Python UDP relay server. 
 
 For the purposes of this demo, we're just syncing the position of a single object.

<img src="https://raw.githubusercontent.com/OliviaLynn/Unity-UDP-ARENA-Demo/main/video3.gif" />

>A little latency, so get ready for Unity-ARENA 2: Electric Boogaloo, where we bypass the relay server entirely and run authentication directly from Unity...

## Getting Started

### Setting Up
- Install [ARENA-py](https://github.com/conix-center/ARENA-py)
- Adjust the variables at the top of `RelayServer.py`
    - Mainly just `SCENE_NAME` for the ARENA scene you plan to use, and `UDP_PORT` for the port your server will be receiving UDP messages on
- Create a new Unity project, or add to a preexisting project
- Put `UDPSend.cs` on a new empty game object (or somewhere else in your scene)
- Add `SyncedObject.cs` to the object whose position you'd like to be tracking
    - Point its inspector `Udp Send` field to your `UDPSend.cs`
- Run the relay server and your Unity project
    - If your ARENA scene isn't already running on a browser tab, launch it at `https://arena.andrew.cmu.edu/<yourusername>/<yourscene>`

### Troubleshooting
- **Firewall:** if Unity is giving you problems here, [this video](https://www.youtube.com/watch?v=gVA-NvX_aR8&t=5s) is really helpful in going over letting Unity use UDP/TCP through certain ports
- **ARENA Auth:** if you need to sign out so you can relaunch the initial auth page, run from cmd:  `$ python3 -c "from arena import auth; auth.signout()"`
- **MQTT Messages:** to see the MQTT messages our relay server is sending to AREA, toggle `debug` where we declare our `scene` var (though watch out, because this gets very cluttered at `UDPSend.cs`'s default 100 message attempts/second)
- **Is Unity Actually Running:** because the simplest way for this demo to work is by moving the object (while the game is playing) from the Scene tab rather than interacting with the Game tab, it's pretty easy to forget to press play, and then wonder why the position isn't updating in ARENA


