using System.Collections.Generic;

class IncomingProcessQueue
{
	List<Process> processes = new List<Process>();

	public bool HasMore => processes.Count > 0;

	public IncomingProcessQueue(List<Process> processes)
	{
		processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));
		this.processes = processes;
	}

	public List<Process> DequeueNewProcesses(int totalTime)
	{
		List<Process> newProcesses = processes.FindAll((e) => e.ArrivalTime <= totalTime);
		foreach (Process process in newProcesses)
			processes.Remove(process);
		return newProcesses;
	}

	public int getEarliestArrivalTime()
	{
		return processes[0].ArrivalTime;
	}
}