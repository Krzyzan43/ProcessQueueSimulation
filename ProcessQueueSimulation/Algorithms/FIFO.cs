using System.Collections.Generic;

class FIFO : StandardAlgorithm
{
	private Queue<Process> processQueue = new Queue<Process>();

	public override string name => "FIFO";

	protected override void NextSimulationStep()
	{
		Process process = processQueue.Dequeue();
		process.RemainingTime = 0;

		totalTime += process.BurstTime;
		process.EndTime = totalTime;

		setAsDone(process);
	}

	protected override void CheckForNewProcesses(IncomingProcessQueue incomingProcesses)
	{
		List<Process> processes = incomingProcesses.DequeueNewProcesses(totalTime);
		foreach (Process process in processes)
			processQueue.Enqueue(process);
	}

	protected override int getWaitingProcessCount()
	{
		return processQueue.Count;
	}
}

