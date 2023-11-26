using System;
using System.Collections.Generic;

class ProcessGenerator
{
	readonly Random random = new Random();
	readonly List<Process> processList = new List<Process>();

	private int getProcessTime(int maxTime)
	{
		double x = random.NextDouble();
		return (int)(x * maxTime);
	}

	public void generate(int maxTime, int queuedCount, int addedCount)
	{
		processList.Clear();

		int totalTime = 0;
		for (int i = 0; i < queuedCount; i++)
		{
			int t = getProcessTime(maxTime);
			Process process = new Process(t);
			processList.Add(process);
			totalTime += process.BurstTime;
		}
		for (int i = 0; i < addedCount; i++)
		{
			int t = getProcessTime(maxTime);
			Process process = new Process(t);
			process.ArrivalTime = random.Next(totalTime);
			processList.Add(process);
			totalTime += process.BurstTime;
		}
	}

	public List<Process> getProcessListCopy()
	{
		List<Process> copy = new List<Process>();
		foreach (var process in processList)
			copy.Add(process.Copy());
		return copy;
	}
}

