using System.Collections.Generic;

class AlgorithmResult
{
	private ICollection<Process> processes;

	public string AlgName { get; }
	public long AvgWaitingTime { get; }

	public AlgorithmResult(ICollection<Process> processes, string algName)
	{
		this.processes = processes;
		AlgName = algName;

		AvgWaitingTime = 0;
		foreach (Process process in processes)
		{
			int waitingTime = process.EndTime - process.ArrivalTime;
			AvgWaitingTime += waitingTime;
		}
		AvgWaitingTime /= processes.Count;

	}

	public void printResult()
	{
		System.Console.WriteLine("Algorithm: " + AlgName);
		System.Console.WriteLine("Average waiting time: " + AvgWaitingTime);
		System.Console.WriteLine();
	}
}
