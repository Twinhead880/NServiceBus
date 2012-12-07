﻿function RunTest (
    [Parameter(Position=0,Mandatory=0)]
    [int]$numThreads = 10,
    [Parameter(Position=1,Mandatory=0)]
    [int]$numMessages = 10000,
    [Parameter(Position=2,Mandatory=0)]
    [string]$serializationFormat = "xml",
    [Parameter(Position=3,Mandatory=0)]
    [string]$transport = "msmq"
)
{

  
    .\bin\debug\Runner.exe $numThreads $numMessages $serializationFormat $transport

}