using System;
using System.Collections.Generic;

class RR : StandardAlgorithm
{
	private int quantumTime;

	private int currentProcessIndex = 0;
	private List<Process> waitingProcesses = new List<Process>();

	public override string name => "RR";

	public RR(int quantumTime)
	{
		this.quantumTime = quantumTime;
	}

	protected override void NextSimulationStep()
	{
		Process process = waitingProcesses[currentProcessIndex];
		int executionTime = Math.Min(quantumTime, process.RemainingTime);
		process.RemainingTime -= executionTime;
		totalTime += executionTime;

		if(process.RemainingTime == 0)
		{
			waitingProcesses.Remove(process);
			setAsDone(process);
			process.EndTime = totalTime;
		}
		else
		{
			currentProcessIndex++;
		}

		if (currentProcessIndex == waitingProcesses.Count)
			currentProcessIndex = 0;
	}

	protected override void CheckForNewProcesses(IncomingProcessQueue incomingQueue)
	{
		List<Process> newProcesses = incomingQueue.DequeueNewProcesses(totalTime);
		foreach (var process in newProcesses)
		{
			int insertIndex = currentProcessIndex - 1;
			if (insertIndex >= 0)
				currentProcessIndex++;
			else
				insertIndex = waitingProcesses.Count;
			
			waitingProcesses.Insert(insertIndex, process);
		}
	}

	protected override int getWaitingProcessCount()
	{
		return waitingProcesses.Count;
	}
}

