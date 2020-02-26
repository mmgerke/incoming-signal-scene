using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalControl : MonoBehaviour
{
    public GameObject speaker;
    public GameObject onlight;
    public CommunicatorController communicator;
    AudioSource source;
    private List<string> display;
    private string lastcommand;
    Text output;
    InputField input;
    List<string> terminalmenu = new List<string> {"TERMINAL MENU - LOW POWER MODE","","COMMANDS:",">> READ LOG",">> SEND DISTRESS SIGNAL"};
    List<string> log = new List<string> {"SHIP 30224-183 LOG","DAY 4721 - MAIN FUEL SUPPLY EMPTY. BACKUP FUEL RESERVES","APPROACHING ZERO. LESS THAN A DAY TIL OXYGEN RUNS OUT.",
                                        "MY ONLY CHANCE NOW IS IF SOMEONE RECIEVES MY EMERGENCY", "SIGNAL AND COMES TO INVESTIGATE. I'LL HAVE TO RISK TURNING ",
                                        "ON THE AUDIO COMMUNICATOR FIRST, THEN SEND THE SIGNAL","USING THE COMMAND TERMINAL. HOPEFULLY SOMETHING OUT THERE",
                                        "CAN SAVE ME. IT CAN'T KILL ME WORSE, RIGHT?"};

    void Start()
    {
        source = speaker.GetComponent<AudioSource>();
        onlight.SetActive(false);
        display = new List<string>();
        input = gameObject.GetComponentInChildren<InputField>();
        output = gameObject.GetComponentInChildren<Text>();
        var se= new InputField.SubmitEvent();
        se.AddListener(SendCommand);
        input.onEndEdit = se;

        // initialize menu text
        _addMenuLines();
        output.text = string.Join("\n", display);
    }

    public void SendCommand(string arg0)
    {
        Debug.Log(arg0);
        input.text = ""; // clear input
        // reselect the inputtext field
        input.ActivateInputField();
        input.Select();

        if (string.Equals(arg0.ToLower(), "read log")) {
            display.Clear();
            foreach (string line in log) {
                _addLine(line);
            }
        } else if (string.Equals(arg0.ToLower(), "back") || string.Equals(arg0.ToLower(), "menu")) {
            display.Clear();
            _addMenuLines();
        } else if (string.Equals(arg0.ToLower(), "send distress signal") && communicator.power_on == true) {
           StartCoroutine(showSignalDisplay());
        } else if (string.Equals(arg0.ToLower(), "send distress signal") && communicator.power_on == false) {
            display.Clear();
            _addLine("UNABLE TO SEND DISTRESS SIGNAL.");
            _addLine("");
            _addLine("THE COMMUNICATOR COULD NOT BE REACHED. PLEASE RECONNECT");
            _addLine("COMMUNICATOR TO POWER AND TRY AGAIN.");
            _addLine("");
            _addLine(">> BACK");
        } else if (string.Equals(arg0.ToLower(), "shutdown")) {
            display.Clear();
            _addLine("");
            _addLine("");
            _addLine("");
            _addLine("SENDING SHUTDOWN SIGNAL........");
            output.text = string.Join("\n", display);
            Application.Quit();
        } else {
            display.Clear();
            _addMenuLines();
            _addLine("");
            _addLine("PLEASE ENTER A VALID COMMAND.");
        }

        output.text = string.Join("\n", display);
    }

    IEnumerator showSignalDisplay() {
        display.Clear();
        _addLine("");
        _addLine("");
        _addLine("");
        _addLine("SENDING DISTRESS SIGNAL........");
        output.text = string.Join("\n", display);
        yield return new WaitForSeconds(2);
        _addLine("");
        _addLine("");
        _addLine("");
        _addLine("........SIGNAL SENT SUCCESSFULLY.");
        output.text = string.Join("\n", display);
        yield return new WaitForSeconds(2);
        display.Clear();
        _addLine("");
        _addLine("");
        _addLine("");
        _addLine("RECIEVING UNKNOWN INCOMING SIGNAL.......");
        output.text = string.Join("\n", display);
        onlight.SetActive(true);
        source.Play();
        yield return new WaitForSeconds(120);
        display.Clear();
        _addLine("Rjgj9waJ4mJ50YqOWHdT");
        _addLine("3llv0R0d14kmKFHqA0H3");
        _addLine("0MHPXTHEREWILLBEXtxs");
        _addLine("0zAMA1NOMERCY3L1dNGk");
        _addLine("gjexen2HfNQeDGbGHFWO");
        _addLine("M4RWRGlsd9nKlpTsEI0N");
        _addLine("z0VVFGOODBYE4AQx3ZxY");
        _addLine("cSh9cBWiuKxJy9iJJ7sN");
        output.text = string.Join("\n", display);
        onlight.SetActive(false);
        source.Pause();
    }

    private void _addLine(string line) {

        if (display.Count > 7) {
            display.RemoveAt(0);
        }
        display.Add(line);
    }

    private void _addMenuLines() {
        foreach (string line in terminalmenu) {
                _addLine(line);
            }
    }


}
