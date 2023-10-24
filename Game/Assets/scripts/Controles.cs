using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;

public class Controles
{
    Thread thread;
    IPHostEntry host;
    IPAddress ipAddr;
    IPEndPoint endPoint;

    Socket s_Server;
    Socket s_Client;

    public string action;

    public Controles(string ip, int port){

        host = Dns.GetHostEntry(ip);
        //buscamos la dureccion Ipv4
        ipAddr = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
        if (ipAddr == null) throw new System.Exception("No IPv4 address found for host.");
        endPoint = new IPEndPoint(ipAddr, port);

        s_Server = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        Debug.Log(endPoint);
        s_Server.Bind(endPoint);
        s_Server.Listen(10);

        thread = new Thread(new ThreadStart(StartControls));
        thread.Start();
    }

    public void StartControls(){
        byte[] buffer; //tamano maximo de datos que recibira el socket
        string msg;
        int endIndex;
        s_Client = s_Server.Accept();
        
        while(true){
            buffer = new byte[1024];
            s_Client.Receive(buffer);
            msg = Encoding.ASCII.GetString(buffer);
            endIndex = msg.IndexOf('\0');
            if(endIndex > 0){
                msg = msg.Substring(0, endIndex);
            }
            // Debug.Log("Se recibio la accion:" + msg);
            action = msg;
        }
    }

    public void EndControls(){
        s_Server.Shutdown(SocketShutdown.Both);
        s_Server.Close();
    }
}
