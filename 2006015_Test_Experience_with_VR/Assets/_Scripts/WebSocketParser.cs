using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using System.IO;
using DigitalRuby.Tween;
using Random = UnityEngine.Random;
public class WebSocketParser : MonoBehaviour
{
    //Play Sound
    public AudioSource playSoundNoData;

    //Play Random Sound Down
    private AudioSource DownSource;
    public AudioClip[] DownClips;

    //Play Random Sound Up
    private AudioSource UpSource;
    public AudioClip[] UpClips;

    //Play on Delay if Play


    public WebSocket ws;

    public delegate void OnConnected();
    public OnConnected OnConnect;
    private float x = 0.0f;
    private float lastFocusValue = 0;
    private string auth;

    private Queue responseData;
    

    public GameObject sphereFocus;

    //Target Position  for Player
    public Transform Target;

    //Start Position for Player
    public Transform StartPoint;


    float speed = 1.0f;

    // LateUpdate Timer
    //float lateTimer = 1;

    //LateUpdate int
    //int totalLateCallsPerSecond;
    //int totalLateUpdateCallsPerSecond;

   
    public string cortexToken;

    public float step = 1;
    float distPerStep = 1f;
    public float timePerStep = 5f;
    public float timePerStepBack = 5f;

    public bool CanUpdate;
    public bool CanNotUpdate;

    

    // Use this for authentification 
    public void Main()
    {

        //Sound
        DownSource = gameObject.AddComponent<AudioSource>();
        UpSource = gameObject.AddComponent<AudioSource>();

        responseData = new Queue();

        var wsUri = new UriBuilder();

        wsUri.Host = "localhost";
        wsUri.Port = 6868;
        wsUri.Scheme = "wss";

        var url = wsUri.Uri;

        Debug.Log("Opening Websocket Interaction connection to " + url.AbsoluteUri.Substring(0, url.AbsoluteUri.Length - 1));
        ws = new WebSocket(url.AbsoluteUri.Substring(0, url.AbsoluteUri.Length - 1));

        ws.OnOpen += (sender, evt) => {
            Debug.Log("Open Websocket connection to");
            Authorize();

        };

        ws.OnMessage += (sender, evt) => {

            responseData.Enqueue(evt.Data);


        };

        ws.Connect();

        float distance = Vector3.Distance(Target.position, sphereFocus.transform.position);
        distPerStep = distance / step;

      
    }

    // Update is called once per frame
    void Update()
    {
       // totalLateUpdateCallsPerSecond++;
       // lateTimer -= Time.deltaTime;

       // if (lateTimer <= 0)
       // {
       //     print("Late Updates: " + totalLateCallsPerSecond);

       //     totalLateUpdateCallsPerSecond = 3;

       //     lateTimer = 1;
       // }

        if (responseData.Count > 0)
        {
            var line = "";
            float lastSignalStrength = 0f;
            string responseString = responseData.Dequeue().ToString();
            Debug.Log(responseString);
            WebSocketData.ResponseResult response = JsonUtility.FromJson<WebSocketData.ResponseResult>(responseString);
            //Debug.Log(response.result);
            WebSocketData.Response responseRaw = JsonUtility.FromJson<WebSocketData.Response>(responseString);

            if (!String.IsNullOrEmpty(responseRaw.result.cortexToken))
            {
                cortexToken = responseRaw.result.cortexToken;
                Debug.Log("cortexToken is: " + cortexToken);
                CreateSession(cortexToken);
            }

            if (!String.IsNullOrEmpty(responseRaw.result.id))
            {
                Debug.Log("session id is: " + responseRaw.result.id);
                Subscribe("met", cortexToken, responseRaw.result.id);
                
            }


            // Debug.Log("Response.Met: " + response.met[18]);

            float newFocus = 0;
            
            

            if (
                response.met.Count > 18 &&
                response.met[18] != null &&
                response.met[18] != ""
            )
            {
                Debug.Log("response value" + response.met[18].GetType());

                newFocus = float.Parse(response.met[18]);
            }
            else if (
                response.met.Count > 18 &&
                response.met[18] != null &&
                response.met[18] == ""
                )
            {
                newFocus = 1000;
            }


            
            Debug.Log("new focus" + newFocus);

            if (newFocus > 300000)
            {

                Debug.Log("Up: "+ newFocus);


                //play sound
                StartCoroutine(WaitForPlayUp());

                //animate
                Vector3 startPos = sphereFocus.transform.position;

                Vector3 endPos = Vector3.MoveTowards(sphereFocus.transform.position, Target.position, distPerStep);



                System.Action<ITween<Vector3>> sphereMovement = (t) =>
                {
                    sphereFocus.transform.position = t.CurrentValue;
                };


                // completion defaults to null if not passed in
                sphereFocus.gameObject.Tween("SphereMovement", startPos, endPos, timePerStep, TweenScaleFunctions.Linear, sphereMovement);
                lastFocusValue = newFocus;


            }



            
            else if (newFocus == 1000)
            {

                Debug.Log("no data");

                //play sound
                //playSoundNoData.Play();


                //animate
                Vector3 startPos = sphereFocus.transform.position;

                Vector3 endPos = Vector3.MoveTowards(sphereFocus.transform.position, Target.position, distPerStep);



                System.Action<ITween<Vector3>> sphereMovement = (t) =>
                {
                    sphereFocus.transform.position = t.CurrentValue;
                };


                // completion defaults to null if not passed in
                sphereFocus.gameObject.Tween("SphereMovement", startPos, endPos, timePerStep, TweenScaleFunctions.Linear, sphereMovement);
                lastFocusValue = newFocus;

            }
            // csvExporter.WriteEEGData(response);

            else if (newFocus <= 300000 && newFocus >=1000)
            {
                Debug.Log("Down: " + newFocus);

                //play sound
                StartCoroutine(WaitForPlayDown());

                Vector3 startPos = sphereFocus.transform.position;
                Vector3 endPos = Vector3.MoveTowards(sphereFocus.transform.position, StartPoint.position, distPerStep);

                System.Action<ITween<Vector3>> sphereMovement = (t) =>
                {
                    sphereFocus.transform.position = t.CurrentValue;
                };

                sphereFocus.gameObject.Tween("SphereMovement", startPos, endPos, timePerStepBack, TweenScaleFunctions.Linear, sphereMovement);
                lastFocusValue = newFocus;
                
            }

        }

    }

    IEnumerator WaitForPlayDown()
    {

        yield return new WaitForSeconds(1);
        PlayRandomSoundDown();
    }

    public void PlayRandomSoundDown()
    {
        int selection = Random.Range(0, DownClips.Length);
        DownSource.PlayOneShot(DownClips[selection]);
    }

    IEnumerator WaitForPlayUp()
    {

        yield return new WaitForSeconds(5);
        PlayRandomSoundUp();
    }

    public void PlayRandomSoundUp()
    {
        int selection = Random.Range(0, UpClips.Length);
        UpSource.PlayOneShot(UpClips[selection]);
    }


    void Authorize()
    {
        WebSocketData.AuthParameter p = new WebSocketData.AuthParameter();
        p.clientId = "ZFDADBiG5lri14hJjNMQSaXdooyu3x8pPDGgEbCe";
        p.clientSecret = "EiZeIaY2fAbyIeEtsbI2yjwlDuiG0WaEPpNShBC3ctnuGDMEdzULTewbIfvTY7fHguSGHjvdFcL5YZ8rFZemT8vXuSTk7IlYia2LsERvt5HS3jwNOvXpa7mzvyQXBcfO";
        SendMethodAuth("authorize", p);
    }



    void CreateSession(string cortexToken)
    {

        WebSocketData.SessionParameter p = new WebSocketData.SessionParameter();
        p.cortexToken = cortexToken;
        p.status = "open";
        p.headset = "INSIGHT-A1D205CF";
        Debug.Log("Create session with cortexToken: " + cortexToken);
        SendMethodSession("createSession", p);
    }

    void Subscribe(string type, string cortexToken, string sessionId)
    {

        WebSocketData.SubscribeParameter p = new WebSocketData.SubscribeParameter();
        p.cortexToken = cortexToken;
        p.session = sessionId;
        p.streams.Add(type);
        Debug.Log("subscribing");
        SendMethodSubscribe("subscribe", p);
    }

    void GetUserLogin()
    {
        SendMethod("getUserLogin", null);
    }

    void SendLogout()
    {

        WebSocketData.Parameter p = new WebSocketData.Parameter();
        p.username = "mimi.yord";
        SendMethod("logout", p);
    }

    void SendLogin()
    {


        WebSocketData.Parameter p = new WebSocketData.Parameter();

        //p.username = "mimi.yord";
        // p.password = "Indochine_24";
        // p.client_id = "ZFDADBiG5lri14hJjNMQSaXdooyu3x8pPDGgEbCe";
        // p.client_secret = "EiZeIaY2fAbyIeEtsbI2yjwlDuiG0WaEPpNShBC3ctnuGDMEdzULTewbIfvTY7fHguSGHjvdFcL5YZ8rFZemT8vXuSTk7IlYia2LsERvt5HS3jwNOvXpa7mzvyQXBcfO";

        SendMethod("login", p);

    }

    void SendMethodSubscribe(string methodName, WebSocketData.SubscribeParameter parameter)
    {
        WebSocketData.MethodSubscribe method = new WebSocketData.MethodSubscribe();
        method.method = methodName;
        method.@params = parameter;
        Debug.Log("method" + JsonUtility.ToJson(method));
        ws.Send(JsonUtility.ToJson(method));
    }

    void SendMethod(string methodName, WebSocketData.Parameter parameter)
    {
        WebSocketData.Method method = new WebSocketData.Method();
        method.method = methodName;
        method.@params = parameter;
        Debug.Log("method" + JsonUtility.ToJson(method));
        ws.Send(JsonUtility.ToJson(method));
    }

    void SendMethodAuth(string methodName, WebSocketData.AuthParameter parameter)
    {
        WebSocketData.MethodAuth method = new WebSocketData.MethodAuth();
        method.method = methodName;
        method.@params = parameter;
        Debug.Log("method" + JsonUtility.ToJson(method));
        ws.Send(JsonUtility.ToJson(method));
    }
    void SendMethodSession(string methodName, WebSocketData.SessionParameter parameter)
    {
        WebSocketData.MethodSession method = new WebSocketData.MethodSession();
        method.method = methodName;
        method.@params = parameter;
        Debug.Log("method" + JsonUtility.ToJson(method));
        ws.Send(JsonUtility.ToJson(method));
    }
}
