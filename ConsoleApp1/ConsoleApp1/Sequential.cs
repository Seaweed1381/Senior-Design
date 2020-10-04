using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public class Sequential
{

	public List<Matrix> weights = new List<Matrix>();
	public List<List<double>> bias = new List<List<double>>();
	public List<List<double>> values = new List<List<double>>();



	public Sequential(List<double> i)
	{
		values.Add(i);
	}


	public void Add(int numOfNeurons, int activationFunction)
    {

		int currentIteration = values.Count - 1;
		int columns = values[currentIteration].Count;
		int rows = numOfNeurons;

		List<double> ones = new List<double>(rows);
		for(int i = 0; i < columns; i++) ones.Add(1);
        

		weights.Add(new Matrix(rows, columns));

		

		List<double> product = weights[currentIteration].multiplication(values[currentIteration]);
		bias.Add(new Matrix(rows,columns).multiplication(ones));


		List<double> linearSum = Matrix.AddLists(product, bias[currentIteration]);

		List<double> processedValues;
		
		if(activationFunction == 0)
        {
			processedValues = linearSum;
        }
		else if (activationFunction == 1)
		{
			processedValues = Relu(linearSum);
		}
		else if(activationFunction == 2)
        {
			processedValues = Sigmoid(linearSum);
        }
        else
        {
			processedValues = linearSum;
        }
		
		values.Add(processedValues);
		
		
    }

	public List<double> Relu(List<double> linearSum)
    {

		List<double> processedValues = new List<double>();
		foreach(var i in linearSum)
        {
			if(i > 0)
            {
				processedValues.Add(i);
            }
            else
            {
				processedValues.Add(0);
            }
        }

		return processedValues;
	}

	public List<double> Sigmoid(List<double> linearSum)
    {

		List<double> processedValues = new List<double>();
		foreach(var i in linearSum)
        {
			double sigm = 1 / (1 + Math.Exp(-i));
			processedValues.Add(sigm);
        }

		return processedValues;
    }



	public void SaveModel(String ModelName)
    {
		DirectoryInfo di = Directory.CreateDirectory(ModelName);
		StreamWriter WriteWeights = File.CreateText(ModelName + @"\Weights.txt");


		List<int> WeightDimension;
		foreach(var i in weights)
        {
			WeightDimension = i.Size();

			for(int j = 1; j <= WeightDimension[0]; j++)
            {
				for(int k = 1; k <= WeightDimension[1]; k++)
                {
					WriteWeights.Write(i.access(j, k) + " ");
                }

				WriteWeights.WriteLine();
            }

			WriteWeights.WriteLine();
        }

		WriteWeights.Close();

		StreamWriter WriteBias = File.CreateText(ModelName + @"\Bias.txt");

		foreach(var i in bias)
        {
			foreach(var j in i)
            {
				WriteBias.Write(j + " ");
            }

			WriteBias.WriteLine();
			WriteBias.WriteLine();
        }		

		WriteBias.Close();

	
    }










	public void PrintWeights()
    {
		foreach(var i in weights)
        {
			i.printMatrix();
			Console.WriteLine();
        }

    }

    public void PrintBias()
    {
        foreach (var i in bias)
        {
            foreach (var j in i)
            {
                Console.Write(j + " ");
            }

            Console.WriteLine();
        }

		Console.WriteLine();
    }

	public void PrintValues()
    {
		foreach(var i in values)
        {
			foreach(var j in i)
            {
				Console.Write(j + " ");
            }

			Console.WriteLine();

		}
    }
	
	
    

    }

	

