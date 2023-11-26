using System.Collections.Generic;
using System;

class SRTF : StandardAlgorithm
{
	private readonly int timeQuantum;

	private List<Process> waitingProcesses = new List<Process>();

	public override string name => "SRTF";


	public SRTF(int timeQuantum)
	{
		this.timeQuantum = timeQuantum;
	}

	protected override void NextSimulationStep()
	{
		Process process = waitingProcesses[0];
		int timeExecuted = Math.Min(timeQuantum, process.RemainingTime);
		process.RemainingTime -= timeExecuted;
		totalTime += timeExecuted;

		if (process.RemainingTime == 0)
		{
			process.EndTime = totalTime;
			waitingProcesses.Remove(process);
			setAsDone(process);
		}
	}

	protected override void CheckForNewProcesses(IncomingProcessQueue incomingProcesses)
	{
		List<Process> newProcesses = incomingProcesses.DequeueNewProcesses(totalTime);
		foreach (var process in newProcesses)
			waitingProcesses.Add(process);
		waitingProcesses.Sort((p1, p2) => p1.RemainingTime.CompareTo(p2.RemainingTime));
	}

	protected override int getWaitingProcessCount()
	{
		return waitingProcesses.Count;
	}
}

