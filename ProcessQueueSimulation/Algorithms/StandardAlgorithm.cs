using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class StandardAlgorithm : Algorithm
{
	private List<Process> doneProcesses = new List<Process>();
	private IncomingProcessQueue incomingProcesses;

	protected int totalTime;

	public abstract string name { get; }

	public void setProcessList(List<Process> processList)
	{
		incomingProcesses = new IncomingProcessQueue(processList);
	}

	public AlgorithmResult simulate()
	{
		doneProcesses.Clear();
		totalTime = 0;

		while (getWaitingProcessCount() > 0 || incomingProcesses.HasMore)
		{
			if (getWaitingProcessCount() == 0)
			{
				WaitForNextProcess();
				CheckForNewProcesses(incomingProcesses);
			}
			NextSimulationStep();
			CheckForNewProcesses(incomingProcesses);
		}
		return new AlgorithmResult(doneProcesses, name);
	}

	private void WaitForNextProcess()
	{
		totalTime = incomingProcesses.getEarliestArrivalTime();
	}

	protected void setAsDone(Process process)
	{
		doneProcesses.Add(process);
		process.EndTime = totalTime;
	}

	protected abstract void NextSimulationStep();

	protected abstract void CheckForNewProcesses(IncomingProcessQueue processQueue);

	protected abstract int getWaitingProcessCount();
}

