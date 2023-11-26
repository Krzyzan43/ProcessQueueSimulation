using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SJF : StandardAlgorithm
{
	private List<Process> waitingProcesses = new List<Process>();

	public override string name => "SJF";

	protected override void NextSimulationStep()
	{
		Process process = waitingProcesses[0];

		process.RemainingTime = 0;
		totalTime += process.BurstTime;
		process.EndTime = totalTime;

		waitingProcesses.Remove(process);
		setAsDone(process);
	}

	protected override void CheckForNewProcesses(IncomingProcessQueue processQueue)
	{
		List<Process> newProcesses = processQueue.DequeueNewProcesses(totalTime);
		foreach (var process in newProcesses)
			waitingProcesses.Add(process);
		waitingProcesses.Sort((p1, p2) => p1.RemainingTime.CompareTo(p2.BurstTime));
	}

	protected override int getWaitingProcessCount()
	{
		return waitingProcesses.Count;
	}
}

