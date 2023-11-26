
using System.Collections.Generic;

interface Algorithm
{
	string name { get; }

	AlgorithmResult simulate();

	void setProcessList(List<Process> processList);
}

