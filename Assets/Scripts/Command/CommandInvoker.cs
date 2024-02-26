using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private Command command;

    public void SetCommand(Command newCommand)
    {
        command = newCommand;
    }

    public void ExecuteCommand()
    {
        command.Execute();
    }
}