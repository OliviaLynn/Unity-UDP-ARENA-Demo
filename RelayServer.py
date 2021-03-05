from arena import *
import socket
import time, math, random, json

SCENE_NAME = "demo1"
UDP_PORT = 8017

# Set up the UDP server
server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server_socket.bind(('', UDP_PORT))

# ARENA
scene = Scene(host="arena.andrew.cmu.edu", realm="realm", scene=SCENE_NAME, debug=False)

box = Box(
    object_id="my_box",
    position=Position(0,1,-2),
    rotation=(0,0,0,1),
    scale={"x":1,"y":1,"z":1}
)
    
@scene.run_once
def make_box():
    scene.add_object(box)

print("Running relay...")

while True:
    message, address = server_socket.recvfrom(1024)
    msg = message.decode('ascii') + "\n" #TODO needed?
    #print(repr(msg))
    jsonObj = json.loads(msg)
    box.data.position.x = jsonObj["x"]
    box.data.position.y = jsonObj["y"]
    box.data.position.z = jsonObj["z"]
    scene.update_object(box)
